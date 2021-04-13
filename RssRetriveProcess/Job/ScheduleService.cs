using LogManagement;
using Quartz;
using Quartz.Impl;
using RssRetriveProcess.Facade;
using RssRetriveProcess.Service;

namespace JudgeInquiryBot.WindowsService.Job
{
    public class ScheduleService
    {
        private readonly IRssRetriveFacade _facade;
        private readonly ILogger _logger;

        private readonly IScheduler scheduler;

        public ScheduleService(IRssRetriveFacade facade, ILogger logger)
        {
            _facade = facade;
            _logger = logger;
            StdSchedulerFactory factory = new StdSchedulerFactory();

            scheduler = factory.GetScheduler().ConfigureAwait(false).GetAwaiter().GetResult();

            scheduler.JobFactory = new IntegrationJobFactory(_facade, _logger);

        }

        public void Start()
        {
            scheduler.Start().ConfigureAwait(false).GetAwaiter().GetResult();
            ScheduleJobs();
          
        }

        public void ScheduleJobs()
        {
            scheduler.ScheduleJob(
                JobBuilder.Create<RSSReadJob>().Build(), DefaultTrigger());


//            scheduler.ScheduleJob(DefaultTrigger()).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        public ITrigger DefaultTrigger()
        {
            return TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                //                 .WithSimpleSchedule(m=>m.WithIntervalInMinutes(7))
                .WithCronSchedule("0 0/10 * * * ?")
                //  .WithIntervalInSeconds(20)
                //.StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(23, 50, 0)
                //    //.WithIntervalInMinutes(2)
                //    //.StartingDailyAt(TimeOfDay.HourMinuteAndSecondOfDay(10, 9, 0)
                //)
                // )
                .StartNow()
                .Build();
        }
        public void Stop()
        {
            scheduler.Shutdown().ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}

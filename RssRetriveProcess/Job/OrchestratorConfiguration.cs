using LogManagement;
using RssRetriveProcess.Facade;
using RssRetriveProcess.Service;
using Topshelf;

namespace JudgeInquiryBot.WindowsService.Job
{
    public class OrchestratorConfiguration
    {
        private readonly IRssRetriveFacade _facade;
        private readonly ILogger _logger;

        public OrchestratorConfiguration(IRssRetriveFacade facade, ILogger logger)
        {
            _facade = facade;
            _logger = logger;
        }

        internal void Configure()
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<ScheduleService>(s =>
                {
                    s.ConstructUsing(name => new ScheduleService(_facade, _logger));
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                //   x.RunAsLocalSystem();
                x.SetDescription("Rss Reader Create Daily Letter");
                x.SetDisplayName("RssReader");
                x.SetServiceName("RssReader");
                x.StartAutomatically();
            });
        }
    }
}
using System;
using System.Threading.Tasks;
using LogManagement;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Spi;
using RssRetriveProcess.Facade;
using RssRetriveProcess.Service;

namespace JudgeInquiryBot.WindowsService.Job
{

    internal sealed class IntegrationJobFactory : IJobFactory
    {
        private readonly IRssRetriveFacade _facade;
        private readonly LogManagement.ILogger _logger;

        public IntegrationJobFactory(IRssRetriveFacade facade, LogManagement.ILogger logger)
        {
            _facade = facade;
            _logger = logger;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            var jobDetail = bundle.JobDetail;
            return new RSSReadJob(_facade, _logger);

        }

        public void ReturnJob(IJob job)
        {
        }
    }

    [PersistJobDataAfterExecution]
    public class RSSReadJob : IJob
    {
        private readonly IRssRetriveFacade _facade;
        private readonly LogManagement.ILogger _logger;

        public RSSReadJob(IRssRetriveFacade facade, LogManagement.ILogger logger)
        {
            _facade = facade;
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("RSSReadJob Is RAN ,{0}" + DateTime.Now.ToString("G"));
                _facade.ReadAndFetchData();
                // _facade.ReadAndReplyToMessage();
            }
            catch (Exception exception)
            {
                _logger.DoLog(exception.Message);
                if (exception.InnerException != null) _logger.DoLog(exception.InnerException.Message);
                // throw exception;
            }
            return Task.CompletedTask;
        }

    }
}
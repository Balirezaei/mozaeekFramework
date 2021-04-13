using System.Threading.Tasks;
using MozaeekCore.Core.Base;

namespace MozaeekCore.Core.CommandHandler
{
    public class LoggingHandlerDecorator<T, TResult> : IBaseAsyncCommandHandler<T, TResult> where T : Command
    {
        private readonly ILogManagement _log;

        public LoggingHandlerDecorator(IBaseAsyncCommandHandler<T, TResult> next, ILogManagement log)
        {
            _log = log;
            _next = next;
        }
       

        public IBaseAsyncCommandHandler<T, TResult> _next { get; }        

        public Task<TResult> HandleAsync(T cmd)
        {
            _log.DoLog(cmd);
            //            Debug.WriteLine(JsonConvert.SerializeObject(cmd));
            return _next.HandleAsync(cmd);
        }

       
    }

}
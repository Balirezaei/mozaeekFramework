using MozaeekCore.Core.Base;
using System.Threading.Tasks;

namespace MozaeekCore.Core.CommandHandler
{
    public class AsyncLoggingHandlerDecorator<T, TResult> :  IBaseAsyncCommandHandler<T, TResult> where T : Command
    {
        private readonly ILogManagement _log;

       
        public AsyncLoggingHandlerDecorator(IBaseAsyncCommandHandler<T, TResult> next, ILogManagement log)
        {
            _log = log;
            _nextAsync = next;
        }
        
        public IBaseAsyncCommandHandler<T, TResult> _nextAsync { get; }
       

        public async Task<TResult> HandleAsync(T cmd)
        {
            await _log.DoLog(cmd);
            //            Debug.WriteLine(JsonConvert.SerializeObject(cmd));
            return await _nextAsync.HandleAsync(cmd);
        }
    }

}
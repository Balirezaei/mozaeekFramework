using System.Threading.Tasks;
using MozaeekCore.Core.Base;

namespace MozaeekCore.Core.CommandHandler
{
    public class AuthorizeCommandHandlerDecorator<T, TResult> : IBaseAsyncCommandHandler<T, TResult> where T : Command
    {
        public AuthorizeCommandHandlerDecorator(IBaseAsyncCommandHandler<T, TResult> next)
        {
            _next = next;
        }
       
        public IBaseAsyncCommandHandler<T, TResult> _next { get; }
      
        public Task<TResult> HandleAsync(T cmd)
        {
            //   Debug.WriteLine(JsonConvert.SerializeObject(cmd));
            return _next.HandleAsync(cmd);
        }

       
    }
}
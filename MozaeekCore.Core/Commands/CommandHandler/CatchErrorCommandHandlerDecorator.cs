using System;
using System.Threading.Tasks;
using MozaeekCore.Core.Base;

namespace MozaeekCore.Core.CommandHandler
{
    public class CatchErrorCommandHandlerDecorator<T, TResult> : IBaseAsyncCommandHandler<T, TResult> where T : Command
    {
        private readonly IErrorHandling _errorHandling;

        public CatchErrorCommandHandlerDecorator(IBaseAsyncCommandHandler<T, TResult> next, IErrorHandling errorHandling)
        {
            _errorHandling = errorHandling;

            _next = next;
        }

        public IBaseAsyncCommandHandler<T, TResult> _next { get; }

        public async Task<TResult> HandleAsync(T cmd)
        {
            try
            {

                return await _next.HandleAsync(cmd);
            }
            catch (Exception e)
            {
                //Log the Eddor 
                await _errorHandling.HandleException(e);
                throw e;
            }
        }


    }

}
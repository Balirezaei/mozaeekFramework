using System.Threading.Tasks;
using MozaeekCore.Core.Base;
using MozaeekCore.Core.Commands;

namespace MozaeekCore.Core.CommandHandler
{
    public class ValidationCommandHandlerDecorator<T, TResult> : IBaseAsyncCommandHandler<T, TResult> where T : Command
    {
        public ValidationCommandHandlerDecorator(IBaseAsyncCommandHandler<T, TResult> next, ICommandValidator<T> validator)
        {
            _validator = validator;
            _next = next;
        }
        public IBaseAsyncCommandHandler<T, TResult> _next { get; }
        private readonly ICommandValidator<T> _validator;

        public async Task<TResult> HandleAsync(T cmd)
        {
            if (_validator != null)
            {
               await _validator.ValidateAsync(cmd);
            }
            return await _next.HandleAsync(cmd);
        }
    }
}

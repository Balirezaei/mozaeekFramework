using System.Threading.Tasks;
using MozaeekCore.Core.Base;

namespace MozaeekCore.Core.Commands
{
    public interface ICommandValidator<T> where T : Command
    {
        ValueTask ValidateAsync(T command);
    }
}
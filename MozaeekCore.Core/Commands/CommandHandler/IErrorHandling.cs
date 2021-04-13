using System;
using System.Threading.Tasks;

namespace MozaeekCore.Core.CommandHandler
{
    public interface IErrorHandling
    {
        Task HandleException(Exception exception);
    }
}
using System;
using System.Threading.Tasks;

namespace MozaeekCore.Core.CommandHandler
{
    public interface ILogManagement
    {
        Task DoLog<T>(T command);
    }
}
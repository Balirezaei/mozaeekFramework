using System.Diagnostics;
using System.Threading.Tasks;
using MozaeekCore.Core;
using MozaeekCore.Core.CommandHandler;
using Newtonsoft.Json;

namespace MozaeekCore.LogManagement
{
    public class DoLogManagement : ILogManagement
    {
     
        public Task DoLog<T>(T command)
        {
            var t = command.GetType();
            var serialize = JsonConvert.SerializeObject(command);
            var log = $"test is doing {t.Name}  with this data ( {serialize} ) ";
            Debug.WriteLine(log);
            return Task.CompletedTask;
        }
    }

}
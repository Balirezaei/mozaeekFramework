namespace LogManagement
{
    public interface ILogger
    {
        void DoLog(string message);

        void DoLogInsideApp(string message);
    }
}
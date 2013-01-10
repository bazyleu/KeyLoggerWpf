namespace KeyLogger.Core.Abstract
{
    public interface IKeyLogger
    {
        void Start();

        void Stop();

        bool IsStarted { get; }
    }
}

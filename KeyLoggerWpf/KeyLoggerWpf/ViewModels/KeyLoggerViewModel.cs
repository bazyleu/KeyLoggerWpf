using System.Windows.Input;
using KeyLogger.Core.Abstract;
using KeyLoggerWpf.Commands;

namespace KeyLoggerWpf.ViewModels
{
    public class KeyLoggerViewModel
    {
        private readonly IKeyLogger keyLogger;

        public KeyLoggerViewModel(IKeyLogger keyLogger)
        {
            this.keyLogger = keyLogger;
        }

        public bool CanStarted()
        {
            return !keyLogger.IsStarted;
        }

        public void Start()
        {
            keyLogger.Start();
        }

        public bool CanStop()
        {
            return keyLogger.IsStarted;
        }

        public void Stop()
        {
            keyLogger.Stop();
        }

        public ICommand StartCommand
        {
            get
            {
                return new CommonCommand(Start, CanStarted);
            }
        }

        public ICommand StopCommand
        {
            get
            {
                return new CommonCommand(Stop, CanStop);
            }
        }

    }
}

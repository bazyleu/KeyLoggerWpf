using System;
using KeyLogger.Core;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyLoggerInstance keyLogger = new KeyLoggerInstance(new KeyCheker(), new ConsoleLogPrinter(), 10, 900);
            keyLogger.Start();
            Console.ReadLine();
        }
        
    }
}

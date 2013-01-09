using System;
using System.Text;
using System.Windows.Forms;
using KeyLogger.Core;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Elapsed += Test;
            timer.Interval = 90;
            Console.ReadLine();
        }
        
        public static void Test(object sender, System.Timers.ElapsedEventArgs e)
        {
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                if (WinApiWrapper.IsKeyPressedDown(key))
                {
                    Console.WriteLine(key + "(true) ");
                }
            }
        }
    }
}

using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KeyLogger.Core
{
    public class WinApiWrapper
    {
        // see 
        //    http://msdn.microsoft.com/ru-ru/library/windows/desktop/ms646293(v=vs.85).aspx
        //    http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/d9c3eee6-a41a-422b-a7c0-8d1b25d26005
        private const short KeyPressedDownMarker = -32767;

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys key);

        public static bool IsKeyPressedDown(Keys key)
        {
            return KeyPressedDownMarker == GetAsyncKeyState(key);
        }
           
    }
}

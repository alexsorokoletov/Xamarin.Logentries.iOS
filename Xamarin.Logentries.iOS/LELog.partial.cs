using Foundation;

namespace Logentries.iOS
{
    public partial class LELog
    {
        public void Log(string message)
        {
            NSObject nsObject = new NSString(message);
            Log(nsObject);
        }
    }
}

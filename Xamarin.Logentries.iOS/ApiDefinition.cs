using Foundation;

namespace Logentries.iOS
{
    // @protocol LELoggableObject <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface LELoggableObject
    {
        // @optional -(NSString *)leDescription;
        [Export("leDescription")]
        string LeDescription { get; }
    }

    // @interface LELog : NSObject
    [BaseType(typeof(NSObject))]
    interface LELog
    {
        // +(LELog *)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        LELog SharedInstance { get; }

        // @property (copy, atomic) NSString * token;
        [Export("token")]
        string Token { get; set; }

        // -(void)log:(NSObject *)object;
        [Export("log:")]
        void Log(NSObject @object);

        /// <summary>
        ///  Display all messages on TTY for debug purposes
        /// </summary>
        /// <value><c>true</c> if debug logging to console; otherwise, <c>false</c>.</value>
        //@property(nonatomic) BOOL debugLogs;
        [Export("debugLogs")]
        bool DebugLoggingToConsole { get; set; }

        // @property (assign, nonatomic) BOOL logApplicationLifecycleNotifications;
        /// <summary>
        /// Log UIApplicationDidFinishLaunchingNotification, UIApplicationDidBecomeActiveNotification, UIApplicationWillEnterForegroundNotification, UIApplicationWillResignActiveNotification, UIApplicationWillTerminateNotification.
        /// </summary>
        /// <value><c>true</c> if log application lifecycle notifications; otherwise, <c>false</c>.</value>
        [Export("logApplicationLifecycleNotifications")]
        bool LogApplicationLifecycleNotifications { get; set; }
    }

}
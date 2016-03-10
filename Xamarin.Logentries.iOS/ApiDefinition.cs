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

        // @property (assign, nonatomic) BOOL logApplicationLifecycleNotifications;
        [Export("logApplicationLifecycleNotifications")]
        bool LogApplicationLifecycleNotifications { get; set; }
    }

}
using System.Runtime.InteropServices;
using Foundation;

namespace Logentries.iOS
{

    static class CFunctions
    {
        // extern int le_init ();
        [DllImport("__Internal")]
        static extern int le_init();

        // extern void le_poke ();
        [DllImport("__Internal")]
        static extern void le_poke();

        // extern void le_log (const char *message);
        [DllImport("__Internal")]
        static extern unsafe void le_log(sbyte* message);

        // extern void le_write_string (NSString *string);
        [DllImport("__Internal")]
        static extern void le_write_string(NSString @string);

        // extern void le_set_token (const char *token);
        [DllImport("__Internal")]
        static extern unsafe void le_set_token(sbyte* token);
    }

}
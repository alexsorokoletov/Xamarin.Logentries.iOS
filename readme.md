# Logentries SDK for Xamarin.iOS
[![NuGet Badge](https://buildstats.info/nuget/Xamarin.Logentries.iOS?includePreReleases=true)](https://www.nuget.org/packages/Xamarin.Logentries.iOS/)

This is a Xamarin iOS unified bindings for Logentries le_ios static library
[le_ios](https://github.com/logentries/le_ios)

Current binding is built against [commit 425e8357802d4834f3d4ce64204dcfd1347bf02f](https://github.com/logentries/le_ios/commit/425e8357802d4834f3d4ce64204dcfd1347bf02f)

[Logentries for iOS features](https://github.com/LogentriesCommunity/le_ios):
-------------

* online/offline logging
* dictionary serialization
* secure TLS connection
* thread safety
* application lifecycle logging
* application crash logging with stack traces

Installation
------------

Install NuGet package: `Install-Package Xamarin.Logentries.iOS`

If you don't have an account yet, go ahead and [create free account](https://logentries.com/learnmore?code=781f627c).

_Note: this is a referral link. Using it will help to grow my logging limits. Here is a plain old url [https://logentries.com/](https://logentries.com/)_

Simple example
--------------

```
using Logentries.iOS;
...
LELog.SharedInstance.Token = yourToken;
LELog.SharedInstance.Log("Hey, world of live logging! What's up?");
```

Additional information available on [Logentries website](https://logentries.com) and [Logentries iOS repository](https://github.com/LogentriesCommunity/le_ios).


### Binding details
Binding was done by compiling le_ios lelib static library for arm64/armv7/i386/x86_64, merging those 4 .a files into one (using `lipo`/`libtool` command, details [here](http://www.cvursache.com/2013/10/06/Combining-Multi-Arch-Binaries/))
`libtool -static lelib.a.armv7 lelib.a.arm64 lelib.a.i386 lelib.a.x86_64 -o libLogentries.a`
To check the final .a file, run this and you should see
`lipo -info libLogentries.a`
`Architectures in the fat file: libLogentries are: armv7 arm64 i386 x86_64`

After that against source code we run [`sharpie`](http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/objective_sharpie/) to generate C# classes.

`sharpie bind -output Binding -v -sdk iphoneos9.2 -scope lelib le_ios/lelib/lelib.h -c -Ilelib -v`

Adding -v in the end helps a lot to understand why the sharpie crashes (and it does sometimes). 

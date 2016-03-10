# Logentries Xamarin.iOS Bindings

Xamarin iOS unified bindings for Logentries le_ios static library
[le_ios](https://github.com/logentries/le_ios)

Current binding is built against [commit 9410167edf11010a439b68475327139284e28a7f](https://github.com/logentries/le_ios/commit/9410167edf11010a439b68475327139284e28a7f)



### Binding details
Binding was done by compiling le_ios lelib static library for arm64/armv7/i386/x86_64, merging those 4 .a files into one (using `lipo`/`libtool` command, details [here](http://www.cvursache.com/2013/10/06/Combining-Multi-Arch-Binaries/))
`libtool -static lelib.a.armv7 lelib.a.arm64 lelib.a.i386 lelib.a.x86_64 -o libLogentries.a`
To check the final .a file, run this and you should see
`lipo -info libLogentries.a`
`Architectures in the fat file: libLogentries are: armv7 arm64 i386 x86_64`

After that against source code we run [`sharpie`](http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/objective_sharpie/) to generate C# classes.

`sharpie bind -output Binding -v -sdk iphoneos9.2 -scope lelib le_ios/lelib/lelib.h -c -Ilelib -v`

Adding -v in the end helps a lot to understand why the sharpie crashes (and it does sometimes). 

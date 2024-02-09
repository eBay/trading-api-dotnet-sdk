**[Build SDK Kernel](../../Source/HowToBuild.htm)**

**Build Sample for .NET:**

1.  All .NET sample are configured  to refer the SDK kernel  libraries under  [SDK home directory](../../). If you have rebuilt the SDK kernel (using  Source\\DOTNET.SOAP.sln) and changed its build configuration (e.g., from "Release" to "Debug" then run CopyDebug.bat) then you need to run batch file SwitchSDKRefConfig.bat to clean all the existing references for all samples before you building samples. Otherwise you may get referencing warning like "eBay.Service...".
2.  Run Microsoft Visual Studio for .NET. to open CSharp Samples.sln.
3.  Rebuild all projects.
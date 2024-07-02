@echo off

REM Register eBay API SDK

REM Make sure you have .NET Framework utilities in path. 
REM Typically for .NET Framework 2.0 it's located at [WindowsDir]Microsoft.NET\Framework\v2.0.50727.
REM If you want to use AttributesLib, you'll need to have MSXML 3.0 installed.

REM Register .NET assemblies of eBay API SDK.

REM Register eBay.Service.dll (the core library of API library) of API library
gacutil -i eBay.Service.dll

REM Registering eBay.Service.SDK.Attribute.dll
gacutil -i Interop.MSXML2.dll
gacutil -i eBay.Service.SDK.Attribute.dll

REM Register the SDK libraries as COM objects so that can be accessed from other programming environment.

REM For eBay.Service Library:
regasm /tlb:eBay.Service.tlb eBay.Service.dll


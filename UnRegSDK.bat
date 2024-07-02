@echo off

REM Unregister eBay API SDK

REM Unregister the SDK COM components.

REM For API Library:
regasm /unregister eBay.Service.dll


REM Unregister .NET assemblies.

REM Unregister eBay.Service.SDK.Attribute:
gacutil -u eBay.Service.SDK.Attribute
gacutil -u Interop.MSXML2

REM Unregister eBay.Service:
gacutil -u eBay.Service



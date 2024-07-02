# Readme for Building the eBay SDK for .NET

To build the SDK, please use the sections below, in the order they are presented.

References to "SDKInstallDir" and to "SDK Installation Directory" refer to the top-level SDK directory (for example, C:\\Program Files\\eBay\\eBay .NET SDK Release).

Building the SDK initially requires that you:

- Install Microsoft Visual Studio 2022 on your computer
- Delete any bin and obj folders that were created with previous versions of Microsoft Visual Studio

## Generate a Strong Name Key

1. Confirm that your Path variable includes the folder of the Microsoft .NET Framework Strong Name Utility (e.g., C:\\Program Files\\Microsoft Visual Studio 22\\SDK\\v2.0\\Bin).

2. Run the following BAT file:  
   SDKInstallDir\\Source\\GenSNKey.bat
   This will generate a Strong Name key to sign the generated components. If you prefer not to use GenSNKey.bat, then in a Command window, at \\SDKInstallDir\\Source, run the following command:  
   `sn -k eBay.snk`.

## Use a WSDL to Generate Code Stubs

1. Follow the code generation instructions in the Readme file in the following folder: SDKInstallDir\\Tools.

2. Confirm that code stubs were generated at SDKInstallDir\\Source\\eBay.Service.SDK\\Core\\Soap\\WebService.cs.

## Use the Solution File to Build the SDK

Note: These instructions assume you are creating a Release build. If you are creating a Debug build, please substitute "Debug" for "Release."

1. Use Microsoft Visual Studio to open DOTNET.SOAP.sln (located at SDKInstallDir\\Source\\DOTNET.SOAP.sln). If prompted, use the Visual Studio Conversion Wizard to update the solution and create backup files.

2. Build the eBay.Service project.

3. Confirm that the eBay.Service.dll file was generated in SDKInstallDir\\Source\\eBay.Service.SDK\\bin\\Release.

4. Confirm that the _eBay.Service_ reference in the eBay.Service.SDK.Attribute and Helper projects is correct. It should point to SDKInstallDir\\Source\\eBay.Service.SDK\\bin\\Release\\eBay.Service.dll.

5. If the Reference is incorrect, update it to point to SDKInstallDir\\Source\\eBay.Service.SDK\\bin\\Release\\eBay.Service.dll.

6. Build the whole DOTNET.SOAP solution.

## Copy the Built Files to the SDK Installation Directory

1. In the SDKInstallDir\\Source folder, run CopyRelease.bat.

2. Use date stamps to confirm that the recently-built files were copied to the SDK installation directory.

Note: SDK samples (located at SDKInstallDir\\Samples) reference the built files in the SDK installation directory.

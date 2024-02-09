# Generating Code Using the eBay Code Generation Tool

You can use the eBayCodeGenerator Tool to generate code from an eBay WSDL. The tool can be executed from inside Visual Studio .NET or from the command line.

1. Confirm that the path to version 4.8 of the Microsoft .NET Framework (for example, C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319) has been set correctly in Setup.bat for VS2022 in the Tools\\Generator folder.

2. Register the code generator as a Custom Tool by running the Setup.bat file. If you are running Visual Studio .NET when you run Setup.bat, close and reopen Visual Studio .NET after running Setup.bat.

3. Update the following file with the WSDL version you want to use for generating code: `C:\Program Files\eBay\<SDK for Windows InstallDir>\Source\eBay.Service.SDK\Core\Soap\WebService.xml.`

   The follow code snippet shows the WSDLFile element, which points to the eBay WSDL file you want to use to generate code: `<WSDLFile>https://developer.ebay.com/webservices/latest/eBaySvc.wsdl</WSDLFile>`

4. The following file will be updated if the code generation by the eBayCodeGenerator Tool is successful: `C:\Program Files\eBay\<SDK for Windows InstallDir>\Source\eBay.Service.SDK\Core\Soap\WebService.cs`.  
   Note the time stamp of the file and confirm that it is writable.

## Running the eBayCodeGenerator Tool from the Command Line

To run the eBayCodeGenerator Tool from the command line, use either gen.bat batch file in Tools\\CodeGen folder, depending on whether you have Visual Studio .NET 2022. The following input parameters are supported:

    -h	display the usage information
    -f	output file name
    -l	language for the generated code; (cs = Csharp, vb = VB .NET)
    -m	mode of the output file
    1	create one file for all generated classes
    2	create one file for one generated class
    -n	root namespace for the generated code
    -p	path for the output file(s)
    -w	URL for the wsdl

The batch files execute the following command:

`CodeGen -f out.cs -m 1 -n eBay.Service.Core.Soap -l cs -p soap -w https://developer.ebay.com/webservices/latest/eBaySvc.wsdl`

ECHO Copying Release version of libraries to SDK home directory...

copy eBay.Service.SDK\bin\Release\eBay.Service.dll ..\
copy eBay.Service.SDK\bin\Release\eBay.Service.tlb ..\
copy eBay.Service.SDK\bin\Release\eBay.Service.xml ..\
del ..\eBay.Service.pdb

copy eBay.Service.SDK.Attribute\bin\Release\eBay.Service.SDK.Attribute.dll ..\
copy eBay.Service.SDK.Attribute\bin\Release\eBay.Service.SDK.Attribute.tlb ..\
copy eBay.Service.SDK.Attribute\bin\Release\Interop.MSXML2.dll ..\
copy eBay.Service.SDK.Attribute\bin\Release\eBay.Service.SDK.Attribute.xml ..\
del ..\eBay.Service.SDK.Attribute.pdb

copy Helper\bin\Release\Samples.Helper.dll ..\
copy Helper\bin\Release\Samples.Helper.tlb ..\
copy Helper\bin\Release\Samples.Helper.xml ..\
del ..\Samples.Helper.pdb

ECHO Run this batch file to clean the existing reference of all samples
ECHO This is necessary when you switch all samples to switch between referencing the Debug and Release build of SDK kernal libraries.

del /S /Q SampleShippingServiceApplication\bin
del /S /Q SampleShippingServiceApplication\obj
rmdir /S /Q SampleShippingServiceApplication\bin
rmdir /S /Q SampleShippingServiceApplication\obj

del /S /Q SimpleSetup\bin
del /S /Q SimpleSetup\obj
rmdir /S /Q SimpleSetup\bin
rmdir /S /Q SimpleSetup\obj

del /S /Q SoapApiDemo\bin
del /S /Q SoapApiDemo\obj
rmdir /S /Q SoapApiDemo\bin
rmdir /S /Q SoapApiDemo\obj
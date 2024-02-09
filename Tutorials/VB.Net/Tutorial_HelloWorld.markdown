# Hello World -- eBay API/SDK Tutorial for VB.Net

This tutorial shows the bare minimum to get started with eBay API/SDK.
You can find the code used in this tutorial in the
Samples/VB.NET/HelloWorld folder of the .NET SDK package.

## Prerequisites:

1. eBay Trading SDK for .NET Framework 4.8

2. An eBay user token

3. Visual Studio 2022

## Steps to Create the Hello World Sample:

1. Create a new Visual Basic Console Application called HelloWorld in
Visual Studio (see Fig 1).

![](./images/image1.png) 

Fig 1. HelloWorld Project

2. Add a new application configuration file (app.config, see Fig. 2) to
this project. This file will contain some configuration information such
as your eBay user token and the API Server Url, which are necessary for
calling an eBay API (see Listing 1). Please update the token value with
your own token before you run this sample.

![](./images/image2.png) 

Fig 2. App.config file

<?xml version="1.0" encoding="utf-8" ?>

<configuration>

<appSettings>

<!-- API Server URL, required -->

<!-- For production site use: https://api.ebay.com/wsapi -->

<!-- For Sandbox site use: https://api.sandbox.ebay.com/wsapi -->

<add key="Environment.ApiServerUrl"
value="https://api.sandbox.ebay.com/wsapi"/>

<!-- User token for API server access, required -->

<add key="UserAccount.ApiToken" value="you ebay user token"/>

</appSettings>

</configuration>

Listing 1. Content of App.config

3. Add a reference to the eBay.Service assembly(see Fig 3). You will
find the assembly in the root folder of your eBay SDK for .Net
installation. eBay.Service assembly is the main component of the SDK,
and it encapsulates eBay API calls and hides the low level communication
details from you. Make sure you also add a reference to the
System.configuration .Net assembly.

![](./images/image3.png)

Fig 3. eBay.Service assembly

4. Add the following code (see Listing 2) in the main Module file(see
Fig 4)

![](./images/image4.png) 

Fig 4. Main Module

``` VB
Imports System.Configuration
Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap

'''<summary>
''' A hello world-like sample
''' showing how to call an eBay API using an eBay SDK
''' </summary>
''' <remarks></remarks>

Module Module1

    Private apiContext As ApiContext = Nothing

    Sub Main()
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")
        Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +")
        Console.WriteLine("+ - HelloWorld +")
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")

        '[Step 1] Initialize eBay ApiContext object
        Dim apiContext As ApiContext = GetApiContext()

        '[Step 2] Create call object and execute the call

        Dim apiCall As GeteBayOfficialTimeCall = New
        GeteBayOfficialTimeCall(apiContext)
        Console.WriteLine("Begin to call eBay API, please wait ...")
        Dim officialTime As DateTime = apiCall.GeteBayOfficialTime()
        Console.WriteLine("End to call eBay API, show call result:")

        '[Step 3] Handle the result returned
        Console.WriteLine("eBay official Time: " + officialTime)
        Console.WriteLine()
        Console.WriteLine("Press any key to close the program.")
        Console.ReadKey()

    End Sub

''' <summary>
''' Populate eBay SDK ApiContext instance with data from application configuration file
''' </summary>
''' <returns>ApiContext instance</returns>
''' <remarks></remarks>
    Private Function GetApiContext() As ApiContext

        'apiContext is a singleton
        'to avoid duplicate configuration reading

        If (apiContext IsNot Nothing) Then
            Return apiContext
        Else
            apiContext = New ApiContext
            'set Api Server Url
            apiContext.SoapApiServerUrl = _ConfigurationManager.AppSettings.Get("Environment.ApiServerUrl")

            'set Api Token to access eBay Api Server
            Dim apiCredential As ApiCredential = New ApiCredential

            apiCredential.eBayToken = _ConfigurationManager.AppSettings.Get("UserAccount.ApiToken")
            apiContext.ApiCredential = apiCredential

            'set eBay Site target to US
            apiContext.Site = SiteCodeType.US
            Return apiContext
        End If
    End Function
End Module
```

Listing 2. Source Code of the Module

5. Debug the HelloWorld project in Visual Studio. You will see
following output in the console window (see Fig 5):

![](./images/image5.png) 

Fig 5. Console Output

This sample calls GeteBayOfficialTime API to get eBay official time. If
everything works correctly, you will see eBay official time returned in
the output window.

Now you have a working sample which can call an eBay API using an eBay
SDK. Congratulations!

## Call Flow Analysis

A typical eBay API/SDK call paradigm (see Fig 6) involves three steps.
Below is an analysis of each step. Please use the source code listed
above (Listing 2) as a reference.

![](./images/image6.png) 

Fig 6. Typical eBay API/SDK Call Paradigm

**[Step 1] Initialize eBay ApiContext object**

In order to call the eBay API, you need to initialize an ApiContext
object first. ApiContext object contains all the configurations and
settings that are necessary to call the eBay API.

In the sample, we populate the ApiContext object with a user token and
server Url found in the App.config file. We also set Site on the
ApiContext object to target the eBay U.S. site.

There are other configurations and settings on the ApiContext object.
This sample only shows the bare minimum, so please refer to SDK
doc/source for more details.

**[Step 2] Create call object and execute the call**

For each eBay API call, there is a corresponding wrapper class in the
SDK. For example, GeteBayOfficialTimeCall is a wrapper class for the
GeteBayOfficialTime API call.

In the sample, we created a new instance of GeteBayOfficialTimeCall
wrapper class and then called its GeteBayOfficalTime() method. If the
call was successful, a DateTime class instance containing eBay official
time was returned.

Because of the wrapper class, you only need to write a few lines of code
to talk to eBay servers. The eBay SDK handles the low-level
communications with eBay servers for you.

**[Step 3] Handle the result returned**

After you get the response, you can handle the response according to
your own requirements. In the sample, we just output the returned eBay
official time in the console.

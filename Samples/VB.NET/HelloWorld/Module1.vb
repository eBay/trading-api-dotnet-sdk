Imports System.Configuration
Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap

''' <summary>
''' A hello-world like sample,
''' showing how to call eBay API using eBay SDK
''' </summary>
''' <remarks></remarks>
Module Module1

    Private apiContext As ApiContext = Nothing

    Sub Main()
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")
        Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +")
        Console.WriteLine("+ - HelloWorld                        +")
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")

        '[Step 1] Initialize eBay ApiContext object
        Dim apiContext As ApiContext = GetApiContext()


        '[Step 2] Create Call object and execute the Call
        Dim apiCall As GeteBayOfficialTimeCall = New GeteBayOfficialTimeCall(apiContext)
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
            apiContext.SoapApiServerUrl = _
                 ConfigurationManager.AppSettings.Get("Environment.ApiServerUrl")
            'set Api Token to access eBay Api Server
            Dim apiCredential As ApiCredential = New ApiCredential
            apiCredential.eBayToken = _
                 ConfigurationManager.AppSettings.Get("UserAccount.ApiToken")
            apiContext.ApiCredential = apiCredential
            'set eBay Site target to US
            apiContext.Site = SiteCodeType.US

            Return apiContext

        End If

    End Function

End Module

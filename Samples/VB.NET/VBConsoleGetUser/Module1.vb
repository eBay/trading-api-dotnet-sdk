Imports System.Configuration
Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap
Imports eBay.Service.Util

''' <summary>
''' A simple GetUser sample,
''' show basic flow to list an item to eBay Site using eBay SDK
''' </summary>
''' <remarks></remarks>

Module Module1
    Private apiContext As ApiContext = Nothing

    Sub Main()

        Try
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")
            Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +")
            Console.WriteLine("+ - ConsoleGetUser                    +")
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")

            'Initialize eBay ApiContext object
            Dim apiContext As ApiContext = GetApiContext()

            'Create Call object and set detail level to specify returned data
            Dim apiCall As GetUserCall = New GetUserCall(apiContext)
            apiCall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll)

            Console.WriteLine("Begin to call eBay API, please wait ...")
            apiCall.Execute()
            Console.WriteLine("End to call eBay API, show call result ...")
            Console.WriteLine()

            'Handle the result returned
            Console.WriteLine("UserID: " + apiCall.User.UserID.ToString())

            Console.WriteLine("EIAS Token is: " + apiCall.User.EIASToken.ToString())
            Console.WriteLine()

            If (apiCall.User.eBayGoodStanding = True) Then
                Console.WriteLine("User has good eBay standing")
            End If

            Console.WriteLine("Rating Star color: " + apiCall.User.FeedbackRatingStar.ToString())
            Console.WriteLine("Feedback score: " + apiCall.User.FeedbackScore.ToString())
            Console.WriteLine()

            Console.WriteLine("Total count of Negative Feedback: " + apiCall.User.UniqueNegativeFeedbackCount.ToString())
            Console.WriteLine("Total count of Neutral Feedback: " + apiCall.User.UniqueNeutralFeedbackCount.ToString())
            Console.WriteLine("Total count of Positive Feedback: " + apiCall.User.UniquePositiveFeedbackCount.ToString())


        Catch ex As Exception
            Console.WriteLine("Failed to get user data : " + ex.Message)
        End Try

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

            'set Api logging
            apiContext.ApiLogManager = New ApiLogManager
            Dim fileLogger As FileLogger = New FileLogger("listing_log.txt", True, True, True)
            apiContext.ApiLogManager.ApiLoggerList.Add(fileLogger)
            apiContext.ApiLogManager.EnableLogging = True

            Return apiContext

        End If

    End Function



End Module

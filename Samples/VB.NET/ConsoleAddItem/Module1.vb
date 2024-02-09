Imports System.Configuration
Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap
Imports eBay.Service.Util

''' <summary>
''' A simple item listing sample,
''' show basic flow to list an item to eBay Site using eBay SDK
''' </summary>
''' <remarks></remarks>
Module Module1

    Private apiContext As ApiContext = Nothing

    Sub Main()

        Try
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")
            Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +")
            Console.WriteLine("+ - ConsoleAddItem                    +")
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")

            '[Step 1] Initialize eBay ApiContext object
            Dim apiContext As ApiContext = GetApiContext()

            '[Step 2] Create a new ItemType object
            Dim item As ItemType = BuildItem()


            '[Step 3] Create Call object and execute the Call
            Dim apiCall As AddItemCall = New AddItemCall(apiContext)
            Console.WriteLine("Begin to call eBay API, please wait ...")
            Dim fees As FeeTypeCollection = apiCall.AddItem(item)
            Console.WriteLine("End to call eBay API, show call result ...")
            Console.WriteLine()

            '[Step 4] Handle the result returned
            Console.WriteLine("The item was listed successfully!")
            Dim listingFee As Double = 0.0
            Dim fee As FeeType
            For Each fee In fees
                If (fee.Name = "ListingFee") Then
                    listingFee = fee.Fee.Value
                End If
            Next
            Console.WriteLine(String.Format("Listing fee is: {0}", listingFee))
            Console.WriteLine(String.Format("Listed Item ID: {0}", item.ItemID))

        Catch ex As Exception
            Console.WriteLine("Fail to list the item : " + ex.Message)
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

            Return apiContext

        End If

    End Function


    ''' <summary>
    ''' Build a sample item
    ''' </summary>
    ''' <returns>ItemType instance</returns>
    Private Function BuildItem() As ItemType
        Dim item As ItemType = New ItemType()

        ' item title
        item.Title = "Test Item"
        ' item description
        item.Description = "eBay SDK sample test item"

        ' listing type
        item.ListingType = ListingTypeCodeType.Chinese
        ' listing price
        item.Currency = CurrencyCodeType.USD
        item.StartPrice = New AmountType()
        item.StartPrice.Value = 20
        item.StartPrice.currencyID = CurrencyCodeType.USD

        ' listing duration
        item.ListingDuration = "Days_3"

        ' item location and country
        item.Location = "San Jose"
        item.Country = CountryCodeType.US

        ' listing category, Coins
        Dim category As CategoryType = New CategoryType()
        category.CategoryID = "162922"
        item.PrimaryCategory = category

        ' item quality
        item.Quantity = 1

        ' payment methods
        item.PaymentMethods = New BuyerPaymentMethodCodeTypeCollection()
        item.PaymentMethods.Add(BuyerPaymentMethodCodeType.PayPal)
        ' email is required if paypal is used as payment method
        item.PayPalEmailAddress = "me@ebay.com"

        ' item condition, New
        item.ConditionID = 1000

        ' item specifics
        item.ItemSpecifics = BuildItemSpecifics()

        ' handling time is required
        item.DispatchTimeMax = 1

        ' shipping details
        item.ShippingDetails = BuildShippingDetails()

        ' return policy
        item.ReturnPolicy = New ReturnPolicyType()
        item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted"

        Return item

    End Function


    ''' <summary>
    ''' Build sample shipping details
    ''' </summary>
    ''' <returns>ShippingDetailsType instance</returns>
    Private Function BuildShippingDetails() As ShippingDetailsType
        ' Shipping details
        Dim sd As ShippingDetailsType = New ShippingDetailsType()

        sd.ApplyShippingDiscount = True
        Dim amount As AmountType = New AmountType()
        amount.Value = 2.8
        amount.currencyID = CurrencyCodeType.USD
        sd.PaymentInstructions = "eBay .Net SDK test instruction."

        ' Shipping type and shipping service options
        sd.ShippingType = ShippingTypeCodeType.Flat
        Dim shippingOptions As ShippingServiceOptionsType = New ShippingServiceOptionsType()
        shippingOptions.ShippingService = _
            ShippingServiceCodeType.ShippingMethodStandard.ToString()
        amount = New AmountType()
        amount.Value = 2.0
        amount.currencyID = CurrencyCodeType.USD
        shippingOptions.ShippingServiceAdditionalCost = amount
        amount = New AmountType()
        amount.Value = 10
        amount.currencyID = CurrencyCodeType.USD
        shippingOptions.ShippingServiceCost = amount
        shippingOptions.ShippingServicePriority = 1
        amount = New AmountType()
        amount.Value = 1.0
        amount.currencyID = CurrencyCodeType.USD
        shippingOptions.ShippingInsuranceCost = amount

        sd.ShippingServiceOptions = New ShippingServiceOptionsTypeCollection()
        sd.ShippingServiceOptions.Add(shippingOptions)

        Return sd

    End Function

    
    ''' <summary>
    ''' Build sample item specifics
    ''' </summary>
    ''' <returns>ItemSpecifics object</returns>
    Private Function BuildItemSpecifics() As NameValueListTypeCollection
        ' create the content of item specifics
        Dim nvCollection As NameValueListTypeCollection = New NameValueListTypeCollection()
        Dim nv1 As NameValueListType = New NameValueListType()
        nv1.Name = "Media"
        Dim nv1Col As StringCollection = New StringCollection()
        Dim strArr1() As String = {"DVD"}
        nv1Col.AddRange(strArr1)
        nv1.Value = nv1Col
        Dim nv2 As NameValueListType = New NameValueListType()
        nv2.Name = "OS"
        Dim nv2Col As StringCollection = New StringCollection()
        Dim strArr2() As String = {"Windows"}
        nv2Col.AddRange(strArr2)
        nv2.Value = nv2Col
        nvCollection.Add(nv1)
        nvCollection.Add(nv2)
        Return nvCollection
    End Function

End Module

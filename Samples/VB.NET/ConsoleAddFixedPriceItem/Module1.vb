Imports System.Configuration
Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap
Imports eBay.Service.Util

''' <summary>
''' A simple item listing sample,
''' show basic flow to list a fixed price item to eBay Site using eBay SDK
''' </summary>
''' <remarks></remarks>
Module Module1

    Private apiContext As ApiContext = Nothing

    Sub Main()

        Try
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")
            Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +")
            Console.WriteLine("+ - ConsoleAddFixedPriceItem          +")
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++")

            '[Step 1] Initialize eBay ApiContext object
            Dim apiContext As ApiContext = GetApiContext()

            '[Step 2] Create a new ItemType object
            Dim item As ItemType = BuildItem()


            '[Step 3] Create Call object and execute the Call
            Dim apiCall As AddFixedPriceItemCall = New AddFixedPriceItemCall(apiContext)
            Console.WriteLine("Begin to call eBay API, please wait ...")
            Dim fees As FeeTypeCollection = apiCall.AddFixedPriceItem(item)
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
        item.ListingType = ListingTypeCodeType.FixedPriceItem
        ' listing price
        item.Currency = CurrencyCodeType.USD

        ' listing duration
        item.ListingDuration = "Days_3"

        ' item location and country
        item.Location = "San Jose"
        item.Country = CountryCodeType.US

        ' listing category, Photography Software
        Dim category As CategoryType = New CategoryType()
        category.CategoryID = "4174" 'Primary Category (e.g.4174,27432,42428)
        item.PrimaryCategory = category


        ' payment methods
        item.PaymentMethods = New BuyerPaymentMethodCodeTypeCollection()
        item.PaymentMethods.Add(BuyerPaymentMethodCodeType.PayPal)
        ' email is required if paypal is used as payment method
        item.PayPalEmailAddress = "me@ebay.com"

        ' item specifics
        item.Variations = BuildVariationsType()

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
    ''' Build sample item Variations
    ''' </summary>
    ''' <returns>Variations object</returns>
    Private Function BuildVariationsType() As VariationsType        
        ' listing variations
        Dim variations As VariationsType = New VariationsType()

        ' first variation
        Dim variation1 As VariationType = New VariationType()
        ' create the content of VariationSpecifics
        Dim nvcol1 As NameValueListTypeCollection = New NameValueListTypeCollection()
        Dim nv11 As NameValueListType = New NameValueListType()
        nv11.Name = "Color"
        Dim nv1StrCol As StringCollection = New StringCollection()
        Dim strArr1() As String = {"RED"}
        nv1StrCol.AddRange(strArr1)
        nv11.Value = nv1StrCol
        Dim nv12 As NameValueListType = New NameValueListType()
        nv12.Name = "Size"
        Dim nv2StrCol As StringCollection = New StringCollection()
        Dim strArr2() As String = {"M"}
        nv2StrCol.AddRange(strArr2)
        nv12.Value = nv2StrCol
        nvcol1.Add(nv11)
        nvcol1.Add(nv12)
        ' set variation-level specifics for first variation
        variation1.VariationSpecifics = nvcol1
        ' set start price
        Dim amount1 As AmountType = New AmountType()
        amount1.Value = 100
        amount1.currencyID = CurrencyCodeType.USD
        variation1.StartPrice = amount1
        ' set quantity
        variation1.Quantity = 10
        ' set variation name
        variation1.VariationTitle = "RED,M"

        ' second variation
        Dim variation2 As VariationType = New VariationType()
        ' create the content of specifics for each variation
        Dim nvcol2 As NameValueListTypeCollection = New NameValueListTypeCollection()
        Dim nv21 As NameValueListType = New NameValueListType()
        nv21.Name = "Color"
        Dim nv21StrCol As StringCollection = New StringCollection()
        Dim strArr21() As String = {"BLACK"}
        nv21StrCol.AddRange(strArr21)
        nv21.Value = nv21StrCol
        Dim nv22 As NameValueListType = New NameValueListType()
        nv22.Name = "Size"
        Dim nv22StrCol As StringCollection = New StringCollection()
        Dim strArr22() As String = {"L"}
        nv22StrCol.AddRange(strArr22)
        nv22.Value = nv22StrCol
        nvcol2.Add(nv21)
        nvcol2.Add(nv22)
        ' set variation-level specifics for first variation
        variation2.VariationSpecifics = nvcol2
        ' set start price
        Dim amount2 As AmountType = New AmountType()
        amount2.Value = 110
        amount2.currencyID = CurrencyCodeType.USD
        variation2.StartPrice = amount2
        ' set quantity
        variation2.Quantity = 20
        ' set variation name
        variation2.VariationTitle = "BLACK,L"

        ' set variation
        Dim varCol As VariationTypeCollection = New VariationTypeCollection()
        varCol.Add(variation1)
        varCol.Add(variation2)
        variations.Variation = varCol

        ' create the content of specifics for variations
        Dim nvcol3 As NameValueListTypeCollection = New NameValueListTypeCollection()
        Dim nv31 As NameValueListType = New NameValueListType()
        nv31.Name = "Color"
        Dim nv31StrCol As StringCollection = New StringCollection()
        Dim strArr31() As String = {"BLACK", "RED"}
        nv31StrCol.AddRange(strArr31)
        nv31.Value = nv31StrCol
        Dim nv32 As NameValueListType = New NameValueListType()
        nv32.Name = "Size"
        Dim nv32StrCol As StringCollection = New StringCollection()
        Dim strArr32() As String = {"M", "L"}
        nv32StrCol.AddRange(strArr32)
        nv32.Value = nv32StrCol
        nvcol3.Add(nv31)
        nvcol3.Add(nv32)
        ' set variationSpecifics
        variations.VariationSpecificsSet = nvcol3
        Return variations
    End Function

End Module

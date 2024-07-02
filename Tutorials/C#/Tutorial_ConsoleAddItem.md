# **Console Add Item -- eBay API/SDK Tutorial**

This tutorial is a simple example of how to create a new listing on the
eBay site using an eBay SDK to interact with the eBay API. You can find
the code used in this tutorial in the Samples/C#/ConsoleAddItem folder
of the .Net SDK package.

***Prerequisites***:

1. eBay Trading SDK for .NET Framework 4.8

2. An eBay user token

3. Visual Studio 2022

## ***Steps to Create the Console Add Item Sample:***

**1.** Create a new console application called ConsoleAddItem in Visual
Studio (see Fig 1).

Fig 1. ConsoleAddItem Project

2. Add a new application configuration file (App.config, see Fig 2)
to this project. This file will contain some configuration information,
such as your eBay user token and API Server URL, needed for calling the
eBay API (see Listing 1). Please update the token value with your own
token before you run this sample.

Fig 2. Application configuration file

```XML
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
```

Listing 1. Content of App.config


**3.** Add references to the eBay.Service assembly and to the
System.configuration .Net assembly (see Fig 3). You will find the
assemblies in the root folder of your eBay SDK for .Net installation.
eBay.Service assembly is the main component of the SDK, and it
encapsulates eBay API calls and hides the low-level communication
details from you.

Fig 3. eBay.Service assembly

**4.** In the main Program class (see Fig. 4), provide references to
calls and classes in the SDK by importing the following .Net namespaces
and SDK namespaces, also provide namespace, class name and variable
definition at the same time:

Fig 4 the Main Program class
``` C#
using System;
using System.Configuration;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
namespace ConsoleAddItem
{
    class Program
    {
        private static ApiContext apiContext = null;

```

Listing 2. Import Namespace

**5.** In order to call the eBay API, you need to initialize an
ApiContext object first. The ApiContext object contains all the
configurations and settings that are necessary to call the eBay API.

In the main Program class, create the following function, called
GetApiContext (see Listing 3). In this function, we populate the
ApiContext object with a user token and the server URL found in the
App.config file. We also set Site in the ApiContext object to target the
eBay US site.

You can configure the ApiContext object to log all of the communication
to a logger (for example, a text file). Here we're going to log all the
SOAP messages to a text file. If anything goes wrong, logging is
extremely helpful for troubleshooting.

``` C#
/// <summary>
/// Populate eBay SDK ApiContext object with data from application configuration file
/// </summary>
/// <returns>ApiContext object</returns>
static ApiContext GetApiContext()
{
    //apiContext is a singleton
    //to avoid duplicate configuration reading

    if (apiContext != null)
    {
        return apiContext;
    }
    else
    {
        apiContext = new ApiContext();
        //set Api Server Url
        apiContext.SoapApiServerUrl = ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
        //set Api Token to access eBay Api Server
        ApiCredential apiCredential = new ApiCredential();
        apiCredential.eBayToken = ConfigurationManager.AppSettings["UserAccount.ApiToken"];
        apiContext.ApiCredential = apiCredential;
        //set eBay Site target to US
        apiContext.Site = SiteCodeType.US;
        //set Api logging
        apiContext.ApiLogManager = new ApiLogManager();
        apiContext.ApiLogManager.ApiLoggerList.Add(new FileLogger("listing_log.txt", true, true, true));
        apiContext.ApiLogManager.EnableLogging = true;
        return apiContext;
    }

}
```

Listing 3. GetApiContext function

**6.** In order to list an item on eBay, you need to create a new
instance of the ItemType class first.

In the main Program class, create the following function, called
BuildItem (see Listing 4). In this function, we populate the item with
information such as item title and description, listing category,
payment methods and shipping details, etc. For detailed requirements
about how much information you should provide to list an item, please
refer to eBay Trading API reference.

``` C#
/// <summary>
/// Build a sample item
/// </summary>
/// <returns>ItemType object</returns>
static ItemType BuildItem()
{
    ItemType item = new ItemType();
    // item title
    item.Title = "Test Item";

    // item description
    item.Description = "eBay SDK sample test item";

    // listing type
    item.ListingType = ListingTypeCodeType.Chinese;

    // listing price
    item.Currency = CurrencyCodeType.USD;
    item.StartPrice = new AmountType();
    item.StartPrice.Value = 20;
    item.StartPrice.currencyID = CurrencyCodeType.USD;

    // listing duration
    item.ListingDuration ="Days_3";

    // item location and country
    item.Location = "San Jose";
    item.Country = CountryCodeType.US;

    // listing category, games
    CategoryType category = new CategoryType();
    category.CategoryID = "139973";
    item.PrimaryCategory = category;

    // item quality
    item.Quantity = 1;
    // payment methods

    item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection();

    item.PaymentMethods.AddRange(new BuyerPaymentMethodCodeType[] { BuyerPaymentMethodCodeType.PayPal });

    // email is required if paypal is used as payment method
    item.PayPalEmailAddress = "me@ebay.com";

    // item condition, New
    item.ConditionID = 1000;

    // handling time is required
    item.DispatchTimeMax = 1;

    // item specifics
    item.ItemSpecifics = buildItemSpecifics();

    Console.WriteLine("Do you want to use Business policy profiles to list this item? y/n");

    String input = Console.ReadLine();
    if (input.ToLower().Equals("y"))
    {
        item.SellerProfiles = BuildSellerProfiles();
    }
    else
    {
        // payment methods
        item.PaymentMethods = new BuyerPaymentMethodCodeTypeCollection();
        item.PaymentMethods.AddRange(
        new BuyerPaymentMethodCodeType[] { BuyerPaymentMethodCodeType.PayPal });

        // email is required if paypal is used as payment method
        item.PayPalEmailAddress ="me@ebay.com";

        // handling time is required
        item.DispatchTimeMax = 1;

        // shipping details
        item.ShippingDetails = BuildShippingDetails();

        // return policy
        item.ReturnPolicy = new ReturnPolicyType();
        item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted";
    }
    return item;
}
```
Listing 4. BuildItem function

**7.** In the main Program class, create a helper function called
BuildShippingDetails (see Listing 5). This function is used by the
BuildItem function to build sample shipping details.
```C#
/// <summary>
/// Build sample shipping details
/// </summary>
/// <returns>ShippingDetailsType object</returns>
static ShippingDetailsType BuildShippingDetails()
{
    // Shipping details
    ShippingDetailsType sd = new ShippingDetailsType();
    sd.ApplyShippingDiscount = true;
    AmountType amount = new AmountType();
    amount.Value = 2.8;
    amount.currencyID = CurrencyCodeType.USD;
    sd.PaymentInstructions = "eBay .Net SDK test instruction.";

    // Shipping type and shipping service options
    sd.ShippingType = ShippingTypeCodeType.Flat;

    ShippingServiceOptionsType shippingOptions = new
    ShippingServiceOptionsType();
    shippingOptions.ShippingService =ShippingServiceCodeType.ShippingMethodStandard.ToString();
    amount = new AmountType();
    amount.Value = 2.0;
    amount.currencyID = CurrencyCodeType.USD;
    shippingOptions.ShippingServiceAdditionalCost = amount;
    amount = new AmountType();
    amount.Value = 10;
    amount.currencyID = CurrencyCodeType.USD;
    shippingOptions.ShippingServiceCost = amount;
    shippingOptions.ShippingServicePriority = 1;
    amount = new AmountType();
    amount.Value = 1.0;
    amount.currencyID = CurrencyCodeType.USD;
    shippingOptions.ShippingInsuranceCost = amount;
    sd.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection(new ShippingServiceOptionsType[] { shippingOptions }
    );
    return sd;
}
```
Listing 5. BuildShippingDetails function

**8.** Now that all the building blocks are ready, let's wire them
together in the Main function (see Listing 6). The overall call flow is
shown in Fig 5:

``` C#
static void Main(string[] args)
{

    try {
        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");

        Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +");

        Console.WriteLine("+ - ConsoleAddItem +");

        Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");

        //[Step 1] Initialize eBay ApiContext object

        ApiContext apiContext = GetApiContext();

        //[Step 2] Create a new ItemType object
        ItemType item = BuildItem();

        //[Step 3] Create Call object and execute the Call
        AddItemCall apiCall = new AddItemCall(apiContext);

        Console.WriteLine("Begin to call eBay API, please wait ...");

        FeeTypeCollection fees = apiCall.AddItem(item);

        Console.WriteLine("End to call eBay API, show call result ...");

        Console.WriteLine();

        //[Step 4] Handle the result returned
        Console.WriteLine("The item was listed successfully!");

        double listingFee = 0.0;

        foreach (FeeType fee in fees)
        {
            if (fee.Name == "ListingFee")
            {
                listingFee = fee.Fee.Value;
            }
        }

        Console.WriteLine(String.Format("Listing fee is: {0}", listingFee));

        Console.WriteLine(String.Format("Listed Item ID: {0}", item.ItemID));
    }

    catch (Exception ex)
    {
        Console.WriteLine("Fail to list the item : " + ex.Message);
    }

    Console.WriteLine();
    Console.WriteLine("Press any key to close the program.");
    Console.ReadKey();
}
```
Listing 6. The Main function

Fig 5. The Call Flow

After the ItemType instance is created, we call the AddItem API and pass
in the newly created ItemType instance as a parameter. If the call is
successful, a FeeTypeCollection class instance will be returned. This
collection instance contains all of the individual fees resulting from
the item listing. Lastly, we output the Listing fee and Listed Item ID
in the console (for your application, you can handle the response
according to your own requirements). The main function also shows the
basic exception handling. If anything goes wrong, you are responsible
for catching and handling exceptions according to your requirements.

**9.** Debug the ConsoleAddItem project in Visual Studio. You will see
the output in the console window (see Fig 6.) (if anything goes wrong,
you can check the log in bin\Debug folder for troubleshooting):

Fig 6. Console Output

**10.** You can verify the item by searching the itemID in the eBay
sandbox (or production if you configured a production API server Url in
the application configuration file) site (see Fig 7).

Now you have a working sample that can list items on the eBay site using
eBay SDK. Congratulations!

Fig 7. Live Item on eBay Site

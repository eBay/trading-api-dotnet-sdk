#region Copyright
/*
 * *
 *  * Copyright 2024 eBay Inc.
 *  *
 *  * Licensed under the Apache License, Version 2.0 (the "License");
 *  * you may not use this file except in compliance with the License.
 *  * You may obtain a copy of the License at
 *  *
 *  *  http://www.apache.org/licenses/LICENSE-2.0
 *  *
 *  * Unless required by applicable law or agreed to in writing, software
 *  * distributed under the License is distributed on an "AS IS" BASIS,
 *  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  * See the License for the specific language governing permissions and
 *  * limitations under the License.
 *  *
 */
#endregion

using System;
using System.Configuration;
using System.Collections.Generic;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;

namespace ConsoleAddItem
{
    /// <summary>
    /// A simple item adding sample,
    /// show basic flow to list an item to eBay Site using eBay SDK.
    /// </summary>
    class Program
    {
        private static ApiContext apiContext = null;

        static void Main(string[] args)
        {

            try {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +");
                Console.WriteLine("+ - ConsoleAddItem                    +");
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

        /// <summary>
        /// Populate eBay SDK ApiContext object with data from application configuration file
        /// </summary>
        /// <returns>ApiContext object</returns>
        static ApiContext GetApiContext()
        {
            //apiContext is a singleton,
            //to avoid duplicate configuration reading
            if (apiContext != null)
            {
                return apiContext;
            }
            else
            {
                apiContext = new ApiContext();

                //set Api Server Url
                apiContext.SoapApiServerUrl = 
                    ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
                //set Api Token to access eBay Api Server
                ApiCredential apiCredential = new ApiCredential();
                apiCredential.eBayToken = 
                    ConfigurationManager.AppSettings["UserAccount.ApiToken"];
                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to US
                apiContext.Site = SiteCodeType.US;

                //set Api logging
                apiContext.ApiLogManager = new ApiLogManager();
                apiContext.ApiLogManager.ApiLoggerList.Add(
                    new FileLogger("listing_log.txt", true, true, true)
                    );
                apiContext.ApiLogManager.EnableLogging = true;


                return apiContext;
            }
        }

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
            item.ListingDuration = "Days_3"; 

            // item location and country
            item.Location = "San Jose";
            item.Country = CountryCodeType.US;

            // listing category, 
            CategoryType category = new CategoryType();
            category.CategoryID = "11104"; //CategoryID = 11104 (CookBooks) , Parent CategoryID=267(Books)
            item.PrimaryCategory = category;
             
            // item quality
            item.Quantity = 1;

            // item condition, New
            item.ConditionID = 1000;

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
                    new BuyerPaymentMethodCodeType[] { BuyerPaymentMethodCodeType.PayPal }
                    );
                // email is required if paypal is used as payment method
                item.PayPalEmailAddress = "me@ebay.com";

                // handling time is required
                item.DispatchTimeMax = 1;
                // shipping details
                item.ShippingDetails = BuildShippingDetails();

                // return policy
                item.ReturnPolicy = new ReturnPolicyType();
                item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted";
            }
            //item Start Price
            AmountType amount = new AmountType();
            amount.Value = 2.8;
            amount.currencyID = CurrencyCodeType.USD;
            item.StartPrice = amount;

            
            return item;
        }

        /// <summary>
        /// Build sample SellerProfile details
        /// </summary>
        /// <returns></returns>
        static SellerProfilesType BuildSellerProfiles()
        {
            /*
             * Beginning with release 763, some of the item fields from
             * the AddItem/ReviseItem/VerifyItem family of calls have been
             * moved to the Business Policies API. 
             * See http://developer.ebay.com/Devzone/business-policies/Concepts/BusinessPoliciesAPIGuide.html for more
             * 
             * This example uses profiles that were previously created using this api.
             */

            SellerProfilesType sellerProfile = new SellerProfilesType();
      
            Console.WriteLine("Enter Return policy profile Id:");            
            sellerProfile.SellerReturnProfile = new SellerReturnProfileType();
            sellerProfile.SellerReturnProfile.ReturnProfileID = Int64.Parse(Console.ReadLine());

            Console.WriteLine("Enter Shipping profile Id:");            
            sellerProfile.SellerShippingProfile = new SellerShippingProfileType();
            sellerProfile.SellerShippingProfile.ShippingProfileID = Int64.Parse(Console.ReadLine());

            Console.WriteLine("Enter Payment profile Id:");            
            sellerProfile.SellerPaymentProfile = new SellerPaymentProfileType();
            sellerProfile.SellerPaymentProfile.PaymentProfileID = Int64.Parse(Console.ReadLine());

            return sellerProfile;
        }

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
            ShippingServiceOptionsType shippingOptions = new ShippingServiceOptionsType();
            shippingOptions.ShippingService = 
                ShippingServiceCodeType.ShippingMethodStandard.ToString();
            amount = new AmountType();
            amount.Value = 2.0;
            amount.currencyID = CurrencyCodeType.USD;
            shippingOptions.ShippingServiceAdditionalCost = amount;
            amount = new AmountType();
            amount.Value = 1;
            amount.currencyID = CurrencyCodeType.USD;
            shippingOptions.ShippingServiceCost = amount;
            shippingOptions.ShippingServicePriority = 1;
            amount = new AmountType();
            amount.Value = 1.0;
            amount.currencyID = CurrencyCodeType.USD;
            shippingOptions.ShippingInsuranceCost = amount;

            sd.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection(
                new ShippingServiceOptionsType[] { shippingOptions }
                );

            return sd;
        }

        /// <summary>
        /// Build sample item specifics
        /// </summary>
        /// <returns>ItemSpecifics object</returns>
        static NameValueListTypeCollection buildItemSpecifics()
        {        	  
	        //create the content of item specifics
            NameValueListTypeCollection nvCollection = new NameValueListTypeCollection();
            NameValueListType nv1 = new NameValueListType();
            nv1.Name = "Platform";
            StringCollection nv1Col = new StringCollection();
            String[] strArr1 = new string[] { "Microsoft Xbox 360" };
            nv1Col.AddRange(strArr1);
            nv1.Value = nv1Col;
            NameValueListType nv2 = new NameValueListType();
            nv2.Name = "Genre";
            StringCollection nv2Col = new StringCollection();
            String[] strArr2 = new string[] { "Simulation" };
            nv2Col.AddRange(strArr2);
            nv2.Value = nv2Col;
            nvCollection.Add(nv1);
            nvCollection.Add(nv2);
            return nvCollection;
         }
    }
}

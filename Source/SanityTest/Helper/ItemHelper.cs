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

#region Namespaces
using System;
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
using AllTestsSuite;
#endregion

namespace UnitTests.Helper
{
	/// <summary>
	/// Summary description for ItemHelper.
	/// </summary>
	public class ItemHelper
	{

		#region constructor

		public ItemHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

		#region public method

		/// <summary>
		/// get an item.
		/// </summary>
		/// <param name="itemGet"></param>
		/// <param name="apiContext"></param>
		/// <param name="message"></param>
		/// <param name="itemOut"></param>
		/// <returns></returns>
		public static bool GetItem(ItemType itemGet,ApiContext apiContext,out string message,out ItemType itemOut)
		{
			message=string.Empty;
			itemOut=null;

			bool includeCrossPromotion=true;
			bool includeItemSpecifics=true;
			bool includeTaxTable=true;
			bool includeWatchCount=true;
			
			try
			{	
				GetItemCall api=new GetItemCall(apiContext);
				DetailLevelCodeType detaillevel= DetailLevelCodeType.ReturnAll;
				api.DetailLevelList=new DetailLevelCodeTypeCollection(new DetailLevelCodeType[]{detaillevel});
				
				itemOut = api.GetItem(itemGet.ItemID,includeWatchCount,includeCrossPromotion,includeItemSpecifics,includeTaxTable,null, null, null, null, false);

				if(itemOut==null)
				{
					message="do not get the item";
				}

				if(itemOut.ItemID!=itemGet.ItemID)
				{
					message="the item getted is not the same as item wanted";
				}
			}
			catch(Exception e)
			{
				message=e.Message;
				return false;
			}

			return true;
		}

		/// <summary>
		/// end an item
		/// </summary>
		/// <param name="apiContext"></param>
		/// <param name="item"></param>
		/// <param name="isSuccess"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static bool EndItem(ApiContext apiContext,ItemType item,out string message)
		{
			message=string.Empty;
			EndItemCall api = new EndItemCall(apiContext);
			// Set the item to be ended.
			api.ItemID = item.ItemID;
			api.EndingReason = EndReasonCodeType.NotAvailable;
			try
			{
				api.Execute();
			}
			catch(Exception e)
			{
				message=e.Message;
				return false;
			}

			return true;
		}

		/// <summary>
		/// return an item
		/// </summary>
		/// <returns></returns>
		public static ItemType BuildItem()
		{
			
			ItemType item = new ItemType();
			item.Site = SiteCodeType.US;
			item.Currency = CurrencyCodeType.USD;
			item.ListingType = ListingTypeCodeType.Chinese;
			String t = "eBay SDK SanityTest " + DateTime.Now + " DO NOT BID!";
			
			item.ApplicationData="this is an application data";
			item.Title = t;
			item.Description = "This is a test item created by eBay SDK SanityTest.";
			item.StartPrice = new AmountType();
			item.StartPrice.Value = 1.01;
			item.StartPrice.currencyID = item.Currency;
			item.ListingDuration = "Days_7";
			item.Location = "San Jose, CA";
			item.Country = CountryCodeType.US;
			BestOfferDetailsType bo = new BestOfferDetailsType();
			bo.BestOfferEnabled = false;
			item.BestOfferDetails = bo;
			CategoryType cat = new CategoryType();
			cat.CategoryID = "14111";
			item.PrimaryCategory = cat;
			item.Quantity = 1;
			item.QuantitySpecified = true;
			//handling time
			item.DispatchTimeMax =1;

            //item condition
            item.ConditionID = 1000;

            

            // Payment
			BuyerPaymentMethodCodeTypeCollection arrPaymentMethods =
				new BuyerPaymentMethodCodeTypeCollection();
			arrPaymentMethods.Add(BuyerPaymentMethodCodeType.PayPal);
			item.PaymentMethods = arrPaymentMethods;
			item.PayPalEmailAddress = "me@ebay.com";
			//shipping service
			item.ShippingDetails = getShippingDetails();
			// Set item picture
			PictureDetailsType pictureDetails = new PictureDetailsType();
			pictureDetails.PictureURL = new StringCollection();
			pictureDetails.PictureURL.Add( "http://pics.ebaystatic.com/aw/pics/navbar/eBayLogoTM.gif");

			item.ReturnPolicy=GetPolicyForUS();

			item.PictureDetails = pictureDetails;
			return item;
		}

        public static ItemType BuildItemForBusinessPoliciesAPI()
        {
            ItemType item = new ItemType();
            item.Site = SiteCodeType.US;
            item.Currency = CurrencyCodeType.USD;
            item.ListingType = ListingTypeCodeType.Chinese;
            String t = "eBay SDK SanityTest " + DateTime.Now + " DO NOT BID!";

            item.ApplicationData = "this is an application data";
            item.Title = t;
            item.Description = "This is a test item created by eBay SDK SanityTest.";
            item.StartPrice = new AmountType();
            item.StartPrice.Value = 1.01;
            item.StartPrice.currencyID = item.Currency;
            item.ListingDuration = "Days_7";
            item.Location = "San Jose, CA";
            item.Country = CountryCodeType.US;
            BestOfferDetailsType bo = new BestOfferDetailsType();
            bo.BestOfferEnabled = false;
            item.BestOfferDetails = bo;
            CategoryType cat = new CategoryType();
            cat.CategoryID = "14111";
            item.PrimaryCategory = cat;
            item.Quantity = 1;
            item.QuantitySpecified = true;
            //handling time
            item.DispatchTimeMax = 1;

            //item condition
            item.ConditionID = 1000;

            // Picture details
            PictureDetailsType pictureDetails = new PictureDetailsType();
			pictureDetails.PictureURL = new StringCollection();
			pictureDetails.PictureURL.Add( "http://pics.ebaystatic.com/aw/pics/navbar/eBayLogoTM.gif");
            
            item.PictureDetails = pictureDetails;

            // Seller Profiles
            SellerProfilesType sellerProfilesType = new SellerProfilesType();
            sellerProfilesType.SellerPaymentProfile = GetSellerPaymentProfile();
            sellerProfilesType.SellerReturnProfile = GetSellerReturnProfile();
            sellerProfilesType.SellerShippingProfile = GetSellerShippingProfile();

            item.SellerProfiles = sellerProfilesType;

            return item;
        }

        private static SellerShippingProfileType GetSellerShippingProfile()
        {
 	        SellerShippingProfileType sellerShippingProfileType = new SellerShippingProfileType();
            sellerShippingProfileType.ShippingProfileID = 123456;
            sellerShippingProfileType.ShippingProfileName = "";
            return sellerShippingProfileType;
        }

        private static SellerReturnProfileType GetSellerReturnProfile()
        {
 	        SellerReturnProfileType sellerReturnProfileType = new SellerReturnProfileType();
            sellerReturnProfileType.ReturnProfileID = 123456;
            sellerReturnProfileType.ReturnProfileName = "";
            return sellerReturnProfileType;
        }

        private static SellerPaymentProfileType GetSellerPaymentProfile()
        {
 	        SellerPaymentProfileType sellerPaymentProfileType = new SellerPaymentProfileType();
            sellerPaymentProfileType.PaymentProfileID = 123465;
            sellerPaymentProfileType.PaymentProfileName = "";
            return sellerPaymentProfileType;
        }


		/// <summary>
		/// get a policy for us site only.
		/// </summary>
		/// <returns></returns>
		public static ReturnPolicyType GetPolicyForUS()
		{
			ReturnPolicyType policy=new ReturnPolicyType();
			policy.Refund="MoneyBack";
			policy.ReturnsWithinOption="Days_14";
			policy.ReturnsAcceptedOption="ReturnsAccepted";
			policy.ShippingCostPaidByOption="Buyer";

			return policy;
		}


		#endregion

		#region private method

		private static ShippingDetailsType getShippingDetails()
		{
			// Shipping details.
			ShippingDetailsType sd = new ShippingDetailsType();
			SalesTaxType salesTax = new SalesTaxType();
			salesTax.SalesTaxPercent = 0.0825F;
			salesTax.SalesTaxPercentSpecified = true;
			salesTax.SalesTaxState = "CA";
			sd.SalesTax = salesTax;
			sd.AllowPaymentEdit = false;
			sd.AllowPaymentEditSpecified = true;
			sd.ApplyShippingDiscount = true;
			sd.ApplyShippingDiscountSpecified = true;
			//sd.InsuranceFee = new AmountType();
			//sd.InsuranceFee.Value = 0.1;
			//sd.InsuranceFee.currencyID = CurrencyCodeType.USD;
			//sd.InsuranceOption = InsuranceOptionCodeType.Optional;
			sd.PaymentInstructions = "eBay Java SDK test instruction.";
			sd.ShippingType = ShippingTypeCodeType.Flat;
			ShippingServiceOptionsType st1 = new ShippingServiceOptionsType();
			st1.ShippingService = ShippingServiceCodeType.USPSPriority.ToString();
			st1.ShippingServiceAdditionalCost = new AmountType();
			st1.ShippingServiceAdditionalCost.Value = 0.1;
			st1.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.USD;
			st1.ShippingServiceCost = new AmountType();
			st1.ShippingServiceCost.Value = 0.1;
			st1.ShippingServiceCost.currencyID = CurrencyCodeType.USD;

			st1.ShippingServicePriority = 1;
			st1.ShippingServicePrioritySpecified = true;
			st1.ShippingInsuranceCost = new AmountType();
			st1.ShippingInsuranceCost.Value = 0.1;
			st1.ShippingInsuranceCost.currencyID = CurrencyCodeType.USD;
			ShippingServiceOptionsType st2 = new ShippingServiceOptionsType();
			st2.ExpeditedService = true;
			st2.ExpeditedServiceSpecified = true;
			st2.ShippingService = ShippingServiceCodeType.USPSFirstClass.ToString();
			st2.ShippingServiceAdditionalCost = new AmountType();
			st2.ShippingServiceAdditionalCost.Value = 0.1;
			st2.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.USD;

			st2.ShippingServiceCost = new AmountType();
			st2.ShippingServiceCost.Value = 0.1;
			st2.ShippingServiceCost.currencyID = CurrencyCodeType.USD;
			st2.ShippingServicePriority = 2;
			st2.ShippingServicePrioritySpecified = true;
			st2.ShippingInsuranceCost = new AmountType();
			st2.ShippingInsuranceCost.Value = 0.1;
			st2.ShippingInsuranceCost.currencyID = CurrencyCodeType.USD;

			sd.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection();
			sd.ShippingServiceOptions.Add(st1);
			sd.ShippingServiceOptions.Add(st2);
			return sd;
			
		}


		#endregion

     }
}

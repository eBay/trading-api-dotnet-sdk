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
#endregion

namespace AllTestsSuite.T_020_OtherTestsSuite
{
	[TestFixture]
	public class T_180_GeteBayDetailsLibrary : SOAPTestBase
	{
		[Test]
		public void GeteBayDetails()
		{
			GeteBayDetailsCall api = new GeteBayDetailsCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			// Call API.
			api.Execute();
			GeteBayDetailsResponseType resp = api.ApiResponse;
			Assert.IsNotNull(resp.CountryDetails);
			Assert.IsTrue(resp.CountryDetails.Count > 0);
			Assert.IsNotNull(resp.CurrencyDetails);
			Assert.IsTrue(resp.CurrencyDetails.Count > 0);
			Assert.IsNotNull(resp.RegionDetails);
			Assert.IsTrue(resp.RegionDetails.Count > 0);
			Assert.IsNotNull(resp.SiteDetails);
			Assert.IsTrue(resp.SiteDetails.Count > 0);
			Assert.IsNotNull(resp.URLDetails);
			Assert.IsTrue(resp.URLDetails.Count > 0);
			Assert.IsNotNull(resp.PaymentOptionDetails);
			Assert.IsTrue(resp.PaymentOptionDetails.Count > 0);
			Assert.IsNotNull(resp.ReturnPolicyDetails!=null);
			
			///////////////
			// Testing EBayDetailsHelper
			///////////////
			///////
			// - Not site specific details:
			///////
			EBayDetailsHelper helper = EBayDetailsHelper.getInstance(apiContext);
			CountryDetailsTypeCollection countryDetails = helper.getCountryDetails();
			Assert.IsNotNull(countryDetails);
			CurrencyDetailsTypeCollection currencyDetails = helper.getCurrencyDetails();
			Assert.IsNotNull(currencyDetails);
			DispatchTimeMaxDetailsTypeCollection dispatchTimeDetails = helper.getDispatchTimeMaxDetails();
			Assert.IsNotNull(dispatchTimeDetails);
			ShippingLocationDetailsTypeCollection shippingLocations = helper.getShippingLocationDetails();
			Assert.IsNotNull(shippingLocations);
			ShippingLocationDetailsType shipLocationDetailsType = helper.getShippingLocationDetailsByShipingLocation("AU");
			Assert.AreEqual("Australia", shipLocationDetailsType.Description);
			SiteDetailsTypeCollection siteDetails = helper.getSiteDetails();
			Assert.IsNotNull(siteDetails);
			TimeZoneDetailsTypeCollection timeZoneDetails = helper.getTimeZoneDetails();
			Assert.IsNotNull(timeZoneDetails);

			////////
			// - Site specific details:
			////////
			/// Payment Option Details
			PaymentOptionDetailsTypeCollection paymentDetails1 = helper.getPaymentOptionDetailsForSite(SiteCodeType.US);
			Assert.IsNotNull(paymentDetails1);
			PaymentOptionDetailsType paymentOption = helper.getPaymentOptionDetailsBySiteAndPaymentMethod(SiteCodeType.US, BuyerPaymentMethodCodeType.Discover);
			Assert.IsNotNull(paymentOption);
			PaymentOptionDetailsTypeCollection paymentDetails2 = helper.getPaymentOptionDetailsForSite(SiteCodeType.UK);
			Assert.IsNotNull(paymentDetails2);
			PaymentOptionDetailsTypeCollection paymentDetails3 = helper.getPaymentOptionDetailsForSite(SiteCodeType.Canada);
			Assert.IsNotNull(paymentDetails3);
			// Tax Jurisdiction Details
			TaxJurisdictionTypeCollection taxCollectionDetails = helper.getTaxJurisdictionDetailsForSite(SiteCodeType.US);
			Assert.IsNotNull(taxCollectionDetails);
			TaxJurisdictionType taxJurisdictionType = helper.getTaxJurisdictionDetailsBySiteAndJurisdictionID(SiteCodeType.US, "WY");
			Assert.AreEqual("Wyoming", taxJurisdictionType.JurisdictionName);
			// Region Details
			//commented by william, 3/15/2008
			RegionDetailsTypeCollection regionDetails = helper.getRegionDetailsForSite(SiteCodeType.US);
			Assert.IsNotNull(regionDetails);
			RegionDetailsType regionDetail = helper.getRegionDetailsBySiteAndRegionID(SiteCodeType.US, "57");
			Assert.AreEqual("CA-Oakland", regionDetail.Description);
			// Shipping Service Details
			ShippingServiceDetailsTypeCollection shippingServiceDetails = helper.getShippingServiceDetailsForSite(SiteCodeType.France);
			Assert.IsNotNull(shippingServiceDetails);
			ShippingServiceDetailsType shipServiceDetails = helper.getShippingServiceDetailsBySiteAndShippingServiceID(SiteCodeType.US, 8);
			//Assert.AreEqual("US Postal Service Parcel Post", shipServiceDetails.Description);
			// URL Details
			URLDetailsTypeCollection urlDetails = helper.getURLDetailsForSite(SiteCodeType.US);
			Assert.IsNotNull(urlDetails);
			URLDetailsType urlDetail = helper.getURLDetailsBySiteAndURLType(SiteCodeType.US, URLTypeCodeType.ViewUserURL);
			Assert.IsNotNull(urlDetail);
		}
	}
}
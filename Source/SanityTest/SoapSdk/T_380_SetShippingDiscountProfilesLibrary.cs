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
	public class T_380_SetShippingDiscountProfilesLibrary : SOAPTestBase
	{
		[Test]
		public void SetShippingDiscountProfilesLibrary() {
			SetShippingDiscountProfilesCall api = new SetShippingDiscountProfilesCall(apiContext);
			CalculatedHandlingDiscountType calcHandlingDiscount = new CalculatedHandlingDiscountType();
			calcHandlingDiscount.DiscountName = HandlingNameCodeType.IndividualHandlingFee;
			AmountType amount = new AmountType();
			amount.Value = 123.45;
			calcHandlingDiscount.OrderHandlingAmount = amount;
			FlatShippingDiscountType flatShippingDiscount = new FlatShippingDiscountType();
			flatShippingDiscount.DiscountName = DiscountNameCodeType.IndividualItemWeight;
			//
			CalculatedShippingDiscountType calcShippingDiscount = new CalculatedShippingDiscountType();
			calcShippingDiscount.DiscountName = DiscountNameCodeType.EachAdditionalAmount;
			PromotionalShippingDiscountDetailsType promoShippingDiscountDetails = new PromotionalShippingDiscountDetailsType();
			promoShippingDiscountDetails.DiscountName = DiscountNameCodeType.MaximumShippingCostPerOrder;

			try 
			{
                    
                    api.SetShippingDiscountProfiles(CurrencyCodeType.USD, CombinedPaymentPeriodCodeType.Days_14,
												    ModifyActionCodeType.Add, flatShippingDiscount, calcShippingDiscount,
												    calcHandlingDiscount, promoShippingDiscountDetails);
			} 
			catch(ApiException apie) 
			{
				Console.WriteLine("ApiException: " + apie.Message); 
			} 
			catch(SdkException sdke) 
			{
				Assert.Fail("SdkException: " + sdke.Message);
			}
			
		}
	}
}
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
using UnitTests.Helper;
#endregion

namespace AllTestsSuite.T_050_ItemTestsSuite
{
	[TestFixture]
	public class T_090_GetItemShippingLibrary : SOAPTestBase
	{
		[Test]
		public void GetItemShipping()
		{
			Assert.IsNotNull(TestData.NewItem, "Failed because no item available -- requires successful AddItem test");
			//
			GetItemShippingCall api = new GetItemShippingCall(this.apiContext);

			string itemID = TestData.NewItem.ItemID;
			string postalCode= "95125";
			int quantitySold=1;
			CountryCodeType countryCode=CountryCodeType.US;
			// Make API call.

			ShippingDetailsType shippingDetails = api.GetItemShipping(itemID,quantitySold,postalCode,countryCode);
			
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(shippingDetails);
		}

	}
}
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
	public class T_080_GetUserPreferencesLibrary : SOAPTestBase
	{
		[Test]
		public void GetUserPreferences()
		{
			GetUserPreferencesCall api = new GetUserPreferencesCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			api.ShowBidderNoticePreferences = true;
			api.ShowCombinedPaymentPreferences = true;
			api.ShowCrossPromotionPreferences = true;
			api.ShowEndOfAuctionEmailPreferences = true;
			api.ShowSellerFavoriteItemPreferences = true;
			api.ShowSellerPaymentPreferences = true;
			// Make API call.
			api.Execute();
			Assert.IsNotNull(api.ApiResponse.BidderNoticePreferences);
			Assert.IsNotNull(api.ApiResponse.CombinedPaymentPreferences);
			Assert.IsNotNull(api.ApiResponse.CrossPromotionPreferences);
			Assert.IsNotNull(api.ApiResponse.EndOfAuctionEmailPreferences);
			Assert.IsNotNull(api.ApiResponse.SellerPaymentPreferences);
			Assert.IsNotNull(api.ApiResponse.SellerPaymentPreferences);
			TestData.UserPreferencesResponse = (GetUserPreferencesResponseType)api.ApiResponse;
			
		}
	}
}
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

namespace AllTestsSuite.T_060_MyeBayTestsSuite
{
	[TestFixture]
	public class T_020_GetMyeBayBuyingLibrary : SOAPTestBase
	{
		[Test]
		public void GetMyeBayBuying()
		{
			GetMyeBayBuyingCall api = new GetMyeBayBuyingCall(this.apiContext);
			if (this.apiContext.SoapApiServerUrl.IndexOf("sandbox") != -1)
				return;
			GetMyeBayBuyingRequestType req = new GetMyeBayBuyingRequestType();
			api.ApiRequest = req;
			ItemListCustomizationType lc = new ItemListCustomizationType();
			lc.Include = true; lc.IncludeSpecified = true;
			lc.IncludeNotes = true; lc.IncludeNotesSpecified = true;
			lc.Sort = ItemSortTypeCodeType.EndTime;
			req.BestOfferList = lc;
			lc = new ItemListCustomizationType();
			lc.Include = true; lc.IncludeSpecified = true;
			lc.IncludeNotes = true; lc.IncludeNotesSpecified = true;
			lc.Sort = ItemSortTypeCodeType.BidCount;
			req.BidList = lc;
			lc = new ItemListCustomizationType();
			lc.Include = true; lc.IncludeSpecified = true;
			lc.IncludeNotes = true; lc.IncludeNotesSpecified = true;
			lc.Sort = ItemSortTypeCodeType.EndTime;
			req.LostList = lc;
			lc = new ItemListCustomizationType();
			lc.Include = true; lc.IncludeSpecified = true;
			lc.IncludeNotes = true; lc.IncludeNotesSpecified = true;
			lc.Sort = ItemSortTypeCodeType.Price;
			req.WonList = lc;
			MyeBaySelectionType selection = new MyeBaySelectionType();
			selection.Include = true; selection.IncludeSpecified = true;
			selection.Sort = SortOrderCodeType.Ascending;
			req.FavoriteSearches = selection;
			MyeBaySelectionType sellerSel = new MyeBaySelectionType();
			sellerSel.Include = true; sellerSel.IncludeSpecified = true;
			sellerSel.Sort = SortOrderCodeType.Ascending;
			req.FavoriteSellers = sellerSel;
			// Make API call.
			api.GetMyeBayBuying();
			GetMyeBayBuyingResponseType resp = api.ApiResponse;
			
		}
	}
}
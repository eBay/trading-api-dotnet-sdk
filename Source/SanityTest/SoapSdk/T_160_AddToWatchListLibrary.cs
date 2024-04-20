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
	public class T_160_AddToWatchListLibrary : SOAPTestBase
	{
		public static ItemType watchListItem = null;

		[Test]
		public void AddToWatchListFull()
		{
			watchListItem =	AddItem();
			Assert.IsNotNull(watchListItem, "Failed because failed to add item");
			Assert.AreNotEqual(watchListItem.ItemID,string.Empty);

			TestData.WatchedItem = watchListItem;
			AddToWatchListCall api = new AddToWatchListCall(this.apiContext);
			// Watch the first one.
			StringCollection ids = new StringCollection(); 
			ids.Add (watchListItem.ItemID);
			// Make API call.
			int num = api.AddToWatchList(ids, null);
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.Greater(num,0);
			Assert.Greater(api.ApiResponse.WatchListCount,0);
			Assert.Greater(api.ApiResponse.WatchListMaximum,0);
		}

		private ItemType  AddItem()
		{
			ItemType item = ItemHelper.BuildItem();
			// Execute the API.
			FeeTypeCollection fees;
			// AddItem
			AddItemCall addItem = new AddItemCall(this.apiContext);
			fees = addItem.AddItem(item);
			Assert.IsNotNull(fees);
			// Save the result.
			return item;
		}

	}
}
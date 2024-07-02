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

namespace AllTestsSuite.T_050_ItemTestsSuite
{
	[TestFixture]
	public class T_170_RemoveFromWatchListLibrary : SOAPTestBase
	{
		[Test]
		public void RemoveFromWatchList()
		{
			ItemType watchListItem = TestData.WatchedItem;
			Assert.IsNotNull(watchListItem, "Failed because no category listings available -- requires successful GetCategoryListings test");
			RemoveFromWatchListCall api = new RemoveFromWatchListCall(this.apiContext);
			// Remove first one.
//			api.RemoveAllItems = true;
			api.ItemIDList = new StringCollection();
			api.ItemIDList.Add(watchListItem.ItemID);
			// Make API call,the api call will return the rest watchList count.
			int result = api.RemoveFromWatchList(api.ItemIDList);
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			
		}
	}
}
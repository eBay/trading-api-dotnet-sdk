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
	public class T_210_GetSellerEventsLibrary : SOAPTestBase
	{
		[Test]
		public void GetSellerEvents()
		{
			Assert.IsNotNull(TestData.NewItem, "Failed because no item available -- requires successful AddItem test");
			GetSellerEventsCall api = new GetSellerEventsCall(this.apiContext);
			// Time filter
			System.DateTime calFrom = System.DateTime.Now.AddHours(-1);
			System.DateTime calTo = System.DateTime.Now.AddHours(1);
			TimeFilter tf = new TimeFilter(calFrom, calTo);
			api.EndTimeFilter = tf;
			// Make API call.
			api.Execute();
		}

		[Test]
		public void GetSellerEventsFull()
		{
			Assert.IsNotNull(TestData.NewItem2, "Failed because no item available -- requires successful AddItem test");
			GetSellerEventsCall api = new GetSellerEventsCall(this.apiContext);
			//specify more info
			string categoryID = TestData.NewItem2.PrimaryCategory.CategoryID;
			DateTime endTimeFrom = DateTime.Now.AddDays(-1);
			DateTime endTimeTo  = DateTime.Now.AddDays(1);

			//these properties how to use?
			bool IncludeWatchCount = true;
			PaginationType pagination =new PaginationType();
			pagination.PageNumber= 1;
			pagination.EntriesPerPage = 20;
			
			api.EndTimeFrom=endTimeFrom;
			api.EndTimeTo=endTimeTo;
			api.IncludeWatchCount = IncludeWatchCount;
			api.DetailLevelList = new DetailLevelCodeTypeCollection(new DetailLevelCodeType[]{DetailLevelCodeType.ReturnAll});
			api.Execute();
			
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			ItemTypeCollection events = api.ApiResponse.ItemArray;
			// Make sure it covers that item that I just added.
			ItemType foundEvent = findItem(events, TestData.NewItem.ItemID);
			Assert.IsNotNull(foundEvent);
		}

		static ItemType findItem(ItemTypeCollection items, String itemID)
		{
			for(int i = 0; i < items.Count; i++ )
			{
				if( items[i].ItemID.Equals(itemID) )
					return items[i];
			}
			return null;
		}
	}
}
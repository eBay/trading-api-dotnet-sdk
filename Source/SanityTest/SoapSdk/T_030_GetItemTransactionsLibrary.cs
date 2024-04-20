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

namespace AllTestsSuite.T_080_TransactionTestsSuite
{
	[TestFixture]
	public class T_030_GetItemTransactionsLibrary : SOAPTestBase
	{
		[Test]
		public void GetItemTransactions()
		{
			Assert.IsNotNull(TestData.NewItem, "Failed because no item available -- requires successful AddItem test");
			GetItemTransactionsCall api = new GetItemTransactionsCall(this.apiContext);
			api.ItemID = TestData.NewItem.ItemID;
			// Time filter
			System.DateTime calTo = DateTime.Now;
			System.DateTime calFrom = calTo.AddHours(-1);
			TimeFilter tf = new TimeFilter(calFrom, calTo);
			api.ModTimeFrom = calFrom;
			api.ModTimeTo = calTo;
			// Pagination
			PaginationType pt = new PaginationType();
			pt.EntriesPerPage = 100; pt.EntriesPerPageSpecified = true;
			pt.PageNumber = 1; pt.PageNumberSpecified = true;
			api.Pagination = pt;
			TransactionTypeCollection trans = api.GetItemTransactions(api.ItemID, api.ModTimeFrom, api.ModTimeTo);
			// NO transaction should be returned.
			Assert.IsTrue(trans == null || trans.Count == 0);
			
		}
	}
}
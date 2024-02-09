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
	public class T_130_GetAccountLibrary : SOAPTestBase
	{
		[Test]
		public void GetAccount()
		{
			GetAccountCall api = new GetAccountCall(this.apiContext);
			api.AccountHistorySelection = AccountHistorySelectionCodeType.LastInvoice;
			/*
			System.DateTime calTo = System.DateTime.Instance;
			System.DateTime calFrom = (System.DateTime)calTo.clone();
			calFrom.add(System.DateTime.DATE, -1);
			TimeFilter tf = new TimeFilter(calFrom, calTo);
			api.ViewPeriod = tf;
			*/
			// Pagination
			PaginationType pt = new PaginationType();
			pt.EntriesPerPage = 0; // No details will be returned.
			pt.EntriesPerPageSpecified = true;
			pt.PageNumber = 1;
			pt.PageNumberSpecified = true;
			api.Pagination = pt;
			ApiException gotException = null;
			try 
			{
				api.GetAccount(AccountHistorySelectionCodeType.LastInvoice);
			}
			catch (ApiException e)
			{
				gotException = e;
			}
			Assert.IsTrue(gotException == null || gotException.containsErrorCode("20154"));

		}
	}
}
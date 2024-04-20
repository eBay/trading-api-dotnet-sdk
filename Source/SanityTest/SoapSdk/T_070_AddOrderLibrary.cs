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
	public class T_070_AddOrderLibrary : SOAPTestBase
	{
		[Test]
		public void AddOrder()
		{
			Assert.IsNotNull(TestData.NewItem, "Failed because no item available -- requires successful AddItem test");
			// Make API call.
			ApiException gotException = null;
			try
			{
			AddOrderCall api = new AddOrderCall(this.apiContext);
			OrderType order = new OrderType();
			api.Order = order;
			TransactionType t1 = new TransactionType();
			t1.Item = TestData.NewItem;
			t1.TransactionID = "0";
			TransactionType t2 = new TransactionType();
			t2.Item = TestData.NewItem;
			t2.TransactionID = "0";
			TransactionTypeCollection tary = new TransactionTypeCollection();
				tary.Add(t1); tary.Add(t2);
			order.TransactionArray = tary;
			api.Order = order;
			// Make API call.
			/*AddOrderResponseType resp =*/ api.Execute();
			}
			catch(ApiException ex)
			{
				gotException = ex;
			}
			Assert.IsNotNull(gotException);
			
		}
	}
}
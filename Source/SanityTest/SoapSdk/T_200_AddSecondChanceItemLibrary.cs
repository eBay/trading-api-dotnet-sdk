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
	public class T_200_AddSecondChanceItemLibrary : SOAPTestBase
	{
		[Test]
		public void AddSecondChanceItem()
		{
			Assert.IsNotNull(TestData.NewItem, "Failed because no item available -- requires successful AddItem test");
			AddSecondChanceItemCall api = new AddSecondChanceItemCall(this.apiContext);
			api.Item = TestData.NewItem;
			api.RecipientBidderUserID = TestData.ApiUserID;
			// Make API call.
			ApiException gotException = null;
			// VerifyAddSecondChanceItem
			try
			{
			api.AddSecondChanceItem(api.Item, api.RecipientBidderUserID);
			}
			catch(ApiException ex)
			{
				gotException = ex;
			}
			Assert.IsNotNull(gotException);
			// AddSecondChanceItem
			gotException = null;
			try
			{
			api.Execute();
			}
			catch(ApiException ex)
			{
			gotException = ex;
			}
			Assert.IsNotNull(gotException);
			
		}
	}
}
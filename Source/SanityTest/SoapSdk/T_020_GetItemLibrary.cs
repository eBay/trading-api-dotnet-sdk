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
using AllTestsSuite.T_050_ItemTestsSuite;
#endregion


namespace AllTestsSuite.T_050_ItemTestsSuite
{

	[TestFixture]
	public class T_020_GetItemLibrary : SOAPTestBase
	{
		/// <summary>
		/// The input object "IncludeExpressRequirements" is no longer supported and will be ignored.
		/// </summary>
		[Test]
		public void GetItem()
		{
			bool includeCrossPromotion=true;
			bool includeItemSpecifics=true;
			bool includeTaxTable=false;
			bool includeWatchCount=true;
			ItemType item = null;

			Assert.IsNotNull(TestData.NewItem2, "Failed because no item available -- requires successful AddItem test");
			
			GetItemCall api=new GetItemCall(this.apiContext);
			
			api.IncludeCrossPromotion = includeCrossPromotion;
			api.IncludeItemSpecifics = includeItemSpecifics;
			api.IncludeTaxTable = includeTaxTable;
			api.IncludeWatchCount = includeWatchCount;
			api.ItemID = TestData.NewItem2.ItemID;
			api.Execute();

			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(api.ApiResponse.Item);
			item = api.ApiResponse.Item;
			Assert.IsTrue(item.ItemSpecifics.Count>0,"this is no item spcifics");
			Assert.IsTrue(item.WatchCount>=0);
		}

	}
}
		
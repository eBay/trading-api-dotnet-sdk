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
using System.Xml;
using System.IO;
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
	public class T_125_EndItemsLibrary: SOAPTestBase
	{
		[Test]
		public void EndItems()
		{
			Assert.IsNotNull(TestData.itemIds);
			Assert.IsTrue(TestData.itemIds.Count>0);

			EndItemsCall api = new EndItemsCall(this.apiContext);
			EndItemRequestContainerTypeCollection endItemsContainers=new EndItemRequestContainerTypeCollection();
			EndItemRequestContainerType container;
			foreach(String itemID in TestData.itemIds)
			{
				container=new EndItemRequestContainerType();
				container.ItemID=itemID;
				container.EndingReason=EndReasonCodeType.LostOrBroken;
				container.MessageID=Convert.ToString(endItemsContainers.Count+1);
				endItemsContainers.Add(container);
			}
			api.EndItemRequestContainerList=endItemsContainers;
			api.Execute();
			
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(api.EndItemResponseContainerList);
			Assert.IsTrue(api.EndItemResponseContainerList.Count==TestData.itemIds.Count);
			TestData.itemIds=null;
		}
	}
}

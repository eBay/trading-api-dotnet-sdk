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
	public class T_015_AddItemsLibrary : SOAPTestBase
	{
		//5 item categories only
		private readonly string[] CATEGORY_ID=new string[]{"50253","29792","279","279","14111"};

		[Test]
		public void AddItems()
		{
			if(TestData.itemIds!=null)
			{
				//call endItems call
				new T_125_EndItemsLibrary().EndItems();
			}
			TestData.itemIds=new StringCollection();

			AddItemsCall api=new AddItemsCall(this.apiContext);
			
			AddItemRequestContainerTypeCollection itemsContainers=new AddItemRequestContainerTypeCollection();
			//add five item one time,this should be successed
			foreach(string category in CATEGORY_ID)
			{
				addItemToContainer(itemsContainers,category);
			}
			api.AddItemRequestContainerList=itemsContainers;

			api.Execute();
			
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(api.AddItemResponseContainerList);
			Assert.AreEqual(api.AddItemResponseContainerList.Count,5);
			foreach(AddItemResponseContainerType containerType in api.AddItemResponseContainerList)
			{
				Assert.IsNotNull(containerType.Fees);
				Assert.IsTrue(containerType.Fees.Count>0);
				Assert.IsTrue(containerType.ItemID!=string.Empty);
				//cache item id
				TestData.itemIds.Add(containerType.ItemID);
			}
		}

		//add item to container with specific categoryid
		private void addItemToContainer(AddItemRequestContainerTypeCollection itemsContainers,string categoryID)
		{
			AddItemRequestContainerType itemContainer = new AddItemRequestContainerType();
			ItemType item = ItemHelper.BuildItem();
			item.PrimaryCategory.CategoryID=categoryID;
			itemContainer.Item=item;
			itemContainer.MessageID=Convert.ToString(itemsContainers.Count+1);
			itemsContainers.Add(itemContainer);
		}
	}
}

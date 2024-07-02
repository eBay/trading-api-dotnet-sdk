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
	public class T_030_AddToItemDescriptionLibrary : SOAPTestBase
	{
		[Test]
		public void AddToItemDescription()
		{
			string message,description,itemID,originalDes;
			ItemType item;
			bool isSuccess;

			Assert.IsNotNull(TestData.NewItem2, "Failed because no item available -- requires successful AddItem test");
			AddToItemDescriptionCall api = new AddToItemDescriptionCall(this.apiContext);
			itemID = TestData.NewItem2.ItemID;
			originalDes = TestData.NewItem2.Description;
			description="SDK appended text.";
			
			DetailLevelCodeTypeCollection detailLevel=new DetailLevelCodeTypeCollection();
			DetailLevelCodeType type=DetailLevelCodeType.ReturnAll;
			detailLevel.Add(type);
			api.DetailLevelList=detailLevel;
			// Make API call.
			api.AddToItemDescription(itemID,description);

			System.Threading.Thread.Sleep(3000);
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			isSuccess=ItemHelper.GetItem(TestData.NewItem2,this.apiContext,out message,out item);
			Assert.IsTrue(isSuccess,message);
			Assert.IsTrue(message==string.Empty,message);
			
			Assert.IsNotNull(item.Description,"the item description is null");
			Assert.Greater(item.Description.Length,originalDes.Length);
		}
	}
}
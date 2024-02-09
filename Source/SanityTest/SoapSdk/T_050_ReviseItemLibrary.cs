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
	public class T_050_ReviseItemLibrary : SOAPTestBase
	{
        [Test]
		public void ReviseItem()
		{
			ItemType itemTest = TestData.NewItem;
			Assert.IsNotNull(itemTest);
			//
			ReviseItemCall rviCall = new ReviseItemCall(this.apiContext);
			ItemType item = new ItemType();
			item.ItemID = itemTest.ItemID;
			item.StartPrice = new AmountType(); 
			item.StartPrice.Value = 2.89; 
			item.StartPrice.currencyID = CurrencyCodeType.USD;
			rviCall.Item = item;
			
            //verify fisrt
            rviCall.VerifyOnly = true;
            rviCall.Execute();
            FeeTypeCollection fees = rviCall.FeeList;

            //check whether the call is success.
            Assert.IsTrue(rviCall.AbstractResponse.Ack == AckCodeType.Success || rviCall.AbstractResponse.Ack == AckCodeType.Warning, "do not success!");
            // Call GetItem and then compare the startPrice.
            GetItemCall getItem1 = new GetItemCall(this.apiContext);
            DetailLevelCodeType[] detailLevels1 = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
            getItem1.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels1);
            ItemType returnedItem1 = getItem1.GetItem(itemTest.ItemID);
            Assert.AreNotEqual(returnedItem1.StartPrice.Value, item.StartPrice.Value);
            
            //revise
            rviCall.VerifyOnly = false;
            rviCall.Execute();
			// Let's wait for the server to "digest" the data.
			System.Threading.Thread.Sleep(1000);
			//check whether the call is success.
			Assert.IsTrue(rviCall.AbstractResponse.Ack==AckCodeType.Success || rviCall.AbstractResponse.Ack==AckCodeType.Warning,"do not success!");
			// Call GetItem and then compare the startPrice.
			GetItemCall getItem2 = new GetItemCall(this.apiContext);
			DetailLevelCodeType[] detailLevels2 = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			getItem2.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels2);
			ItemType returnedItem2 = getItem2.GetItem(itemTest.ItemID);
			Assert.AreEqual(returnedItem2.StartPrice.Value, item.StartPrice.Value);
			// Update itemTest.
			TestData.NewItem = returnedItem2;
			
		}

        [Test]
		public void ReviseFixedPriceItem()
		{
			ItemType itemTest = TestData.NewFixedPriceItem;
			Assert.IsNotNull(itemTest);
			//
			ReviseFixedPriceItemCall rviCall = new ReviseFixedPriceItemCall(this.apiContext);
			ItemType item = new ItemType();
			item.ItemID = itemTest.ItemID;
			item.StartPrice = new AmountType(); 
			item.StartPrice.Value = 2.89; 
			item.StartPrice.currencyID = CurrencyCodeType.USD;
			rviCall.Item = item;
			rviCall.Execute();
			// Let's wait for the server to "digest" the data.
			System.Threading.Thread.Sleep(1000);
			//check whether the call is success.
			Assert.IsTrue(rviCall.AbstractResponse.Ack==AckCodeType.Success || rviCall.AbstractResponse.Ack==AckCodeType.Warning,"do not success!");
			// Call GetItem and then compare the startPrice.
			GetItemCall getItem = new GetItemCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
																			   DetailLevelCodeType.ReturnAll
																		   };
			getItem.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			ItemType returnedItem = getItem.GetItem(itemTest.ItemID);
			Assert.AreEqual(returnedItem.StartPrice.Value, item.StartPrice.Value);
			// Update itemTest.
			TestData.NewFixedPriceItem = returnedItem;
			
		}

		[Test]
		public void ReviseItemFull()
		{
			bool isSuccess;
			string message;

			ItemType item = TestData.NewItem2,itemOut;
			Assert.IsNotNull(item);
			ReviseItemCall rviCall = new ReviseItemCall(this.apiContext);
			
			StringCollection stringCol=new StringCollection();
			stringCol.Add("item.ApplicationData");
			rviCall.DeletedFieldList=stringCol;
			
			item.StartPrice = new AmountType(); 
			item.StartPrice.Value = 2.89; 
			item.StartPrice.currencyID = CurrencyCodeType.USD;
			
			rviCall.Item = item;
			rviCall.Execute();
			// Let's wait for the server to "digest" the data.
			System.Threading.Thread.Sleep(1000);
			isSuccess=ItemHelper.GetItem(item,this.apiContext,out message,out itemOut);
			Assert.IsTrue(isSuccess,message);
			Assert.IsTrue(message==string.Empty,message);

			Assert.IsNull(itemOut.ApplicationData);
			Assert.AreEqual(itemOut.StartPrice.Value,item.StartPrice.Value);
		}
	}
}
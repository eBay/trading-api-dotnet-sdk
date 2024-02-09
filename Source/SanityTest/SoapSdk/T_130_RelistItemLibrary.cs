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
	public class T_130_RelistItemLibrary : SOAPTestBase
	{
		
		[Test]
		public void RelistItemFull()
		{

			Assert.IsNotNull(TestData.EndedItem2);
			
			TestData.EndedItem2.ApplicationData="this is new appilcation data which is specified by "+DateTime.Now.ToShortDateString();
			RelistItemCall rviCall = new RelistItemCall(this.apiContext);
			ItemType item = TestData.EndedItem2;
			item.CategoryMappingAllowed=true;
			item.CategoryMappingAllowed=true;

			rviCall.Item=item;
			StringCollection fields =new StringCollection();
			String field="Item.ApplicationData";
			fields.Add(field);
			rviCall.DeletedFieldList=fields;
			rviCall.Execute();

			//check whether the call is success.
			Assert.IsTrue(rviCall.AbstractResponse.Ack==AckCodeType.Success || rviCall.AbstractResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(rviCall.FeeList,"the Fees is null");
			/*
			foreach(FeeType fee in rviCall.FeeList)
			{
				isTherePropertyNull=ReflectHelper.IsProperteValueNotNull(fee,out nullPropertyNums,out nullPropertyNames);
				Assert.IsTrue(isTherePropertyNull,"there are" +nullPropertyNums.ToString()+ " properties value is null. (" +nullPropertyNames+ ")");
			}*/
			Assert.IsNotNull(rviCall.ItemID,"the ItemID is null");
			Assert.IsNotNull(rviCall.StartTime ,"the StartTime is null");

			//Assert.IsTrue(false,"NewItem:"+TestData.NewItem.ItemID+";EndedItem:"+TestData.EndedItem.ItemID+";NewItem2:"+TestData.NewItem2.ItemID+";EndedItem2:"+TestData.EndedItem2.ItemID);

		}

		//it cause the later unit test do not work
		[Test]
		public void RelistItem()
		{
			Assert.IsNotNull(TestData.EndedItem);
			//
			RelistItemCall rviCall = new RelistItemCall(this.apiContext);
			ItemType item = new ItemType();
			item.ItemID = TestData.EndedItem.ItemID;
			item.StartPrice = new AmountType(); 
			item.StartPrice.Value = 1.98; 
			item.StartPrice.currencyID = CurrencyCodeType.USD;
			//StringCollection modList = new StringCollection();
			//modList.Add("item.startPrice");
			//ModifiedFieldType[] mfList = eBayUtil.CopyModifiedList(modList, null);
			//rviCall.ModifiedFields = mfList;


            //verify first
            VerifyRelistItemCall vriCall = new VerifyRelistItemCall(this.apiContext);
            vriCall.Item = item;
            vriCall.Execute();
            FeeTypeCollection fees = vriCall.FeeList;
            Assert.IsNotNull(fees);

            GetItemCall getItem1 = new GetItemCall(this.apiContext);
            DetailLevelCodeType[] detailLevels1 = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
            getItem1.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels1);
            ItemType returnedItem1 = getItem1.GetItem(item.ItemID);
            // Make sure it's relisted.
            /*
            Assert.AreEqual(returnedItem.ListingDetails.getRelistedItemID().Value,
            TestData.EndedItem);
            */
            Assert.AreNotEqual(returnedItem1.StartPrice.Value, item.StartPrice.Value);

            
            rviCall.Item = item;
            rviCall.RelistItem(item);

			// Let's wait for the server to "digest" the data.
			System.Threading.Thread.Sleep(1000);
			// Call GetItem and then compare the startPrice.
			GetItemCall getItem2 = new GetItemCall(this.apiContext);
			DetailLevelCodeType[] detailLevels2 = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			getItem2.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels2);
			ItemType returnedItem2 = getItem2.GetItem(item.ItemID);
			// Make sure it's relisted.
			/*
			Assert.AreEqual(returnedItem.ListingDetails.getRelistedItemID().Value,
			TestData.EndedItem);
			*/
			Assert.AreEqual(returnedItem2.StartPrice.Value, item.StartPrice.Value);
			// End the new created item.
			EndItemCall api = new EndItemCall(this.apiContext);
			// Set the item to be ended.
			api.ItemID = item.ItemID;
			api.EndingReason = EndReasonCodeType.NotAvailable;
			api.Execute();
		
		}

		[Test]
		public void RelistFixedPriceItem()
		{
			Assert.IsNotNull(TestData.EndedFixedPriceItem);
			//
			RelistFixedPriceItemCall rviCall = new RelistFixedPriceItemCall(this.apiContext);
			ItemType item = new ItemType();
			item.ItemID = TestData.EndedFixedPriceItem.ItemID;
			item.StartPrice = new AmountType(); 
			item.StartPrice.Value = 1.98; 
			item.StartPrice.currencyID = CurrencyCodeType.USD;

			rviCall.RelistFixedPriceItem(item, null);
			// Let's wait for the server to "digest" the data.
			System.Threading.Thread.Sleep(1000);
			// Call GetItem and then compare the startPrice.
			GetItemCall getItem = new GetItemCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
																			   DetailLevelCodeType.ReturnAll
																		   };
			getItem.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			ItemType returnedItem = getItem.GetItem(item.ItemID);
			// Make sure it's relisted.
			/*
			Assert.AreEqual(returnedItem.ListingDetails.getRelistedItemID().Value,
			TestData.EndedItem);
			*/
			Assert.AreEqual(returnedItem.StartPrice.Value, item.StartPrice.Value);
			// End the new created item.
			EndItemCall api = new EndItemCall(this.apiContext);
			// Set the item to be ended.
			api.ItemID = item.ItemID;
			api.EndingReason = EndReasonCodeType.NotAvailable;
			api.Execute();
		
		}

	}
}
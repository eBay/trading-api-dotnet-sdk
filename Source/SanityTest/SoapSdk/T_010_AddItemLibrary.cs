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
using AllTestsSuite.T_050_ItemTestsSuite;

using UnitTests.Helper;
#endregion

namespace AllTestsSuite.T_050_ItemTestsSuite
{
	[TestFixture]
	public class T_010_AddItemLibrary : SOAPTestBase
	{
		// int categoryId=15825;// (Real Estate > Commercial) include required attributes
        private const int CATEGORYID = 104970;//the category which enable custom Item Specifics 104971 , 104970 , 104973
		private const string CATALOGENABLED="29792";//this category is catalog enabled.66694,66695,66696,2987,66700,279.
		private const int MEDIACATEGORYID=279;//the category is Books > Children's Books.
        private const string ISBN = "9780545010221";//ISBN-13,it is an ISBN number of Harry Potter and the Deathly Hallows
		private const string  PSPACATEGORYID="279";// It is an ProductSearchPageAvailable category id.
		private const int ISBN13ATTRIBUTEID=63739;// 63739 is the ISBN-13's attribute id.

		[Test]
		public void AddItem()
		{
			if(TestData.NewItem != null )
			{
				(new T_120_EndItemLibrary()).EndItem();
				TestData.NewItem = null;
			}
			ItemType item = ItemHelper.BuildItem();
			// Execute the API.
			FeeTypeCollection fees;
			// VerifyAddItem
			VerifyAddItemCall vi = new VerifyAddItemCall(this.apiContext);
			fees = vi.VerifyAddItem(item);
			Assert.IsNotNull(fees);
			// AddItem
			AddItemCall addItem = new AddItemCall(this.apiContext);
			fees = addItem.AddItem(item);
			Assert.IsNotNull(fees);
			// Save the result.
			TestData.NewItem = item;
		}

		[Test]
		public void AddFixedPriceItem()
		{
			if( TestData.NewFixedPriceItem != null )
			{
				string outMsg;
				ItemHelper.EndItem(this.apiContext, TestData.NewFixedPriceItem, out outMsg);
				TestData.NewFixedPriceItem = null;
			}
			ItemType item = ItemHelper.BuildItem();
			item.ListingType = ListingTypeCodeType.FixedPriceItem;
			// Execute the API.
			FeeTypeCollection fees;
			// VerifyAddItem
			VerifyAddFixedPriceItemCall vi = new VerifyAddFixedPriceItemCall(this.apiContext);
			fees = vi.VerifyAddFixedPriceItem(item);
			Assert.IsNotNull(fees);
			// AddItem
			AddFixedPriceItemCall ai = new AddFixedPriceItemCall(this.apiContext);
			fees = ai.AddFixedPriceItem(item);
			Assert.IsNotNull(fees);
			// Save the result.
			TestData.NewFixedPriceItem = item;
		}
		
		/// <summary>
		/// this item contains custom item specific and  item specific defined by ebay.
		/// </summary>
		[Test]
		public void AddItemFull()
		{
			if( TestData.NewItem2 != null )
			{
				(new T_120_EndItemLibrary()).EndItemFull();
				TestData.NewItem2 = null;
			}

			bool isSucess,isSupport = true;
			string message;
			ItemType item= ItemHelper.BuildItem();
			item.PrimaryCategory.CategoryID=CATEGORYID.ToString();
			//add Item AttributeSetArray
			//AttributeSetTypeCollection attributeSAT=GetAttributeSetCol(CATEGORYID,apiContext);
			//item.AttributeSetArray=attributeSAT;

			//check this category is custom specifics support
			FeatureIDCodeTypeCollection features=new FeatureIDCodeTypeCollection();
			FeatureIDCodeType feature=FeatureIDCodeType.ItemSpecificsEnabled;
			features.Add(feature);
			isSucess=UnitTests.Helper.CategoryHelper.IsSupportFeature(CATEGORYID,features,apiContext,out isSupport,out message);
            System.Console.WriteLine(message);
			Assert.IsTrue(isSucess,"there are some errors during checkging the CategoryFeatures");
            Assert.IsTrue(isSupport, "this category 104970 do not support the custom item specified any more!");
			//add CIS
			item.ItemSpecifics = getCIS();

			FeeTypeCollection fees;

			VerifyAddItemCall vi = new VerifyAddItemCall(apiContext);
			fees = vi.VerifyAddItem(item);
			Assert.IsNotNull(fees);

			AddItemCall addItemCall = new AddItemCall(apiContext);;
			fees = addItemCall.AddItem(item);
			//check whether the call is success.
			Assert.IsTrue(addItemCall.AbstractResponse.Ack==AckCodeType.Success || addItemCall.AbstractResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(fees);
			// Save the result.
			TestData.NewItem2 = item;
		}
		

		/// <summary>
		/// this item tests item external product id and pre-fill item information
		/// </summary>
		//[Test]
        //public void AddItemFull2()
        //{
        //    bool isSucess,isCatalogEnabled;
        //    string message;
        //    ItemType item= ItemHelper.BuildItem();
        //    //check whether the category is catalog enabled.
        //    isSucess=CategoryHelper.IsCatagoryEnabled(this.apiContext,MEDIACATEGORYID.ToString(),CategoryEnableCodeType.CatalogEnabled,out isCatalogEnabled,out message);
        //    Assert.IsTrue(isSucess,message);
        //    Assert.IsTrue(isCatalogEnabled,message);
        //    //modify item information approporiately.
        //    item.PrimaryCategory.CategoryID=MEDIACATEGORYID.ToString();
        //    item.Description = "check media category like books whether can be added by specifing ISBN,This is a test item created by eBay SDK SanityTest.";
        //    ExternalProductIDType isbn=new ExternalProductIDType();
        //    isbn.Type=ExternalProductCodeType.ISBN;
        //    isbn.Value=ISBN;
        //    //item.ExternalProductID=isbn;

        //    FeeTypeCollection fees;

        //    VerifyAddItemCall vi = new VerifyAddItemCall(apiContext);
        //    fees = vi.VerifyAddItem(item);
        //    Assert.IsNotNull(fees);

        //    AddItemCall addItemCall = new AddItemCall(apiContext);;
        //    fees = addItemCall.AddItem(item);
        //    //check whether the call is success.
        //    Assert.IsTrue(addItemCall.AbstractResponse.Ack==AckCodeType.Success || addItemCall.AbstractResponse.Ack==AckCodeType.Warning,"do not success!");
        //    Assert.IsTrue(item.ItemID!=string.Empty);
        //    Assert.IsNotNull(fees);

        //    //caution check
        //    ItemType itemOut;
        //    isSucess=ItemHelper.GetItem(item,this.apiContext,out message, out itemOut);
        //    Assert.IsTrue(isSucess,message);
        //    Assert.IsNotNull(itemOut,"Item is null");
        //    //Assert.Greater(itemOut.AttributeSetArray.Count,0);
        //    //Assert.Greater(itemOut.AttributeSetArray[0].Attribute.Count,0);
        //    //Assert.Greater(itemOut.AttributeSetArray[0].Attribute[0].Value.Count,0);
        //}
		
		/// <summary>
		/// add a item used for getHigherBiddersCall.
		/// </summary>
		/// 
		[Test]
		public void AddItemFull4()
		{
			if( TestData.ChineseAuctionItem != null )
			{
				(new T_120_EndItemLibrary()).EndChineseAuctionItem();
				TestData.ChineseAuctionItem = null;
			}
			ItemType item = addChineseAuctionItem();
			// Execute the API.
			FeeTypeCollection fees;
			// VerifyAddItem
			VerifyAddItemCall vi = new VerifyAddItemCall(this.apiContext);
			fees = vi.VerifyAddItem(item);
			Assert.IsNotNull(fees);
			// AddItem
			AddItemCall addItem = new AddItemCall(this.apiContext);
			fees = addItem.AddItem(item);
			Assert.IsNotNull(fees);
			// Save the result.
			TestData.ChineseAuctionItem = item;
		
		}

		/// <summary>
		/// ProPay
		/// </summary>
		[Test]
		public void AddItemProPay()
		{
			ItemType item = ItemHelper.BuildItem();
			item.PaymentMethods=new BuyerPaymentMethodCodeTypeCollection(new BuyerPaymentMethodCodeType[]{BuyerPaymentMethodCodeType.ProPay,BuyerPaymentMethodCodeType.PayPal});
			// Execute the API.
			FeeTypeCollection fees;
			// VerifyAddItem
			VerifyAddItemCall vi = new VerifyAddItemCall(this.apiContext);
			fees = vi.VerifyAddItem(item);
			Assert.IsNotNull(fees);
			// AddItem
			AddItemCall addItem = new AddItemCall(this.apiContext);
			fees = addItem.AddItem(item);
			Assert.IsNotNull(fees);
		}
		
		
		#region private methods
		
		/// <summary>
		/// add an item of chinese category.
		/// </summary>
		/// <returns></returns>
		private ItemType  addChineseAuctionItem()
		{
			ItemType item = ItemHelper.BuildItem();
			
			//modify the property to adapt the Chinese Type Item
			item.ListingType = ListingTypeCodeType.Chinese;
			item.Quantity=1;

			// Execute the API.
			FeeTypeCollection fees;
			// AddItem
			AddItemCall addItem = new AddItemCall(this.apiContext);
			fees = addItem.AddItem(item);
			Assert.IsNotNull(fees);
			// Save the result.
			return item;
		}
		
		/// <summary>
		/// Specify custom item specify
		/// </summary>
		/// <returns></returns>
		private NameValueListTypeCollection getCIS()
		{
			NameValueListTypeCollection list = new NameValueListTypeCollection();
			StringCollection tmp=new StringCollection();

			NameValueListType nameValue1=new NameValueListType();
			nameValue1.Name="test specifics(add name1)";
			tmp.Add("test specifics(add value1)");
			nameValue1.Value=tmp;

			NameValueListType nameValue2=new NameValueListType();
			nameValue2.Name="test specifics(add name2)";
			tmp.Clear();
			tmp.Add("test specifics(add value2)");
			nameValue2.Value=tmp;

			list.Add(nameValue1);
			list.Add(nameValue2);

			return list;
			
		}
		
		/// <summary>
		/// get all attributes from the charactersic with which the specific category is mapping
		/// </summary>
		/// <param name="categoryId"></param>
		/// <param name="apiContext"></param>
		/// <returns></returns>
        //private static AttributeSetTypeCollection GetAttributeSetCol(int categoryId,ApiContext apiContext)
        //{
        //    IAttributesMaster attributesMaster=new AttributesMaster();
        //    AttributeSetTypeCollection attributeSTC=new AttributeSetTypeCollection();
			
        //    attributesMaster.CategoryCSProvider=new CategoryCSDownloader(apiContext);
        //    attributesMaster.XmlProvider=new AttributesXmlDownloader(apiContext);
        //    //get the characteristic set id of the specified category
        //    IAttributeSetCollection attributeSetCol=attributesMaster.GetItemSpecificAttributeSetsForCategories(new Int32Collection(new int[]{categoryId}));
			
        //    Assert.IsNotNull(attributeSetCol);
			
        //    IAttributesXmlProvider iaxp=attributesMaster.XmlProvider;
        //    //download all attributes from ebay
        //    XmlDocument document=iaxp.DownloadXml();
        //    //write the memory xml to disk
        //    WriteXMLToDisk(document);
        //    AttributeSetTypeCollection attributeSetTypeCol=new AttributeSetTypeCollection();
        //    //get Required Item specifics by call getAttributesCS
        //    foreach(AttributeSet attributeSet in attributeSetCol)
        //    {
        //        AttributeSetType attributeST=new AttributeSetType();
        //        attributeST.attributeSetID=attributeSet.attributeSetID;
        //        String xpath="//Characteristics/CharacteristicsSet[@id='"+attributeSet.attributeSetID.ToString()+"']//CharacteristicsList//Initial//Attribute";
        //        XmlNodeList nodeList;
        //        XmlNode root = document.DocumentElement;
        //        nodeList=root.SelectNodes(xpath);
        //        AttributeTypeCollection attributeTypeCol=new AttributeTypeCollection();
        //        foreach (XmlNode node in nodeList)
        //        {
        //            AttributeType attributeT=new AttributeType();
        //            XmlAttributeCollection attributes=node.Attributes;
        //            Assert.IsNotNull(attributes);
        //            XmlNode idNode = attributes.GetNamedItem("id");
        //            attributeT.attributeID=int.Parse(idNode.Value);
        //            ValTypeCollection valTypeCol=getValue(node);
        //            if(valTypeCol==null)
        //            {
        //                System.Console.WriteLine("can not find any specific value!");
        //            }
        //            attributeT.Value=valTypeCol;
        //            attributeTypeCol.Add(attributeT);
        //        }

        //        attributeST.Attribute=attributeTypeCol;
        //        attributeSTC.Add(attributeST);
        //    }
        //    return attributeSTC;
        //}

		private static void WriteXMLToDisk(XmlDocument doc)
		{
			doc.Save("attributesMaster.xml");
		}


		#endregion

	}
}
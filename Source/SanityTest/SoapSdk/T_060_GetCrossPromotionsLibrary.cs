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
	public class T_060_GetCrossPromotionsLibrary : SOAPTestBase
	{
		[Test]
		public void GetCrossPromotions()
		{
            //Assert.IsNotNull(TestData.NewItem, "Failed because no item available -- requires successful AddItem test");
            //GetCrossPromotionsCall api = new GetCrossPromotionsCall(this.apiContext);
            //api.ItemID = TestData.NewItem.ItemID;
            //api.PromotionMethod = PromotionMethodCodeType.CrossSell;
            //api.PromotionViewMode = TradingRoleCodeType.Seller;
            //// Make API call.
            //api.Execute();
            //CrossPromotionsType cr = api.ApiResponse.CrossPromotion;
			
		}

		[Test]
		public void GetCrossPromotionsFull()
		{
            //Assert.IsNotNull(TestData.NewItem2, "Failed because no item available -- requires successful AddItem test");
            //GetCrossPromotionsCall api = new GetCrossPromotionsCall(this.apiContext);
            //api.ItemID = TestData.NewItem2.ItemID;
            //api.PromotionMethod = PromotionMethodCodeType.CrossSell;
            //api.PromotionViewMode = TradingRoleCodeType.Seller;
            //// Make API call.
            //api.Execute();
            ////check whether the call is success.
            //Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
            //CrossPromotionsType cr = api.ApiResponse.CrossPromotion;
			
            //Assert.IsNotNull(cr);
			
            ////the following item could not be null
            //Assert.IsNotNull(cr.ItemID);
            //if (cr.PromotedItem!=null&&cr.PromotedItem.Count>0)
            //{
            //    Assert.IsNotNull(cr.PromotedItem[0].ListingType);
            //    Assert.IsNotNull(cr.PromotedItem[0].Position);
            //    Assert.IsNotNull(cr.PromotedItem[0].PromotionDetails);
            //    if (cr.PromotedItem[0].PromotionDetails.Count>0)
            //    {
            //        Assert.IsNotNull(cr.PromotedItem[0].PromotionDetails[0].PromotionPrice); 
            //        Assert.IsNotNull(cr.PromotedItem[0].PromotionDetails[0].PromotionPriceType); 
            //    }
            //    Assert.IsNotNull(cr.PromotedItem[0].SelectionType);
            //    Assert.IsNotNull(cr.PromotedItem[0].TimeLeft);
            //    Assert.IsNotNull(cr.PromotedItem[0].Title);
            //}
            //Assert.IsNotNull(cr.PromotionMethod);
            //Assert.IsNotNull(cr.SellerID);
            //Assert.IsNotNull(cr.ShippingDiscount);
		}

	}
}
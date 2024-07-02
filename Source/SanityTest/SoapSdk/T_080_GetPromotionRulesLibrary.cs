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
	public class T_080_GetPromotionRulesLibrary : SOAPTestBase
	{
		[Test]
		public void GetPromotionRules()
		{
            //GetPromotionRulesCall api = new GetPromotionRulesCall(this.apiContext);
            //api.PromotionMethod = PromotionMethodCodeType.CrossSell;
            //api.StoreCategoryID = 1;
            //// Make API call.
            //PromotionRuleTypeCollection rules = api.GetPromotionRules(api.ItemID, api.PromotionMethod);
            //// Verify the result.
            //Assert.IsNotNull(rules);
		}

		
		[Test]
		public void GetPromotionRulesFull()
		{
            //bool isTherePropertyNull;
            //int nullPropertyNums;
            //string nullPropertyNames;

            //Assert.IsNotNull(TestData.NewItem2, "Failed because no item available -- requires successful AddItem test");
            //GetPromotionRulesCall api = new GetPromotionRulesCall(this.apiContext);
			
            //string itemID = TestData.NewItem2.ItemID;
            //PromotionMethodCodeType promotionType= PromotionMethodCodeType.UpSell;
            //PromotionRuleTypeCollection rules = api.GetPromotionRules(itemID,promotionType);
            ////check whether the call is success.
            //Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");

            //Assert.IsNotNull(rules);
            //if(rules!=null && rules.Count>0)
            //{
            //    isTherePropertyNull=ReflectHelper.IsProperteValueNotNull(rules[0],out nullPropertyNums,out nullPropertyNames);
            //    Assert.IsTrue(isTherePropertyNull,"there are" +nullPropertyNums.ToString()+ " properties(" +nullPropertyNames+ ")value is null");
            //}
			
		}
	}
}
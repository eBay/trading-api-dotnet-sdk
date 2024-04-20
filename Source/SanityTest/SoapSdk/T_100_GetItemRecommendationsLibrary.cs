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
	public class T_100_GetItemRecommendationsLibrary : SOAPTestBase
	{
		[Test]
		public void GetItemRecommendations()
		{
            //Assert.IsNotNull(TestData.NewItem, "Failed because no item available -- requires successful AddItem test");
            ////
            //GetItemRecommendationsCall api = new GetItemRecommendationsCall(this.apiContext);
            //GetRecommendationsRequestContainerType req = new GetRecommendationsRequestContainerType();
            //GetRecommendationsRequestContainerTypeCollection reqc = new GetRecommendationsRequestContainerTypeCollection();
            //reqc.Add(req);
            //req.Item = TestData.NewItem;
            //req.Item.LookupAttributeArray = null;
            //req.ListingFlow = ListingFlowCodeType.ReviseItem;
            //req.RecommendationEngine = new RecommendationEngineCodeTypeCollection();
            //req.RecommendationEngine.Add(RecommendationEngineCodeType.ListingAnalyzer);
            //// Make API call.
            //api.GetItemRecommendations(reqc);
            //GetRecommendationsResponseContainerTypeCollection resps = api.ApiResponse.GetRecommendationsResponseContainer;
            //Assert.IsNotNull(resps);
            //Assert.IsTrue(resps.Count > 0);
			
		}

		
		/// <summary>
		/// 
		/// </summary>
		[Test]
		public void GetItemRecommendationsFull()
		{
            //bool isTherePropertyNull;
            //int nullPropertyNums;
            //string nullPropertyNames;

            //Assert.IsNotNull(TestData.NewItem2, "Failed because no item available -- requires successful AddItem test");
            ////
            //GetItemRecommendationsCall api = new GetItemRecommendationsCall(this.apiContext);
            //GetRecommendationsRequestContainerType req = new GetRecommendationsRequestContainerType();
            //GetRecommendationsRequestContainerTypeCollection reqc = new GetRecommendationsRequestContainerTypeCollection();
            //reqc.Add(req);
            //req.Item = TestData.NewItem2;
            //req.ListingFlow=ListingFlowCodeType.AddItem;
            //req.RecommendationEngine = new RecommendationEngineCodeTypeCollection();
            //req.RecommendationEngine.Add(RecommendationEngineCodeType.ListingAnalyzer);
            //req.RecommendationEngine.Add(RecommendationEngineCodeType.SuggestedAttributes);
            //req.RecommendationEngine.Add(RecommendationEngineCodeType.ProductPricing);
            //req.Query="shoe";
            //GetRecommendationsResponseContainerTypeCollection resps = api.GetItemRecommendations(reqc);
			
            ////check whether the call is success.
            //Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
            //Assert.IsNotNull(resps);
            //Assert.IsTrue(resps.Count > 0);
            //if(resps[0].AttributeRecommendations!=null && 
            //    resps[0].AttributeRecommendations.AttributeSetArray!=null && 
            //    resps[0].AttributeRecommendations.AttributeSetArray.Count>0) 
            //{
            //    AttributeSetType attributeSet = resps[0].AttributeRecommendations.AttributeSetArray[0];

            //    isTherePropertyNull=ReflectHelper.IsProperteValueNotNull(attributeSet,out nullPropertyNums,out nullPropertyNames);
            //    Assert.IsTrue(isTherePropertyNull,"there are" +nullPropertyNums.ToString()+ " properties value is null. (" +nullPropertyNames+ ")");
				
            //    if(attributeSet.Attribute!=null && attributeSet.Attribute.Count>0)
            //    {
            //        AttributeType attribute = attributeSet.Attribute[0];

            //        isTherePropertyNull=ReflectHelper.IsProperteValueNotNull(attribute,out nullPropertyNums,out nullPropertyNames);
            //        Assert.IsTrue(isTherePropertyNull,"there are" +nullPropertyNums.ToString()+ " properties value is null. (" +nullPropertyNames+ ")");
            //    }
            //}
		}

	}
}
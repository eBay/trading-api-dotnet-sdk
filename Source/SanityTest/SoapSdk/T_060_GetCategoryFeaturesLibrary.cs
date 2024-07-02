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
#endregion

namespace AllTestsSuite.T_030_CategoryTestsSuite
{
	[TestFixture]
	public class T_060_GetCategoryFeaturesLibrary : SOAPTestBase
	{
		private const string COOKBOOKSCATEGORYID = "11104";

		[Test]
		public void GetCategoryFeatures()
		{
			GetCategoryFeaturesCall api = new GetCategoryFeaturesCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			api.LevelLimit = 1;
			api.ViewAllNodes = true;
			// Make API call.
			CategoryFeatureTypeCollection features = api.GetCategoryFeatures();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success,"the call is failure!");
			Assert.IsNotNull(features);
			Assert.IsTrue(features.Count > 0);
			Assert.IsNotNull(api.ApiResponse.CategoryVersion);

			// Testing GetCategoryFeaturesHelper
			this.apiContext.Site = SiteCodeType.Austria;
			GetCategoryFeaturesHelper helper = new GetCategoryFeaturesHelper(this.apiContext);
			Assert.IsTrue(helper.hasCategoryFeatures(SiteCodeType.Austria));
			this.apiContext.Site = SiteCodeType.China;
			helper.loadCategoryFeatures(this.apiContext);
			Assert.IsTrue(helper.hasCategoryFeatures(SiteCodeType.Austria));
			Assert.IsTrue(helper.hasCategoryFeatures(SiteCodeType.China));
			this.apiContext.Site = SiteCodeType.US;
			helper.loadCategoryFeatures(this.apiContext);
			Assert.IsTrue(helper.hasCategoryFeatures(SiteCodeType.Austria));
			Assert.IsTrue(helper.hasCategoryFeatures(SiteCodeType.China));
			Assert.IsTrue(helper.hasCategoryFeatures(SiteCodeType.US));
			//
			FeatureDefinitionsType USFeatures = helper.getSiteFeatures(SiteCodeType.US);
			Assert.IsNotNull(USFeatures);
			System.Console.WriteLine(USFeatures.ToString());
		}

		/// <summary>
		/// only return summary info
		/// </summary>
		[Test]
		public void GetCategoryFeaturesFull()
		{
			GetCategoryFeaturesCall api = new GetCategoryFeaturesCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnSummary
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			api.Execute();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			Assert.IsNotNull(api.ApiResponse.FeatureDefinitions);
		}

		/// <summary>
		/// return the specific features for specific category
		/// </summary>
		[Test]
		public void GetCategoryFeaturesFull2()
		{
			GetCategoryFeaturesCall api = new GetCategoryFeaturesCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			FeatureIDCodeTypeCollection features=new FeatureIDCodeTypeCollection();
			FeatureIDCodeType feature=FeatureIDCodeType.BestOfferEnabled;
			features.Add(feature);
			api.FeatureIDList=features;
			api.CategoryID=COOKBOOKSCATEGORYID;
			api.Execute();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack == AckCodeType.Success || api.ApiResponse.Ack == AckCodeType.Warning,"the call is failure!");
			Assert.IsNotNull(api.ApiResponse.FeatureDefinitions);
			Assert.AreEqual(api.ApiResponse.Category[0].CategoryID,COOKBOOKSCATEGORYID);
		}

	}
}
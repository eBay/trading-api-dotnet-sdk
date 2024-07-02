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
	public class T_020_GetCategoriesLibrary : SOAPTestBase
	{
		[Test]
		public void GetCategories()
		{
			bool isValid=true;
			GetCategoriesCall api = new GetCategoriesCall(this.apiContext);
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
			api.LevelLimit = 1;
			api.ViewAllNodes = true;
			api.Timeout = 300000;
			//
			CategoryTypeCollection cats = api.GetCategories();
			//check whether the call is success.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
			Assert.IsNotNull(cats);
			Assert.IsTrue(cats.Count > 0);

			//the return category's level must be 1.
			foreach(CategoryType category in cats)
			{
				if(category.CategoryLevel!=1)
				{
					isValid=false;
					break;
				}
			}

			Assert.IsTrue(isValid,"the return value is not valid");
			// Save the result.
			TestData.Categories = cats;
			
		}

	}
}
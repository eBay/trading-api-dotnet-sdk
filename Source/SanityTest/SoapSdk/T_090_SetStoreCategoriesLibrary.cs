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

namespace AllTestsSuite.T_100_StoreTestsSuite
{
	[TestFixture]
	public class T_090_SetStoreCategoriesLibrary : SOAPTestBase
	{
		[Test]
		public void SetStoreCategories()
		{
			// Skip if the user is not store enabled.
			if (TestData.Store == null)
			return;
			SetStoreCategoriesCall api = new SetStoreCategoriesCall(this.apiContext);
			// Build the StoreType object.
			StoreType st = new StoreType();
			st.Description = TestData.Store.Description;
			st.Logo = TestData.Store.Logo;
			st.MerchDisplay = TestData.Store.MerchDisplay;
			st.Name = TestData.Store.Name;
			api.Action = StoreCategoryUpdateActionCodeType.Add;
			api.DestinationParentCategoryID = 1234;
			api.ItemDestinationCategoryID = 4321;
			StoreCustomCategoryTypeCollection catArray = new StoreCustomCategoryTypeCollection();
			api.StoreCategoryList = catArray;
			StoreCustomCategoryType cat = new StoreCustomCategoryType();
			catArray.Add(cat);
			cat.CategoryID = 102;
			cat.Name = "TestStoreCategory";
			// Make API call.
			ApiException gotException = null;
			// Negative test.
			try 
			{
				api.Execute();
			} 
			catch (ApiException ex) 
			{
				gotException = ex;
			}
			Assert.IsNotNull(gotException);		
		}
	}
}
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

using System;
using System.Collections;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Call;
using Samples.Helper.Cache;

namespace SampleShippingServiceApplication
{
	/// <summary>
	/// Summary description for CategoryFeatureManager.
	/// </summary>
	public class CategoryFeatureManager
	{
		public CategoryFeatureManager()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private const int TABLE_SIZE = 30000;
		//catid -> category
		private static Hashtable catsTable = new Hashtable(TABLE_SIZE);
		//catid -> category featrue
		private static Hashtable cfsTable = new Hashtable(TABLE_SIZE);
		private static SiteDefaultsType siteDefaults;
		private static FeatureDefinitionsType featureDefinition;

		public static void GetAllCategoriesFeatures(ApiContext context)
		{
			FeaturesDownloader downloader = new FeaturesDownloader(context);
			GetCategoryFeaturesResponseType resp = downloader.GetCategoryFeatures();
			CategoryFeatureTypeCollection cfCol = resp.Category;
				
			//cache the features in hashtable	
			foreach(CategoryFeatureType cf in cfCol)
			{
				cfsTable.Add(cf.CategoryID, cf);
			}
			
			//cache site defaults
			siteDefaults = resp.SiteDefaults;
			//cahce feature definitions
			featureDefinition = resp.FeatureDefinitions;
		}


		//get eBay Details
		public static GeteBayDetailsResponseType GetShippingServices(ApiContext apiContext)
		{
				GeteBayDetailsCall api = new GeteBayDetailsCall(apiContext);
				DetailNameCodeTypeCollection names=new DetailNameCodeTypeCollection();
				names.Add(DetailNameCodeType.ShippingLocationDetails);
				names.Add(DetailNameCodeType.ShippingServiceDetails);
				api.GeteBayDetails(null);
				return api.ApiResponse;
		}

		//get all categories
		public static CategoryTypeCollection GetAllCategories(ApiContext apiContext) 
		{
			CategoriesDownloader downloader = new CategoriesDownloader(apiContext);
			CategoryTypeCollection catsCol = downloader.GetAllCategories();
			
			//cache the categories in hashtable
			foreach(CategoryType cat in catsCol)
			{
				catsTable.Add(cat.CategoryID, cat);
			}
			
			return catsCol;
		}

		//sort categories in ascending order and remove nonleaf category
		public static CategoryTypeCollection SortCategories(CategoryTypeCollection catsCol)
		{
			SortedList catSL = new SortedList();
			foreach(CategoryType cat in catsCol)
			{
				if (cat.LeafCategory) //we only care leaf categories
				{
					catSL.Add(int.Parse(cat.CategoryID), cat);
				}
			}
			CategoryTypeCollection sortedCatCol = new CategoryTypeCollection();
			for(int i = 0; i < catSL.Count; i++)
			{
				sortedCatCol.Add((CategoryType)catSL.GetByIndex(i));
			}
			return sortedCatCol;
		}

		//recursively find out the payment metheds for a given category
		private static BuyerPaymentMethodCodeTypeCollection getPaymentMethods(string catId)
		{
			if(cfsTable.ContainsKey(catId))
			{
				CategoryFeatureType cf = (CategoryFeatureType)cfsTable[catId];
				if (cf.PaymentMethod != null)
				{
					return cf.PaymentMethod;
				}
			}

			CategoryType cat = (CategoryType)catsTable[catId];
			//if we reach top level, return null
			if (cat.CategoryLevel == 1)
			{
				return null;
			}

			//check parent category
			return getPaymentMethods(cat.CategoryParentID[0]);
			
		}

		//recursively find out the listing duration reference type for a given category
		private static ListingDurationReferenceTypeCollection getListingTypes(string catId)
		{
			if (cfsTable.ContainsKey(catId))
			{
				CategoryFeatureType cf = cfsTable[catId] as CategoryFeatureType;
				if (cf.ListingDuration != null) 
				{
					return cf.ListingDuration;
				}
			}

			CategoryType cat = catsTable[catId] as CategoryType;
			//if we reach top level, return null
			if (cat.CategoryLevel == 1)
			{
				return null;
			}

			//check parent category
			return getListingTypes(cat.CategoryParentID[0]);
		}

		/// <summary>
		/// construct a mapping between listing type and listing duration
		/// </summary>
		/// <param name="listingTypes"></param>
		/// <param name="listingDurations"></param>
		/// <returns>Hashtable</returns>
		private static Hashtable constructListingTypeDurationMapping(ListingDurationReferenceTypeCollection listingTypes,ListingDurationDefinitionsType listingDurations)
		{
			Hashtable listingTypeDurationMap = new Hashtable();
			eBay.Service.Core.Soap.StringCollection listingDuration = null;

			foreach (ListingDurationReferenceType listingType in listingTypes)
			{
				string key =listingType.type.ToString();
				//iterate listingDuration collection to find specific listingDuration whose durationSetID equals listingType id
				foreach (ListingDurationDefinitionType definition in listingDurations.ListingDuration)
				{
					if(definition.durationSetID.Equals(listingType.Value))
					{
						listingDuration=definition.Duration;
					}
				}

				listingTypeDurationMap.Add(key,listingDuration);
			}

			return listingTypeDurationMap;
		}

		public static Hashtable getListingType2DurationTable(String catid)
		{
			//listing types, recursively search
			ListingDurationReferenceTypeCollection listingTypes = getListingTypes(catid);
			if (listingTypes == null || listingTypes.Count == 0)//get site defaults
			{
				listingTypes = siteDefaults.ListingDuration;
			}
			//listing duration definitions
			ListingDurationDefinitionsType listingDurations=featureDefinition.ListingDurations;

			return constructListingTypeDurationMapping(listingTypes, listingDurations);
		}

		public static BuyerPaymentMethodCodeTypeCollection getCatPaymentMethods(String catid)
		{
			//payment methods, recursively search
			BuyerPaymentMethodCodeTypeCollection paymentMethods = getPaymentMethods(catid);
			if (paymentMethods == null || paymentMethods.Count == 0)//get site defautls
			{
				paymentMethods = siteDefaults.PaymentMethod;
			}
			return paymentMethods;
		}

	}
}

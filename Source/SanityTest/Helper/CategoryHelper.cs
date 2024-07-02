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
using AllTestsSuite;
#endregion


namespace UnitTests.Helper
{
	/// <summary>
	/// Summary description for CategoryHelper.
	/// </summary>
	public class CategoryHelper: SOAPTestBase
	{

		#region private variable
		
		/// <summary>
		/// store all categories
		/// </summary>
		private static CategoryTypeCollection allCategories;

		#endregion

		#region constructors

		public CategoryHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

		#region public methods

		/// <summary>
		///return leaf category objects of specific number
		/// </summary>
		/// <param name="number">how many leaf categories you wanna get.</param>
		/// <param name="category"></param>
		/// <param name="apiContext"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static bool GetLeafCategory(int number,out CategoryTypeCollection categories,ApiContext apiContext,out string message)
		{
			CategoryTypeCollection categoryTypeCollection;
			categories=new CategoryTypeCollection();
			if(number<=0)
			{
				number=1;
			}

			if(getAllCategories(apiContext,out categoryTypeCollection,out message))
			{
				foreach(CategoryType category in categoryTypeCollection)
				{
					if(category.LeafCategory==true)
					{
						categories.Add(category);

						if(categories.Count==number)
						{
							break;
						}
					}
				}

				return true;
			}

			return false;
		}
		
		/// <summary>
		/// check wheather an category is a leaf category. if the isLeaf returns true, the category is a leaf category.
		/// if the category do not exist or is not a leaf category, the return value is false.
		/// </summary>
		/// <param name="categoryID"></param>
		/// <param name="isSuccess"></param>
		/// <returns></returns>
		public static bool IsLeafCategory(int categoryID,ApiContext apiContext,out bool isLeaf,out string message)
		{
			CategoryTypeCollection categoryTypeCollection;
			isLeaf=false;

			//if execute success
			if(getAllSubCategories(categoryID,apiContext,out categoryTypeCollection,out message))
			{
				foreach(CategoryType category in categoryTypeCollection)
				{
					if(categoryID==int.Parse(category.CategoryID))
					{
						if(category.LeafCategory==true)
						{
							isLeaf=true;
						}
					}
				}

				return true;
			}

			return false;
		}

		/// <summary>
		/// get all categories
		/// </summary>
		/// <param name="apiContext"></param>
		/// <param name="categoryTypeCollection"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static bool GetAllCategories(ApiContext apiContext,out CategoryTypeCollection categoryTypeCollection,out string message)
		{
			return getAllCategories(apiContext,out categoryTypeCollection,out message);
		}

		public static bool GetCISSupportLeafCategory(int number,out CategoryTypeCollection categories,ApiContext apiContext,out string message)
		{
			CategoryTypeCollection categoryTypeCollection;
			categories=new CategoryTypeCollection();
			bool isSuccess,isSupport;
			if(number<=0)
			{
				number=1;
			}

			if(getAllCategories(apiContext,out categoryTypeCollection,out message))
			{
				foreach(CategoryType category in categoryTypeCollection)
				{
					if(category.LeafCategory==true)
					{
						//check whether the category support the ItemSpecificsEnabled;
						FeatureIDCodeTypeCollection features=new FeatureIDCodeTypeCollection();
						FeatureIDCodeType type=FeatureIDCodeType.ItemSpecificsEnabled;
						features.Add(type);
						isSuccess=isSupportFeature(int.Parse(category.CategoryID),features,apiContext,out isSupport,out message);
						if(!isSuccess)
						{
							return false;
						}
						
						if(isSupport)
						{
							categories.Add(category);

							if(categories.Count==number)
							{
								break;
							}
						}
					}//end if
				}//end foreach

				return true;
			}

			return false;
		}

		
		/// <summary>
		/// whether support the specific features
		/// </summary>
		/// <param name="categoryID"></param>
		/// <param name="features"></param>
		/// <param name="apiContext"></param>
		/// <returns></returns>
		public static bool IsSupportFeature(int categoryID,FeatureIDCodeTypeCollection features,ApiContext apiContext,out bool isSupport,out string message)
		{
			return isSupportFeature(categoryID,features,apiContext,out isSupport,out message);
		}

		
		/// <summary>
		/// get some items which supports the ad format category, you can specify the number
		/// </summary>
		/// <param name="apiContext"></param>
		/// <param name="num"></param>
		/// <param name="categoryTypeCollection"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static  bool GetAdFormatCategory(ApiContext apiContext,int num,out CategoryTypeCollection categoryTypeCollection,out string message)
		{
			message=string.Empty;
			CategoryTypeCollection tmpCategories;
			categoryTypeCollection = null;
			num=(num<=0)?1:num;

			GetCategoryFeaturesCall api = new GetCategoryFeaturesCall(apiContext);
			setBasicInfo(ref api);
			//spcify category id
			if(!getAllCategories(apiContext,out tmpCategories, out message))
			{
				message=message+",203";
				return false;
			}
			
			FeatureIDCodeTypeCollection features=new FeatureIDCodeTypeCollection();
			FeatureIDCodeType type=FeatureIDCodeType.AdFormatEnabled;
			features.Add(type);

			string categoryID=string.Empty;

			foreach(CategoryType category in tmpCategories)
			{
				if(category.LeafCategory == true)
				{
					categoryID=category.CategoryID;
					try
					{
						//call
						CategoryFeatureTypeCollection featureTypes = api.GetCategoryFeatures(categoryID,10,true,features,true);
					
						if(featureTypes!=null&&featureTypes.Count>0)
						{
							if(featureTypes[0].AdFormatEnabled==AdFormatEnabledCodeType.Enabled)
							{
								categoryTypeCollection.Add(category);
							}

							if(categoryTypeCollection.Count>=num)
							{
								break;
							}
						}

					}
					catch(Exception e)
					{
						message=e.Message+",204";
						return false;
					}
				}	
			}
			
			return true;
		}


		/// <summary>
		/// check whether a category id is valid.
		/// </summary>
		/// <param name="apiContext"></param>
		/// <param name="isValid"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		public static bool IsValidCategory(ApiContext apiContext,ref string categoryID,out bool isValid,out string message)
		{
			return isValidCategory(apiContext,ref categoryID,out isValid,out message);
		}
		#endregion

		#region private methods
		/// <summary>
		/// return all categories on us sit
		/// </summary>
		/// <param name="categoryTypeCollection"></param>
		/// <returns></returns>
		private static  bool getAllCategories(ApiContext apiContext,out CategoryTypeCollection categoryTypeCollection,out string message)
		{
			//basic init
			categoryTypeCollection=new CategoryTypeCollection();
			GetCategoriesCall api = new GetCategoriesCall(apiContext);
			setBasicInfo(ref api);
			message=string.Empty;
			
			try
			{
				if(allCategories==null)
				{
					//call
					categoryTypeCollection = api.GetCategories();
					//cach all categories
					allCategories=categoryTypeCollection;
				}
				else
				{
					categoryTypeCollection=allCategories;
				}
			}
			catch(Exception e)
			{
				message=e.Message;
				return false;
			}

			return true;
		}
		
		
		
		/// <summary>
		/// return the all leaf categories
		/// </summary>
		/// <param name="parentCategoryID"></param>
		/// <param name="categoryTypeCollection"></param>
		/// <returns></returns>
		private static  bool getAllSubCategories(int parentCategoryID,ApiContext apiContext,out CategoryTypeCollection categoryTypeCollection,out string message)
		{
			//basic init
			GetCategoriesCall api = new GetCategoriesCall(apiContext);
			setBasicInfo(ref api);
			//return all childs categories
			StringCollection parent=new StringCollection();
			parent.Add(parentCategoryID.ToString());
			api.CategoryParent=parent;
			api.ViewAllNodes=true;
			api.LevelLimit=10;
			categoryTypeCollection=null;
			message=string.Empty;
			
			try
			{
				//call
				categoryTypeCollection = api.GetCategories();
			}
			catch(Exception e)
			{
				message=e.Message;
				return false;
			}
			
			return true;
		}

		/// <summary>
		/// just support custom item specific. it would be enchance later.
		/// </summary>
		/// <param name="categoryID"></param>
		/// <param name="ids"></param>
		/// <returns></returns>
		private static bool isSupportFeature(int categoryID,FeatureIDCodeTypeCollection features,ApiContext apiContext,out bool isSupport,out string message)
		{
			isSupport=true;
			message=string.Empty;

			GetCategoryFeaturesCall api = new GetCategoryFeaturesCall(apiContext);
			setBasicInfo(ref api);
			//spcify category id
			api.CategoryID=categoryID.ToString();
			api.FeatureIDList = features;
			try
			{
				//call
				CategoryFeatureTypeCollection featureTypes = api.GetCategoryFeatures();

                SiteDefaultsType siteDefaultsType = api.SiteDefaults;

				if(featureTypes!=null&&featureTypes.Count>0)
				{
					foreach(FeatureIDCodeType feature in features)
					{
						if(feature.ToString()=="ItemSpecificsEnabled")
						{
                            // Check if the specified category is ItemspecificEnabled,
                            // Check for ItemspecificEnabled element in the features level
                            // If the tag does not occur then fetch it from site defaults
                            if (!featureTypes[0].ItemSpecificsEnabledSpecified)
                            {
                                if (siteDefaultsType.ItemSpecificsEnabledSpecified)
                                {
                                    if (siteDefaultsType.ItemSpecificsEnabled != ItemSpecificsEnabledCodeType.Enabled)
                                    {
                                        isSupport = false;
                                        message = "ItemSpecificsEnabled is not supported!";
                                        break;
                                    }
                                }
                            } else if (featureTypes[0].ItemSpecificsEnabled!=ItemSpecificsEnabledCodeType.Enabled)
							{
								isSupport=false;
								message="ItemSpecificsEnabled is not supported!";
								break;
							}
						}

						if(feature.ToString()=="AdFormatEnabled")
						{
							if(featureTypes[0].AdFormatEnabled!=AdFormatEnabledCodeType.Enabled)
							{
								isSupport=false;
								message="AdFormatEnabled is not supported!";
								break;
							}
						}

					}
				}
			}
			catch(Exception e)
			{
				message=e.Message;
				return false;
			}
				
			return true;
		}


		/// <summary>
		/// get a number of CatalogEnabled Categories.
		/// </summary>
		/// <param name="number"></param>
		/// <param name="apiContext"></param>
		/// <param name="categories"></param>
		/// <param name="message"></param>
		/// <returns></returns>
        //private static bool getCatagoryEnabledCategory(int number,ApiContext apiContext,CategoryEnableCodeType enableType,out CategoryTypeCollection categories,out string message)
        //{
        //    CategoryTypeCollection categoryTypeCollection;
        //    categories=new CategoryTypeCollection();
        //    bool isSuccess,isCatalogEnable;

        //    if(number<=0)
        //    {
        //        number=1;
        //    }

        //    if(getAllCategories(apiContext,out categoryTypeCollection,out message))
        //    {
        //        foreach(CategoryType category in categoryTypeCollection)
        //        {
        //            if(category.LeafCategory)
        //            {
        //                isSuccess = isCatagoryEnabled(apiContext,category.CategoryID,enableType,out isCatalogEnable,out message);
        //                if(isSuccess)
        //                {

        //                    if(isCatalogEnable)
        //                    {
        //                        categories.Add(category);
        //                    }

        //                    if(categories.Count>=number)
        //                    {
        //                        return true;
        //                    }
        //                }
        //                else
        //                {
        //                    message=message+";get features failure!";
        //                    return false;
        //                }
        //            }
        //        }//end foreach

        //        return true;
        //    }

        //    return false;
        //}
		
		/// <summary>
		/// check an category whether it is catalog-enabled.
		/// </summary>
		/// <param name="apiContext"></param>
		/// <param name="categorid"></param>
		/// <param name="isCatalogEnable"></param>
		/// <param name="message"></param>
		/// <returns></returns>
        //private static bool isCatagoryEnabled(ApiContext apiContext,string categorid,CategoryEnableCodeType enableType,out bool isEnable,out string message)
        //{
        //    CategoryTypeCollection categories;
        //    isEnable=false;
        //    message=string.Empty;

        //    GetCategory2CSCall api =new GetCategory2CSCall(apiContext);
        //    //GetCategoryFeaturesCall api = new GetCategoryFeaturesCall(apiContext);
        //    DetailLevelCodeType detaillevel= DetailLevelCodeType.ReturnAll;
        //    api.DetailLevelList=new DetailLevelCodeTypeCollection(new DetailLevelCodeType[]{detaillevel});
        //    api.CategoryID=categorid;
        //    try
        //    {
        //        categories = api.GetCategoryFeatures();
        //        foreach(CategoryType category in categories)
        //        {
        //            if(string.Compare(category.CategoryID,categorid,false)==0)
        //            {
        //                if(enableType==CategoryEnableCodeType.CatalogEnabled)
        //                {
        //                    isEnable=category.CatalogEnabled;
        //                    break;
        //                }
        //                else if(enableType==CategoryEnableCodeType.ProductSearchPageAvailable)
        //                {
        //                    isEnable=category.ProductSearchPageAvailable;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception e)
        //    {
        //        message=e.Message;
        //        return false;
        //    }
			
        //    return true;
        //}

		
		/// <summary>
		/// check whether a category id is valid.
		/// </summary>
		/// <param name="apiContext"></param>
		/// <param name="isValid"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private static bool isValidCategory(ApiContext apiContext,ref string categoryID,out bool isValid,out string message)
		{
			CategoryTypeCollection categories=null;
			message=string.Empty;
			isValid=false;

			GetCategoriesCall api=new GetCategoriesCall(apiContext);
			setBasicInfo(ref api);
			StringCollection parents=new StringCollection();
			parents.Add(categoryID);
			api.CategoryParent=parents;
			
			try
			{
				categories=api.GetCategories();

				if(categories!=null&&categories.Count>0)
				{
					foreach(CategoryType category in categories)
					{
						if(string.Compare(category.CategoryID,categoryID,true)==0)
						{
							isValid=true;
							break;
						}
					}
				}
			}
			catch(Exception e)
			{
				message=e.Message;
				return false;
			}

			return true;
		}

		/// <summary>
		/// init the call
		/// </summary>
		/// <param name="api"></param>
		private static  void setBasicInfo(ref GetCategoriesCall api)
		{
			//set basic info to the call
			api.CategorySiteID=Convert.ToString(0);
			DetailLevelCodeTypeCollection detailLevel=new DetailLevelCodeTypeCollection();
			DetailLevelCodeType type=DetailLevelCodeType.ReturnAll;
			detailLevel.Add(type);
			api.DetailLevelList=detailLevel;
		}
		
		/// <summary>
		/// set basic info for GetCategoryFeaturesCall
		/// </summary>
		/// <param name="api"></param>
		private static void setBasicInfo(ref GetCategoryFeaturesCall api)
		{
			DetailLevelCodeType[] detailLevels = new DetailLevelCodeType[] {
			DetailLevelCodeType.ReturnAll
			};
			api.Site=SiteCodeType.US;
			api.DetailLevelList = new DetailLevelCodeTypeCollection(detailLevels);
		}

		#endregion


	}


	/// <summary>
	/// specify the property of the category.
	/// </summary>
	public enum CategoryEnableCodeType
	{
		CatalogEnabled,
		ProductSearchPageAvailable,
		ProductFinderAvailable
	}
}

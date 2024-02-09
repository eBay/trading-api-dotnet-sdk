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
using System.Runtime.InteropServices;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.EPS;
using eBay.Service.Util;

#endregion

namespace eBay.Service.Call
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class GetCategoriesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetCategoriesCall()
		{
			ApiRequest = new GetCategoriesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetCategoriesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetCategoriesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the latest eBay category hierarchy for a given eBay site.
		/// Information returned for each category includes the category name
		/// and the unique ID for the category (unique within the eBay site for which
		/// categories are retrieved). A category ID is a required input when you list most items.
		/// </summary>
		/// 
		/// <param name="CategorySiteID">
		/// This field is used if the user wants to retrieve category data for another eBay site (other than the one specified in the <code>X-EBAY-API-SITEID</code> request header).
		/// 
		/// 
		/// If the user wishes to retrieve category data for the US eBay Motors site, the user must set the Site ID in the <code>X-EBAY-API-SITEID</code> request header to <code>0</code>, and then set this field's value to <code>100</code>.
		/// </param>
		///
		/// <param name="CategoryParent">
		/// This field is used if the user wishes to retrieve category hierarchy information on one or more specific eBay categories, and optionally, one or more levels of each category's children (if a category has one or more levels of children). For example, if you wanted to view the entire category hierarchy under the <em>Home & Garden</em> L1 category, you would include this field and set its value to <code>11700</code>. As long as the <b>LevelLimit</b> field is omitted, all of  <em>Home & Garden</em>'s child categories are returned. If you only wanted to see the next level (L2s) of <em>Home & Garden</em> categories, you would include the <b>LevelLimit</b> field and set its value to <code>2</code>, allowing the L1 category (<em>Home & Garden</em>) and all of its L2 categories to appear in the response.
		/// 
		/// 
		/// If you wanted to see all of the Category IDs for the eBay site's L1 categories, you could omit the <b>CategoryParent</b> field but include the  <b>LevelLimit</b> field and set its value to <code>1</code>.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// Numerous Category IDs may be specified under multiple <b>CategoryParent</b> fields in a <b>GetCategories</b> request, but if multiple <b>CategoryParent</b> fields are used, the specified Category IDs should all be at the same level (L1, L2, L3, etc.).
		/// </span>
		/// </param>
		///
		/// <param name="LevelLimit">
		/// This field is used if the user wants to control the maximum depth of the category hierarchy to retrieve, or in other words, how many levels of eBay categories that are returned in the response. If this field is omitted, every eBay category from the root on down will be returned, or, if a <b>CategoryParent</b> category is specified, the specified category and all of its children (down to the leaf categories) are returned.
		/// 
		/// 
		/// If the <b>CategoryParent</b> is not used, but the <b>LevelLimit</b> field is used and set to <code>1</code>, only the top-level categories (also known as L1 categories) are returned in the response.
		/// </param>
		///
		/// <param name="ViewAllNodes">
		/// This flag controls whether all eBay categories (that satisfy input filters) are returned, or only leaf categories (you can only list items in leaf categories) are returned. The default value is 'true', so if this field is omitted, all eBay categories will be returned. If you only want to retrieve leaf categories, include this flag and set it to <code>false</code>.
		/// 
		/// </param>
		///
		public CategoryTypeCollection GetCategories(string CategorySiteID, StringCollection CategoryParent, int LevelLimit, bool ViewAllNodes)
		{
			this.CategorySiteID = CategorySiteID;
			this.CategoryParent = CategoryParent;
			this.LevelLimit = LevelLimit;
			this.ViewAllNodes = ViewAllNodes;

			Execute();
			return ApiResponse.CategoryArray;
		}


 		/// <summary>
 		/// Call GetCategoriesVersion to retrieve the Category version for a site.
 		/// </summary>
 		/// <returns>The <see cref="GetCategoriesResponseType.CategoryVersion"/>.</returns>
 		public string GetCategoriesVersion()
 		{
 			this.DetailLevelOverride = true;
 			Execute();
 			this.DetailLevelOverride = false;
 			return CategoryVersionResponse;
 		}	

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public CategoryTypeCollection GetCategories()
		{
			Execute();
			return CategoryList;
		}

		#endregion




		#region Properties
		/// <summary>
		/// The base interface object.
		/// </summary>
		/// <remarks>This property is reserved for users who have difficulty querying multiple interfaces.</remarks>
		public ApiCall ApiCallBase
		{
			get { return this; }
		}

		/// <summary>
		/// Gets or sets the <see cref="GetCategoriesRequestType"/> for this API call.
		/// </summary>
		public GetCategoriesRequestType ApiRequest
		{ 
			get { return (GetCategoriesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetCategoriesResponseType"/> for this API call.
		/// </summary>
		public GetCategoriesResponseType ApiResponse
		{ 
			get { return (GetCategoriesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoriesRequestType.CategorySiteID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategorySiteID
		{ 
			get { return ApiRequest.CategorySiteID; }
			set { ApiRequest.CategorySiteID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoriesRequestType.CategoryParent"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection CategoryParent
		{ 
			get { return ApiRequest.CategoryParent; }
			set { ApiRequest.CategoryParent = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoriesRequestType.LevelLimit"/> of type <see cref="int"/>.
		/// </summary>
		public int LevelLimit
		{ 
			get { return ApiRequest.LevelLimit; }
			set { ApiRequest.LevelLimit = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoriesRequestType.ViewAllNodes"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ViewAllNodes
		{ 
			get { return ApiRequest.ViewAllNodes; }
			set { ApiRequest.ViewAllNodes = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoriesResponseType.CategoryArray"/> of type <see cref="CategoryTypeCollection"/>.
		/// </summary>
		public CategoryTypeCollection CategoryList
		{ 
			get { return ApiResponse.CategoryArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoriesResponseType.CategoryCount"/> of type <see cref="int"/>.
		/// </summary>
		public int CategoryCount
		{ 
			get { return ApiResponse.CategoryCount; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoriesResponseType.UpdateTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime UpdateTime
		{ 
			get { return ApiResponse.UpdateTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoriesResponseType.CategoryVersion"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryVersionResponse
		{ 
			get { return ApiResponse.CategoryVersion; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoriesResponseType.ReservePriceAllowed"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ReservePriceAllowed
		{ 
			get { return ApiResponse.ReservePriceAllowed; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoriesResponseType.MinimumReservePrice"/> of type <see cref="double"/>.
		/// </summary>
		public double MinimumReservePrice
		{ 
			get { return ApiResponse.MinimumReservePrice; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoriesResponseType.ReduceReserveAllowed"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ReduceReserveAllowed
		{ 
			get { return ApiResponse.ReduceReserveAllowed; }
		}
		

		#endregion

		
	}
}

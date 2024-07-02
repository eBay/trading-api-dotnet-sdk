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
	public class GetCategoryFeaturesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetCategoryFeaturesCall()
		{
			ApiRequest = new GetCategoryFeaturesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetCategoryFeaturesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetCategoryFeaturesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Returns information about the features that are applicable to different categories,
		/// such as listing durations, shipping term requirements, and Best Offer support.
		/// </summary>
		/// 
		/// <param name="CategoryID">
		/// Specifies the category for which you want to retrieve the feature settings.
		/// 
		/// Specify a CategoryID, set DetailLevel to ReturnAll, and set
		/// ViewAllNodes to true to return the default site settings, the
		/// overrides for the specified category, plus all the child
		/// categories that have overrides on the features they inherit.
		/// 
		/// If you also set AllFeaturesForCategory to true, eBay returns the site
		/// defaults, plus all the settings for the specified category. Child
		/// category information is not returned in this case.
		/// 
		/// If CategoryID is not specified, eBay returns the feature settings for
		/// the site. To return details on all categories that have overrides on
		/// the properties they inherit, set DetailLevel to ReturnAll, and set
		/// ViewAllNodes to true. If you also set AllFeaturesForCategory to true,
		/// eBay returns only the site defaults with no child category information.
		/// </param>
		///
		/// <param name="LevelLimit">
		/// This field is used if the user wants to control the maximum depth of the category hierarchy to retrieve, or in other words, how many levels of eBay categories that are returned in the response. If this field is omitted, and no <b>CategoryID</b> is specified, eBay feature metadata for every eBay category from the root on down will be returned. If this field is omitted, but a <b>CategoryID</b> is specified, the specified category and all of its children (down to the leaf categories) are returned.
		/// 
		/// 
		/// If the <b>CategoryID</b> field is not used, but the <b>LevelLimit</b> field is used and set to <code>1</code>, eBay feature metadata is only returned for the top-level categories (also known as L1 categories).
		/// </param>
		///
		/// <param name="ViewAllNodes">
		/// You must set <b>DetailLevel</b> to <code>ReturnAll</code> in order to correctly populate the
		/// response when you set <b>ViewAllNodes</b> to true. In this case, eBay returns the
		/// site defaults along with all the categories that override the feature
		/// settings they inherit. Here, each Category container shows only the
		/// features that it has overridden from its parent node.
		/// 
		/// If you also specify a <b>CategoryID</b>, eBay returns the details for that category,
		/// along with containers for each of its child categories that have feature
		/// overrides.
		/// 
		/// Note that if <b>ViewAllNodes</b> is set to false (the default) and <b>DetailLevel</b> is
		/// set to <code>ReturnAll</code>, eBay returns only the leaf categories that have features
		/// that override the settings they inherit. In this case, the call will not
		/// return leaf categories that do not have overrides.
		/// </param>
		///
		/// <param name="FeatureIDList">
		/// Use this field if you want to know if specific features are enabled at the site or root category level. Multiple <b>FeatureID</b> elements can be used in the request. If no <b>FeatureID</b> elements are used, the call retrieves data for all features, as applicable to the other request parameters.
		/// </param>
		///
		/// <param name="AllFeaturesForCategory">
		/// Use this switch to view all of the feature settings for a specific category.
		/// All feature settings are returned, regardless of the site default settings.
		/// This element works in conjunction with CategoryID--refer to the notes for
		/// that element for more details.
		/// 
		/// If you also set FeatureID, eBay returns the status of the specified
		/// features only, for the specified category.
		/// </param>
		///
		public CategoryFeatureTypeCollection GetCategoryFeatures(string CategoryID, int LevelLimit, bool ViewAllNodes, FeatureIDCodeTypeCollection FeatureIDList, bool AllFeaturesForCategory)
		{
			this.CategoryID = CategoryID;
			this.LevelLimit = LevelLimit;
			this.ViewAllNodes = ViewAllNodes;
			this.FeatureIDList = FeatureIDList;
			this.AllFeaturesForCategory = AllFeaturesForCategory;

			Execute();
			return ApiResponse.Category;
		}


 		/// <summary>
 		/// Call GetCategoryFeaturesVersion to retrieve the Category version for a site.
 		/// </summary>
 		/// <returns>The <see cref="GetCategoryFeaturesResponseType.CategoryVersion"/>.</returns>
 		public string GetCategoryFeaturesVersion()
 		{
 			this.DetailLevelOverride = true;
 			Execute();
 			this.DetailLevelOverride = false;
 			return ApiResponse.CategoryVersion;
 		}	

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public CategoryFeatureTypeCollection GetCategoryFeatures(/*FeatureIDCodeTypeCollection FeatureIDList*/)
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
		/// Gets or sets the <see cref="GetCategoryFeaturesRequestType"/> for this API call.
		/// </summary>
		public GetCategoryFeaturesRequestType ApiRequest
		{ 
			get { return (GetCategoryFeaturesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetCategoryFeaturesResponseType"/> for this API call.
		/// </summary>
		public GetCategoryFeaturesResponseType ApiResponse
		{ 
			get { return (GetCategoryFeaturesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryFeaturesRequestType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiRequest.CategoryID; }
			set { ApiRequest.CategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryFeaturesRequestType.LevelLimit"/> of type <see cref="int"/>.
		/// </summary>
		public int LevelLimit
		{ 
			get { return ApiRequest.LevelLimit; }
			set { ApiRequest.LevelLimit = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryFeaturesRequestType.ViewAllNodes"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ViewAllNodes
		{ 
			get { return ApiRequest.ViewAllNodes; }
			set { ApiRequest.ViewAllNodes = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryFeaturesRequestType.FeatureID"/> of type <see cref="FeatureIDCodeTypeCollection"/>.
		/// </summary>
		public FeatureIDCodeTypeCollection FeatureIDList
		{ 
			get { return ApiRequest.FeatureID; }
			set { ApiRequest.FeatureID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetCategoryFeaturesRequestType.AllFeaturesForCategory"/> of type <see cref="bool"/>.
		/// </summary>
		public bool AllFeaturesForCategory
		{ 
			get { return ApiRequest.AllFeaturesForCategory; }
			set { ApiRequest.AllFeaturesForCategory = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryFeaturesResponseType.CategoryVersion"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryVersion
		{ 
			get { return ApiResponse.CategoryVersion; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryFeaturesResponseType.UpdateTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime UpdateTime
		{ 
			get { return ApiResponse.UpdateTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryFeaturesResponseType.Category"/> of type <see cref="CategoryFeatureTypeCollection"/>.
		/// </summary>
		public CategoryFeatureTypeCollection CategoryList
		{ 
			get { return ApiResponse.Category; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryFeaturesResponseType.SiteDefaults"/> of type <see cref="SiteDefaultsType"/>.
		/// </summary>
		public SiteDefaultsType SiteDefaults
		{ 
			get { return ApiResponse.SiteDefaults; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetCategoryFeaturesResponseType.FeatureDefinitions"/> of type <see cref="FeatureDefinitionsType"/>.
		/// </summary>
		public FeatureDefinitionsType FeatureDefinitions
		{ 
			get { return ApiResponse.FeatureDefinitions; }
		}
		

		#endregion

		
	}
}

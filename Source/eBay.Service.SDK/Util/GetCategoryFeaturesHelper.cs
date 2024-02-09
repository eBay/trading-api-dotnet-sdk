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
using System.Collections;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Call;
using eBay.Service.Util;
using System.Runtime.InteropServices;
#endregion

namespace eBay.Service.Util
{
	/// <summary>
	/// Summary description for GetCategoryFeaturesHelper.
	/// </summary>
	public class GetCategoryFeaturesHelper
	{
		#region Private Fields

		private ApiContext _apiContext;
		private SiteCodeType _site;
		private String _categoryID = null;
		private int _levelLimit = 3;
		private bool _viewAllNodes = true;
        private bool _allFeaturesForCategory = true;
		private FeatureIDCodeTypeCollection _featureIDs = null;

		private static Hashtable _categoryFeaturesBySite = new Hashtable(5);
		private CategoryFeatureTypeCollection _categoryFeatures;
	 
		private static Hashtable _categoryVersionsBySite = new Hashtable(5);
		private String _categoryVersion;
	 
		private static Hashtable _siteDefaultsBySite = new Hashtable(5);
		private SiteDefaultsType _siteDefaults;
	 
		private static Hashtable _siteFeaturesBySite = new Hashtable(5);
		private FeatureDefinitionsType _siteFeatures;

		#endregion

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetCategoryFeaturesHelper(ApiContext ApiContext) 
		{
			_apiContext = ApiContext;
			_site = _apiContext.Site;
			loadCategoryFeatures(_site);
		}
	 
		/// <summary>
		/// 
		/// </summary>
        public GetCategoryFeaturesHelper(ApiContext ApiContext, string CategoryID, int LevelLimit, bool ViewAllNodes, FeatureIDCodeTypeCollection FeatureIDList, bool AllFeaturesForCategory) 
		{
			_apiContext = ApiContext;
			_site = _apiContext.Site;
			_categoryID = CategoryID;
			_levelLimit = LevelLimit;
			_viewAllNodes = ViewAllNodes;
			_featureIDs = FeatureIDList;
            _allFeaturesForCategory = AllFeaturesForCategory;
			loadCategoryFeatures(_site);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		public bool hasCategoryFeatures(SiteCodeType site) 
		{
		 return _categoryFeaturesBySite.ContainsKey(site) ||
		 		_categoryVersionsBySite.ContainsKey(site) ||
		 		_siteDefaultsBySite.ContainsKey(site) ||
		 		_siteFeaturesBySite.ContainsKey(site);
	 }
	 
		/// <summary>
		/// 
		/// </summary>
		public  void loadCategoryFeatures(SiteCodeType site) 
		{
		 if(!_categoryFeaturesBySite.ContainsKey(site)) {
			 SiteCodeType savedSite =_site;
			 _site = site;
			 getCategoryFeatures();
			 addToCategoryFeaturesMap();
			 addToSiteDefaultsMap();
			 addToSiteFeaturesMap();
			 addToCategoryVersionMap();
			 _site = savedSite;
		 }
	 }
	 
	/// <summary>
	/// 
	/// </summary>
	 public void loadCategoryFeatures(ApiContext apiContext)  {
		 _apiContext = apiContext;
		 _site = _apiContext.Site;
		 loadCategoryFeatures(_site);
	 }
	 
		/// <summary>
		/// 
		/// </summary>
		public string getCategoryVersion(SiteCodeType site) 
		{
		 return (String)_categoryVersionsBySite[site];
	 }
		/// <summary>
		/// 
		/// </summary>
	 
	 public String getCategoryVersion() 
	 {
		 return getCategoryVersion(_apiContext.Site);
	 }
		/// <summary>
		/// 
		/// </summary>
	 
	 public SiteDefaultsType getSiteDefaults(SiteCodeType site) 
	 {
		 return (SiteDefaultsType)_siteDefaultsBySite[site];
	 }
		/// <summary>
		/// 
		/// </summary>
	 public SiteDefaultsType getSiteDefaults() 
	 {
		 return getSiteDefaults(_apiContext.Site);
	 }
		/// <summary>
		/// 
		/// </summary>
	 public FeatureDefinitionsType getSiteFeatures(SiteCodeType site) 
	 {
		 return (FeatureDefinitionsType)_siteFeaturesBySite[site];
	 }
		/// <summary>
		/// 
		/// </summary>	 
	 public FeatureDefinitionsType getSiteFeatures() 
	 {
		 return getSiteFeatures(_apiContext.Site);
	 }
		/// <summary>
		/// 
		/// </summary>
		public CategoryFeatureType getCategoryFeature(SiteCodeType site, CategoryType category) 
		{
		 Hashtable myCategoryMap = (Hashtable)_categoryFeaturesBySite[site];
		 if(myCategoryMap != null) {
			 return (CategoryFeatureType)myCategoryMap[category];
		 }
		 return null;
	 }
		/// <summary>
		/// 
		/// </summary>
	 
	 public CategoryFeatureType getCategoryFeature(CategoryType category) 
	 {
		 return getCategoryFeature(_apiContext.Site, category);
	 }
		/// <summary>
		/// 
		/// </summary>
	 
	 public SiteCodeType getCurrentSite() 
	 {
		 return _site;
	 }
		#endregion

		#region Private Methods
	 private void addToCategoryFeaturesMap() 
	 {
		 if(!_categoryFeaturesBySite.ContainsKey(_site)) {
			 Hashtable myCategoryMap = new Hashtable();
			 for(int i = 0; i < _categoryFeatures.Count; i++) {
				 CategoryFeatureType myCategory = _categoryFeatures[i];
				 myCategoryMap.Add(myCategory.CategoryID, myCategory);
			 }
			 _categoryFeaturesBySite.Add(_site, myCategoryMap);
		 }
	 }
	 
	 private void addToSiteDefaultsMap() {
		 if(!_siteDefaultsBySite.ContainsKey(_site)) {
			 _siteDefaultsBySite.Add(_site, _siteDefaults);
		 }
	 }
	 
	 private void addToSiteFeaturesMap() {
		 if(!_siteFeaturesBySite.ContainsKey(_site)) {
			 _siteFeaturesBySite.Add(_site, _siteFeatures);
		 }
	 }
	 
	 private void addToCategoryVersionMap() {
		 if(!_categoryVersionsBySite.ContainsKey(_site)) {
			 _categoryVersionsBySite.Add(_site, _categoryVersion);
		 }
	 }
	 
	 private void getCategoryFeatures() {
		 GetCategoryFeaturesCall api = new GetCategoryFeaturesCall(_apiContext);
		 DetailLevelCodeTypeCollection detailLevels = new DetailLevelCodeTypeCollection( new DetailLevelCodeType[] {DetailLevelCodeType.ReturnAll});
		 api.DetailLevelList = detailLevels;

		 // Make API call.
         api.GetCategoryFeatures(_categoryID, _levelLimit, _viewAllNodes, _featureIDs, _allFeaturesForCategory);
		 _categoryFeatures = api.CategoryList;
		 _categoryVersion = api.CategoryVersion;
		 _siteDefaults = api.SiteDefaults;
		 _siteFeatures = api.FeatureDefinitions;
	 }
		#endregion
	}
}

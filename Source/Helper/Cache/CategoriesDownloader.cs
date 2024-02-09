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
using System.ComponentModel;
using System.Web;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.IO;
using System.Reflection;

using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
using eBay.Service.Call;
namespace Samples.Helper.Cache
{
	/// <summary>
	/// Helper class with cache function for GetCategories call
	/// </summary>
	public class CategoriesDownloader:BaseDownloader
	{
		#region constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="context"></param>
		public CategoriesDownloader(ApiContext context)
		{
			this.context=context;
			//must initialize some super class fields
			this.filePrefix = "AllCategories";
			this.fileSuffix = "cats";
			this.objType = typeof(GetCategoriesResponseType);
		}

		#endregion

		#region public methods

		/// <summary>
		/// Get all categories for a given site
		/// </summary>
		public CategoryTypeCollection GetAllCategories()
		{
			object obj = getObject();
			GetCategoriesResponseType response = (GetCategoriesResponseType)obj;
			return response.CategoryArray;
		}

		#endregion
		
		#region protected methods

		
		/// <summary>
		/// get last update time from site
		/// </summary>
		/// <returns>string</returns>
		protected override string getLastUpdateTime()
		{
			GetCategoriesCall api = new GetCategoriesCall(context);			
			//set output selector
			api.ApiRequest.OutputSelector = new StringCollection(new String[]{"UpdateTime"});
			//execute call
			api.GetCategories();

			DateTime updateTime = api.ApiResponse.UpdateTime;

			return updateTime.ToString("yyyy-MM-dd-hh-mm-ss");
		}


		/// <summary>
		/// call GetCategories to get all categories for a given site
		/// </summary>
		/// <returns>generic object</returns>
		protected override object callApi()
		{
			GetCategoriesCall api = new GetCategoriesCall(context);
			//set detail level
			api.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);	
			api.Timeout = 480000;
			api.ViewAllNodes =true;
			//execute call
			api.GetCategories();

			return api.ApiResponse;
		}

		#endregion

	}//close CategoriesDownloader class
}

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
	public class GetStoreCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetStoreCall()
		{
			ApiRequest = new GetStoreRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetStoreCall(ApiContext ApiContext)
		{
			ApiRequest = new GetStoreRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call is used to retrieve detailed information on a seller's eBay Store, including store theme information and eBay Store category hierarchy.
		/// </summary>
		/// 
		/// <param name="CategoryStructureOnly">
		/// Include this field and set its value to <code>true</code> if you wish to restrict the call response to only the store category hierarchy data. If this field is not included or set to <code>false</code>, store category hierarchy and all store configuration data is returned.
		/// </param>
		///
		/// <param name="RootCategoryID">
		/// The unique identifier of an eBay Store category. This field is used if the user wants to isolate the category hierarchy data to one particular eBay category (and its subcategories if applicable). The <b>LevelLimit</b> value will determine how many additional levels of categories are returned.
		/// </param>
		///
		/// <param name="LevelLimit">
		/// This field allows the seller to limit the number of levels of eBay Store categories that are returned. To return only top-level eBay Store categories, the user can include this field and set its value to <code>1</code> (and not use a <b>RootCategoryID</b> value). To retrieve a specific eBay Store Category and that category's child categories, the user could specify the unique eBay Store Category ID in the <b>RootCategoryID</b> field and then set the <b>LevelLimit</b> value to <code>2</code>.
		/// <br/><br/>
		/// If <b>LevelLimit</b> is omitted, the complete eBay Store Category hierarchy is returned, or all of specified store category's child categories. Currently, eBay Stores support only three levels of store categories.
		/// </param>
		///
		/// <param name="UserID">
		/// The unique identifier for an eBay Store owner. This field is only required if the user wants to view the eBay Store theme and category information for a different eBay Store owner. If this field is omitted, eBay Store theme and category information is returned for the eBay Store owner that is making the call.
		/// </param>
		///
		public StoreType GetStore(bool CategoryStructureOnly, long RootCategoryID, int LevelLimit, string UserID)
		{
			this.CategoryStructureOnly = CategoryStructureOnly;
			this.RootCategoryID = RootCategoryID;
			this.LevelLimit = LevelLimit;
			this.UserID = UserID;

			Execute();
			return ApiResponse.Store;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public StoreType GetStore()
		{

			Execute();
			return ApiResponse.Store;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public StoreType GetStore(bool CategoryStructureOnly, long RootCategoryID, int LevelLimit)
		{
			this.CategoryStructureOnly = CategoryStructureOnly;
			this.RootCategoryID = RootCategoryID;
			this.LevelLimit = LevelLimit;

			Execute();
			return ApiResponse.Store;
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
		/// Gets or sets the <see cref="GetStoreRequestType"/> for this API call.
		/// </summary>
		public GetStoreRequestType ApiRequest
		{ 
			get { return (GetStoreRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetStoreResponseType"/> for this API call.
		/// </summary>
		public GetStoreResponseType ApiResponse
		{ 
			get { return (GetStoreResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetStoreRequestType.CategoryStructureOnly"/> of type <see cref="bool"/>.
		/// </summary>
		public bool CategoryStructureOnly
		{ 
			get { return ApiRequest.CategoryStructureOnly; }
			set { ApiRequest.CategoryStructureOnly = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetStoreRequestType.RootCategoryID"/> of type <see cref="long"/>.
		/// </summary>
		public long RootCategoryID
		{ 
			get { return ApiRequest.RootCategoryID; }
			set { ApiRequest.RootCategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetStoreRequestType.LevelLimit"/> of type <see cref="int"/>.
		/// </summary>
		public int LevelLimit
		{ 
			get { return ApiRequest.LevelLimit; }
			set { ApiRequest.LevelLimit = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetStoreRequestType.UserID"/> of type <see cref="string"/>.
		/// </summary>
		public string UserID
		{ 
			get { return ApiRequest.UserID; }
			set { ApiRequest.UserID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetStoreResponseType.Store"/> of type <see cref="StoreType"/>.
		/// </summary>
		public StoreType Store
		{ 
			get { return ApiResponse.Store; }
		}
		

		#endregion

		
	}
}

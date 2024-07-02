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
	public class SetStoreCategoriesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetStoreCategoriesCall()
		{
			ApiRequest = new SetStoreCategoriesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetStoreCategoriesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetStoreCategoriesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call allows you to set or modify the category structure of an eBay Store. Sellers must have an eBay Store subscription in order to use this call.
		/// </summary>
		/// 
		/// <param name="Action">
		/// Specifies the type of action (Add, Move, Delete, or Rename) to carry out
		/// for the specified eBay Store categories.
		/// </param>
		///
		/// <param name="ItemDestinationCategoryID">
		/// Items can only be contained within child categories. A parent category
		/// cannot contain items. If adding, moving, or deleting categories displaces
		/// items, you must specify a destination child category under which the
		/// displaced items will be moved. The destination category must have no
		/// child categories.
		/// </param>
		///
		/// <param name="DestinationParentCategoryID">
		/// When adding or moving store categories, specifies the category under
		/// which the listed categories will be located. To add or move categories to
		/// the top level, set the value to -999.
		/// </param>
		///
		/// <param name="StoreCategoryList">
		/// Specifies the store categories on which to act.
		/// </param>
		///
		public long SetStoreCategories(StoreCategoryUpdateActionCodeType Action, long ItemDestinationCategoryID, long DestinationParentCategoryID, StoreCustomCategoryTypeCollection StoreCategoryList)
		{
			this.Action = Action;
			this.ItemDestinationCategoryID = ItemDestinationCategoryID;
			this.DestinationParentCategoryID = DestinationParentCategoryID;
			this.StoreCategoryList = StoreCategoryList;

			Execute();
			return ApiResponse.TaskID;
		}


		public long SetStoreCategories(StoreCategoryUpdateActionCodeType Action, StoreCustomCategoryTypeCollection StoreCategoryList)
		{
			this.Action = Action;
			this.StoreCategoryList = StoreCategoryList;

			Execute();
			return ApiResponse.TaskID;
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
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType"/> for this API call.
		/// </summary>
		public SetStoreCategoriesRequestType ApiRequest
		{ 
			get { return (SetStoreCategoriesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetStoreCategoriesResponseType"/> for this API call.
		/// </summary>
		public SetStoreCategoriesResponseType ApiResponse
		{ 
			get { return (SetStoreCategoriesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.Action"/> of type <see cref="StoreCategoryUpdateActionCodeType"/>.
		/// </summary>
		public StoreCategoryUpdateActionCodeType Action
		{ 
			get { return ApiRequest.Action; }
			set { ApiRequest.Action = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.ItemDestinationCategoryID"/> of type <see cref="long"/>.
		/// </summary>
		public long ItemDestinationCategoryID
		{ 
			get { return ApiRequest.ItemDestinationCategoryID; }
			set { ApiRequest.ItemDestinationCategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.DestinationParentCategoryID"/> of type <see cref="long"/>.
		/// </summary>
		public long DestinationParentCategoryID
		{ 
			get { return ApiRequest.DestinationParentCategoryID; }
			set { ApiRequest.DestinationParentCategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetStoreCategoriesRequestType.StoreCategories"/> of type <see cref="StoreCustomCategoryTypeCollection"/>.
		/// </summary>
		public StoreCustomCategoryTypeCollection StoreCategoryList
		{ 
			get { return ApiRequest.StoreCategories; }
			set { ApiRequest.StoreCategories = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="SetStoreCategoriesResponseType.TaskID"/> of type <see cref="long"/>.
		/// </summary>
		public long TaskID
		{ 
			get { return ApiResponse.TaskID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="SetStoreCategoriesResponseType.Status"/> of type <see cref="TaskStatusCodeType"/>.
		/// </summary>
		public TaskStatusCodeType Status
		{ 
			get { return ApiResponse.Status; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="SetStoreCategoriesResponseType.CustomCategory"/> of type <see cref="StoreCustomCategoryTypeCollection"/>.
		/// </summary>
		public StoreCustomCategoryTypeCollection CustomCategoryList
		{ 
			get { return ApiResponse.CustomCategory; }
		}
		

		#endregion

		
	}
}

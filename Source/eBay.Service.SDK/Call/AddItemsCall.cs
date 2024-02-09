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
	public class AddItemsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddItemsCall()
		{
			ApiRequest = new AddItemsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddItemsCall(ApiContext ApiContext)
		{
			ApiRequest = new AddItemsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Defines from one to five items and lists them on a specified eBay site.
		/// </summary>
		/// 
		/// <param name="AddItemRequestContainerList">
		/// Defines a single item to be listed on eBay. This container is similar to an <b>AddItem</b> request. Up to five of these containers can be included in one <b>AddItems</b> request.
		/// </param>
		///
		public AddItemResponseContainerTypeCollection AddItems(AddItemRequestContainerTypeCollection AddItemRequestContainerList)
		{
			this.AddItemRequestContainerList = AddItemRequestContainerList;

			Execute();
			return ApiResponse.AddItemResponseContainer;
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
		/// Gets or sets the <see cref="AddItemsRequestType"/> for this API call.
		/// </summary>
		public AddItemsRequestType ApiRequest
		{ 
			get { return (AddItemsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddItemsResponseType"/> for this API call.
		/// </summary>
		public AddItemsResponseType ApiResponse
		{ 
			get { return (AddItemsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddItemsRequestType.AddItemRequestContainer"/> of type <see cref="AddItemRequestContainerTypeCollection"/>.
		/// </summary>
		public AddItemRequestContainerTypeCollection AddItemRequestContainerList
		{ 
			get { return ApiRequest.AddItemRequestContainer; }
			set { ApiRequest.AddItemRequestContainer = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="AddItemsResponseType.AddItemResponseContainer"/> of type <see cref="AddItemResponseContainerTypeCollection"/>.
		/// </summary>
		public AddItemResponseContainerTypeCollection AddItemResponseContainerList
		{ 
			get { return ApiResponse.AddItemResponseContainer; }
		}
		

		#endregion

		
	}
}

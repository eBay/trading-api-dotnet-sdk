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
	public class EndItemsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public EndItemsCall()
		{
			ApiRequest = new EndItemsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public EndItemsCall(ApiContext ApiContext)
		{
			ApiRequest = new EndItemsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The <b>EndItems</b> call is used to end up to 10 specified eBay listings before the date and time at which those listings would normally end per the listing duration.
		/// </summary>
		/// 
		/// <param name="EndItemRequestContainerList">
		/// An <b>EndItemRequestContainer</b> container is required for each eBay listing that the seller plans to end through the <b>EndItems</b> call. Up to 10 eBay listings can be ended with one <b>EndItems</b> call.
		/// </param>
		///
		public EndItemResponseContainerTypeCollection EndItems(EndItemRequestContainerTypeCollection EndItemRequestContainerList)
		{
			this.EndItemRequestContainerList = EndItemRequestContainerList;

			Execute();
			return ApiResponse.EndItemResponseContainer;
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
		/// Gets or sets the <see cref="EndItemsRequestType"/> for this API call.
		/// </summary>
		public EndItemsRequestType ApiRequest
		{ 
			get { return (EndItemsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="EndItemsResponseType"/> for this API call.
		/// </summary>
		public EndItemsResponseType ApiResponse
		{ 
			get { return (EndItemsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="EndItemsRequestType.EndItemRequestContainer"/> of type <see cref="EndItemRequestContainerTypeCollection"/>.
		/// </summary>
		public EndItemRequestContainerTypeCollection EndItemRequestContainerList
		{ 
			get { return ApiRequest.EndItemRequestContainer; }
			set { ApiRequest.EndItemRequestContainer = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="EndItemsResponseType.EndItemResponseContainer"/> of type <see cref="EndItemResponseContainerTypeCollection"/>.
		/// </summary>
		public EndItemResponseContainerTypeCollection EndItemResponseContainerList
		{ 
			get { return ApiResponse.EndItemResponseContainer; }
		}
		

		#endregion

		
	}
}

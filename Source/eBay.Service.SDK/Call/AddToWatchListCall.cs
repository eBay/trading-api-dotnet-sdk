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
	public class AddToWatchListCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddToWatchListCall()
		{
			ApiRequest = new AddToWatchListRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddToWatchListCall(ApiContext ApiContext)
		{
			ApiRequest = new AddToWatchListRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Adds one or more order line items to the eBay user's Watch List. An auction item or a single-variation, fixed-price listing is identified with an <b>ItemID</b> value. To add a specific item variation to the Watch List from within a multi-variation, fixed-price listing, the user will use the  <b>VariationKey</b> container instead.
		/// </summary>
		/// 
		/// <param name="ItemIDList">
		/// The unique identifier of the single-variation listing that is to be added to the eBay user's Watch List. The item must be a currently active item, and the total number of items in the user's Watch List (after the items in the request have been added) cannot exceed the maximum allowed number of Watch List items. One or more <b>ItemID</b> fields can be specified. A separate error node will be returned for each item that was not successfully added to the Watch List.  The user must use either one or more <b>ItemID</b> values or one or more <b>VariationKey</b> containers, but the user may not use both of these entities in the same call.
		/// </param>
		///
		/// <param name="VariationKeyList">
		/// This container is used to specify one or more item variations in a multi-variation, fixed-price listing that you want to add to the Watch List.
		/// The listing is identified through the <b>ItemID</b> value and each item variation existing within that listing is identified through a <b>VariationSpecifics.NameValueList</b> container.
		/// 
		/// 
		/// The user must use either one or more <b>ItemID</b> values or one or more <b>VariationKey</b> containers, but the user may not use both of these entities in the same call.
		/// </param>
		///
		public int AddToWatchList(StringCollection ItemIDList, VariationKeyTypeCollection VariationKeyList)
		{
			this.ItemIDList = ItemIDList;
			this.VariationKeyList = VariationKeyList;

			Execute();
			return ApiResponse.WatchListCount;
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
		/// Gets or sets the <see cref="AddToWatchListRequestType"/> for this API call.
		/// </summary>
		public AddToWatchListRequestType ApiRequest
		{ 
			get { return (AddToWatchListRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddToWatchListResponseType"/> for this API call.
		/// </summary>
		public AddToWatchListResponseType ApiResponse
		{ 
			get { return (AddToWatchListResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddToWatchListRequestType.ItemID"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection ItemIDList
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddToWatchListRequestType.VariationKey"/> of type <see cref="VariationKeyTypeCollection"/>.
		/// </summary>
		public VariationKeyTypeCollection VariationKeyList
		{ 
			get { return ApiRequest.VariationKey; }
			set { ApiRequest.VariationKey = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="AddToWatchListResponseType.WatchListCount"/> of type <see cref="int"/>.
		/// </summary>
		public int WatchListCount
		{ 
			get { return ApiResponse.WatchListCount; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddToWatchListResponseType.WatchListMaximum"/> of type <see cref="int"/>.
		/// </summary>
		public int WatchListMaximum
		{ 
			get { return ApiResponse.WatchListMaximum; }
		}
		

		#endregion

		
	}
}

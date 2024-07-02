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
	public class RemoveFromWatchListCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public RemoveFromWatchListCall()
		{
			ApiRequest = new RemoveFromWatchListRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public RemoveFromWatchListCall(ApiContext ApiContext)
		{
			ApiRequest = new RemoveFromWatchListRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The call enables a user to remove one or more items from their Watch List. A user can view the items that they are currently watching by calling <b>GetMyeBayBuying</b>.
		/// <br/><br/>
		/// The user has the option of removing one or more single-variation listings, one or more product variations within a multiple-variation listing, or removing all items from the Watch List.
		/// </summary>
		/// 
		/// <param name="ItemIDList">
		/// The unique identifier of the item to be removed from the
		/// user's Watch List. Multiple <b>ItemID</b> fields can be specified in the same request, but note that the <b>RemoveAllItems</b> field or <b>VariationKey</b> container cannot be specified if one or more <b>ItemID</b> fields are used.
		/// <br/><br/>
		/// </param>
		///
		/// <param name="RemoveAllItems">
		/// If this field is included and set to <code>true</code>, then all the items in the user's
		/// Watch List are removed. Note that if the <b>RemoveAllItems</b> field is specified, one or more <b>ItemID</b> fields or the <b>VariationKey</b> cannot be used.
		/// </param>
		///
		/// <param name="VariationKeyList">
		/// This container is used if the user want to remove one or more product variations (within a multiple-variation listing) from the Watch List. Note that if the <b>VariationKey</b> container is used, one or more <b>ItemID</b> fields or the <b>RemoveAllItems</b> field cannot be used.
		/// </param>
		///
		public int RemoveFromWatchList(StringCollection ItemIDList, bool RemoveAllItems, VariationKeyTypeCollection VariationKeyList)
		{
			this.ItemIDList = ItemIDList;
			this.RemoveAllItems = RemoveAllItems;
			this.VariationKeyList = VariationKeyList;

			Execute();
			return ApiResponse.WatchListCount;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public int RemoveFromWatchList(StringCollection ItemIDList)
		{
			this.ItemIDList = ItemIDList;
			Execute();
			return this.WatchListCount;
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
		/// Gets or sets the <see cref="RemoveFromWatchListRequestType"/> for this API call.
		/// </summary>
		public RemoveFromWatchListRequestType ApiRequest
		{ 
			get { return (RemoveFromWatchListRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="RemoveFromWatchListResponseType"/> for this API call.
		/// </summary>
		public RemoveFromWatchListResponseType ApiResponse
		{ 
			get { return (RemoveFromWatchListResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="RemoveFromWatchListRequestType.ItemID"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection ItemIDList
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RemoveFromWatchListRequestType.RemoveAllItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool RemoveAllItems
		{ 
			get { return ApiRequest.RemoveAllItems; }
			set { ApiRequest.RemoveAllItems = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RemoveFromWatchListRequestType.VariationKey"/> of type <see cref="VariationKeyTypeCollection"/>.
		/// </summary>
		public VariationKeyTypeCollection VariationKeyList
		{ 
			get { return ApiRequest.VariationKey; }
			set { ApiRequest.VariationKey = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="RemoveFromWatchListResponseType.WatchListCount"/> of type <see cref="int"/>.
		/// </summary>
		public int WatchListCount
		{ 
			get { return ApiResponse.WatchListCount; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="RemoveFromWatchListResponseType.WatchListMaximum"/> of type <see cref="int"/>.
		/// </summary>
		public int WatchListMaximum
		{ 
			get { return ApiResponse.WatchListMaximum; }
		}
		

		#endregion

		
	}
}

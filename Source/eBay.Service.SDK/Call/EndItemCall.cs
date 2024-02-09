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
	public class EndItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public EndItemCall()
		{
			ApiRequest = new EndItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public EndItemCall(ApiContext ApiContext)
		{
			ApiRequest = new EndItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Ends the specified item listing before the date and time at which it would normally end per the listing duration.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique item ID that identifies the listing that you want to end.
		/// </param>
		///
		/// <param name="EndingReason">
		/// The seller's reason for ending the listing early is input into this required field. The seller is not allowed to use the <code>ProductDeleted</code> value, as this ending reason can only be used internally by eBay to administratively end a listing due to the associated Catalog product being removed from the eBay Catalog.
		/// </param>
		///
		/// <param name="SellerInventoryID">
		/// This field was previously only used to identify and end Half.com listings, and since the Half.com site has been shut down, this element is no longer applicable.
		/// </param>
		///
		public DateTime EndItem(string ItemID, EndReasonCodeType EndingReason, string SellerInventoryID)
		{
			this.ItemID = ItemID;
			this.EndingReason = EndingReason;
			this.SellerInventoryID = SellerInventoryID;

			Execute();
			return ApiResponse.EndTime;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void EndItem(string ItemID, EndReasonCodeType EndingReason)
		{
			this.ItemID = ItemID;
			this.EndingReason = EndingReason;
			Execute();
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
		/// Gets or sets the <see cref="EndItemRequestType"/> for this API call.
		/// </summary>
		public EndItemRequestType ApiRequest
		{ 
			get { return (EndItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="EndItemResponseType"/> for this API call.
		/// </summary>
		public EndItemResponseType ApiResponse
		{ 
			get { return (EndItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="EndItemRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="EndItemRequestType.EndingReason"/> of type <see cref="EndReasonCodeType"/>.
		/// </summary>
		public EndReasonCodeType EndingReason
		{ 
			get { return ApiRequest.EndingReason; }
			set { ApiRequest.EndingReason = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="EndItemRequestType.SellerInventoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string SellerInventoryID
		{ 
			get { return ApiRequest.SellerInventoryID; }
			set { ApiRequest.SellerInventoryID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="EndItemResponseType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiResponse.EndTime; }
		}
		

		#endregion

		
	}
}

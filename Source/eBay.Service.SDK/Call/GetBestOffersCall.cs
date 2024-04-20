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
	public class GetBestOffersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetBestOffersCall()
		{
			ApiRequest = new GetBestOffersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetBestOffersCall(ApiContext ApiContext)
		{
			ApiRequest = new GetBestOffersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This is the base request type of the <b>GetBestOffers</b> call. Depending on the input parameters that are used, this call can be used by a seller to retrieve all active Best Offers, all Best Offers on a specific listing, a specific Best Offer for a specific listing, or Best Offers in a specific state.
		/// <br/><br/>
		/// <span class="tablenote"><b>Note: </b>
		/// The Best Offer feature is now available for auction listings on the following sites: US, Canada, UK, Germany, Australia, France, Italy, and Spain. However, sellers must choose between offering Best Offer or Buy It Now on an auction listing, as both features cannot be enabled on the same auction listing.
		/// </span>
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The unique identifier of an eBay listing. If an <b>ItemID</b> is used by itself in the call request, all Best Offers in all states are retrieved for this listing. However, the seller can also combine <b>ItemID</b> and a <b>BestOfferStatus</b> value if that seller only wants to see Best Offers in a specific state. If a <b>BestOfferID</b> field is included in the call request, any <b>ItemID</b> value will be ignored since eBay will only search for and return the Best Offer identified in the <b>BestOfferID</b> field.
		/// </param>
		///
		/// <param name="BestOfferID">
		/// The unique identifier of a Best Offer. An identifier for a Best Offer is automatically created by eBay once a prospective buyer makes a Best Offer on a Best Offer-enabled listing. If a <b>BestOfferID</b> value is supplied in the call request, any <b>ItemID</b> or <b>BestOfferStatus</b> values will be ignored. Only the Best Offer identified by the <b>BestOfferID</b> value will be returned.
		/// </param>
		///
		/// <param name="BestOfferStatus">
		/// This field can be used if the seller wants to retrieve Best Offers in a specific state. The typical use case for this field is when the seller wants to retrieve Best Offers in all states for a specific listing. In fact, the <b>All</b> value can only be used if an <b>ItemID</b> value is also supplied in the call request. If a <b>BestOfferID</b> field is included in the call request, any <b>BestOfferStatus</b> value will be ignored since eBay will only search for and return the Best Offer identified in the <b>BestOfferID</b> field.
		/// <br/>
		/// </param>
		///
		/// <param name="Pagination">
		/// This container can be used if the seller is expecting that the <b>GetBestOffers</b> call will retrieve a large number of results, so that seller wishes to view just a subset (one page of multiple pages) of those results at a time. See this container's child fields for more information on how pagination is used.
		/// </param>
		///
		public BestOfferTypeCollection GetBestOffers(string ItemID, string BestOfferID, BestOfferStatusCodeType BestOfferStatus, PaginationType Pagination)
		{
			this.ItemID = ItemID;
			this.BestOfferID = BestOfferID;
			this.BestOfferStatus = BestOfferStatus;
			this.Pagination = Pagination;

			Execute();
			return ApiResponse.BestOfferArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public BestOfferTypeCollection GetBestOffers(string ItemID)
		{
			this.ItemID = ItemID;
			Execute();
			return BestOfferList;
		}
		
		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.ItemBestOffersArray"/> of type <see cref="ItemBestOffersTypeCollection"/>.
		/// </summary>
		public ItemBestOffersTypeCollection ItemBestOffersList
		{ 
			get {
				if (ApiResponse.ItemBestOffersArray == null)
					return null;
				return ApiResponse.ItemBestOffersArray.ItemBestOffers; }
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
		/// Gets or sets the <see cref="GetBestOffersRequestType"/> for this API call.
		/// </summary>
		public GetBestOffersRequestType ApiRequest
		{ 
			get { return (GetBestOffersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetBestOffersResponseType"/> for this API call.
		/// </summary>
		public GetBestOffersResponseType ApiResponse
		{ 
			get { return (GetBestOffersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.BestOfferID"/> of type <see cref="string"/>.
		/// </summary>
		public string BestOfferID
		{ 
			get { return ApiRequest.BestOfferID; }
			set { ApiRequest.BestOfferID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.BestOfferStatus"/> of type <see cref="BestOfferStatusCodeType"/>.
		/// </summary>
		public BestOfferStatusCodeType BestOfferStatus
		{ 
			get { return ApiRequest.BestOfferStatus; }
			set { ApiRequest.BestOfferStatus = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBestOffersRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.BestOfferArray"/> of type <see cref="BestOfferTypeCollection"/>.
		/// </summary>
		public BestOfferTypeCollection BestOfferList
		{ 
			get { return ApiResponse.BestOfferArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiResponse.Item; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.ItemBestOffersArray"/> of type <see cref="ItemBestOffersArrayType"/>.
		/// </summary>
		public ItemBestOffersArrayType ItemBestOffersArray
		{ 
			get { return ApiResponse.ItemBestOffersArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBestOffersResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		

		#endregion

		
	}
}

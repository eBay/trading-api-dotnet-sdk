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
	public class GetMyeBayBuyingCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetMyeBayBuyingCall()
		{
			ApiRequest = new GetMyeBayBuyingRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetMyeBayBuyingCall(ApiContext ApiContext)
		{
			ApiRequest = new GetMyeBayBuyingRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves information regarding a user's buying activity, such as items they are watching, bidding on, have won, did not win, and have made Best Offers on.
		/// </summary>
		/// 
		/// <param name="WatchList">
		/// Include this container and set the <b>WatchList.Include</b> field to <code>true</code> to return the list of items on the eBay user's Watch List.
		/// 
		/// The user also has the option of using pagination and sorting for the list of watched items that will be returned.
		/// </param>
		///
		/// <param name="BidList">
		/// Include this container and set the <b>BidList.Include</b> field to <code>true</code> to return the list of auction items on which the eBay user has bid.
		/// 
		/// The user also has the option of using pagination and sorting for the list of auction items that will be returned.
		/// </param>
		///
		/// <param name="BestOfferList">
		/// Include this container and set the <b>BestOfferList.Include</b> field to <code>true</code> to return the list of items on which the eBay user has made a Best Offer.
		/// 
		/// The user also has the option of using pagination and sorting for the list of items that will be returned.
		/// </param>
		///
		/// <param name="WonList">
		/// Include this container and set the <b>WonList.Include</b> field to <code>true</code> to return the list of auction items on which the eBay user has bid on and won.
		/// 
		/// The user also has the option of using pagination and sorting for the list of auction items that will be returned.
		/// </param>
		///
		/// <param name="LostList">
		/// Include this container and set the <b>LostList.Include</b> field to <code>true</code> to return the list of auction items on which the eBay user has bid on and lost.
		/// 
		/// The user also has the option of using pagination and sorting for the list of auction items that will be returned.
		/// </param>
		///
		/// <param name="FavoriteSearches">
		/// Include this container and set the <b>FavoriteSearches.Include</b> field to <code>true</code> to return the list of the eBay user's saved searches.
		/// </param>
		///
		/// <param name="FavoriteSellers">
		/// Include this container and set the <b>FavoriteSellers.Include</b> field to <code>true</code> to return the list of the eBay user's saved sellers.
		/// </param>
		///
		/// <param name="SecondChanceOffer">
		/// Include this container and set the <b>SecondChanceOffer.Include</b> field to <code>true</code> to return any Second Chance Offers that the eBay user has received.
		/// </param>
		///
		/// <param name="BidAssistantList">
		/// This field is deprecated.
		/// </param>
		///
		/// <param name="DeletedFromWonList">
		/// Include this container and set the <b>DeletedFromWonList.Include</b> field to <code>true</code> to return the list of auction items on which the eBay user has bid on and won, but has deleted from their My eBay page.
		/// 
		/// The user also has the option of using pagination and sorting for the list of auction items that will be returned.
		/// </param>
		///
		/// <param name="DeletedFromLostList">
		/// Include this container and set the <b>DeletedFromLostList.Include</b> field to <code>true</code> to return the list of auction items on which the eBay user has bid on and lost, and has deleted from their My eBay page.
		/// 
		/// The user also has the option of using pagination and sorting for the list of auction items that will be returned.
		/// </param>
		///
		/// <param name="BuyingSummary">
		/// Include this container and set the <b>BuyingSummary.Include</b> field to <code>true</code> to return the <b>BuyingSummary</b> container in the response. The <b>BuyingSummary</b> container consists of buying/bidding activity counts and values.
		/// </param>
		///
		/// <param name="UserDefinedLists">
		/// Include this container and set the <b>UserDefinedLists.Include</b> field to <code>true</code> to return one or more user-defined lists. User-defined lists are lists created by the user in My eBay and consists of a combination of items, saved sellers, and/or saved searches.
		/// </param>
		///
		/// <param name="HideVariations">
		/// If this field is included and set to <code>true</code>, the <b>Variations</b> node (and all variation data) is omitted for all multiple-variation listings in the response. If this field is omitted or set to <code>false</code>, the <b>Variations</b> node is returned for all multiple-variation listings in the response.
		/// 
		/// </param>
		///
        //public BuyingSummaryType GetMyeBayBuying(ItemListCustomizationType WatchList, ItemListCustomizationType BidList, ItemListCustomizationType BestOfferList, ItemListCustomizationType WonList, ItemListCustomizationType LostList, MyeBaySelectionType FavoriteSearches, MyeBaySelectionType FavoriteSellers, MyeBaySelectionType SecondChanceOffer, BidAssistantListType BidAssistantList, ItemListCustomizationType DeletedFromWonList, ItemListCustomizationType DeletedFromLostList, ItemListCustomizationType BuyingSummary, MyeBaySelectionType UserDefinedLists, bool HideVariations)
        //{
        //    this.WatchList = WatchList;
        //    this.BidList = BidList;
        //    this.BestOfferList = BestOfferList;
        //    this.WonList = WonList;
        //    this.LostList = LostList;
        //    this.FavoriteSearches = FavoriteSearches;
        //    this.FavoriteSellers = FavoriteSellers;
        //    this.SecondChanceOffer = SecondChanceOffer;
        //    this.BidAssistantList = BidAssistantList;
        //    this.DeletedFromWonList = DeletedFromWonList;
        //    this.DeletedFromLostList = DeletedFromLostList;
        //    this.BuyingSummary = BuyingSummary;
        //    this.UserDefinedLists = UserDefinedLists;
        //    this.HideVariations = HideVariations;

        //    Execute();
        //    return ApiResponse.BuyingSummary;
        //}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public BuyingSummaryType GetMyeBayBuying(ItemListCustomizationType WatchList, ItemListCustomizationType BidList, ItemListCustomizationType BestOfferList, ItemListCustomizationType WonList, ItemListCustomizationType LostList, MyeBaySelectionType FavoriteSearches, MyeBaySelectionType FavoriteSellers, MyeBaySelectionType SecondChanceOffer)
		{
			this.WatchList = WatchList;
			this.BidList = BidList;
			this.BestOfferList = BestOfferList;
			this.WonList = WonList;
			this.LostList = LostList;
			this.FavoriteSearches = FavoriteSearches;
			this.FavoriteSellers = FavoriteSellers;
			this.SecondChanceOffer = SecondChanceOffer;

			Execute();
			return ApiResponse.BuyingSummary;
		}
		
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void GetMyeBayBuying()
		{
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
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType"/> for this API call.
		/// </summary>
		public GetMyeBayBuyingRequestType ApiRequest
		{ 
			get { return (GetMyeBayBuyingRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetMyeBayBuyingResponseType"/> for this API call.
		/// </summary>
		public GetMyeBayBuyingResponseType ApiResponse
		{ 
			get { return (GetMyeBayBuyingResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.WatchList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType WatchList
		{ 
			get { return ApiRequest.WatchList; }
			set { ApiRequest.WatchList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.BidList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType BidList
		{ 
			get { return ApiRequest.BidList; }
			set { ApiRequest.BidList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.BestOfferList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType BestOfferList
		{ 
			get { return ApiRequest.BestOfferList; }
			set { ApiRequest.BestOfferList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.WonList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType WonList
		{ 
			get { return ApiRequest.WonList; }
			set { ApiRequest.WonList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.LostList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType LostList
		{ 
			get { return ApiRequest.LostList; }
			set { ApiRequest.LostList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.FavoriteSearches"/> of type <see cref="MyeBaySelectionType"/>.
		/// </summary>
		public MyeBaySelectionType FavoriteSearches
		{ 
			get { return ApiRequest.FavoriteSearches; }
			set { ApiRequest.FavoriteSearches = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.FavoriteSellers"/> of type <see cref="MyeBaySelectionType"/>.
		/// </summary>
		public MyeBaySelectionType FavoriteSellers
		{ 
			get { return ApiRequest.FavoriteSellers; }
			set { ApiRequest.FavoriteSellers = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.SecondChanceOffer"/> of type <see cref="MyeBaySelectionType"/>.
		/// </summary>
		public MyeBaySelectionType SecondChanceOffer
		{ 
			get { return ApiRequest.SecondChanceOffer; }
			set { ApiRequest.SecondChanceOffer = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.BidAssistantList"/> of type <see cref="BidAssistantListType"/>.
		/// </summary>
        //public BidAssistantListType BidAssistantList
        //{ 
        //    get { return ApiRequest.BidAssistantList; }
        //    set { ApiRequest.BidAssistantList = value; }
        //}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.DeletedFromWonList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType DeletedFromWonList
		{ 
			get { return ApiRequest.DeletedFromWonList; }
			set { ApiRequest.DeletedFromWonList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.DeletedFromLostList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType DeletedFromLostList
		{ 
			get { return ApiRequest.DeletedFromLostList; }
			set { ApiRequest.DeletedFromLostList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.BuyingSummary"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType BuyingSummary
		{ 
			get { return ApiRequest.BuyingSummary; }
			set { ApiRequest.BuyingSummary = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.UserDefinedLists"/> of type <see cref="MyeBaySelectionType"/>.
		/// </summary>
		public MyeBaySelectionType UserDefinedLists
		{ 
			get { return ApiRequest.UserDefinedLists; }
			set { ApiRequest.UserDefinedLists = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBayBuyingRequestType.HideVariations"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HideVariations
		{ 
			get { return ApiRequest.HideVariations; }
			set { ApiRequest.HideVariations = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.BuyingSummary"/> of type <see cref="BuyingSummaryType"/>.
		/// </summary>
		public BuyingSummaryType BuyingSummaryReturn
		{ 
			get { return ApiResponse.BuyingSummary; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.WatchList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType WatchListReturn
		{ 
			get { return ApiResponse.WatchList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.BidList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType BidListReturn
		{ 
			get { return ApiResponse.BidList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.BestOfferList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType BestOfferListReturn
		{ 
			get { return ApiResponse.BestOfferList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.WonList"/> of type <see cref="PaginatedOrderTransactionArrayType"/>.
		/// </summary>
		public PaginatedOrderTransactionArrayType WonListReturn
		{ 
			get { return ApiResponse.WonList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.LostList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType LostListReturn
		{ 
			get { return ApiResponse.LostList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.FavoriteSearches"/> of type <see cref="MyeBayFavoriteSearchListType"/>.
		/// </summary>
		public MyeBayFavoriteSearchListType FavoriteSearchesReturn
		{ 
			get { return ApiResponse.FavoriteSearches; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.FavoriteSellers"/> of type <see cref="MyeBayFavoriteSellerListType"/>.
		/// </summary>
		public MyeBayFavoriteSellerListType FavoriteSellersReturn
		{ 
			get { return ApiResponse.FavoriteSellers; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.SecondChanceOffer"/> of type <see cref="ItemTypeCollection"/>.
		/// </summary>
		public ItemTypeCollection SecondChanceOfferReturn
		{ 
			get { return ApiResponse.SecondChanceOffer; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.BidAssistantList"/> of type <see cref="BidGroupTypeCollection"/>.
		/// </summary>
        //public BidGroupTypeCollection BidAssistantListList
        //{ 
        //    get { return ApiResponse.BidAssistantList; }
        //}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.DeletedFromWonList"/> of type <see cref="PaginatedOrderTransactionArrayType"/>.
		/// </summary>
		public PaginatedOrderTransactionArrayType DeletedFromWonListReturn
		{ 
			get { return ApiResponse.DeletedFromWonList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.DeletedFromLostList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType DeletedFromLostListReturn
		{ 
			get { return ApiResponse.DeletedFromLostList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBayBuyingResponseType.UserDefinedList"/> of type <see cref="UserDefinedListTypeCollection"/>.
		/// </summary>
		public UserDefinedListTypeCollection UserDefinedListList
		{ 
			get { return ApiResponse.UserDefinedList; }
		}
		

		#endregion

		
	}
}

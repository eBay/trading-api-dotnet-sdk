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
	public class RespondToBestOfferCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public RespondToBestOfferCall()
		{
			ApiRequest = new RespondToBestOfferRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public RespondToBestOfferCall(ApiContext ApiContext)
		{
			ApiRequest = new RespondToBestOfferRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call enables the seller to accept or decline a buyer's Best Offer on an item, or make a counter offer to the buyer's Best Offer. A seller can decline multiple Best Offers with one call, but the seller cannot accept or counter offer multiple Best Offers with one call. Best Offers are not applicable to auction listings.
		/// <br/><br/>
		/// <span class="tablenote"><b>Note: </b>
		/// Historically, the Best Offer feature has not been available for auction listings, but beginning with Version 1027, sellers in the US, UK, and DE sites are able to offer the Best Offer feature in auction listings. The seller can offer Buy It Now or Best Offer in an auction listing, but not both.
		/// </span>
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The unique identifier of the listing to which the seller is responding to a Best Offer.
		/// </param>
		///
		/// <param name="BestOfferIDList">
		/// The unique identifier of a buyer's Best Offer for the order line item. This ID is created once the buyer makes a Best Offer. It is possible that a seller will get multiple Best Offers for an order line item, and if that seller would like to decline multiple/all of the Best Offers with one <b>RespondToBestOffer</b> call, the seller would pass in each of these identifiers in a separate <b>BestOfferID</b> field. However, the seller can only accept or counter offer one Best Offer at a time.
		/// </param>
		///
		/// <param name="Action">
		/// The enumeration value that the seller passes in to this field will control whether the seller accepts or make a counter offer to a single buyer's Best Offer, or declines one or more buyers' Best Offers. A seller can decline multiple Best Offers with one call, but the seller cannot accept or counter offer multiple Best Offers with one call.
		/// </param>
		///
		/// <param name="SellerResponse">
		/// This optional text field allows the seller to provide more details to the buyer about the action being taken against the buyer's Best Offer.
		/// 
		/// </param>
		///
		/// <param name="CounterOfferPrice">
		/// The seller inserts counter offer price into this field. This field is conditionally required and only applicable when the <b>Action</b> value is set to <code>Counter</code>, The counter offer price cannot exceed the Buy It Now price for a single quantity item. However, the dollar value in this field may exceed the Buy It Now price if the buyer is requesting or the seller is offering multiple quantity of the item (in a multiple-quantity listing). The quantity of the item must be specified in the <b>CounterOfferQuantity</b> field if the seller is making a counter offer.
		/// </param>
		///
		/// <param name="CounterOfferQuantity">
		/// The seller inserts the quantity of items in the counter offer into this field. This field is conditionally required and only applicable when the <b>Action</b> value is set to <code>Counter</code>, The counter offer price must be specified in the <b>CounterOfferPrice</b> field if the seller is making a counter offer. This price should reflect the quantity of items in the counter offer. So, if the seller's counter offer 'unit' price is 15 dollars, and the item quantity is '2', the dollar value passed into the <b>CounterOfferPrice</b> field would be <code>30.0</code>.
		/// </param>
		///
		public BestOfferTypeCollection RespondToBestOffer(string ItemID, StringCollection BestOfferIDList, BestOfferActionCodeType Action, string SellerResponse, AmountType CounterOfferPrice, int CounterOfferQuantity)
		{
			this.ItemID = ItemID;
			this.BestOfferIDList = BestOfferIDList;
			this.Action = Action;
			this.SellerResponse = SellerResponse;
			this.CounterOfferPrice = CounterOfferPrice;
			this.CounterOfferQuantity = CounterOfferQuantity;

			Execute();
			return ApiResponse.RespondToBestOffer;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public BestOfferTypeCollection RespondToBestOffer(string ItemID, StringCollection BestOfferIDList, BestOfferActionCodeType Action, string SellerResponse)
		{
			this.ItemID = ItemID;
			this.BestOfferIDList = BestOfferIDList;
			this.Action = Action;
			this.SellerResponse = SellerResponse;
			Execute();
			return this.RespondToBestOfferList;
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
		/// Gets or sets the <see cref="RespondToBestOfferRequestType"/> for this API call.
		/// </summary>
		public RespondToBestOfferRequestType ApiRequest
		{ 
			get { return (RespondToBestOfferRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="RespondToBestOfferResponseType"/> for this API call.
		/// </summary>
		public RespondToBestOfferResponseType ApiResponse
		{ 
			get { return (RespondToBestOfferResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToBestOfferRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToBestOfferRequestType.BestOfferID"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection BestOfferIDList
		{ 
			get { return ApiRequest.BestOfferID; }
			set { ApiRequest.BestOfferID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToBestOfferRequestType.Action"/> of type <see cref="BestOfferActionCodeType"/>.
		/// </summary>
		public BestOfferActionCodeType Action
		{ 
			get { return ApiRequest.Action; }
			set { ApiRequest.Action = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToBestOfferRequestType.SellerResponse"/> of type <see cref="string"/>.
		/// </summary>
		public string SellerResponse
		{ 
			get { return ApiRequest.SellerResponse; }
			set { ApiRequest.SellerResponse = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToBestOfferRequestType.CounterOfferPrice"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType CounterOfferPrice
		{ 
			get { return ApiRequest.CounterOfferPrice; }
			set { ApiRequest.CounterOfferPrice = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="RespondToBestOfferRequestType.CounterOfferQuantity"/> of type <see cref="int"/>.
		/// </summary>
		public int CounterOfferQuantity
		{ 
			get { return ApiRequest.CounterOfferQuantity; }
			set { ApiRequest.CounterOfferQuantity = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="RespondToBestOfferResponseType.RespondToBestOffer"/> of type <see cref="BestOfferTypeCollection"/>.
		/// </summary>
		public BestOfferTypeCollection RespondToBestOfferList
		{ 
			get { return ApiResponse.RespondToBestOffer; }
		}
		

		#endregion

		
	}
}

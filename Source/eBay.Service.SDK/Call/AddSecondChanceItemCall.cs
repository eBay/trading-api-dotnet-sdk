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
	public class AddSecondChanceItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddSecondChanceItemCall()
		{
			ApiRequest = new AddSecondChanceItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddSecondChanceItemCall(ApiContext ApiContext)
		{
			ApiRequest = new AddSecondChanceItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Used by the seller of an auction listing to provide a Second Chance Offer to one of that auction item's non-winning bidders. A Second Chance Offer is used by sellers whenever the seller was unable to complete the sale with the winning bidder because the bidder didn't pay, or if the auction listing ended without the Reserve Price being met, or if that seller has multiple identical items for sale and wants to give other bidders a chance to purchase the item.
		/// 
		/// 
		/// To get information on the bidders for a recently-ended auction listing, the seller can use the <b>GetAllBidders</b> call and pass the corresponding <b>ItemID</b> value into the call request.
		/// 
		/// 
		/// For more information on the specifics of Second Chance Offers, see the <a href="https://pages.ebay.com/help/sell/second_chance_offer.html" target="_blank">Making a Second Chance Offer</a> help page.
		/// </summary>
		/// 
		/// <param name="RecipientBidderUserID">
		/// This field is used to specify the bidder that is being offered the Second Chance Offer. The eBay User ID of the bidder is used in this field. Specify only one <b>RecipientBidderUserID</b> per call. If multiple users are specified, only the last one specified receives the offer. User ID values will be returned in the <b>Offer.User.UserID</b> field of the <b>GetAllBidders</b> call response.
		/// </param>
		///
		/// <param name="BuyItNowPrice">
		/// The amount the offer recipient must pay to purchase the item as a Second Chance Offer. This field should only be used when the original item was listed in an eBay Motors vehicle category (or in some categories on U.S. and international sites for high-priced items, such as items in many U.S. and Canada Business and Industrial categories) and it ended unsold because the reserve price was not met. Otherwise, eBay establishes the price and no price should be submitted. The price offered to the Second Chance Offer recipient is generally the highest bid that the user made on the original listing.
		/// </param>
		///
		/// <param name="Duration">
		/// This enumeration value indicates the length of time (in days) that the Second Chance Offer will be available to the recipient. Upon receiving the Second Chance Offer, the recipient bidder will have this many days to accept the offer before the offer expires. One of the values in <b>SecondChanceOfferDurationCodeType</b> must be used.
		/// </param>
		///
		/// <param name="ItemID">
		/// This field is used to identify the original auction listing through its unique identifier (Item ID). Upon a successful call, the Second Chance Offer will be identified by a new <b>ItemID</b> in the response.
		/// </param>
		///
		/// <param name="SellerMessage">
		/// This optional field is used to provide a message to the recipient of the Second Chance Offer. This message cannot contain HTML, asterisks, or quotes. The content in this field will be included in the Second Chance Offer email that is sent to the recipient.
		/// </param>
		///
		public string AddSecondChanceItem(string RecipientBidderUserID, AmountType BuyItNowPrice, SecondChanceOfferDurationCodeType Duration, string ItemID, string SellerMessage)
		{
			this.RecipientBidderUserID = RecipientBidderUserID;
			this.BuyItNowPrice = BuyItNowPrice;
			this.Duration = Duration;
			this.ItemID = ItemID;
			this.SellerMessage = SellerMessage;

			Execute();
			return ApiResponse.ItemID;
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Execute()
		{
			base.Execute();
			if (Item != null)
			{
				Item.ItemID = ApiResponse.ItemID;

				if (Item.ListingDetails == null)
					Item.ListingDetails = new ListingDetailsType();
				Item.ListingDetails.StartTime = ApiResponse.StartTime;
				Item.ListingDetails.EndTime = ApiResponse.EndTime;
				Item.ListingDetails.SecondChanceOriginalItemID = ApiRequest.ItemID;
			}
		}

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void AddSecondChanceItem(string ItemID, string ListingDuration, string RecipientBidderUserID)
		{
			ItemType item = new ItemType();
			item.ItemID = ItemID;
			item.ListingDuration = ListingDuration;
			AddSecondChanceItem(item, RecipientBidderUserID);
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void AddSecondChanceItem(ItemType Item, string RecipientBidderUserID)
		{
			this.Item = Item;
			this.RecipientBidderUserID = RecipientBidderUserID;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void  AddSecondChanceItem(string RecipientBidderUserID, AmountType BuyItNowPrice, bool CopyEmailToSeller, SecondChanceOfferDurationCodeType Duration, string ItemID)
		{
			this.RecipientBidderUserID = RecipientBidderUserID;
			this.BuyItNowPrice = BuyItNowPrice;
			this.Duration = Duration;
			this.ItemID = ItemID;

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
		/// Gets or sets the <see cref="AddSecondChanceItemRequestType"/> for this API call.
		/// </summary>
		public AddSecondChanceItemRequestType ApiRequest
		{ 
			get { return (AddSecondChanceItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddSecondChanceItemResponseType"/> for this API call.
		/// </summary>
		public AddSecondChanceItemResponseType ApiResponse
		{ 
			get { return (AddSecondChanceItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddSecondChanceItemRequestType.RecipientBidderUserID"/> of type <see cref="string"/>.
		/// </summary>
		public string RecipientBidderUserID
		{ 
			get { return ApiRequest.RecipientBidderUserID; }
			set { ApiRequest.RecipientBidderUserID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddSecondChanceItemRequestType.BuyItNowPrice"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType BuyItNowPrice
		{ 
			get { return ApiRequest.BuyItNowPrice; }
			set { ApiRequest.BuyItNowPrice = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddSecondChanceItemRequestType.Duration"/> of type <see cref="SecondChanceOfferDurationCodeType"/>.
		/// </summary>
		public SecondChanceOfferDurationCodeType Duration
		{ 
			get { return ApiRequest.Duration; }
			set { ApiRequest.Duration = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddSecondChanceItemRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddSecondChanceItemRequestType.SellerMessage"/> of type <see cref="string"/>.
		/// </summary>
		public string SellerMessage
		{ 
			get { return ApiRequest.SellerMessage; }
			set { ApiRequest.SellerMessage = value; }
		}
		/// <summary>
		/// 
		/// </summary>
		public ItemType Item
		{ 
			get	{  return mItem; }
			set 
			{ 
				ApiRequest.ItemID = value.ItemID;
		
				ApiRequest.Duration  = (SecondChanceOfferDurationCodeType) Enum.Parse(typeof(SecondChanceOfferDurationCodeType), value.ListingDuration, true);
				if (value.BuyItNowPrice != null )
					ApiRequest.BuyItNowPrice = value.BuyItNowPrice;;

				mItem = value; 
			}
		}

		
 		/// <summary>
		/// Gets the returned <see cref="AddSecondChanceItemResponseType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemIDResult
		{ 
			get { return ApiResponse.ItemID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddSecondChanceItemResponseType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiResponse.StartTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddSecondChanceItemResponseType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiResponse.EndTime; }
		}
		

		#endregion

		#region Private Fields
		private ItemType mItem;
		#endregion
		
	}
}

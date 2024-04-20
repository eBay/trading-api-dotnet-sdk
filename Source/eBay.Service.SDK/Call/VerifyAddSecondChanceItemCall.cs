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
	public class VerifyAddSecondChanceItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public VerifyAddSecondChanceItemCall()
		{
			ApiRequest = new VerifyAddSecondChanceItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public VerifyAddSecondChanceItemCall(ApiContext ApiContext)
		{
			ApiRequest = new VerifyAddSecondChanceItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Simulates the creation of a new Second Chance Offer
		/// listing of an item without actually creating a listing.
		/// </summary>
		/// 
		/// <param name="RecipientBidderUserID">
		/// Specifies the bidder from the original, ended listing to whom the seller
		/// is extending the second chance offer. Specify only one
		/// <b>RecipientBidderUserID</b> per call. If multiple users are specified (each in a
		/// <b>RecipientBidderUserID</b> node), only the last one specified receives the
		/// offer.
		/// </param>
		///
		/// <param name="BuyItNowPrice">
		/// Specifies the amount the offer recipient must pay to purchase the item
		/// from the Second Chance Offer listing. Use only when the original item was
		/// an eBay Motors (or in some categories on U.S. and international sites for
		/// high-priced items, such as items in many U.S. and Canada Business and
		/// Industrial categories) and it ended unsold because the reserve price was
		/// not met. Call fails with an error for any other item conditions.
		/// </param>
		///
		/// <param name="Duration">
		/// Specifies the length of time the Second Chance Offer listing will be
		/// active. The recipient bidder has that much time to purchase the item or
		/// the listing expires.
		/// </param>
		///
		/// <param name="ItemID">
		/// This field is used to identify the recently-ended auction listing for which a Second Chance Offer will be made to one of the non-winning bidders on the recently-ended auction listing.
		/// </param>
		///
		/// <param name="SellerMessage">
		/// Message content. Cannot contain HTML, asterisks, or quotes. This content
		/// is included in the Second Chance Offer email sent to the recipient, which
		/// can be retrieved with <b>GetMyMessages</b>.
		/// </param>
		///
		public DateTime VerifyAddSecondChanceItem(string RecipientBidderUserID, AmountType BuyItNowPrice, SecondChanceOfferDurationCodeType Duration, string ItemID, string SellerMessage)
		{
			this.RecipientBidderUserID = RecipientBidderUserID;
			this.BuyItNowPrice = BuyItNowPrice;
			this.Duration = Duration;
			this.ItemID = ItemID;
			this.SellerMessage = SellerMessage;

			Execute();
			return ApiResponse.StartTime;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void VerifyAddSecondChanceItem(ItemType Item, string RecipientBidderUserID)
		{
			this.Item = Item;
			this.RecipientBidderUserID = RecipientBidderUserID;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void VerifyAddSecondChanceItem(string RecipientBidderUserID, AmountType BuyItNowPrice, bool CopyEmailToSeller, SecondChanceOfferDurationCodeType Duration, string ItemID)
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
		/// Gets or sets the <see cref="VerifyAddSecondChanceItemRequestType"/> for this API call.
		/// </summary>
		public VerifyAddSecondChanceItemRequestType ApiRequest
		{ 
			get { return (VerifyAddSecondChanceItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="VerifyAddSecondChanceItemResponseType"/> for this API call.
		/// </summary>
		public VerifyAddSecondChanceItemResponseType ApiResponse
		{ 
			get { return (VerifyAddSecondChanceItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyAddSecondChanceItemRequestType.RecipientBidderUserID"/> of type <see cref="string"/>.
		/// </summary>
		public string RecipientBidderUserID
		{ 
			get { return ApiRequest.RecipientBidderUserID; }
			set { ApiRequest.RecipientBidderUserID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyAddSecondChanceItemRequestType.BuyItNowPrice"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType BuyItNowPrice
		{ 
			get { return ApiRequest.BuyItNowPrice; }
			set { ApiRequest.BuyItNowPrice = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyAddSecondChanceItemRequestType.Duration"/> of type <see cref="SecondChanceOfferDurationCodeType"/>.
		/// </summary>
		public SecondChanceOfferDurationCodeType Duration
		{ 
			get { return ApiRequest.Duration; }
			set { ApiRequest.Duration = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyAddSecondChanceItemRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyAddSecondChanceItemRequestType.SellerMessage"/> of type <see cref="string"/>.
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
			get { return mItem; }
			set { mItem = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddSecondChanceItemResponseType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiResponse.StartTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddSecondChanceItemResponseType.EndTime"/> of type <see cref="DateTime"/>.
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

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
	public class LeaveFeedbackCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public LeaveFeedbackCall()
		{
			ApiRequest = new LeaveFeedbackRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public LeaveFeedbackCall(ApiContext ApiContext)
		{
			ApiRequest = new LeaveFeedbackRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a buyer and seller to leave Feedback for their order partner at the
		/// conclusion of a successful order.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier for an eBay listing. A listing can have multiple
		/// order line items, but only one <b>ItemID</b>. Unless an
		/// <b>OrderLineItemID</b> is specified in the <b>LeaveFeedback</b> request, the <b>ItemID</b> is
		/// required along with the <b>TargetUser</b> to identify an order line item
		/// existing between the caller and the <b>TargetUser</b> that requires feedback. A
		/// Feedback comment will be posted for this order line item. If there are
		/// multiple order line items between the two order partners that still
		/// require feedback, the <b>TransactionID</b> will also be required to isolate the
		/// targeted order line item. Feedback cannot be left for order line items
		/// with creation dates more than 60 days in the past.
		/// </param>
		///
		/// <param name="CommentText">
		/// Textual comment that explains, clarifies, or justifies the feedback
		/// score specified in <b>CommentType</b>.
		/// 
		/// </param>
		///
		/// <param name="CommentType">
		/// Score for the Feedback being left. May be Positive, Neutral, or Negative.
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// Sellers can not leave neutral or negative feedback for buyers. In addition, buyers can not leave neutral or negative feedback within 7 days from the completion of the order for active Power Sellers who have been on eBay for 12 months.
		/// </span>
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for an eBay order line item. If there
		/// are multiple order line items between the two order partners that still
		/// require Feedback, the <b>TransactionID</b> is required along with the
		/// corresponding <b>ItemID</b> and <b>TargetUser</b> to isolate the targeted order line
		/// item. If an <b>OrderLineItemID</b> is included in the response to identify a
		/// specific order line item, none of the preceding fields (<b>ItemID</b>,
		/// <b>TransactionID</b>, <b>TargetUser</b>) are needed. Feedback cannot be left for order
		/// line items with creation dates more than 60 days in the past.
		/// </param>
		///
		/// <param name="TargetUser">
		/// Specifies the recipient user about whom the Feedback is being left.
		/// </param>
		///
		/// <param name="SellerItemRatingDetailArrayList">
		/// Container for detailed seller ratings (DSRs). If a buyer is providing DSRs, they are specified in this container. Sellers have access to the number of ratings they've received, as well as to the averages of the DSRs they've received in each DSR area (i.e., to the average of ratings in the item-description area, etc.).
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// <b>OrderLineItemID</b> is a unique identifier for an eBay order line item. If an <b>OrderLineItemID</b> is included in
		/// the request, the <b>ItemID</b>, <b>TransactionID</b>, and <b>TargetUser</b> fields are not
		/// required. Feedback cannot be left for order line items with creation
		/// dates more than 60 days in the past.
		/// 
		/// </param>
		///
		/// <param name="ItemArrivedWithinEDDType">
		/// This field or the <b>ItemDeliveredWithinEDD</b> field should be included if it is the buyer leaving feedback for the seller. This field will inform eBay about whether or not the buyer received the order line item within the estimated delivery date, which is established once a buyer purchases or commits to buy an item.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> A new "Late shipment rate" metric became a new component of Seller Standards beginning in February 2016. On-time shipping means that the seller shipped the item before the "handling time" expired and/or the item was received by the buyer within the estimated delivery date window, which is established once the buyer pays for the order line item. Previously, a seller's account could be dinged just for getting a low rating for the "shippping time" Detailed Seller Rating. </span>
		/// </param>
		///
		/// <param name="ItemDeliveredWithinEDD">
		/// This field or the <b>ItemArrivedWithinEDDType</b> field should be included if it is the buyer leaving feedback for the seller. This field will inform eBay about whether or not the buyer received the order line item within the estimated delivery date window, which is established once a buyer purchases or commits to buy an item. The value of this field is set to <code>true</code> if the item did arrive within the estimated delivery date, or <code>false</code> if the item arrived past the estimated delivery date.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> A new "Late shipment rate" metric became a new component of Seller Standards beginning in February 2016. On-time shipping means that the seller shipped the item before the "handling time" expired and/or the item was received by the buyer within the estimated delivery date window, which is established once the buyer pays for the order line item. Previously, a seller's account could be dinged just for getting a low rating for the "shippping time" Detailed Seller Rating. </span>
		/// </param>
		///
		public string LeaveFeedback(string ItemID, string CommentText, CommentTypeCodeType CommentType, string TransactionID, string TargetUser, ItemRatingDetailsTypeCollection SellerItemRatingDetailArrayList, string OrderLineItemID, ItemArrivedWithinEDDCodeType ItemArrivedWithinEDDType, bool ItemDeliveredWithinEDD)
		{
			this.ItemID = ItemID;
			this.CommentText = CommentText;
			this.CommentType = CommentType;
			this.TransactionID = TransactionID;
			this.TargetUser = TargetUser;
			this.SellerItemRatingDetailArrayList = SellerItemRatingDetailArrayList;
			this.OrderLineItemID = OrderLineItemID;
			this.ItemArrivedWithinEDDType = ItemArrivedWithinEDDType;
			this.ItemDeliveredWithinEDD = ItemDeliveredWithinEDD;

			Execute();
			return ApiResponse.FeedbackID;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public string LeaveFeedback(string TargetUser, string ItemID, string TransactionID, CommentTypeCodeType CommentType, string CommentText)
		{
			this.TargetUser = TargetUser;
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.CommentType = CommentType;
			this.CommentText = CommentText;
			Execute();
			return FeedbackID;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public string LeaveFeedback(string TargetUser, string ItemID, CommentTypeCodeType CommentType, string CommentText)
		{
			this.TargetUser = TargetUser;
			this.ItemID = ItemID;
			this.CommentType = CommentType;
			this.CommentText = CommentText;
			Execute();
			return FeedbackID;
		}
		
				
		///
		/// For backward compatibility with old wrappers
		/// 
		///
		public string LeaveFeedback(string ItemID, string CommentText, CommentTypeCodeType CommentType, string TransactionID, string TargetUser)
		{
			this.ItemID = ItemID;
			this.CommentText = CommentText;
			this.CommentType = CommentType;
			this.TransactionID = TransactionID;
			this.TargetUser = TargetUser;

			Execute();
			return ApiResponse.FeedbackID;
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
		/// Gets or sets the <see cref="LeaveFeedbackRequestType"/> for this API call.
		/// </summary>
		public LeaveFeedbackRequestType ApiRequest
		{ 
			get { return (LeaveFeedbackRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="LeaveFeedbackResponseType"/> for this API call.
		/// </summary>
		public LeaveFeedbackResponseType ApiResponse
		{ 
			get { return (LeaveFeedbackResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.CommentText"/> of type <see cref="string"/>.
		/// </summary>
		public string CommentText
		{ 
			get { return ApiRequest.CommentText; }
			set { ApiRequest.CommentText = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.CommentType"/> of type <see cref="CommentTypeCodeType"/>.
		/// </summary>
		public CommentTypeCodeType CommentType
		{ 
			get { return ApiRequest.CommentType; }
			set { ApiRequest.CommentType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.TargetUser"/> of type <see cref="string"/>.
		/// </summary>
		public string TargetUser
		{ 
			get { return ApiRequest.TargetUser; }
			set { ApiRequest.TargetUser = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.SellerItemRatingDetailArray"/> of type <see cref="ItemRatingDetailsTypeCollection"/>.
		/// </summary>
		public ItemRatingDetailsTypeCollection SellerItemRatingDetailArrayList
		{ 
			get { return ApiRequest.SellerItemRatingDetailArray; }
			set { ApiRequest.SellerItemRatingDetailArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.ItemArrivedWithinEDDType"/> of type <see cref="ItemArrivedWithinEDDCodeType"/>.
		/// </summary>
		public ItemArrivedWithinEDDCodeType ItemArrivedWithinEDDType
		{ 
			get { return ApiRequest.ItemArrivedWithinEDDType; }
			set { ApiRequest.ItemArrivedWithinEDDType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="LeaveFeedbackRequestType.ItemDeliveredWithinEDD"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ItemDeliveredWithinEDD
		{ 
			get { return ApiRequest.ItemDeliveredWithinEDD; }
			set { ApiRequest.ItemDeliveredWithinEDD = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="LeaveFeedbackResponseType.FeedbackID"/> of type <see cref="string"/>.
		/// </summary>
		public string FeedbackID
		{ 
			get { return ApiResponse.FeedbackID; }
		}
		

		#endregion

		
	}
}

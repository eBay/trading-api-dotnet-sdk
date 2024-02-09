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
	public class CompleteSaleCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public CompleteSaleCall()
		{
			ApiRequest = new CompleteSaleRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public CompleteSaleCall(ApiContext ApiContext)
		{
			ApiRequest = new CompleteSaleRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to perform various tasks with a single or multiple line item order. Tasks available with this call include marking the order as paid, marking the order as shipped, providing shipment tracking details to the buyer, and leaving feedback for the buyer.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier for an eBay listing. An <b>ItemID</b> value can be paired up with a corresponding <b>TransactionID</b> value in a <b>CompleteSale</b> request to identify a single order line item. Alternatively, the <b>OrderLineItemID</b> value for the order line item can be used.
		/// 
		/// Unless an <b>OrderLineItemID</b> value is used to identify a single order line item, or the <b>OrderID</b> value is used to identify a single or multiple line item order, the <b>ItemID</b>/<b>TransactionID</b> pair must be specified. To perform an action on an entire multiple line item order, the <b>OrderID</b> field must be used. If an <b>OrderID</b> or <b>OrderLineItemID</b> value is specified, an <b>ItemID</b>/<b>TransactionID</b> pair will be ignored (if present in the same request).
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for a sales transaction. A <b>TransactionID</b> identifier is created once there is a commitment to buy (bidder wins the auction, buyer clicks buy button, or buyer purchases item through <b>PlaceOffer</b> call). The
		/// <b>TransactionID</b> can be paired up with the corresponding <b>ItemID</b> value in a <b>CompleteSale</b> request to identify a single order line item. Alternatively, the <b>OrderLineItemID</b> value for the order line item can be used.
		/// 
		/// Unless an <b>OrderLineItemID</b> value is used to identify a single order line item, or the <b>OrderID</b> value is used to identify a single or multiple line item order, the <b>ItemID</b>/<b>TransactionID</b> pair must be specified. To perform an action on an entire multiple line item order, the <b>OrderID</b> field must be used. If an <b>OrderID</b> or <b>OrderLineItemID</b> value is specified, an <b>ItemID</b>/<b>TransactionID</b> pair will be ignored (if present in the same request).
		/// </param>
		///
		/// <param name="FeedbackInfo">
		/// This container is used by the seller to leave feedback for the buyer for the order line item identified in the call request. The seller must include and specify all fields of this type, including the buyer's eBay User ID, the Feedback rating (a seller can only leave a buyer a 'Positive' rating), and a comment, which helps justify the Feedback rating. The eBay User ID must match the buyer who bought the order line item, or an error will occur. An error will also occur if Feedback has already been left for the buyer (either through API or the Web flow).
		/// 
		/// To determine if Feedback has already been left for an order line item, you can call <b class="con">GetFeedback</b>, passing in the <b class="con">OrderLineItemID</b> value in the call request.
		/// 
		/// <span class="tablenote"><b>Note: </b> Feedback entries are submitted at the order line item level, so either an <b>OrderLineItemID</b> value or an <b>ItemID</b>/<b>TransactionID</b> pair should be specified to identify the order line item (and not an <b>OrderLineItemID</b> value). To leave Feedback for all line items in a multiple line item order, the seller would need a separate <b>CompleteSale</b> request for each order line item.
		/// </span>
		/// </param>
		///
		/// <param name="Shipped">
		/// The seller includes and sets this field to true if the order or order line item has been shipped. If the call is successful, the order line item(s) are marked as Shipped in My eBay.
		/// 
		/// If the seller includes and sets this field to false, the order or order line item are marked (or remain) as 'Not Shipped' in eBay's system.
		/// 
		/// If this field is not included, the shipped status of the order or order line item remain unchanged in My eBay.
		/// 
		/// If shipment tracking information is provided for an order or order line item through the <b>Shipment</b> container in the same request, the <b>Shipped</b> status is set to <code>true</code> automatically, and the <b>Shipped</b> field is not necessary.
		/// </param>
		///
		/// <param name="Paid">
		/// The seller includes and sets this field to true if the order has been
		/// paid for by the buyer. If the call is successful, the order line item(s)
		/// are marked as 'Paid' in eBay's system.
		/// 
		/// If the seller includes and sets this field to <code>false</code>, the order line item(s) are marked (or remain) as 'Not Paid' in eBay's system.
		/// 
		/// If this field is not included, the paid status of the order line item(s) remain unchanged in eBay's system.
		/// </param>
		///
		/// <param name="ListingType">
		/// <span class="tablenote"><b>Note: </b> DO NOT USE THIS FIELD. Previously, this field's only purpose was to classify the order to be updated as a Half.com order. However, since the Half.com site has been shut down, this field is no longer applicable.
		/// </span>
		/// </param>
		///
		/// <param name="Shipment">
		/// Container consisting of shipment tracking information, shipped time, and an optional text field to provide additional details to the buyer. Setting the tracking number and shipping carrier automatically marks the order line item as shipped and the <b>Shipped</b> field is not necessary.
		/// 
		/// If you supply <b>ShipmentTrackingNumber</b>, you must also supply <b>ShippingCarrierUsed</b>; otherwise you will get an error.
		/// 
		/// To modify the shipping tracking number and/or shipping carrier, supply the new number in the <b>ShipmentTrackingNumber</b> field or supply the value for <b>ShippingCarrierUsed</b>, or both. The old number and carrier are deleted and the new ones are added.
		/// 
		/// To simply delete the current tracking details altogether, supply empty <b>Shipment</b> tags.
		///  
		/// <span class="tablenote"><b>Note:</b> Top-Rated sellers must have a record of uploading shipment tracking information (through site or through API) for at least 95 percent of their order line items (purchased by U.S. buyers) to keep their status as Top-Rated sellers. For more information on the requirements to becoming a Top-Rated Seller, see the <a href="http://pages.ebay.com/help/sell/top-rated.html">Becoming a Top-Rated Seller and qualifying for Top-Rated Plus</a> customer support page. </span> 
		/// </param>
		///
		/// <param name="OrderID">
		/// A unique identifier for an eBay order. An <b>OrderID</b> value should only be used in a <b>CompleteSale</b> call for a single line item order. For a multiple line item order, the <b>OrderLineItemID</b> or <b>ItemID</b>/<b>TransactionID</b> pair must be used to identify an order line item within the order.
		/// 
		/// <b>OrderID</b> overrides an <b>OrderLineItemID</b> or <b>ItemID</b>/<b>TransactionID</b> pair if these fields are also specified in the same request.
		/// 
		/// <span class="tablenote"><b>Note: </b> As of June 2019, eBay has changed the format of order identifier values. The new format is a non-parsable string, globally unique across all eBay marketplaces, and consistent for both single line item and multiple line item orders. Unlike in the past, instead of just being known and exposed to the seller, these unique order identifiers will also be known and used/referenced by the buyer and eBay customer support.
		/// 
		/// For developers and sellers who are already integrated with the Trading API's order management calls, this change shouldn't impact your integration unless you parse the existing order identifiers (e.g., <b>OrderID</b> or <b>OrderLineItemID</b>), or otherwise infer meaning from the format (e.g., differentiating between a single line item order versus a multiple line item order). Because we realize that some integrations may have logic that is dependent upon the old identifier format, eBay is rolling out this Trading API change with version control to support a transition period of approximately 9 months before applications must switch to the new format completely.
		/// 
		/// During the transition period, for developers/sellers using a Trading WSDL older than Version 1113, they can use the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header in API calls to control whether the new or old <b>OrderID</b> format is returned in call response payloads. To get the new <b>OrderID</b> format, the value of the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header must be set to <code>1113</code>. During the transition period and even after, the new and old <b>OrderID</b> formats will still be supported/accepted in all Trading API call request payloads. After the transition period (which will be announced), only the new <b>OrderID</b> format will be returned in all Trading API call response payloads, regardless of the Trading WSDL version used or specified compatibility level.
		/// </span>
		/// 
		/// <span class="tablenote"><b>Note: </b> For sellers integrated with the new order ID format, please note that the identifier for an order will change as it goes from unpaid to paid status. Sellers can check to see if an order has been paid by looking for a value of 'Complete' in the <b>CheckoutStatus.Status</b> field in the response of <b>GetOrders</b> or <b>GetOrderTransactions</b> call, or in the <b>Status.CompleteStatus</b> field in the response of <b>GetItemTransactions</b> or <b>GetSellerTransactions</b> call. Sellers should  not fulfill orders until buyer has made payment. When using a <b>CompleteSale</b> call, either of these order IDs (paid or unpaid status) can be used to update an order. Similarly, either of these order IDs (paid or unpaid status) can be used in <b>GetOrders</b> or <b>GetOrderTransactions</b> call to retrieve specific order(s).
		/// </span>
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// A unique identifier for an eBay order line item. <b>OrderLineItemID</b> values are returned (at the order line item level) in Trading API's order management calls. This identifier is created once there is a commitment to buy (bidder wins the auction, buyer clicks buy button, or buyer purchases item through <b>PlaceOffer</b> call). An <b>OrderLineItemID</b> value can be used in a <b>CompleteSale</b> request to identify a line item within an order. Alternatively, an <b>ItemID</b>/<b>TransactionID</b> pair can also be used to identify a line item.
		/// 
		/// Unless an <b>ItemID</b>/<b>TransactionID</b> pair is used to identify an order line
		/// item, or an <b>OrderID</b> value is used to identify an order, the <b>OrderLineItemID</b> must be specified. If <b>OrderLineItemID</b> is specified, the <b>ItemID</b>/<b>TransactionID</b> pair are
		/// ignored if present in the same request.
		/// </param>
		///
		public void CompleteSale(string ItemID, string TransactionID, FeedbackInfoType FeedbackInfo, bool Shipped, bool Paid, ListingTypeCodeType ListingType, ShipmentType Shipment, string OrderID, string OrderLineItemID)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.FeedbackInfo = FeedbackInfo;
			this.Shipped = Shipped;
			this.Paid = Paid;
			this.ListingType = ListingType;
			this.Shipment = Shipment;
			this.OrderID = OrderID;
			this.OrderLineItemID = OrderLineItemID;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void CompleteSale(string ItemID, string TransactionID, bool Paid, bool Shipped, FeedbackInfoType FeedbackInfo)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.Paid = Paid;
			this.Shipped = Shipped;
			this.FeedbackInfo = FeedbackInfo;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void CompleteSale(string ItemID, string TransactionID, bool Paid, bool Shipped)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.Paid = Paid;
			this.Shipped = Shipped;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>

		public void CompleteSale(string ItemID, string TransactionID, FeedbackInfoType FeedbackInfo, bool Shipped, bool Paid)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.FeedbackInfo = FeedbackInfo;
			this.Shipped = Shipped;
			this.Paid = Paid;

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
		/// Gets or sets the <see cref="CompleteSaleRequestType"/> for this API call.
		/// </summary>
		public CompleteSaleRequestType ApiRequest
		{ 
			get { return (CompleteSaleRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="CompleteSaleResponseType"/> for this API call.
		/// </summary>
		public CompleteSaleResponseType ApiResponse
		{ 
			get { return (CompleteSaleResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.FeedbackInfo"/> of type <see cref="FeedbackInfoType"/>.
		/// </summary>
		public FeedbackInfoType FeedbackInfo
		{ 
			get { return ApiRequest.FeedbackInfo; }
			set { ApiRequest.FeedbackInfo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.Shipped"/> of type <see cref="bool"/>.
		/// </summary>
		public bool Shipped
		{ 
			get { return ApiRequest.Shipped; }
			set { ApiRequest.Shipped = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.Paid"/> of type <see cref="bool"/>.
		/// </summary>
		public bool Paid
		{ 
			get { return ApiRequest.Paid; }
			set { ApiRequest.Paid = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.ListingType"/> of type <see cref="ListingTypeCodeType"/>.
		/// </summary>
		public ListingTypeCodeType ListingType
		{ 
			get { return ApiRequest.ListingType; }
			set { ApiRequest.ListingType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.Shipment"/> of type <see cref="ShipmentType"/>.
		/// </summary>
		public ShipmentType Shipment
		{ 
			get { return ApiRequest.Shipment; }
			set { ApiRequest.Shipment = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="CompleteSaleRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
		

		#endregion

		
	}
}

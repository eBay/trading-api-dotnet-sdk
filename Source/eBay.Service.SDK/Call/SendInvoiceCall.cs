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
	public class SendInvoiceCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SendInvoiceCall()
		{
			ApiRequest = new SendInvoiceRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SendInvoiceCall(ApiContext ApiContext)
		{
			ApiRequest = new SendInvoiceRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to send an order invoice to a buyer. Where applicable, updates
		/// to shipping, payment methods, and sales tax made in this request are applied to
		/// the specified order as a whole and to the individual order line items whose data
		/// are stored in individual <b>Transaction</b> objects.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier for an eBay listing. Unless <b>OrderID</b> or
		/// <b>OrderLineItemID</b> is provided in the request, the <b>ItemID</b> (or <b>SKU</b>) is
		/// required and must be paired with the corresponding <b>TransactionID</b> to
		/// identify a single line item order. For a multiple line item order, <b>OrderID</b> should be used.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for an eBay sales transaction. This identifier is created once there is a commitment from a buyer to purchase an item. Since an auction listing can only have one sales transaction during the duration of the listing, the <b>TransactionID</b> value for auction listings is always <code>0</code>. Unless <b>OrderID</b> or <b>OrderLineItemID</b> is provided in the request, the <b>TransactionID</b> is required and must be paired with the corresponding <b>ItemID</b> to identify a single line item order. For a multiple line item order, <b>OrderID</b> should be used.
		/// </param>
		///
		/// <param name="OrderID">
		/// A unique identifier that identifies a single line item or multiple line
		/// item order.
		/// 
		/// Unless the <b>ItemID</b> (or SKU) and corresponding <b>TransactionID</b>, or the <b>OrderLineItemID</b> is provided in the request to identify a single line item order, the <b>OrderID</b> must be specified. If <b>OrderID</b> is specified, <b>OrderLineItemID</b>, <b>ItemID</b>, <b>TransactionID</b>, and <b>SKU</b> are ignored if present in the same request.
		/// 
		/// <span class="tablenote"><b>Note: </b> As of June 2019, eBay has changed the format of order identifier values. The new format is a non-parsable string, globally unique across all eBay marketplaces, and consistent for both single line item and multiple line item orders. Unlike in the past, instead of just being known and exposed to the seller, these unique order identifiers will also be known and used/referenced by the buyer and eBay customer support.
		/// 
		/// For developers and sellers who are already integrated with the Trading API's order management calls, this change shouldn't impact your integration unless you parse the existing order identifiers (e.g., <b>OrderID</b> or <b>OrderLineItemID</b>), or otherwise infer meaning from the format (e.g., differentiating between a single line item order versus a multiple line item order). Because we realize that some integrations may have logic that is dependent upon the old identifier format, eBay is rolling out this Trading API change with version control to support a transition period of approximately 9 months before applications must switch to the new format completely.
		/// 
		/// During the transition period, for developers/sellers using a Trading WSDL older than Version 1113, they can use the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header in API calls to control whether the new or old <b>OrderID</b> format is returned in call response payloads. To get the new <b>OrderID</b> format, the value of the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header must be set to <code>1113</code>. During the transition period and even after, the new and old <b>OrderID</b> formats will still be supported/accepted in all Trading API call request payloads. After the transition period (which will be announced), only the new <b>OrderID</b> format will be returned in all Trading API call response payloads, regardless of the Trading WSDL version used or specified compatibility level.
		/// </span>
		/// 
		/// <span class="tablenote"><b>Note: </b> For sellers integrated with the new order ID format, please note that the identifier for an order will change as it goes from unpaid to paid status. Sellers can check to see if an order has been paid by looking for a value of 'Complete' in the <b>CheckoutStatus.Status</b> field in the response of <b>GetOrders</b> or <b>GetOrderTransactions</b> call, or in the <b>Status.CompleteStatus</b> field in the response of <b>GetItemTransactions</b> or <b>GetSellerTransactions</b> call. When using a <b>SendInvoice</b> call, either of these order IDs (paid or unpaid status) can be used to update an order. Similarly, either of these order IDs (paid or unpaid status) can be used in <b>GetOrders</b> or <b>GetOrderTransactions</b> call to retrieve specific order(s).
		/// </span>
		/// </param>
		///
		/// <param name="InternationalShippingServiceOptionsList">
		/// If the buyer has an International shipping address, use this container
		/// to offer up to four International shipping services (or five if one of them is a Global Shipping Program service). If International
		/// shipping services are offered, (domestic) <b>ShippingServiceOptions</b> should
		/// not be included in the request.
		/// 
		/// </param>
		///
		/// <param name="ShippingServiceOptionsList">
		/// If the buyer has a domestic shipping address, use this container
		/// to offer up to four domestic shipping services. If domestic
		/// shipping services are offered, <b>InternationalShippingServiceOptions</b> should
		/// not be included in the request.
		/// 
		/// </param>
		///
		/// <param name="SalesTax">
		/// This container is used if the seller wishes to apply sales tax to the order. The amount of sales tax applied to the order is dependent on the sales tax rate in the buyer's state and whether sales tax is being applied to the cost of the order only or the cost of the order plus shipping and handling.
		/// 
		/// <span class="tablenote"><b>Note: </b> As of January 1, 2019, buyers in some US states will automatically be charged sales tax for eBay purchases. eBay will collect and remit this sales tax to the proper taxing authority on the buyer's behalf. So, if the order's buyer is in a state that is subject to 'eBay Collect and Remit Tax', the seller should not send the buyer any sales tax information, since eBay will be handling the sales tax instead without buyer's assistance. For a list of the US states that will become subject to 'eBay Collect and Remit' (and effective dates), see the <a href="https://www.ebay.com/help/selling/fees-credits-invoices/taxes-import-charges?id=4121#section4">eBay sales tax collection</a> help topic.
		/// </span>
		/// </param>
		///
		/// <param name="InsuranceOption">
		/// This field is no longer applicable as it is no longer possible for a seller to offer a buyer shipping insurance.
		/// </param>
		///
		/// <param name="InsuranceFee">
		/// This field is no longer applicable as it is no longer possible for a seller to offer a buyer shipping insurance.
		/// </param>
		///
		/// <param name="PaymentMethodsList">
		/// This optional field allows a US or German seller to add specific payment methods that were not in the original listing. The only valid values for this field are 'PayPal' for a US listing (or 'CreditCard' for sellers opted in to eBay Managed Payments), or 'MoneyXferAcceptedInCheckout' (CIP+) for a listing on the Germany site.
		/// </param>
		///
		/// <param name="PayPalEmailAddress">
		/// If the <b>PaymentMethods</b> field is used and set to <code>PayPal</code>, the seller provides his/her PayPal email address in this field.
		/// </param>
		///
		/// <param name="CheckoutInstructions">
		/// This field allows the seller to provide a message or instructions
		/// regarding checkout/payment, or the return policy.
		/// </param>
		///
		/// <param name="EmailCopyToSeller">
		/// This field is included and set to <code>true</code> if the seller wishes to receive an email copy of the invoice sent to the buyer.
		/// </param>
		///
		/// <param name="CODCost">
		/// This dollar value indicates the money due from the buyer upon delivery of the item.
		/// 
		/// This field should only be specified in the <b>SendInvoice</b> request if 'COD'
		/// (cash-on-delivery) was the payment method selected by the buyer and it is included
		/// as the <b>PaymentMethods</b> value in the same request.
		/// </param>
		///
		/// <param name="SKU">
		/// The seller's unique identifier for an item that is being tracked by this
		/// SKU. If <b>OrderID</b> or <b>OrderLineItemID</b> are not provided, both <b>SKU</b> (or
		/// <b>ItemID</b>) and corresponding <b>TransactionID</b> must be provided to uniquely
		/// identify a single line item order. For a multiple line item order, <b>OrderID</b> must be used.
		/// 
		/// 
		/// This field can only be used if the <b>Item.InventoryTrackingMethod</b> field
		/// (set with the <b>AddFixedPriceItem</b> or <b>RelistFixedPriceItem</b> calls) is set to
		/// <code>SKU</code>.
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// A unique identifier for an eBay order line item. This identifier is created as soon as there is a commitment to buy (bidder wins the auction, buyer clicks buy button, or buyer purchases item through <b>PlaceOffer</b> call).
		/// 
		/// 
		/// Unless the <b>ItemID</b> (or <b>SKU</b>) and corresponding <b>TransactionID</b> is used to
		/// identify a single line item order, or the <b>OrderID</b> is used to identify a
		/// single or multiple line item order, the
		/// <b>OrderLineItemID</b> must be specified. For a multiple line item order, <b>OrderID</b> should be used. If <b>OrderLineItemID</b> is specified,
		/// <b>ItemID</b>, <b>TransactionID</b>, and <b>SKU</b> are ignored if present in the same
		/// request.
		/// </param>
		///
		/// <param name="AdjustmentAmount">
		/// This field allows the seller to adjust the total cost of the order to account for an extra charge or to pass down a discount to the buyer. 
		/// The currency used in this field must be the same currency of the listing site. A positive value in this field indicates that the amount is an extra charge being paid to the seller by the buyer, and a negative value indicates that the amount is a discount given to the buyer by the seller.
		/// </param>
		///
		public void SendInvoice(string ItemID, string TransactionID, string OrderID, InternationalShippingServiceOptionsTypeCollection InternationalShippingServiceOptionsList, ShippingServiceOptionsTypeCollection ShippingServiceOptionsList, SalesTaxType SalesTax, BuyerPaymentMethodCodeTypeCollection PaymentMethodsList, string CheckoutInstructions, bool EmailCopyToSeller, AmountType CODCost, string SKU, string OrderLineItemID, AmountType AdjustmentAmount)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.OrderID = OrderID;
			this.InternationalShippingServiceOptionsList = InternationalShippingServiceOptionsList;
			this.ShippingServiceOptionsList = ShippingServiceOptionsList;
			this.SalesTax = SalesTax;
			this.PaymentMethodsList = PaymentMethodsList;
			this.CheckoutInstructions = CheckoutInstructions;
			this.EmailCopyToSeller = EmailCopyToSeller;
			this.SKU = SKU;
			this.OrderLineItemID = OrderLineItemID;
			this.AdjustmentAmount = AdjustmentAmount;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SendInvoice(string ItemID, string TransactionID, ShippingServiceOptionsTypeCollection ShippingServiceOptionsList)
		{
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.ShippingServiceOptionsList = ShippingServiceOptionsList;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SendInvoice(string OrderID)
		{
			this.OrderID = OrderID;
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
		/// Gets or sets the <see cref="SendInvoiceRequestType"/> for this API call.
		/// </summary>
		public SendInvoiceRequestType ApiRequest
		{ 
			get { return (SendInvoiceRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SendInvoiceResponseType"/> for this API call.
		/// </summary>
		public SendInvoiceResponseType ApiResponse
		{ 
			get { return (SendInvoiceResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.InternationalShippingServiceOptions"/> of type <see cref="InternationalShippingServiceOptionsTypeCollection"/>.
		/// </summary>
		public InternationalShippingServiceOptionsTypeCollection InternationalShippingServiceOptionsList
		{ 
			get { return ApiRequest.InternationalShippingServiceOptions; }
			set { ApiRequest.InternationalShippingServiceOptions = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.ShippingServiceOptions"/> of type <see cref="ShippingServiceOptionsTypeCollection"/>.
		/// </summary>
		public ShippingServiceOptionsTypeCollection ShippingServiceOptionsList
		{ 
			get { return ApiRequest.ShippingServiceOptions; }
			set { ApiRequest.ShippingServiceOptions = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.SalesTax"/> of type <see cref="SalesTaxType"/>.
		/// </summary>
		public SalesTaxType SalesTax
		{ 
			get { return ApiRequest.SalesTax; }
			set { ApiRequest.SalesTax = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.PaymentMethods"/> of type <see cref="BuyerPaymentMethodCodeTypeCollection"/>.
		/// </summary>
		public BuyerPaymentMethodCodeTypeCollection PaymentMethodsList
		{ 
			get { return ApiRequest.PaymentMethods; }
			set { ApiRequest.PaymentMethods = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.CheckoutInstructions"/> of type <see cref="string"/>.
		/// </summary>
		public string CheckoutInstructions
		{ 
			get { return ApiRequest.CheckoutInstructions; }
			set { ApiRequest.CheckoutInstructions = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.EmailCopyToSeller"/> of type <see cref="bool"/>.
		/// </summary>
		public bool EmailCopyToSeller
		{ 
			get { return ApiRequest.EmailCopyToSeller; }
			set { ApiRequest.EmailCopyToSeller = value; }
		} 

 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiRequest.SKU; }
			set { ApiRequest.SKU = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SendInvoiceRequestType.AdjustmentAmount"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType AdjustmentAmount
		{ 
			get { return ApiRequest.AdjustmentAmount; }
			set { ApiRequest.AdjustmentAmount = value; }
		}
		
		

		#endregion

		
	}
}

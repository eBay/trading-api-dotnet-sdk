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
	public class SetUserNotesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetUserNotesCall()
		{
			ApiRequest = new SetUserNotesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetUserNotesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetUserNotesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables users to add, modify, or delete a pinned note for any item that is being tracked in the My eBay All Selling and All Buying areas.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier of the listing to which the My eBay note will be
		/// attached. Notes can only be added to items that are
		/// currently being tracked in My eBay.
		/// </param>
		///
		/// <param name="Action">
		/// The seller must include this field and set it to 'AddOrUpdate' to add a new user note or update an existing user note, or set it to 'Delete' to delete an existing user note.
		/// </param>
		///
		/// <param name="NoteText">
		/// This field is needed if the <b>Action</b> is <code>AddOrUpdate</code>. The text supplied in this field will
		/// completely replace any existing My eBay note for the
		/// specified item.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for the order line item to which the My
		/// eBay note will be attached. Notes can only be added to order line items
		/// that are currently being tracked in My eBay. Buyers can
		/// view user notes made on order line items in the
		/// <b>PrivateNotes</b> field of the <b>WonList</b> container in <b>GetMyeBayBuying</b>, and
		/// sellers can view user notes made on order line items in
		/// the <b>PrivateNotes</b> field of the <b>SoldList</b> and <b>DeletedFromSoldList</b>
		/// containers in <b>GetMyeBaySellinging</b>.
		/// </param>
		///
		/// <param name="VariationSpecificList">
		/// Container consisting of name-value pairs that identify (match) one
		/// variation within a fixed-price, multiple-variation listing. The specified
		/// name-value pair(s) must exist in the listing specified by either the
		/// <b>ItemID</b> or <b>SKU</b> values specified in the request. If a specific order line
		/// item is targeted in the request with an
		/// <b>ItemID</b>/<b>TransactionID</b> pair or an <b>OrderLineItemID</b> value, any specified
		/// <b>VariationSpecifics</b> container is ignored by the call.
		/// </param>
		///
		/// <param name="SKU">
		/// SKU value of the item variation to which the My eBay note will be
		/// attached. Notes can only be added to items that are currently being
		/// tracked in My eBay. A SKU (stock keeping unit) value is defined by and
		/// used by the seller to identify a variation within a fixed-price, multiple-
		/// variation listing. The SKU value is assigned to a variation of an item
		/// through the <b>Variations.Variation.SKU</b> element.
		/// 
		/// 
		/// This field can only be used if the <b>Item.InventoryTrackingMethod</b> field
		/// (set with the <b>AddFixedPriceItem</b> or <b>RelistFixedPriceItem</b> calls) is set to
		/// SKU.
		/// 
		/// 
		/// If a specific order line item is targeted in the request
		/// with an <b>ItemID</b>/<b>TransactionID</b> pair or an <b>OrderLineItemID</b> value, any
		/// specified <b>SKU</b> is ignored by the call.
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// A unique identifier for an eBay order line item. This field is created as
		/// soon as there is a commitment to buy from the seller. <b>OrderLineItemID</b> can be used in the input instead of
		/// an <b>ItemID</b>/<b>TransactionID</b> pair to identify an order line item.
		/// 
		/// 
		/// Notes can only be added to order line items that are currently being
		/// tracked in My eBay. Buyers can view user notes made on order line items in
		/// the <b>PrivateNotes</b> field of the <b>WonList</b> container in <b>GetMyeBayBuying</b>, and
		/// sellers can view user notes made on order line items in the <b>PrivateNotes</b>
		/// field of the <b>SoldList</b> and <b>DeletedFromSoldList</b> containers in
		/// <b>GetMyeBaySellinging</b>.
		/// </param>
		///
		public void SetUserNotes(string ItemID, SetUserNotesActionCodeType Action, string NoteText, string TransactionID, NameValueListTypeCollection VariationSpecificList, string SKU, string OrderLineItemID)
		{
			this.ItemID = ItemID;
			this.Action = Action;
			this.NoteText = NoteText;
			this.TransactionID = TransactionID;
			this.VariationSpecificList = VariationSpecificList;
			this.SKU = SKU;
			this.OrderLineItemID = OrderLineItemID;

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
		/// Gets or sets the <see cref="SetUserNotesRequestType"/> for this API call.
		/// </summary>
		public SetUserNotesRequestType ApiRequest
		{ 
			get { return (SetUserNotesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetUserNotesResponseType"/> for this API call.
		/// </summary>
		public SetUserNotesResponseType ApiResponse
		{ 
			get { return (SetUserNotesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.Action"/> of type <see cref="SetUserNotesActionCodeType"/>.
		/// </summary>
		public SetUserNotesActionCodeType Action
		{ 
			get { return ApiRequest.Action; }
			set { ApiRequest.Action = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.NoteText"/> of type <see cref="string"/>.
		/// </summary>
		public string NoteText
		{ 
			get { return ApiRequest.NoteText; }
			set { ApiRequest.NoteText = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.VariationSpecifics"/> of type <see cref="NameValueListTypeCollection"/>.
		/// </summary>
		public NameValueListTypeCollection VariationSpecificList
		{ 
			get { return ApiRequest.VariationSpecifics; }
			set { ApiRequest.VariationSpecifics = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiRequest.SKU; }
			set { ApiRequest.SKU = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserNotesRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
		

		#endregion

		
	}
}

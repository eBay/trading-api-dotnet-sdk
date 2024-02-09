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
	public class GetItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetItemCall()
		{
			ApiRequest = new GetItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetItemCall(ApiContext ApiContext)
		{
			ApiRequest = new GetItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The <b>GetItem</b> call returns listing data such as title, description, price information, user information, and so on, for the specified <b>ItemID</b>.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// This field is used to identify the eBay listing by Item ID value.
		/// 
		/// <b>ItemID</b> is a required input in most cases. <b>SKU</b> can be used instead in certain
		/// cases (see the description of SKU). If both <b>ItemID</b> and <b>SKU</b> are specified for
		/// items where the inventory tracking method is <b>ItemID</b>, <b>ItemID</b> takes precedence.
		/// </param>
		///
		/// <param name="IncludeWatchCount">
		/// The seller can include this field and set its value to <code>true</code> if that seller wants to see how many prospective bidders/buyers currently have the item added to their Watch Lists. The Watch count is returned in the <b>WatchCount</b> field in the response.
		/// 
		/// 
		/// This field will only be returnd to the seller of the item.
		/// </param>
		///
		/// <param name="IncludeCrossPromotion">
		/// This field is deprecated.
		/// </param>
		///
		/// <param name="IncludeItemSpecifics">
		/// If this field is included and set to <code>true</code>, the call response includes the <b>ItemSpecifics</b> container
		/// if Item Specifics are defined for the listing.
		/// 
		/// An Item Specific is any aspect that helps define/classify the item. Many eBay categories mandate including specific Item Specifics, so it is always a good idea to make a call to <b>GetCategorySpecifics</b> to see what Item Specifics are required and which ones are recommended.
		/// 
		/// Including this field and setting it to <code>true</code> will also return the <strong>UnitInfo</strong> container if applicable. The <strong>UnitInfo</strong> container will provide information about the weight, volume or other quantity measurement of a listed item. The European Union requires listings for certain types of products to include the price per unit so buyers can accurately compare prices. eBay uses the <strong>UnitType</strong> and <strong>UnitQuantity</strong> values and the item's listed price to calculate and display the per-unit price on eBay EU sites.
		/// </param>
		///
		/// <param name="IncludeTaxTable">
		/// The seller will include this field and set its value to <code>true</code> if the seller wishes to view the defined sales tax rates for the various jurisdictions in the country (generally, states and provinces). Information for each defined sales tax rate will be returned in the <b>TaxTable</b> container in the response.
		/// <br/><br/>
		/// Even if this field is included and set to <code>true</code>, no <b>TaxTable</b> container will be returned If no sales tax rates are defined for any tax jurisdiction in the seller's sales tax table.
		/// <br/><br/>
		/// Sales tax tables are only available for eBay US and Canada marketplaces. Sales tax rates can be added/modified in My eBay, through the <b>SetTaxTable</b> and <b>GetTaxTable</b> calls of the Trading API, or through the Sales Tax calls of the Account API.
		/// </param>
		///
		/// <param name="SKU">
		/// Retrieves an item that was listed by the user identified
		/// in AuthToken and that is being tracked by this SKU.
		/// 
		/// A SKU (stock keeping unit) is an identifier defined by a seller.
		/// Some sellers use SKUs to track complex flows of products
		/// and information on the client side.
		/// eBay preserves the SKU on the item, enabling you
		/// to obtain it before and after an order line item is created.
		/// (SKU is recommended as an alternative to
		/// ApplicationData.)
		/// 
		/// In <b>GetItem</b>, <b>SKU</b> can only be used to retrieve one of your
		/// own items, where you listed the item by using <b>AddFixedPriceItem</b>
		/// or <b>RelistFixedPriceItem</b>,
		/// and you set <b>Item.InventoryTrackingMethod</b> to <b>SKU</b> at
		/// the time the item was listed. (These criteria are necessary to
		/// uniquely identify the listing by a SKU.)
		/// 
		/// Either <b>ItemID</b> or <b>SKU</b> is required in the request.
		/// If both are passed, they must refer to the same item,
		/// and that item must have <b>InventoryTrackingMethod</b> set to <b>SKU</b>.
		/// </param>
		///
		/// <param name="VariationSKU">
		/// Variation-level SKU that uniquely identifes a Variation within
		/// the listing identified by <b>ItemID</b>. Only applicable when the
		/// seller listed the item with Variation-level SKU (<b>Variation.SKU</b>)
		/// values. Retrieves all the usual <b>Item</b> fields, but limits the
		/// <b>Variations</b> content to the specified Variation.
		/// If not specified, the response includes all Variations.
		/// </param>
		///
		/// <param name="VariationSpecificList">
		/// Name-value pairs that identify one or more Variations within the
		/// listing identified by <b>ItemID</b>. Only applicable when the seller
		/// listed the item with Variations. Retrieves all the usual <b>Item</b>
		/// fields, but limits the Variations content to the specified
		/// Variation(s). If the specified pairs do not match any Variation,
		/// eBay returns all Variations.
		/// 
		/// To retrieve only one variation, specify the full set of
		/// name/value pairs that match all the name-value pairs of one
		/// Variation. 
		/// 
		/// To retrieve multiple variations (using a wildcard),
		/// specify one or more name/value pairs that partially match the
		/// desired variations. For example, if the listing contains
		/// Variations for shirts in different colors and sizes, specify
		/// Color as Red (and no other name/value pairs) to retrieve
		/// all the red shirts in all sizes (but no other colors).
		/// </param>
		///
		/// <param name="TransactionID">
		/// A unique identifier for an order line item. An order line item is created
		/// when a buyer commits to purchasing an item.
		/// 
		/// Since you can change active multiple-quantity fixed-price listings even
		/// after one of the items has been purchased, the <b>TransactionID</b> is
		/// associated with a snapshot of the item data at the time of the purchase.
		/// 
		/// After one item in a multi-quantity listing has been sold, sellers can not
		/// change the values in the Title, Primary Category, Secondary Category,
		/// Listing Duration, and Listing Type fields. However, all other fields are
		/// editable.
		/// 
		/// Specifying a <b>TransactionID</b> in the <b>GetItem</b> request allows you to retrieve
		/// a snapshot of the listing as it was when the order line item was created.
		/// </param>
		///
		/// <param name="IncludeItemCompatibilityList">
		/// This field is used to specify whether or not to retrieve Parts
		/// Compatiblity information for a motor part or accessory listing. If this field is included and set to <code>true</code>, the <b>Item.ItemCompatibilityList</b> container will be returned if a Parts Compatibility list exists for the listing. A Parts Compatibility list is a list of motor vehicles that are compatible with the listed motor part or accesory item. If a Parts Compatibility list does not exist for the listing, this field will have no effect if it is included, regardless of its value (<code>true</code> or <code>false</code>).
		/// 
		/// If this field is included and set to <code>false</code> or omitted, but a Parts Compatibility list does exist for the listing, the  <b>Item.ItemCompatibilityList</b> container will not be returned, but the <b>Item.ItemCompatibilityCount</b> field will be returned, and this field will simply indicate the quantity of motor vehicles that are compatible with the the listed motor part or accesory item.
		/// 
		/// Parts Compatibility lists are only applicable to motor parts and accessory categories on the sites that support eBay Motors - US, CA, UK, and DE.
		/// </param>
		///
		public ItemType GetItem(string ItemID, bool IncludeWatchCount, bool IncludeCrossPromotion, bool IncludeItemSpecifics, bool IncludeTaxTable, string SKU, string VariationSKU, NameValueListTypeCollection VariationSpecificList, string TransactionID, bool IncludeItemCompatibilityList)
		{
			this.ItemID = ItemID;
			this.IncludeWatchCount = IncludeWatchCount;
			this.IncludeCrossPromotion = IncludeCrossPromotion;
			this.IncludeItemSpecifics = IncludeItemSpecifics;
			this.IncludeTaxTable = IncludeTaxTable;
			this.SKU = SKU;
			this.VariationSKU = VariationSKU;
			this.VariationSpecificList = VariationSpecificList;
			this.TransactionID = TransactionID;
			this.IncludeItemCompatibilityList = IncludeItemCompatibilityList;

			Execute();
			return ApiResponse.Item;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemType GetItem(string ItemID)
		{
			this.ItemID = ItemID;
			Execute();
			return Item;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemType GetItem(string ItemID, bool IncludeWatchCount)
		{
			this.ItemID = ItemID;
			this.IncludeWatchCount = IncludeWatchCount;

			Execute();
			return ApiResponse.Item;
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
		/// Gets or sets the <see cref="GetItemRequestType"/> for this API call.
		/// </summary>
		public GetItemRequestType ApiRequest
		{ 
			get { return (GetItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetItemResponseType"/> for this API call.
		/// </summary>
		public GetItemResponseType ApiResponse
		{ 
			get { return (GetItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeWatchCount"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeWatchCount
		{ 
			get { return ApiRequest.IncludeWatchCount; }
			set { ApiRequest.IncludeWatchCount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeCrossPromotion"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeCrossPromotion
		{ 
			get { return ApiRequest.IncludeCrossPromotion; }
			set { ApiRequest.IncludeCrossPromotion = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeItemSpecifics"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeItemSpecifics
		{ 
			get { return ApiRequest.IncludeItemSpecifics; }
			set { ApiRequest.IncludeItemSpecifics = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeTaxTable"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeTaxTable
		{ 
			get { return ApiRequest.IncludeTaxTable; }
			set { ApiRequest.IncludeTaxTable = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiRequest.SKU; }
			set { ApiRequest.SKU = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.VariationSKU"/> of type <see cref="string"/>.
		/// </summary>
		public string VariationSKU
		{ 
			get { return ApiRequest.VariationSKU; }
			set { ApiRequest.VariationSKU = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.VariationSpecifics"/> of type <see cref="NameValueListTypeCollection"/>.
		/// </summary>
		public NameValueListTypeCollection VariationSpecificList
		{ 
			get { return ApiRequest.VariationSpecifics; }
			set { ApiRequest.VariationSpecifics = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemRequestType.IncludeItemCompatibilityList"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeItemCompatibilityList
		{ 
			get { return ApiRequest.IncludeItemCompatibilityList; }
			set { ApiRequest.IncludeItemCompatibilityList = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemResponseType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiResponse.Item; }
		}
		

		#endregion

		
	}
}

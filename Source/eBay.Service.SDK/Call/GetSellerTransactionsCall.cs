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
	public class GetSellerTransactionsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellerTransactionsCall()
		{
			ApiRequest = new GetSellerTransactionsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellerTransactionsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellerTransactionsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves a seller's order line item information. To retrieve order line items for another seller, the <b>GetItemTransactions</b>) call should be used. This call cannot retrieve sales older than 90 days old.
		/// 
		/// If one or more <b>SKU</b> values or the date range filters (<b>ModTimeFrom</b>/<b>ModTimeTo</b> or <b>NumberOfDays</b>) are not used, the <b>GetItemTransactions</b>) call will retrieve order line items created (or modified) within the last 30 days.
		/// </summary>
		/// 
		/// <param name="ModTimeFrom">
		/// The <b>ModTimeFrom</b> and <b>ModTimeTo</b> fields are used to specify a date range for retrieving order line items associated with the seller. The <b>ModTimeFrom</b> field is the starting date range. All of the seller's order line items that were created (or last modified) within this date range are returned in the output.  The maximum date range that may be specified is 30 days. This value cannot be set back more than 90 days in the past, as this call cannot retrieve sales older than 90 days. This field is not applicable if the <b>NumberOfDays</b> date filter is used.
		/// 
		/// If you don't specify a <b>ModTimeFrom</b>/<b>ModTimeTo</b> filter, the <b>NumberOfDays</b> time filter is used and it defaults to 30 (days).
		/// </param>
		///
		/// <param name="ModTimeTo">
		/// The <b>ModTimeFrom</b> and <b>ModTimeTo</b> fields are used to specify a date range for retrieving order line items associated with the seller. The <b>ModTimeTo</b> field is the ending date range. All of the seller's order line items that were created (or last modified) within this date range are returned in the output. The maximum date range that may be specified is 30 days.
		/// <br/><br/>
		/// If the <b>ModTimeFrom</b> field is
		/// used and the <b>ModTimeTo</b> field is omitted, the <b>ModTimeTo</b> value defaults to
		/// the present time or to 30 days past the <b>ModTimeFrom</b> value (if
		/// <b>ModTimeFrom</b> value is more than 30 days in the past). This field is not
		/// applicable if the <b>NumberOfDays</b> date filter is used.
		/// 
		/// If you don't specify a <b>ModTimeFrom</b>/<b>ModTimeTo</b> filter, the <b>NumberOfDays</b>
		/// time filter is used and it defaults to 30 (days).
		/// </param>
		///
		/// <param name="Pagination">
		/// If many order line items are	available to retrieve, you may need to call <b>GetSellerTransactions</b> multiple times to retrieve all the data. Each result set is returned as a page of order line items. Use the <b>Pagination</b> filters to control the maximum number of order line items to retrieve per page (i.e., per call), and the page number to retrieve.
		/// </param>
		///
		/// <param name="IncludeFinalValueFee">
		/// This field is included and set to <code>true</code> if the user wants to view the Final Value Fee (FVF) for all order line items in the response. The Final Value Fee is returned in the <b>Transaction.FinalValueFee</b> field. The Final Value Fee is assessed right after the creation of an order line item.
		/// <br/>
		/// </param>
		///
		/// <param name="IncludeContainingOrder">
		/// This field is included and set to <code>true</code> if the user wants to view order-level details, including the unique identifier of the order and the status of the order. The order-level details will be shown in the <b>ContainingOrder</b> container in the response.
		/// <br/>
		/// </param>
		///
		/// <param name="SKUArrayList">
		/// This container is used to search for order line items generated from one or more product SKU values. The response will only include order line items for the seller's product(s) that are represented by the specified SKU value(s).
		///  
		/// If a user wants to retrieve order line items based on SKUs, the
		/// <b>InventoryTrackingMethod</b> must be set to <code>SKU</code>. The <b>InventoryTrackingMethod</b> value can be set when the seller lists the item through an <b>AddFixedPriceItem</b> call, or it can be set by including the <b>InventoryTrackingMethod</b> field in a <b>GetSellerTransactions</b> call and setting its value to <code>SKU</code>.
		///  
		/// <span class="tablenote"><b>Note: </b> SKU values must be defined for products in listings for this container to be applicable.
		/// </span>
		/// </param>
		///
		/// <param name="Platform">
		/// <span class="tablenote"><b>Note: </b> This field should no longer be used since its sole purpose was to allow the seller to filter between eBay orders and Half.com orders, and the Half.com site no longer exists.
		/// </span>
		/// </param>
		///
		/// <param name="NumberOfDays">
		/// This field is used to specify how many days (24-hour periods) back in the past you wish to retrieve order line items. All order line items created (or last modified) within this period are retrieved. This value can be set between 1 (day) and 30 (days), and defaults to 30 (days) if omitted from the call.
		/// <br/><br/>
		/// If the <b>NumberOfDays</b> filter is used, <b>ModTimeFrom</b> and <b>ModTimeTo</b> date range filters are ignored (if included in the same request).
		/// <br/>
		/// </param>
		///
		/// <param name="InventoryTrackingMethod">
		/// This filter is used if the seller wishes to set/change the inventory tracking method. When creating a listing with the <b>AddFixedPriceItem</b> call (or relisting with <b>RelistFixedPriceItem</b> call), sellers can decide whether to track their inventory by Item ID (generated by eBay at listing time) or by seller-defined SKU value.
		/// 
		/// This field is needed (and its value must be set to <code>SKU</code>) if the seller wishes to retrieve order line items based on specified SKU values (specified through <b>SKUArray</b> container) and the current inventory tracking method is set to Item ID.
		/// 
		/// A seller can use a <b>GetItem</b> call for a listing (and look for the <b>Item.InventoryTrackingMethod</b> in the response) to see which inventory tracking method is used for the listing/product.
		/// </param>
		///
		/// <param name="IncludeCodiceFiscale">
		/// If this field is included in the call request and set to <code>true</code>, taxpayer identification information for the buyer is returned under the <b>BuyerTaxIdentifier</b> container.
		/// 
		/// Codice Fiscale is only applicable to buyers on the Italy and Spain sites. It is required that buyers on the Italy site provide their Codice Fiscale ID before buying an item, and sellers on the Spain site have the option of requiring buyers on the Spain site to provide their taxpayer ID.
		/// </param>
		///
		public TransactionTypeCollection GetSellerTransactions(DateTime ModTimeFrom, DateTime ModTimeTo, PaginationType Pagination, bool IncludeFinalValueFee, bool IncludeContainingOrder, StringCollection SKUArrayList, TransactionPlatformCodeType Platform, int NumberOfDays, InventoryTrackingMethodCodeType InventoryTrackingMethod, bool IncludeCodiceFiscale)
		{
			this.ModTimeFrom = ModTimeFrom;
			this.ModTimeTo = ModTimeTo;
			this.Pagination = Pagination;
			this.IncludeFinalValueFee = IncludeFinalValueFee;
			this.IncludeContainingOrder = IncludeContainingOrder;
			this.SKUArrayList = SKUArrayList;
			this.Platform = Platform;
			this.NumberOfDays = NumberOfDays;
			this.InventoryTrackingMethod = InventoryTrackingMethod;
			this.IncludeCodiceFiscale = IncludeCodiceFiscale;

			Execute();
			return ApiResponse.TransactionArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public TransactionTypeCollection GetSellerTransactions(TimeFilter ModTimeFilter)
		{
			this.ModTimeFilter = ModTimeFilter;
			Execute();
			return TransactionList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public TransactionTypeCollection GetSellerTransactions(DateTime TimeFrom, DateTime TimeTo)
		{
			this.ModTimeFilter = new TimeFilter(TimeFrom, TimeTo);
			Execute();
			return TransactionList;
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
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType"/> for this API call.
		/// </summary>
		public GetSellerTransactionsRequestType ApiRequest
		{ 
			get { return (GetSellerTransactionsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellerTransactionsResponseType"/> for this API call.
		/// </summary>
		public GetSellerTransactionsResponseType ApiResponse
		{ 
			get { return (GetSellerTransactionsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.ModTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeFrom
		{ 
			get { return ApiRequest.ModTimeFrom; }
			set { ApiRequest.ModTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.ModTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeTo
		{ 
			get { return ApiRequest.ModTimeTo; }
			set { ApiRequest.ModTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.IncludeFinalValueFee"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeFinalValueFee
		{ 
			get { return ApiRequest.IncludeFinalValueFee; }
			set { ApiRequest.IncludeFinalValueFee = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.IncludeContainingOrder"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeContainingOrder
		{ 
			get { return ApiRequest.IncludeContainingOrder; }
			set { ApiRequest.IncludeContainingOrder = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.SKUArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection SKUArrayList
		{ 
			get { return ApiRequest.SKUArray; }
			set { ApiRequest.SKUArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.Platform"/> of type <see cref="TransactionPlatformCodeType"/>.
		/// </summary>
		public TransactionPlatformCodeType Platform
		{ 
			get { return ApiRequest.Platform; }
			set { ApiRequest.Platform = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.NumberOfDays"/> of type <see cref="int"/>.
		/// </summary>
		public int NumberOfDays
		{ 
			get { return ApiRequest.NumberOfDays; }
			set { ApiRequest.NumberOfDays = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.InventoryTrackingMethod"/> of type <see cref="InventoryTrackingMethodCodeType"/>.
		/// </summary>
		public InventoryTrackingMethodCodeType InventoryTrackingMethod
		{ 
			get { return ApiRequest.InventoryTrackingMethod; }
			set { ApiRequest.InventoryTrackingMethod = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.IncludeCodiceFiscale"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeCodiceFiscale
		{ 
			get { return ApiRequest.IncludeCodiceFiscale; }
			set { ApiRequest.IncludeCodiceFiscale = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetSellerTransactionsRequestType.ModTimeFrom"/> and <see cref="GetSellerTransactionsRequestType.ModTimeTo"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter ModTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.ModTimeFrom, ApiRequest.ModTimeTo); }
			set 
			{
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.ModTimeFrom = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.ModTimeTo = value.TimeTo;
			}
		}

		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.HasMoreTransactions"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreTransactions
		{ 
			get { return ApiResponse.HasMoreTransactions; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.TransactionsPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int TransactionsPerPage
		{ 
			get { return ApiResponse.TransactionsPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.ReturnedTransactionCountActual"/> of type <see cref="int"/>.
		/// </summary>
		public int ReturnedTransactionCountActual
		{ 
			get { return ApiResponse.ReturnedTransactionCountActual; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.Seller"/> of type <see cref="UserType"/>.
		/// </summary>
		public UserType Seller
		{ 
			get { return ApiResponse.Seller; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerTransactionsResponseType.TransactionArray"/> of type <see cref="TransactionTypeCollection"/>.
		/// </summary>
		public TransactionTypeCollection TransactionList
		{ 
			get { return ApiResponse.TransactionArray; }
		}
		

		#endregion

		
	}
}

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
	public class GetOrdersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetOrdersCall()
		{
			ApiRequest = new GetOrdersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetOrdersCall(ApiContext ApiContext)
		{
			ApiRequest = new GetOrdersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the orders for which the authenticated user is a participant, either as the buyer or the seller. The call returns all the orders that meet the request criteria. Orders older than 90 days old will not be returned.
		/// </summary>
		/// 
		/// <param name="OrderIDList">
		/// This container is used if the user wants to retrieve one or more specific orders in which they are involved as either the seller or buyer. If one or more order IDs are specified in this container, any order role, order status, or date range filters are ignored if specified in the request.
		/// 
		/// <span class="tablenote"><b>Note: </b> As of June 2019, eBay has changed the format of order identifier values. The new format is a non-parsable string, globally unique across all eBay marketplaces, and consistent for both single line item and multiple line item orders. Unlike in the past, instead of just being known and exposed to the seller, these unique order identifiers will also be known and used/referenced by the buyer and eBay customer support.
		/// 
		/// For developers and sellers who are already integrated with the Trading API's order management calls, this change shouldn't impact your integration unless you parse the existing order identifiers (e.g., <b>OrderID</b> or <b>OrderLineItemID</b>), or otherwise infer meaning from the format (e.g., differentiating between a single line item order versus a multiple line item order). Because we realize that some integrations may have logic that is dependent upon the old identifier format, eBay is rolling out this Trading API change with version control to support a transition period of approximately 9 months before applications must switch to the new format completely.
		/// 
		/// During the transition period, for developers/sellers using a Trading WSDL older than Version 1113, they can use the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header in API calls to control whether the new or old <b>OrderID</b> format is returned in call response payloads. To get the new <b>OrderID</b> format, the value of the <b>X-EBAY-API-COMPATIBILITY-LEVEL</b> HTTP header must be set to <code>1113</code>. During the transition period and even after, the new and old <b>OrderID</b> formats will still be supported/accepted in all Trading API call request payloads. After the transition period (which will be announced), only the new <b>OrderID</b> format will be returned in all Trading API call response payloads, regardless of the Trading WSDL version used or specified compatibility level.
		/// </span>
		/// 
		/// <span class="tablenote"><b>Note: </b> For sellers integrated with the new order ID format, please note that the identifier for an order will change as it goes from unpaid to paid status. Sellers can check to see if an order has been paid by looking for a value of 'Complete' in the <b>CheckoutStatus.Status</b> field in the response of <b>GetOrders</b> or <b>GetOrderTransactions</b> call, or in the <b>Status.CompleteStatus</b> field in the response of <b>GetItemTransactions</b> or <b>GetSellerTransactions</b> call. Sellers should  not fulfill orders until buyer has made payment. When using a <b>GetOrders</b> or <b>GetOrderTransactions</b> call to retrieve specific order(s), either of these order IDs (paid or unpaid status) can be used to retrieve an order.
		/// </span>
		/// </param>
		///
		/// <param name="CreateTimeFrom">
		/// The <b>CreateTimeFrom</b> and <b>CreateTimeTo</b> fields specify a date range for retrieving orders that were created during this time period. The <b>CreateTimeFrom</b> field is the starting date range. All eBay orders that were created within this date range are returned in the output. The maximum date range that may be specified with the <b>CreateTimeFrom</b> and <b>CreateTimeTo</b> fields is 90 days. <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> date filters are ignored if the <b>NumberOfDays</b> date filter is used in the request, or if one or more order IDs are passed in the request. This value cannot be set back more than 90 days in the past, as this call cannot retrieve sales older than 90 days old.
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// Unless one or more <b>OrderID</b> values are used, one of the three available date range filters must be used.
		/// </span>
		/// </param>
		///
		/// <param name="CreateTimeTo">
		/// The <b>CreateTimeFrom</b> and <b>CreateTimeTo</b> fields specify a date range for retrieving orders that were created during this time period. The <b>CreateTimeTo</b> field is the ending date range. All eBay orders that were created within this date range are returned in the output. The maximum date range that may be specified with the <b>CreateTimeFrom</b> and <b>CreateTimeTo</b> fields is 90 days. If the <b>CreateTimeFrom</b> field is used and the <b>CreateTimeTo</b> field is omitted, the "TimeTo" value defaults to the present time or to 90 days past the <b>CreateTimeFrom</b> value (if <b>CreateTimeFrom</b> value is more than 90 days in the past). <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> date filters are ignored if the <b>NumberOfDays</b> date filter is used in the request, or if one or more order IDs are passed in the request.
		/// 
		/// <span class="tablenote"><strong>Note:</strong> If a <b>GetOrders</b> call is made within a few seconds after the creation of a multiple line item order, the caller runs the risk of retrieving orders that are in an inconsistent state, since the order consolidation involved in a multiple line item order may not have been completed. For this reason, it is recommended that sellers include the <b>CreateTimeTo</b> field in the call, and set its value to: <i>Current Time</i> - 2 minutes.
		/// </span>
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// Unless one or more <b>OrderID</b> values are used, one of the three available date range filters must be used.
		/// </span>
		/// </param>
		///
		/// <param name="OrderRole">
		/// This filter is used to toggle between retrieving orders based on the role of the user (seller or buyer). The order role defaults to <code>Seller</code> if this field is not used. If this field is used with a date filter, returned orders must satisfy both the date range and the <b>OrderRole</b> value.
		/// 
		/// </param>
		///
		/// <param name="OrderStatus">
		/// The field is used to retrieve eBay orders that are in a specific state. If this field is used with a date filter, only orders that satisfy both the date range and the <b>OrderStatus</b> value are retrieved.  If one or more <b>OrderID</b> values are specified through the <b>OrderIDArray</b> container, the <b>OrderStatus</b> field should not be used, and it is ignored if it is used. If an <b>OrderStatus</b> value is not used and no <b>OrderID</b> values are specified, orders in all states are returned.
		/// 
		/// </param>
		///
		/// <param name="ListingType">
		/// <span class="tablenote"><b>Note: </b> This field's purpose was to allow the seller to retrieve only Half.com listings. Since the Half.com site has been shut down, this field is no longer applicable.
		/// </span>
		/// </param>
		///
		/// <param name="Pagination">
		/// If many orders are	available to retrieve, you may need to call <b>GetOrders</b> multiple times to retrieve all the data. Each result set is returned as a page of orders. Use the <b>Pagination</b> filters to control the maximum number of orders to retrieve per page (i.e., per call), and the page number to retrieve.
		/// </param>
		///
		/// <param name="ModTimeFrom">
		/// The <b>ModTimeFrom</b> and <b>ModTimeTo</b> fields specify a date range for retrieving existing orders that have been modified within this time period (for example, <code>Incomplete</code> status to <code>Pending</code> status or <code>Pending</code> status to <code>Complete</code> status). The <b>ModTimeFrom</b> field is the starting date range. All eBay orders that were last modified within this date range are returned in the output. Unlike the <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> filters, which may cover a maximum period of 90 days, the maximum date range that may be specified with the <b>ModTimeFrom</b> and <b>ModTimeTo</b> fields is only 30 days. This value cannot be set back more than 90 days in the past, as this call cannot retrieve sales older than 90 days old. <b>ModTimeFrom</b>/<b>ModTimeTo</b> date filters are ignored if the <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> or <b>NumberOfDays</b> date filters are used in the request, or if one or more order IDs are passed in the request.
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// Unless one or more <b>OrderID</b> values are used, one of the three available date range filters must be used.
		/// </span>
		/// </param>
		///
		/// <param name="ModTimeTo">
		/// The <b>ModTimeFrom</b> and <b>ModTimeTo</b> fields specify a date range for retrieving existing orders that have been modified within this time window (for example, <code>Incomplete</code> status to <code>Pending</code> status or <code>Pending</code> status to <code>Complete</code> status). The <b>ModTimeTo</b> field is the ending date range. All eBay orders that were last modified within this date range are returned in the output. Unlike the <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> filters, which may cover a maximum period of 90 days, the maximum date range that may be specified with the <b>ModTimeFrom</b> and <b>ModTimeTo</b> fields is 30 days. If the <b>ModTimeFrom</b> field is used and the <b>ModTimeTo</b> field is omitted, the 'TimeTo' value defaults to the present time (if <b>ModTimeFrom</b> value is less than 30 days in the past) or to 30 days past the <b>ModTimeFrom</b> value. <b>ModTimeFrom</b>/<b>ModTimeTo</b> date filters are ignored if the <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> or <b>NumberOfDays</b> date filters are used in the request, or if one or more order IDs are passed in the request.
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// Unless one or more <b>OrderID</b> values are used, one of the three available date range filters must be used.
		/// </span>
		/// </param>
		///
		/// <param name="NumberOfDays">
		/// This filter specifies the number of days (24-hour periods) in the past to search for orders. All eBay orders that were either created or modified within this period are returned in the output. This field cannot be used in conjunction with the <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> or <b>ModTimeFrom</b>/<b>ModTimeTo</b> date filters.
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// This date filter only allows you to retrieve orders created/modified within the last 30 days. So, if you wish to retrieve orders created and/or modified more than 30 days in the past, the <b>CreateTimeFrom</b>/<b>CreateTimeTo</b> or <b>ModTimeFrom</b>/<b>ModTimeTo</b> date filters should be used instead.
		/// </span>
		/// 
		/// <span class="tablenote"><strong>Note:</strong>
		/// Unless one or more <b>OrderID</b> values are used, one of the three available date range filters must be used.
		/// </span>
		/// </param>
		///
		/// <param name="IncludeFinalValueFee">
		/// This field is included and set to <code>true</code> if the user wants to view the Final Value Fee (FVF) for all orders in the response. The Final Value Fee is returned in the <b>Transaction.FinalValueFee</b> field. The Final Value Fee is assessed right after the creation of an order line item.
		/// <br/>
		/// </param>
		///
		/// <param name="SortingOrder">
		/// This filter controls whether orders are retrieved in ascending order (oldest to newest according to modification date) or descending order (newest to oldest according to modification date). The default is <code>Ascending</code>, so the user will need to include this field and set it to <code>Descending</code> if the user wishes to view the most recent orders first in the retrieved output.
		/// 
		/// </param>
		///
		public OrderArrayType GetOrders(StringCollection OrderIDList, DateTime CreateTimeFrom, DateTime CreateTimeTo, TradingRoleCodeType OrderRole, OrderStatusCodeType OrderStatus, ListingTypeCodeType ListingType, PaginationType Pagination, DateTime ModTimeFrom, DateTime ModTimeTo, int NumberOfDays, bool IncludeFinalValueFee, SortOrderCodeType SortingOrder)
		{
			this.OrderIDList = OrderIDList;
			this.CreateTimeFrom = CreateTimeFrom;
			this.CreateTimeTo = CreateTimeTo;
			this.OrderRole = OrderRole;
			this.OrderStatus = OrderStatus;
			this.ListingType = ListingType;
			this.Pagination = Pagination;
			this.ModTimeFrom = ModTimeFrom;
			this.ModTimeTo = ModTimeTo;
			this.NumberOfDays = NumberOfDays;
			this.IncludeFinalValueFee = IncludeFinalValueFee;
			this.SortingOrder = SortingOrder;

			Execute();

            return ApiResponse.OrderArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public OrderArrayType GetOrders(StringCollection OrderIDList)
		{
			this.OrderIDList = OrderIDList;
			Execute();
			return OrderList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public OrderArrayType GetOrders(TimeFilter CreateTimeFilter, TradingRoleCodeType OrderRole, OrderStatusCodeType OrderStatus)
		{
			this.OrderRole = OrderRole;
			this.OrderStatus = OrderStatus;
			this.CreateTimeFilter = CreateTimeFilter;
			this.OrderIDList = OrderIDList;
			Execute();
			return OrderList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
        public OrderArrayType GetOrders(DateTime CreateTimeFrom, DateTime CreateTimeTo, TradingRoleCodeType OrderRole, OrderStatusCodeType OrderStatus)
		{
			this.OrderRole = OrderRole;
			this.OrderStatus = OrderStatus;
			this.CreateTimeFilter = new TimeFilter(CreateTimeFrom, CreateTimeTo);
			this.OrderIDList = OrderIDList;
			Execute();
			return OrderList;
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
		/// Gets or sets the <see cref="GetOrdersRequestType"/> for this API call.
		/// </summary>
		public GetOrdersRequestType ApiRequest
		{ 
			get { return (GetOrdersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetOrdersResponseType"/> for this API call.
		/// </summary>
		public GetOrdersResponseType ApiResponse
		{ 
			get { return (GetOrdersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.OrderIDArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection OrderIDList
		{ 
			get { return ApiRequest.OrderIDArray; }
			set { ApiRequest.OrderIDArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.CreateTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime CreateTimeFrom
		{ 
			get { return ApiRequest.CreateTimeFrom; }
			set { ApiRequest.CreateTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.CreateTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime CreateTimeTo
		{ 
			get { return ApiRequest.CreateTimeTo; }
			set { ApiRequest.CreateTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.OrderRole"/> of type <see cref="TradingRoleCodeType"/>.
		/// </summary>
		public TradingRoleCodeType OrderRole
		{ 
			get { return ApiRequest.OrderRole; }
			set { ApiRequest.OrderRole = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.OrderStatus"/> of type <see cref="OrderStatusCodeType"/>.
		/// </summary>
		public OrderStatusCodeType OrderStatus
		{ 
			get { return ApiRequest.OrderStatus; }
			set { ApiRequest.OrderStatus = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.ListingType"/> of type <see cref="ListingTypeCodeType"/>.
		/// </summary>
		public ListingTypeCodeType ListingType
		{ 
			get { return ApiRequest.ListingType; }
			set { ApiRequest.ListingType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.ModTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeFrom
		{ 
			get { return ApiRequest.ModTimeFrom; }
			set { ApiRequest.ModTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.ModTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeTo
		{ 
			get { return ApiRequest.ModTimeTo; }
			set { ApiRequest.ModTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.NumberOfDays"/> of type <see cref="int"/>.
		/// </summary>
		public int NumberOfDays
		{ 
			get { return ApiRequest.NumberOfDays; }
			set { ApiRequest.NumberOfDays = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.IncludeFinalValueFee"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeFinalValueFee
		{ 
			get { return ApiRequest.IncludeFinalValueFee; }
			set { ApiRequest.IncludeFinalValueFee = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.SortingOrder"/> of type <see cref="SortOrderCodeType"/>.
		/// </summary>
		public SortOrderCodeType SortingOrder
		{ 
			get { return ApiRequest.SortingOrder; }
			set { ApiRequest.SortingOrder = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetOrdersRequestType.CreateTimeFrom"/> and <see cref="GetOrdersRequestType.CreateTimeTo"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter CreateTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.CreateTimeFrom, ApiRequest.CreateTimeTo); }
			set { 
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.CreateTimeFrom = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.CreateTimeTo = value.TimeTo;
			}
		}

		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.HasMoreOrders"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreOrders
		{ 
			get { return ApiResponse.HasMoreOrders; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.OrderArray"/> of type <see cref="OrderTypeCollection"/>.
		/// </summary>
		public OrderArrayType OrderList
		{ 
			get { return ApiResponse.OrderArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.OrdersPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int OrdersPerPage
		{ 
			get { return ApiResponse.OrdersPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetOrdersResponseType.ReturnedOrderCountActual"/> of type <see cref="int"/>.
		/// </summary>
		public int ReturnedOrderCountActual
		{ 
			get { return ApiResponse.ReturnedOrderCountActual; }
		}
		

		#endregion

		
	}
}

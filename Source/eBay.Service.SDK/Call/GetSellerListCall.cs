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
	public class GetSellerListCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellerListCall()
		{
			ApiRequest = new GetSellerListRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellerListCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellerListRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call is used to retrieve an array of listings for the seller. The seller must be associated with the user/application token being used to make the call.
		/// <br/><br/>
		/// This call requires that either the 'Start Time' or 'End Time' date range filters be used. The date range specified by either of these filters can not exceed 120 days or an error will occur.
		/// <br/><br/>
		/// This call also requires that pagination be used.
		/// </summary>
		/// 
		/// <param name="MotorsDealerUserList">
		/// Specifies the list of Motors Dealer sellers for which a special set of
		/// metrics can be requested. Applies to eBay Motors Pro applications only.
		/// </param>
		///
		/// <param name="EndTimeFrom">
		/// Specifies the earliest (oldest) date to use in a date range filter based on
		/// item end time. Specify either an end-time range or a start-time range
		/// filter in every call request. Each of the time ranges must be a value less than
		/// 120 days.
		/// </param>
		///
		/// <param name="EndTimeTo">
		/// Specifies the latest (most recent) date to use in a date range filter based on item end time. Must be specified if <b>EndTimeFrom</b> is specified.
		/// </param>
		///
		/// <param name="Sort">
		/// This field can be used to control the order in which returned listings are sorted (based on the listings' actual/scheduled end dates). Valid values are as follows:
		/// <ul>
		/// <li><code>1</code> (descending order)</li>
		/// <li>code>2</code> (ascending order)</li>
		/// </ul>
		/// </param>
		///
		/// <param name="StartTimeFrom">
		/// Specifies the earliest (oldest) date to use in a date range filter based on
		/// item start time. Each of the time ranges must be a value less than
		/// 120 days. In all calls, at least one date-range filter must be specified
		/// (i.e., you must specify either the end time range or start time range
		/// in every request).
		/// </param>
		///
		/// <param name="StartTimeTo">
		/// Specifies the latest (most recent) date to use in a date range filter based on item start time. Must be specified if <b>StartTimeFrom</b> is specified.
		/// </param>
		///
		/// <param name="Pagination">
		/// This container controls the maximum number of listings that can appear on one page of the result set, as well as the page number of the result to return.
		/// 
		/// The <b>GetSellerList</b> call requires that the <b>EntriesPerPage</b> value be set. The <b>PageNumber</b> field is not required but will default to <code>1</code> if not included.
		/// </param>
		///
		/// <param name="GranularityLevel">
		/// This field allows the user to control the amount of data that is returned in the response. See the <a href="#GranularityLevel">Granularity Level</a> table on this page for a list of the fields that are returned for each granularity level. Either <b>GranularityLevel</b> or  <b>DetailLevel</b> can be used in a <b>GetSellerList</b> call, but not both. If both are specified, <b>DetailLevel</b> is ignored. If neither are used, the response fields will be the ones shown for 'Coarse' granularity.
		/// </param>
		///
		/// <param name="SKUArrayList">
		/// This container can be used to specify one or multiple SKUs, and only listings associated with these SKUs are retrieved. Note that all other request criteria are also considered when one or more SKU values are specified.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// Listings with matching SKUs are returned regardless of their
		/// <b>Item.InventoryTrackingMethod</b> setting.
		/// </span>
		/// </param>
		///
		/// <param name="IncludeWatchCount">
		/// This field may be included and set to <code>true</code> if the seller wishes to see the number of eBay users that are watching each listing.
		/// </param>
		///
		/// <param name="AdminEndedItemsOnly">
		/// This boolean field can be included and set to <code>true</code> if the seller would like to retrieve any listings that were administratively ended by eBay due to a listing policy violation.
		/// </param>
		///
		/// <param name="CategoryID">
		/// If you specify a <b>CategoryID</b> value, the response will only contain listings in the category you specify.
		/// </param>
		///
		/// <param name="IncludeVariations">
		/// If this field is included and set to <code>true</code>, the <b>Variations</b> node is returned for all multi-variation listings in the response.
		/// 
		/// 
		/// <span class="tablenote"><b>Note: </b> If the seller has many multiple-variation listings, that seller may not want to include variations in the <b>GetSellerList</b> response.  Or, a seller can include variations data, but possibly limit the response by specifying shorter date ranges with the date range filters, or by reducing the number of listings returned per results (decreasing the <b>Pagination.EntriesPerPage</b> value).
		/// </span>
		/// </param>
		///
		public ItemTypeCollection GetSellerList(UserIDArrayType MotorsDealerUserList, DateTime EndTimeFrom, DateTime EndTimeTo, int Sort, DateTime StartTimeFrom, DateTime StartTimeTo, PaginationType Pagination, GranularityLevelCodeType GranularityLevel, StringCollection SKUArrayList, bool IncludeWatchCount, bool AdminEndedItemsOnly, int CategoryID, bool IncludeVariations)
		{
			this.MotorsDealerUserList = MotorsDealerUserList;
			this.EndTimeFrom = EndTimeFrom;
			this.EndTimeTo = EndTimeTo;
			this.Sort = Sort;
			this.StartTimeFrom = StartTimeFrom;
			this.StartTimeTo = StartTimeTo;
			this.Pagination = Pagination;
			this.GranularityLevel = GranularityLevel;
			this.SKUArrayList = SKUArrayList;
			this.IncludeWatchCount = IncludeWatchCount;
			this.AdminEndedItemsOnly = AdminEndedItemsOnly;
			this.CategoryID = CategoryID;
			this.IncludeVariations = IncludeVariations;

			Execute();
			return ApiResponse.ItemArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemTypeCollection GetSellerList()
		{
			Execute();
			return ItemList;
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
		/// Gets or sets the <see cref="GetSellerListRequestType"/> for this API call.
		/// </summary>
		public GetSellerListRequestType ApiRequest
		{ 
			get { return (GetSellerListRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellerListResponseType"/> for this API call.
		/// </summary>
		public GetSellerListResponseType ApiResponse
		{ 
			get { return (GetSellerListResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.MotorsDealerUsers"/> of type <see cref="UserIDArrayType"/>.
		/// </summary>
		public UserIDArrayType MotorsDealerUserList
		{ 
			get { return ApiRequest.MotorsDealerUsers; }
			set { ApiRequest.MotorsDealerUsers = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.EndTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeFrom
		{ 
			get { return ApiRequest.EndTimeFrom; }
			set { ApiRequest.EndTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.EndTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeTo
		{ 
			get { return ApiRequest.EndTimeTo; }
			set { ApiRequest.EndTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.Sort"/> of type <see cref="int"/>.
		/// </summary>
		public int Sort
		{ 
			get { return ApiRequest.Sort; }
			set { ApiRequest.Sort = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.StartTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTimeFrom
		{ 
			get { return ApiRequest.StartTimeFrom; }
			set { ApiRequest.StartTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.StartTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTimeTo
		{ 
			get { return ApiRequest.StartTimeTo; }
			set { ApiRequest.StartTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.GranularityLevel"/> of type <see cref="GranularityLevelCodeType"/>.
		/// </summary>
		public GranularityLevelCodeType GranularityLevel
		{ 
			get { return ApiRequest.GranularityLevel; }
			set { ApiRequest.GranularityLevel = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.SKUArray"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection SKUArrayList
		{ 
			get { return ApiRequest.SKUArray; }
			set { ApiRequest.SKUArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.IncludeWatchCount"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeWatchCount
		{ 
			get { return ApiRequest.IncludeWatchCount; }
			set { ApiRequest.IncludeWatchCount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.AdminEndedItemsOnly"/> of type <see cref="bool"/>.
		/// </summary>
		public bool AdminEndedItemsOnly
		{ 
			get { return ApiRequest.AdminEndedItemsOnly; }
			set { ApiRequest.AdminEndedItemsOnly = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.CategoryID"/> of type <see cref="int"/>.
		/// </summary>
		public int CategoryID
		{ 
			get { return ApiRequest.CategoryID; }
			set { ApiRequest.CategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.IncludeVariations"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeVariations
		{ 
			get { return ApiRequest.IncludeVariations; }
			set { ApiRequest.IncludeVariations = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.EndTimeFrom"/> and <see cref="GetSellerListRequestType.EndTimeTo"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter EndTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.EndTimeFrom, ApiRequest.EndTimeTo); }
			set 
			{
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.EndTimeFrom = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.EndTimeTo = value.TimeTo;
			}
		}

		/// <summary>
		/// Gets or sets the <see cref="GetSellerListRequestType.StartTimeFrom"/> and <see cref="GetSellerListRequestType.StartTimeTo"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter StartTimeFilter
		{ 
			get { return new TimeFilter(ApiRequest.StartTimeFrom, ApiRequest.StartTimeTo); }
			set 
			{
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.StartTimeFrom = value.TimeFrom;
				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.StartTimeTo = value.TimeTo;
			}
		}


		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerListResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerListResponseType.HasMoreItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreItems
		{ 
			get { return ApiResponse.HasMoreItems; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerListResponseType.ItemArray"/> of type <see cref="ItemTypeCollection"/>.
		/// </summary>
		public ItemTypeCollection ItemList
		{ 
			get { return ApiResponse.ItemArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerListResponseType.ItemsPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int ItemsPerPage
		{ 
			get { return ApiResponse.ItemsPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerListResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerListResponseType.ReturnedItemCountActual"/> of type <see cref="int"/>.
		/// </summary>
		public int ReturnedItemCountActual
		{ 
			get { return ApiResponse.ReturnedItemCountActual; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerListResponseType.Seller"/> of type <see cref="UserType"/>.
		/// </summary>
		public UserType Seller
		{ 
			get { return ApiResponse.Seller; }
		}
		

		#endregion

		
	}
}

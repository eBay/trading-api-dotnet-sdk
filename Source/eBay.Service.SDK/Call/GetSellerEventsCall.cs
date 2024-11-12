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
	public class GetSellerEventsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSellerEventsCall()
		{
			ApiRequest = new GetSellerEventsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSellerEventsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSellerEventsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call is used by a seller to retrieve changes to their own listings that have occurred within the last 48 hours, including price changes, available quantity, and other revisions to listing.
		/// <br/><br/>
		/// One of the available date range filters must be used with this call.
		/// </summary>
		/// 
		/// <param name="UserID">
		/// <span class="tablenote"><strong>Note:</strong>
		/// This field should no longer be used, and will be ignored if it is included in a <b>GetSellerEvents</b> request. There are plans to remove this field from the public WSDL. The only eBay user ID that can be used is the one associated with the authentication token.
		/// </span>
		/// </param>
		///
		/// <param name="StartTimeFrom">
		/// Describes the earliest (oldest) time to use in a time range filter based
		/// on item start time. Must be specified if <b>StartTimeTo</b> is specified.
		/// <br/><br/>
		/// Either
		/// the <b>StartTimeFrom</b>, <b>EndTimeFrom</b>, or <b>ModTimeFrom</b> filter must be specified.
		/// <br/><br/>
		/// If you do not specify the corresponding <b>To</b> filter,
		/// it is set to the time you make the call.
		/// <br/><br/>
		/// For better results, the time period you use should be less than 48 hours.
		/// If 3000 or more items are found, use a smaller time range.
		/// 
		/// Include a 2-minute, overlapping buffer between requests.
		/// For example, if <b>StartTimeTo</b> was 6:58 in a prior request,
		/// the current request should use 6:56 in <b>StartTimeFrom</b>
		/// (e.g., use ranges like 5:56-6:58, 6:56-7:58, 7:56-8:58).
		/// </param>
		///
		/// <param name="StartTimeTo">
		/// Describes the latest (most recent) date to use in a time range filter
		/// based on item start time. If you specify the corresponding <b>From</b> filter,
		/// but you do not include <b>StartTimeTo</b>, the <b>StartTimeTo</b> is set to
		/// the time you make the call.
		/// </param>
		///
		/// <param name="EndTimeFrom">
		/// Describes the earliest (oldest) date to use in a time range filter based
		/// on item end time. Must be specified if <b>EndTimeTo</b> is specified.
		/// <br/><br/>
		/// Either
		/// the <b>StartTimeFrom</b>, <b>EndTimeFrom</b>, or <b>ModTimeFrom</b> filter must be specified.
		/// If you do not specify the corresponding To filter,
		/// it is set to the time you make the call.
		/// 
		/// For better results, the time range you use should be less than 48 hours.
		/// If 3000 or more items are found, use a smaller time range.
		/// 
		/// Include a 2-minute, overlapping buffer between requests.
		/// For example, if <b>EndTimeTo</b> was 6:58 in a prior request,
		/// the current request should use 6:56 in <b>EndTimeFrom</b>
		/// (e.g., use ranges like 5:56-6:58, 6:56-7:58, 7:56-8:58).
		/// </param>
		///
		/// <param name="EndTimeTo">
		/// Describes the latest (most recent) date to use in a time range filter
		/// based on item end time.
		/// <br/><br/>
		/// If you specify the corresponding <b>From</b> filter,
		/// but you do not include <b>EndTimeTo</b>, then <b>EndTimeTo</b> is set
		/// to the time you make the call.
		/// </param>
		///
		/// <param name="ModTimeFrom">
		/// Describes the earliest (oldest) date to use in a time range filter based
		/// on item modification time. Must be specified if <b>ModTimeTo</b> is specified. Either
		/// the <b>StartTimeFrom</b>, <b>EndTimeFrom</b>, or <b>ModTimeFrom</b> filter must be specified.
		/// If you do not specify the corresponding To filter,
		/// it is set to the time you make the call.
		/// 
		/// Include a 2-minute, overlapping buffer between requests.
		/// For example, if <b>ModTimeTo</b> was 6:58 in a prior request,
		/// the current request should use 6:56 in <b>ModTimeFrom</b>
		/// (e.g., use ranges like 5:56-6:58, 6:56-7:58, 7:56-8:58).
		/// 
		/// For better results, the time range you use should be less than 48 hours.
		/// If 3000 or more items are found, use a smaller time range.
		/// 
		/// If an unexpected item is returned (including an old item
		/// or an unchanged active item), please ignore the item.
		/// Although a maintenance process may have triggered a change in the modification time, item characteristics are unchanged.
		/// </param>
		///
		/// <param name="ModTimeTo">
		/// Describes the latest (most recent) date and time to use in a time range filter based on the time an item's record was modified. If you specify the corresponding <b>From</b> filter, but you do not include <b>ModTimeTo</b> , then <b>ModTimeTo</b> is set to the time you make the call. Include a 2-minute buffer between the current time and the <b>ModTimeTo</b> filter.
		/// </param>
		///
		/// <param name="IncludeNewItem">
		/// If true, response includes only items that have been modified
		/// within the <b>ModTime</b> range. If false, response includes all items.
		/// </param>
		///
		/// <param name="IncludeWatchCount">
		/// The seller can include this field and set its value to <code>true</code> if that seller wants to see how many prospective bidders/buyers currently have an item added to their Watch Lists. The Watch count is returned in the <b>WatchCount</b> field for each item in the response.
		/// </param>
		///
		/// <param name="IncludeVariationSpecifics">
		/// Specifies whether to force the response to include
		/// variation specifics for multiple-variation listings. 
		/// 
		/// If false (or not specified), eBay keeps the response as small as
		/// possible by not returning <b>Variation.VariationSpecifics</b>.
		/// It only returns <b>Variation.SKU</b> as an identifier
		/// (along with the variation price and other selling details).
		/// If the variation has no SKU, then <b>Variation.VariationSpecifics</b>
		/// is returned as the variation's unique identifier.
		/// 
		/// If true, <b>Variation.VariationSpecifics</b> is returned.
		/// (<b>Variation.SKU</b> is also returned, if the variation has a SKU.)
		/// This may be useful for applications that don't track variations
		/// by SKU.
		/// 
		/// Ignored when <b>HideVariations</b> is set to <b>true</b>.
		/// 
		/// 
		/// <b>Note:</b>  If the seller includes a large number of
		/// variations in many listings, using this flag may degrade the
		/// call's performance. Therefore, when you use this flag, you may
		/// need to reduce the total number of items you're requesting at
		/// once. For example, you may need to use shorter time ranges in
		/// the <b>StartTimeFrom</b>, <b>EndTimeFrom</b>, or <b>ModTimeFrom</b> filters.
		/// </param>
		///
		/// <param name="HideVariations">
		/// Specifies whether to force the response to hide
		/// variation details for multiple-variation listings.
		/// 
		/// If false (or not specified), eBay returns variation details (if
		/// any). In this case, the amount of detail can be controlled by
		/// using <b>IncludeVariationSpecifics</b>.
		/// 
		/// If true, variation details are not returned (and
		/// <b>IncludeVariationSpecifics</b> has no effect). This may be useful for applications that use other calls, notifications, alerts, or reports to track price and quantity details.
		/// </param>
		///
		public void GetSellerEvents(string UserID, DateTime StartTimeFrom, DateTime StartTimeTo, DateTime EndTimeFrom, DateTime EndTimeTo, DateTime ModTimeFrom, DateTime ModTimeTo, bool IncludeNewItem, bool IncludeWatchCount, bool IncludeVariationSpecifics, bool HideVariations)
		{
			this.StartTimeFrom = StartTimeFrom;
			this.StartTimeTo = StartTimeTo;
			this.EndTimeFrom = EndTimeFrom;
			this.EndTimeTo = EndTimeTo;
			this.ModTimeFrom = ModTimeFrom;
			this.ModTimeTo = ModTimeTo;
			this.IncludeNewItem = IncludeNewItem;
			this.IncludeWatchCount = IncludeWatchCount;
			this.IncludeVariationSpecifics = IncludeVariationSpecifics;
			this.HideVariations = HideVariations;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemTypeCollection GetSellerEvents(TimeFilter ModTimeFilter)
		{
			this.ModTimeFilter = ModTimeFilter;
			Execute();
			return ItemEventList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ItemTypeCollection GetSellerEvents(DateTime ModTimeFrom, DateTime ModTimeTo)
		{
			this.ModTimeFilter = new TimeFilter(ModTimeFrom, ModTimeTo);
			Execute();
			return ItemEventList;
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
		/// Gets or sets the <see cref="GetSellerEventsRequestType"/> for this API call.
		/// </summary>
		public GetSellerEventsRequestType ApiRequest
		{ 
			get { return (GetSellerEventsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSellerEventsResponseType"/> for this API call.
		/// </summary>
		public GetSellerEventsResponseType ApiResponse
		{ 
			get { return (GetSellerEventsResponseType) AbstractResponse; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.StartTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTimeFrom
		{ 
			get { return ApiRequest.StartTimeFrom; }
			set { ApiRequest.StartTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.StartTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTimeTo
		{ 
			get { return ApiRequest.StartTimeTo; }
			set { ApiRequest.StartTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.EndTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeFrom
		{ 
			get { return ApiRequest.EndTimeFrom; }
			set { ApiRequest.EndTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.EndTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeTo
		{ 
			get { return ApiRequest.EndTimeTo; }
			set { ApiRequest.EndTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.ModTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeFrom
		{ 
			get { return ApiRequest.ModTimeFrom; }
			set { ApiRequest.ModTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.ModTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime ModTimeTo
		{ 
			get { return ApiRequest.ModTimeTo; }
			set { ApiRequest.ModTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.NewItemFilter"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeNewItem
		{ 
			get { return ApiRequest.NewItemFilter; }
			set { ApiRequest.NewItemFilter = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.IncludeWatchCount"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeWatchCount
		{ 
			get { return ApiRequest.IncludeWatchCount; }
			set { ApiRequest.IncludeWatchCount = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.IncludeVariationSpecifics"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeVariationSpecifics
		{ 
			get { return ApiRequest.IncludeVariationSpecifics; }
			set { ApiRequest.IncludeVariationSpecifics = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.HideVariations"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HideVariations
		{ 
			get { return ApiRequest.HideVariations; }
			set { ApiRequest.HideVariations = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetSellerEventsRequestType.EndTimeFrom"/> and <see cref="GetSearchResultsRequestType.EndTimeTo"/> of type <see cref="TimeFilter"/>.
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
		/// Gets or sets the <see cref="GetSellerEventsRequestType.ModTimeFrom"/> and <see cref="GetSellerEventsRequestType.ModTimeTo"/> of type <see cref="TimeFilter"/>.
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
		/// Gets or sets the <see cref="GetSellerEventsRequestType.StartTimeFrom"/> and <see cref="GetSellerEventsRequestType.StartTimeTo"/> of type <see cref="TimeFilter"/>.
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
		/// Gets the returned <see cref="GetSellerEventsResponseType.TimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime TimeTo
		{ 
			get { return ApiResponse.TimeTo; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSellerEventsResponseType.ItemArray"/> of type <see cref="ItemTypeCollection"/>.
		/// </summary>
		public ItemTypeCollection ItemEventList
		{ 
			get { return ApiResponse.ItemArray; }
		}
		

		#endregion

		
	}
}

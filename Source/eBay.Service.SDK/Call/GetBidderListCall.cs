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
	public class GetBidderListCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetBidderListCall()
		{
			ApiRequest = new GetBidderListRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetBidderListCall(ApiContext ApiContext)
		{
			ApiRequest = new GetBidderListRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves all items that the user is currently bidding on, and the ones they have won or purchased.
		/// </summary>
		/// 
		/// <param name="ActiveItemsOnly">
		/// Indicates whether or not to limit the result set to active items. If <code>true</code>, only
		/// active items are returned and the <b>EndTimeFrom</b> and <b>EndTimeTo</b> filters are
		/// ignored. If <code>false</code> (or not sent), both active and ended items are returned.
		/// </param>
		///
		/// <param name="EndTimeFrom">
		/// Used in conjunction with <b>EndTimeTo</b>. Limits returned items to only those for
		/// which the item's end date is on or after the date/time specified. Specify an
		/// end date within 30 days prior to today. Items that ended more than 30 days
		/// ago are omitted from the results. If specified, <b>EndTimeTo</b> must also be
		/// specified. Express date/time in the format <code>YYYY-MM-DD HH:MM:SS</code>, and in GMT.
		/// This field is ignored if <b>ActiveItemsOnly</b> is set to <code>true</code>.
		/// </param>
		///
		/// <param name="EndTimeTo">
		/// Used in conjunction with <b>EndTimeFrom</b>. Limits returned items to only those for
		/// which the item's end date is on or before the date/time specified. If
		/// specified, <b>EndTimeFrom</b> must also be specified. Express date/time in the format
		/// <code>YYYY-MM-DD HH:MM:SS</code>, and in GMT. This field is ignored if <b>ActiveItemsOnly</b> is set to
		/// <code>true</code>. Note that for GTC items, whose end times automatically increment by 30
		/// days every 30 days, an <b>EndTimeTo</b> value within the first 30 days of a listing will
		/// refer to the listing's initial end time.
		/// 
		/// <span class="tablenote"><b>Note: </b>
		/// Starting July 1, 2019, the Good 'Til Cancelled renewal schedule will be modified from every 30 days to once per calendar month. For example, if a GTC listing is created July 5, the next monthly renewal date will be August 5. If a GTC listing is created on the 31st of the month, but the following month only has 30 days, the renewal will happen on the 30th in the following month. Finally, if a GTC listing is created on January 29-31, the renewal will happen on February 28th (or 29th during a 'Leap Year'). See the
		/// <a href="https://pages.ebay.com/seller-center/seller-updates/2019-spring/marketplace-updates.html#good-til-cancelled" target="_blank">Good 'Til Cancelled listings update</a> in the <b>Spring 2019 Seller Updates</b> for more information about this change.
		/// </span>
		/// </param>
		///
		/// <param name="UserID">
		/// The unique identifier of an eBay user.
		/// 
		/// This field is generally not required unless there are multiple User IDs tied to the requester credentials that are specified through the <b>RequesterCredentials</b> header. If there are multiple User IDs tied to the requester credentials, this field allows you to specify the User ID for which you wish to retrieves bids and purchases.
		/// </param>
		///
		/// <param name="GranularityLevel">
		/// You can control some of the fields returned in the response by specifying one of two values in the <b>GranularityLevel</b> field: <code>Fine</code> or <code>Medium</code>. <code>Fine</code> returns more fields than the default, while setting this field to <code>Medium</code> returns an abbreviated set of results.
		/// </param>
		///
		public ItemTypeCollection GetBidderList(bool ActiveItemsOnly, DateTime EndTimeFrom, DateTime EndTimeTo, string UserID, GranularityLevelCodeType GranularityLevel)
		{
			this.ActiveItemsOnly = ActiveItemsOnly;
			this.EndTimeFrom = EndTimeFrom;
			this.EndTimeTo = EndTimeTo;
			this.UserID = UserID;
			this.GranularityLevel = GranularityLevel;

			Execute();
			return ApiResponse.BidItemArray;
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
		/// Gets or sets the <see cref="GetBidderListRequestType"/> for this API call.
		/// </summary>
		public GetBidderListRequestType ApiRequest
		{ 
			get { return (GetBidderListRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetBidderListResponseType"/> for this API call.
		/// </summary>
		public GetBidderListResponseType ApiResponse
		{ 
			get { return (GetBidderListResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetBidderListRequestType.ActiveItemsOnly"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ActiveItemsOnly
		{ 
			get { return ApiRequest.ActiveItemsOnly; }
			set { ApiRequest.ActiveItemsOnly = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBidderListRequestType.EndTimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeFrom
		{ 
			get { return ApiRequest.EndTimeFrom; }
			set { ApiRequest.EndTimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBidderListRequestType.EndTimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeTo
		{ 
			get { return ApiRequest.EndTimeTo; }
			set { ApiRequest.EndTimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBidderListRequestType.UserID"/> of type <see cref="string"/>.
		/// </summary>
		public string UserID
		{ 
			get { return ApiRequest.UserID; }
			set { ApiRequest.UserID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetBidderListRequestType.GranularityLevel"/> of type <see cref="GranularityLevelCodeType"/>.
		/// </summary>
		public GranularityLevelCodeType GranularityLevel
		{ 
			get { return ApiRequest.GranularityLevel; }
			set { ApiRequest.GranularityLevel = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetBidderListResponseType.Bidder"/> of type <see cref="UserType"/>.
		/// </summary>
		public UserType Bidder
		{ 
			get { return ApiResponse.Bidder; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetBidderListResponseType.BidItemArray"/> of type <see cref="ItemTypeCollection"/>.
		/// </summary>
		public ItemTypeCollection BidItemList
		{ 
			get { return ApiResponse.BidItemArray; }
		}
		

		#endregion

		
	}
}

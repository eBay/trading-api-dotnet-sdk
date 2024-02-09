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
	public class GetAllBiddersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetAllBiddersCall()
		{
			ApiRequest = new GetAllBiddersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetAllBiddersCall(ApiContext ApiContext)
		{
			ApiRequest = new GetAllBiddersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This is the base request type for the <b>GetAllBidders</b> call, which is used to retrieve bidders from an active or recently-ended auction listing.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// This is the unique identifier of the auction listing for which bidders are being retrieved. This auction listing can be active or recently ended. However, to retrieve bidders for an active auction listing, the only <b>CallMode</b> enumeration value that can be used is <code>ViewAll</code>.
		/// </param>
		///
		/// <param name="CallMode">
		/// The enumeration value that is passed into this field will control the set of bidders that will be retrieved in the response. To retrieve bidders from a recently-ended auction listing, any of the three values can be used. To retrieve bidders for an active auction listing, only the <code>ViewAll</code> enumeration value can be used. These values are discussed in <b>GetAllBiddersModeCodeType</b>.
		/// <br/>
		/// </param>
		///
		/// <param name="IncludeBiddingSummary">
		/// The user must include this field and set its value to <code>true</code> if the user wishes to retrieve the  <b>BiddingSummary</b> container for each bidder. The <b>BiddingSummary</b> container consists of more detailed bidding information on each bidder.
		/// </param>
		///
		public OfferTypeCollection GetAllBidders(string ItemID, GetAllBiddersModeCodeType CallMode, bool IncludeBiddingSummary)
		{
			this.ItemID = ItemID;
			this.CallMode = CallMode;
			this.IncludeBiddingSummary = IncludeBiddingSummary;

			Execute();
			return ApiResponse.BidArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public OfferTypeCollection GetAllBidders(string ItemID, GetAllBiddersModeCodeType CallMode)
		{
			this.ItemID = ItemID;
			this.CallMode = CallMode;

			Execute();
			return ApiResponse.BidArray;
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
		/// Gets or sets the <see cref="GetAllBiddersRequestType"/> for this API call.
		/// </summary>
		public GetAllBiddersRequestType ApiRequest
		{ 
			get { return (GetAllBiddersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetAllBiddersResponseType"/> for this API call.
		/// </summary>
		public GetAllBiddersResponseType ApiResponse
		{ 
			get { return (GetAllBiddersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetAllBiddersRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAllBiddersRequestType.CallMode"/> of type <see cref="GetAllBiddersModeCodeType"/>.
		/// </summary>
		public GetAllBiddersModeCodeType CallMode
		{ 
			get { return ApiRequest.CallMode; }
			set { ApiRequest.CallMode = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAllBiddersRequestType.IncludeBiddingSummary"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeBiddingSummary
		{ 
			get { return ApiRequest.IncludeBiddingSummary; }
			set { ApiRequest.IncludeBiddingSummary = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetAllBiddersResponseType.BidArray"/> of type <see cref="OfferTypeCollection"/>.
		/// </summary>
		public OfferTypeCollection BidList
		{ 
			get { return ApiResponse.BidArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAllBiddersResponseType.HighBidder"/> of type <see cref="string"/>.
		/// </summary>
		public string HighBidder
		{ 
			get { return ApiResponse.HighBidder; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAllBiddersResponseType.HighestBid"/> of type <see cref="AmountType"/>.
		/// </summary>
		public AmountType HighestBid
		{ 
			get { return ApiResponse.HighestBid; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAllBiddersResponseType.ListingStatus"/> of type <see cref="ListingStatusCodeType"/>.
		/// </summary>
		public ListingStatusCodeType ListingStatus
		{ 
			get { return ApiResponse.ListingStatus; }
		}
		

		#endregion

		
	}
}

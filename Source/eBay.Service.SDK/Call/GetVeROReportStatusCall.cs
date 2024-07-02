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
	public class GetVeROReportStatusCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetVeROReportStatusCall()
		{
			ApiRequest = new GetVeROReportStatusRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetVeROReportStatusCall(ApiContext ApiContext)
		{
			ApiRequest = new GetVeROReportStatusRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves status information about VeRO reported items you have submitted. You
		/// can receive the status of individual items you have reported or, by specifying
		/// <strong>VeROReportPacketID</strong>, you can retrieve status for all items reported with a given
		/// <strong>VeROReportItems</strong> request. You can also retrieve items that were reported during a
		/// given time period. If no input parameters are specified, status is returned on all
		/// items you have reported in the last two years.
		/// You must be a member of the Verified Rights Owner (VeRO) Program to use this
		/// call.
		/// </summary>
		/// 
		/// <param name="VeROReportPacketID">
		/// Packet identifier associated with the reported items for which you want to
		/// retrieve status. By default, reported item details are not returned when
		/// you specify the packet ID in the request. Applies only to items reported
		/// with the <strong>VeROReportItems</strong> call.
		/// </param>
		///
		/// <param name="ItemID">
		/// Unique identifier for an eBay listing reported for alleged infringement. Applies to items reported with the <strong>VeROReportItems</strong> call or by other means (e.g., through the Web flow).
		/// </param>
		///
		/// <param name="IncludeReportedItemDetails">
		/// Set to true to return reported item details when you specify <strong>VeROReportPacketID</strong> in the request.
		/// </param>
		///
		/// <param name="TimeFrom">
		/// Limits returned items to only those that were submited on or after the
		/// date-time specified. If specified, TimeTo must also be specified.
		/// Express the date-time in the format YYYY-MM-DD HH:MM:SS, and in GMT.
		/// (For information on how to convert between your local time zone
		/// and GMT, see Time Values Note.) Applies to items reported with
		/// VeROReportItems or by other means (e.g., through the web flow).
		/// Infringement reporting data is maintained for two years after the date of
		/// submission.
		/// This field is ignored if <strong>VeROReportPacketID</strong> or <strong>ItemID</strong> is specified.
		/// </param>
		///
		/// <param name="TimeTo">
		/// Limits returned items to only those that were submited on or before the
		/// date-time specified. If specified, TimeFrom must also be specified.
		/// Express date-time in the format YYYY-MM-DD HH:MM:SS, and in GMT.
		/// (For information on how to convert between your local time zone
		/// and GMT, see Time Values Note.) Applies to items reported with
		/// VeROReportItems or by other means (e.g., through the web flow).
		/// Infringement reporting data is maintained for two years after the date of
		/// submission.
		/// This field is ignored if <strong>VeROReportPacketID</strong> or <strong>ItemID</strong> is specified.
		/// </param>
		///
		/// <param name="Pagination">
		/// Contains the data controlling the pagination of the returned values: how
		/// many items are returned per page of data (per call) and the number of the
		/// page to return with the current call.
		/// </param>
		///
		public PaginationResultType GetVeROReportStatus(long VeROReportPacketID, string ItemID, bool IncludeReportedItemDetails, DateTime TimeFrom, DateTime TimeTo, PaginationType Pagination)
		{
			this.VeROReportPacketID = VeROReportPacketID;
			this.ItemID = ItemID;
			this.IncludeReportedItemDetails = IncludeReportedItemDetails;
			this.TimeFrom = TimeFrom;
			this.TimeTo = TimeTo;
			this.Pagination = Pagination;

			Execute();
			return ApiResponse.PaginationResult;
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
		/// Gets or sets the <see cref="GetVeROReportStatusRequestType"/> for this API call.
		/// </summary>
		public GetVeROReportStatusRequestType ApiRequest
		{ 
			get { return (GetVeROReportStatusRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetVeROReportStatusResponseType"/> for this API call.
		/// </summary>
		public GetVeROReportStatusResponseType ApiResponse
		{ 
			get { return (GetVeROReportStatusResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReportStatusRequestType.VeROReportPacketID"/> of type <see cref="long"/>.
		/// </summary>
		public long VeROReportPacketID
		{ 
			get { return ApiRequest.VeROReportPacketID; }
			set { ApiRequest.VeROReportPacketID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReportStatusRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReportStatusRequestType.IncludeReportedItemDetails"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeReportedItemDetails
		{ 
			get { return ApiRequest.IncludeReportedItemDetails; }
			set { ApiRequest.IncludeReportedItemDetails = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReportStatusRequestType.TimeFrom"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime TimeFrom
		{ 
			get { return ApiRequest.TimeFrom; }
			set { ApiRequest.TimeFrom = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReportStatusRequestType.TimeTo"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime TimeTo
		{ 
			get { return ApiRequest.TimeTo; }
			set { ApiRequest.TimeTo = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReportStatusRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReportStatusResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReportStatusResponseType.HasMoreItems"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreItems
		{ 
			get { return ApiResponse.HasMoreItems; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReportStatusResponseType.ItemsPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int ItemsPerPage
		{ 
			get { return ApiResponse.ItemsPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReportStatusResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReportStatusResponseType.VeROReportPacketID"/> of type <see cref="long"/>.
		/// </summary>
		public long VeROReportPacketIDReturn
		{ 
			get { return ApiResponse.VeROReportPacketID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReportStatusResponseType.VeROReportPacketStatus"/> of type <see cref="VeROReportPacketStatusCodeType"/>.
		/// </summary>
		public VeROReportPacketStatusCodeType VeROReportPacketStatus
		{ 
			get { return ApiResponse.VeROReportPacketStatus; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReportStatusResponseType.ReportedItemDetails"/> of type <see cref="VeROReportedItemTypeCollection"/>.
		/// </summary>
		public VeROReportedItemTypeCollection ReportedItemDetailList
		{ 
			get { return ApiResponse.ReportedItemDetails; }
		}
		

		#endregion

		
	}
}

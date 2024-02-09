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
	public class GetFeedbackCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetFeedbackCall()
		{
			ApiRequest = new GetFeedbackRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetFeedbackCall(ApiContext ApiContext)
		{
			ApiRequest = new GetFeedbackRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves one, many, or all Feedback records for a specific eBay user. There is a filter option in the call request to limit Feedback records to those that are received, or to those that are left for other buyers, as well as a filter option to limit Feedback records to those that are received as a buyer or seller.
		/// </summary>
		/// 
		/// <param name="UserID">
		/// The user's eBay User ID is specified in this field. If this field is used, all retrieved Feedback data will be for this eBay user. Specifies the user whose feedback data is to be returned. If this field is omitted in the call request, all retrieved Feedback records will be for the eBay user making the call.
		/// </param>
		///
		/// <param name="FeedbackID">
		/// The unique identifier of a Feedback record. This field is used if the user wants to retrieve a specific Feedback record. If <b>FeedbackID</b> is specified in the call request, all other input fields are ignored.
		/// </param>
		///
		/// <param name="ItemID">
		/// Unique identifier for an eBay listing. A listing can have multiple order line items, but only one <b>ItemID</b>. If <b>ItemID</b> is specified in the <b>GetFeedback</b> request, the returned Feedback record(s) are restricted to the specified <b>ItemID</b>. The maximum number of Feedback records that can be returned is 100.
		/// </param>
		///
		/// <param name="TransactionID">
		/// Unique identifier for an eBay order line item. A
		/// <b>TransactionID</b> can be paired up with its corresponding <b>ItemID</b> and used as
		/// an input filter in the <b>GetFeedback</b> request. If an <b>ItemID</b>/<b>TransactionID</b>
		/// pair or an <b>OrderLineItemID</b> value is used to retrieve a feedback record
		/// on a specific order line item, the <b>FeedbackType</b> and <b>Pagination</b>
		/// fields (if included) are ignored.
		/// </param>
		///
		/// <param name="CommentTypeList">
		/// This field is used to retrieve Feedback records of a specific type (Positive, Negative, or Neutral) in <b>FeedbackDetailArray</b>. You can include one or two <b> CommentType</b> fields in the request. If no <b>CommentType</b> value is specified, Feedback records of all types are returned.
		/// </param>
		///
		/// <param name="FeedbackType">
		/// This field is used to restrict retrieved Feedback records to those that the user left for other buyers, Feedback records received as a seller, Feedback records received as a buyer, or Feedback records received as a buyer and seller. The default value is <b>FeedbackReceived</b>, so if the  <b>FeedbackType</b> field is omitted in the request, all Feedback records received by the user as a buyer and seller are returned in the response. "Feedback Left" data will not be returned in the call response.
		/// </param>
		///
		/// <param name="Pagination">
		/// Controls the pagination of the result set. Child elements, <b>EntriesPerPage</b> and
		/// <b>PageNumber</b>, specify the maximum number of individual feedback records to return
		/// per call and which page of data to return. Only applicable if <b>DetailLevel</b> is
		/// set to <b>ReturnAll</b> and the call is returning feedback for a <b>UserID</b>. Feedback
		/// summary data is not paginated, but when pagination is used, it is returned
		/// after the last feedback detail entry.
		/// 
		/// Accepted values for <b>Pagination.EntriesPerPage</b> for GetFeedback is 25 (the
		/// default), 50, 100, and 200. If you specify a value of zero, or a value
		/// greater than 200, the call fails with an error. If you specify a value between
		/// one and twenty-four, the value is rounded up to 25. Values between 26 and 199
		/// that are not one of the accepted values are rounded down to the nearest
		/// accepted value.
		/// </param>
		///
		/// <param name="OrderLineItemID">
		/// <b>OrderLineItemID</b> is a unique identifier for an eBay order line item. An <b>OrderLineItemID</b> can be used as an
		/// input filter in the <b>GetFeedback</b> request. If an <b>OrderLineItemID</b> value is
		/// used to retrieve a feedback record on a specific order line item, the
		/// <b>FeedbackType</b> and <b>Pagination</b> fields (if included) are ignored.
		/// </param>
		///
		public FeedbackDetailTypeCollection GetFeedback(string UserID, string FeedbackID, string ItemID, string TransactionID, CommentTypeCodeTypeCollection CommentTypeList, FeedbackTypeCodeType FeedbackType, PaginationType Pagination, string OrderLineItemID)
		{
			this.UserID = UserID;
			this.FeedbackID = FeedbackID;
			this.ItemID = ItemID;
			this.TransactionID = TransactionID;
			this.CommentTypeList = CommentTypeList;
			this.FeedbackType = FeedbackType;
			this.Pagination = Pagination;
			this.OrderLineItemID = OrderLineItemID;

			Execute();
			return ApiResponse.FeedbackDetailArray;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public FeedbackDetailTypeCollection GetFeedback()
		{
			Execute();
			return FeedbackList;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public FeedbackDetailTypeCollection GetFeedback(string UserID)
		{
			this.UserID = UserID;
			Execute();
			return FeedbackList;
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
		/// Gets or sets the <see cref="GetFeedbackRequestType"/> for this API call.
		/// </summary>
		public GetFeedbackRequestType ApiRequest
		{ 
			get { return (GetFeedbackRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetFeedbackResponseType"/> for this API call.
		/// </summary>
		public GetFeedbackResponseType ApiResponse
		{ 
			get { return (GetFeedbackResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.UserID"/> of type <see cref="string"/>.
		/// </summary>
		public string UserID
		{ 
			get { return ApiRequest.UserID; }
			set { ApiRequest.UserID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.FeedbackID"/> of type <see cref="string"/>.
		/// </summary>
		public string FeedbackID
		{ 
			get { return ApiRequest.FeedbackID; }
			set { ApiRequest.FeedbackID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.TransactionID"/> of type <see cref="string"/>.
		/// </summary>
		public string TransactionID
		{ 
			get { return ApiRequest.TransactionID; }
			set { ApiRequest.TransactionID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.CommentType"/> of type <see cref="CommentTypeCodeTypeCollection"/>.
		/// </summary>
		public CommentTypeCodeTypeCollection CommentTypeList
		{ 
			get { return ApiRequest.CommentType; }
			set { ApiRequest.CommentType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.FeedbackType"/> of type <see cref="FeedbackTypeCodeType"/>.
		/// </summary>
		public FeedbackTypeCodeType FeedbackType
		{ 
			get { return ApiRequest.FeedbackType; }
			set { ApiRequest.FeedbackType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetFeedbackRequestType.OrderLineItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderLineItemID
		{ 
			get { return ApiRequest.OrderLineItemID; }
			set { ApiRequest.OrderLineItemID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetFeedbackResponseType.FeedbackDetailArray"/> of type <see cref="FeedbackDetailTypeCollection"/>.
		/// </summary>
		public FeedbackDetailTypeCollection FeedbackList
		{ 
			get { return ApiResponse.FeedbackDetailArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetFeedbackResponseType.FeedbackDetailItemTotal"/> of type <see cref="int"/>.
		/// </summary>
		public int FeedbackDetailItemTotal
		{ 
			get { return ApiResponse.FeedbackDetailItemTotal; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetFeedbackResponseType.FeedbackSummary"/> of type <see cref="FeedbackSummaryType"/>.
		/// </summary>
		public FeedbackSummaryType FeedbackSummary
		{ 
			get { return ApiResponse.FeedbackSummary; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetFeedbackResponseType.FeedbackScore"/> of type <see cref="int"/>.
		/// </summary>
		public int FeedbackScore
		{ 
			get { return ApiResponse.FeedbackScore; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetFeedbackResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetFeedbackResponseType.EntriesPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int EntriesPerPage
		{ 
			get { return ApiResponse.EntriesPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetFeedbackResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		

		#endregion

		
	}
}

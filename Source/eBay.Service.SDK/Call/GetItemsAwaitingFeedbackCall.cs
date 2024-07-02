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
	public class GetItemsAwaitingFeedbackCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetItemsAwaitingFeedbackCall()
		{
			ApiRequest = new GetItemsAwaitingFeedbackRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetItemsAwaitingFeedbackCall(ApiContext ApiContext)
		{
			ApiRequest = new GetItemsAwaitingFeedbackRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This is the base request type of the <b>GetItemsAwaitingFeedback</b> call. This call retrieves all completed order line items for which the user (buyer or seller) still needs to leave Feedback for their order partner.
		/// </summary>
		/// 
		/// <param name="Sort">
		/// This field allows the user to control how the order line items are returned in the response. If this field is not used, order line items are returned based on end time (from most recent to oldest).
		/// Valid values for this field are:
		/// <ul>
		/// <li><code>EndTime</code></li>
		/// <li><code>EndTimeDescending</code> (default value)</li>
		/// <li><code>FeedbackLeft</code></li>
		/// <li><code>FeedbackLeftDescending</code></li>
		/// <li><code>FeedbackReceived</code></li>
		/// <li><code>FeedbackReceivedDescending</code></li>
		/// <li><code>Title</code></li>
		/// <li><code>TitleDescending</code></li>
		/// <li><code>UserID</code></li>
		/// <li><code>UserIDDescending</code></li>
		/// </ul>
		/// Reference the <a href="types/ItemSortTypeCodeType.html">ItemSortTypeCodeType</a> definition for more information on these sort values.
		/// <br/>
		/// </param>
		///
		/// <param name="Pagination">
		/// This container can be used if the user only wants to see a subset of order line item results. In this container, the user will specify the number of order line items to return per page of data, and will specify the specific page of data they want to view with each call.
		/// <br/><br/>
		/// With the <b>GetItemsAwaitingFeedback</b> call, the maximum allowed value for <b>EntriesPerPage</b> is 200.
		/// </param>
		///
		public PaginatedTransactionArrayType GetItemsAwaitingFeedback(ItemSortTypeCodeType Sort, PaginationType Pagination)
		{
			this.Sort = Sort;
			this.Pagination = Pagination;

			Execute();
			return ApiResponse.ItemsAwaitingFeedback;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public PaginatedTransactionArrayType GetItemsAwaitingFeedback(PaginationType Pagination)
		{
			this.Pagination = Pagination;
			Execute();
			return ItemsAwaitingFeedback;
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
		/// Gets or sets the <see cref="GetItemsAwaitingFeedbackRequestType"/> for this API call.
		/// </summary>
		public GetItemsAwaitingFeedbackRequestType ApiRequest
		{ 
			get { return (GetItemsAwaitingFeedbackRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetItemsAwaitingFeedbackResponseType"/> for this API call.
		/// </summary>
		public GetItemsAwaitingFeedbackResponseType ApiResponse
		{ 
			get { return (GetItemsAwaitingFeedbackResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemsAwaitingFeedbackRequestType.Sort"/> of type <see cref="ItemSortTypeCodeType"/>.
		/// </summary>
		public ItemSortTypeCodeType Sort
		{ 
			get { return ApiRequest.Sort; }
			set { ApiRequest.Sort = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemsAwaitingFeedbackRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemsAwaitingFeedbackResponseType.ItemsAwaitingFeedback"/> of type <see cref="PaginatedTransactionArrayType"/>.
		/// </summary>
		public PaginatedTransactionArrayType ItemsAwaitingFeedback
		{ 
			get { return ApiResponse.ItemsAwaitingFeedback; }
		}
		

		#endregion

		
	}
}

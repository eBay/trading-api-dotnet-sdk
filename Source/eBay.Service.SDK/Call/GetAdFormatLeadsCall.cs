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
	public class GetAdFormatLeadsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetAdFormatLeadsCall()
		{
			ApiRequest = new GetAdFormatLeadsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetAdFormatLeadsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetAdFormatLeadsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves sales lead information for a lead generation listing.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The unique identifier of an item listed on the eBay site.
		/// Returned by eBay when the item is created. This ID must correspond
		/// to an ad format item.
		/// </param>
		///
		/// <param name="Status">
		/// Filters the leads based on their status.
		/// </param>
		///
		/// <param name="IncludeMemberMessages">
		/// Boolean which indicates whether to return mail messages for this lead in a MemberMessage node.
		/// </param>
		///
		/// <param name="StartCreationTime">
		/// Used with EndCreationTime to limit the returned leads for a user to only
		/// those with a creation date greater than or equal to the specified date and
		/// time.
		/// </param>
		///
		/// <param name="EndCreationTime">
		/// Used with StartCreationTime to limit the returned leads for a user to only
		/// those with a creation date less than or equal to the specified date and
		/// time.
		/// </param>
		///
		public AdFormatLeadTypeCollection GetAdFormatLeads(string ItemID, MessageStatusTypeCodeType Status, bool IncludeMemberMessages, DateTime StartCreationTime, DateTime EndCreationTime)
		{
			this.ItemID = ItemID;
			this.Status = Status;
			this.IncludeMemberMessages = IncludeMemberMessages;
			this.StartCreationTime = StartCreationTime;
			this.EndCreationTime = EndCreationTime;

			Execute();
			return ApiResponse.AdFormatLead;
		}


		/// <summary>
		/// Retrieve sales lead information for a real estate advertisement listing.
		/// GetAdFormatLeadsRequest returns the number of leads for an ad and any contact
		/// information that the prospective buyer submitted.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The unique identifier of an item listed on the eBay site.
		/// Returned by eBay when the item is created. This ID must correspond 
		/// to an ad format item.
		/// </param>
		///
		public AdFormatLeadTypeCollection GetAdFormatLeads(string ItemID)
		{
			this.ItemID = ItemID;

			Execute();
			return ApiResponse.AdFormatLead;
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
		/// Gets or sets the <see cref="GetAdFormatLeadsRequestType"/> for this API call.
		/// </summary>
		public GetAdFormatLeadsRequestType ApiRequest
		{ 
			get { return (GetAdFormatLeadsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetAdFormatLeadsResponseType"/> for this API call.
		/// </summary>
		public GetAdFormatLeadsResponseType ApiResponse
		{ 
			get { return (GetAdFormatLeadsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetAdFormatLeadsRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAdFormatLeadsRequestType.Status"/> of type <see cref="MessageStatusTypeCodeType"/>.
		/// </summary>
		public MessageStatusTypeCodeType Status
		{ 
			get { return ApiRequest.Status; }
			set { ApiRequest.Status = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAdFormatLeadsRequestType.IncludeMemberMessages"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeMemberMessages
		{ 
			get { return ApiRequest.IncludeMemberMessages; }
			set { ApiRequest.IncludeMemberMessages = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAdFormatLeadsRequestType.StartCreationTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartCreationTime
		{ 
			get { return ApiRequest.StartCreationTime; }
			set { ApiRequest.StartCreationTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAdFormatLeadsRequestType.EndCreationTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndCreationTime
		{ 
			get { return ApiRequest.EndCreationTime; }
			set { ApiRequest.EndCreationTime = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetAdFormatLeadsResponseType.AdFormatLead"/> of type <see cref="AdFormatLeadTypeCollection"/>.
		/// </summary>
		public AdFormatLeadTypeCollection AdFormatLeadList
		{ 
			get { return ApiResponse.AdFormatLead; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAdFormatLeadsResponseType.AdFormatLeadCount"/> of type <see cref="int"/>.
		/// </summary>
		public int AdFormatLeadCount
		{ 
			get { return ApiResponse.AdFormatLeadCount; }
		}
		

		#endregion

		
	}
}

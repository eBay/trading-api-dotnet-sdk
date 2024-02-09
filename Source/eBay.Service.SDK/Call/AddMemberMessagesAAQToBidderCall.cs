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
	public class AddMemberMessagesAAQToBidderCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddMemberMessagesAAQToBidderCall()
		{
			ApiRequest = new AddMemberMessagesAAQToBidderRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddMemberMessagesAAQToBidderCall(ApiContext ApiContext)
		{
			ApiRequest = new AddMemberMessagesAAQToBidderRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The base request of the <b>AddMemberMessagesAAQToBidder</b> call, which allows a seller to send up to 10 messages to bidders/potential buyers regarding an active listing. These potential buyers may include those who have made a Best Offer on a listing.
		/// </summary>
		/// 
		/// <param name="AddMemberMessagesAAQToBidderRequestContainerList">
		/// An <b>AddMemberMessagesAAQToBidderRequestContainer</b> container is required for each message being sent to unique bidders/potential buyers.  A seller can send up to 10 messages to unique bidders/potential buyers in one <b>AddMemberMessagesAAQToBidder</b> call.
		/// </param>
		///
		public AddMemberMessagesAAQToBidderResponseContainerTypeCollection AddMemberMessagesAAQToBidder(AddMemberMessagesAAQToBidderRequestContainerTypeCollection AddMemberMessagesAAQToBidderRequestContainerList)
		{
			this.AddMemberMessagesAAQToBidderRequestContainerList = AddMemberMessagesAAQToBidderRequestContainerList;

			Execute();
			return ApiResponse.AddMemberMessagesAAQToBidderResponseContainer;
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
		/// Gets or sets the <see cref="AddMemberMessagesAAQToBidderRequestType"/> for this API call.
		/// </summary>
		public AddMemberMessagesAAQToBidderRequestType ApiRequest
		{ 
			get { return (AddMemberMessagesAAQToBidderRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddMemberMessagesAAQToBidderResponseType"/> for this API call.
		/// </summary>
		public AddMemberMessagesAAQToBidderResponseType ApiResponse
		{ 
			get { return (AddMemberMessagesAAQToBidderResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddMemberMessagesAAQToBidderRequestType.AddMemberMessagesAAQToBidderRequestContainer"/> of type <see cref="AddMemberMessagesAAQToBidderRequestContainerTypeCollection"/>.
		/// </summary>
		public AddMemberMessagesAAQToBidderRequestContainerTypeCollection AddMemberMessagesAAQToBidderRequestContainerList
		{ 
			get { return ApiRequest.AddMemberMessagesAAQToBidderRequestContainer; }
			set { ApiRequest.AddMemberMessagesAAQToBidderRequestContainer = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="AddMemberMessagesAAQToBidderResponseType.AddMemberMessagesAAQToBidderResponseContainer"/> of type <see cref="AddMemberMessagesAAQToBidderResponseContainerTypeCollection"/>.
		/// </summary>
		public AddMemberMessagesAAQToBidderResponseContainerTypeCollection AddMemberMessagesAAQToBidderResponseContainerList
		{ 
			get { return ApiResponse.AddMemberMessagesAAQToBidderResponseContainer; }
		}
		

		#endregion

		
	}
}

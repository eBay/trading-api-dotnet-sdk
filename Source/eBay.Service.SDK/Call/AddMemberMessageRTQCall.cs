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
	public class AddMemberMessageRTQCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddMemberMessageRTQCall()
		{
			ApiRequest = new AddMemberMessageRTQRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddMemberMessageRTQCall(ApiContext ApiContext)
		{
			ApiRequest = new AddMemberMessageRTQRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The base request of the <b>AddMemberMessageRTQ</b> call that enables a seller to reply to a question about an active item listing.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The unique identifier of the listing about which the question was asked. This field is not required if the request includes a <b>RecipientID</b> value in the <b>MemberMessage</b> container, and the bidder/potential buyer and seller do not have more than one listing in common between one another.
		/// </param>
		///
		/// <param name="MemberMessage">
		/// This container is used by the seller to answer the question from the bidder/potential buyer. This container includes the recipient ID of the bidder/potential buyer, the message subject, the message body (where the question is answered), and other values related to the message.
		/// </param>
		///
		public void AddMemberMessageRTQ(string ItemID, MemberMessageType MemberMessage)
		{
			this.ItemID = ItemID;
			this.MemberMessage = MemberMessage;

			Execute();
			
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
		/// Gets or sets the <see cref="AddMemberMessageRTQRequestType"/> for this API call.
		/// </summary>
		public AddMemberMessageRTQRequestType ApiRequest
		{ 
			get { return (AddMemberMessageRTQRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddMemberMessageRTQResponseType"/> for this API call.
		/// </summary>
		public AddMemberMessageRTQResponseType ApiResponse
		{ 
			get { return (AddMemberMessageRTQResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddMemberMessageRTQRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddMemberMessageRTQRequestType.MemberMessage"/> of type <see cref="MemberMessageType"/>.
		/// </summary>
		public MemberMessageType MemberMessage
		{ 
			get { return ApiRequest.MemberMessage; }
			set { ApiRequest.MemberMessage = value; }
		}
		
		

		#endregion

		
	}
}

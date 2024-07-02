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
	public class AddMemberMessageAAQToPartnerCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddMemberMessageAAQToPartnerCall()
		{
			ApiRequest = new AddMemberMessageAAQToPartnerRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddMemberMessageAAQToPartnerCall(ApiContext ApiContext)
		{
			ApiRequest = new AddMemberMessageAAQToPartnerRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a buyer and seller in an order relationship to
		/// send messages to each other's My Messages Inboxes.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// Unique identifier for the listing that is being discussed between the two order partners.
		/// </param>
		///
		/// <param name="MemberMessage">
		/// This container holds the message, and includes the subject, message body, and other details related to the message.
		/// </param>
		///
		public void AddMemberMessageAAQToPartner(string ItemID, MemberMessageType MemberMessage)
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
		/// Gets or sets the <see cref="AddMemberMessageAAQToPartnerRequestType"/> for this API call.
		/// </summary>
		public AddMemberMessageAAQToPartnerRequestType ApiRequest
		{ 
			get { return (AddMemberMessageAAQToPartnerRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddMemberMessageAAQToPartnerResponseType"/> for this API call.
		/// </summary>
		public AddMemberMessageAAQToPartnerResponseType ApiResponse
		{ 
			get { return (AddMemberMessageAAQToPartnerResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddMemberMessageAAQToPartnerRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="AddMemberMessageAAQToPartnerRequestType.MemberMessage"/> of type <see cref="MemberMessageType"/>.
		/// </summary>
		public MemberMessageType MemberMessage
		{ 
			get { return ApiRequest.MemberMessage; }
			set { ApiRequest.MemberMessage = value; }
		}
		
		

		#endregion

		
	}
}

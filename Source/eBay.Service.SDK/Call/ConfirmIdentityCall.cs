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
	public class ConfirmIdentityCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ConfirmIdentityCall()
		{
			ApiRequest = new ConfirmIdentityRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ConfirmIdentityCall(ApiContext ApiContext)
		{
			ApiRequest = new ConfirmIdentityRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Returns the ID of a user who has gone through an application's consent flow
		/// process for obtaining an authorization token.
		/// </summary>
		/// 
		/// <param name="SessionID">
		/// A string obtained by making a <b>GetSessionID</b> call, passed in redirect URL to the eBay signin page.
		/// </param>
		///
		public string ConfirmIdentity(string SessionID)
		{
			this.SessionID = SessionID;

			Execute();
			return ApiResponse.UserID;
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
		/// Gets or sets the <see cref="ConfirmIdentityRequestType"/> for this API call.
		/// </summary>
		public ConfirmIdentityRequestType ApiRequest
		{ 
			get { return (ConfirmIdentityRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ConfirmIdentityResponseType"/> for this API call.
		/// </summary>
		public ConfirmIdentityResponseType ApiResponse
		{ 
			get { return (ConfirmIdentityResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ConfirmIdentityRequestType.SessionID"/> of type <see cref="string"/>.
		/// </summary>
		public string SessionID
		{ 
			get { return ApiRequest.SessionID; }
			set { ApiRequest.SessionID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="ConfirmIdentityResponseType.UserID"/> of type <see cref="string"/>.
		/// </summary>
		public string UserID
		{ 
			get { return ApiResponse.UserID; }
		}
		

		#endregion

		
	}
}

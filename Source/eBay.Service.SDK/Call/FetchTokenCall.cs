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
	public class FetchTokenCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public FetchTokenCall()
		{
			ApiRequest = new FetchTokenRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public FetchTokenCall(ApiContext ApiContext)
		{
			ApiRequest = new FetchTokenRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves an authentication token for a user.
		/// </summary>
		/// 
		/// <param name="SecretID">
		/// A value associated with the token retrieval request. SecretID is
		/// defined by the application, and is passed in the redirect URL to the
		/// eBay sign-in page. eBay recommends using a UUID for the secret ID
		/// value. You must also set Username (part of the RequesterCredentials)
		/// for the particular user of interest. SecretID and Username are not
		/// required if SessionID is present.
		/// </param>
		///
		/// <param name="SessionID">
		/// A value associated with the token retrieval request. eBay generates the
		/// session ID when the application makes a GetSessionID request. SessionID
		/// is passed in the redirect URL to the eBay sign-in page. The advantage
		/// of using SessionID is that it does not require UserID as part of the
		/// FetchToken request. SessionID is not required if SecretID is present.
		/// </param>
		///
		public string FetchToken(string SecretID, string SessionID)
		{
			this.SecretID = SecretID;
			this.SessionID = SessionID;

			Execute();
			return ApiResponse.eBayAuthToken;
		}


		/// <summary>
		/// Fetch token using SessionID(new token fetch flow).
		/// </summary>
		public string FetchToken(string SessionID)
		{
			this.SessionID = SessionID;

			Execute();
			return ApiResponse.eBayAuthToken;
		}

		#endregion

		#region Private Methods
		/// <summary>
		/// Constructs a security header from values in <see cref="ApiCall.ApiContext"/>.
		/// </summary>
		/// <returns>Security information of type <see cref="CustomSecurityHeaderType"/>.</returns>
		protected override CustomSecurityHeaderType GetSecurityHeader()
		{
			CustomSecurityHeaderType sechdr = new CustomSecurityHeaderType();

			if (ApiContext.ApiCredential.ApiAccount != null)
			{
				sechdr.Credentials = new UserIdPasswordType();
				sechdr.Credentials.AppId = ApiContext.ApiCredential.ApiAccount.Application;
				sechdr.Credentials.DevId = ApiContext.ApiCredential.ApiAccount.Developer;
				sechdr.Credentials.AuthCert = ApiContext.ApiCredential.ApiAccount.Certificate;
				
				//Need Username if SecretID is used
				if (ApiContext.ApiCredential.eBayAccount != null && ApiContext.ApiCredential.eBayAccount.UserName != null
					&& ApiContext.ApiCredential.eBayAccount.UserName.Length > 0)
				{
					sechdr.Credentials.Username = ApiContext.ApiCredential.eBayAccount.UserName;
				}

			}
			
			return (sechdr);
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
		/// Gets or sets the <see cref="FetchTokenRequestType"/> for this API call.
		/// </summary>
		public FetchTokenRequestType ApiRequest
		{ 
			get { return (FetchTokenRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="FetchTokenResponseType"/> for this API call.
		/// </summary>
		public FetchTokenResponseType ApiResponse
		{ 
			get { return (FetchTokenResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="FetchTokenRequestType.SecretID"/> of type <see cref="string"/>.
		/// </summary>
		public string SecretID
		{ 
			get { return ApiRequest.SecretID; }
			set { ApiRequest.SecretID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="FetchTokenRequestType.SessionID"/> of type <see cref="string"/>.
		/// </summary>
		public string SessionID
		{ 
			get { return ApiRequest.SessionID; }
			set { ApiRequest.SessionID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="FetchTokenResponseType.eBayAuthToken"/> of type <see cref="string"/>.
		/// </summary>
		public string eBayToken
		{ 
			get { return ApiResponse.eBayAuthToken; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="FetchTokenResponseType.HardExpirationTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime HardExpirationTime
		{ 
			get { return ApiResponse.HardExpirationTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="FetchTokenResponseType.RESTToken"/> of type <see cref="string"/>.
		/// </summary>
		public string RESTToken
		{ 
			get { return ApiResponse.RESTToken; }
		}
		

		#endregion

		
	}
}

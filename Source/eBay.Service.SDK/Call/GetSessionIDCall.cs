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
	public class GetSessionIDCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSessionIDCall()
		{
			ApiRequest = new GetSessionIDRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSessionIDCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSessionIDRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves a session ID that identifies a user and your application when you make a <b>FetchToken</b> request.
		/// </summary>
		/// 
		/// <param name="RuName">
		/// The eBay Registered URL must be specified in this field. An eBay Registered URL is created and associated with a developer's Sandbox or Production key set by logging into the user's developer account on <b>developer.ebay.com</b> and going to the <b>User Tokens</b> page. The <b>RuName</b> value passed in this field must match the one specified for the specific Sandbox or Production key set being used to make the <b>GetSessionID</b> call. For more information on adding and registering your <b class="con">RuName</b>, see the <a href="../../HowTo/Tokens/GettingTokens.html#step1">Setting Up an Application to Receive Tokens</a> tutorial.
		/// </param>
		///
		public string GetSessionID(string RuName)
		{
			this.RuName = RuName;

			Execute();
			return ApiResponse.SessionID;
		}


		/// <summary>
		/// Request for a SessionID, which is a unique identifier for authenticating data entry during the process that creates a user token.
		/// </summary>
		/// 
		public string GetSessionID()
		{
			Execute();
			return ApiResponse.SessionID;
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
			}
			else
			{
			        throw new SdkException("GetSessionID needs Api Account to be called!");			
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
		/// Gets or sets the <see cref="GetSessionIDRequestType"/> for this API call.
		/// </summary>
		public GetSessionIDRequestType ApiRequest
		{ 
			get { return (GetSessionIDRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSessionIDResponseType"/> for this API call.
		/// </summary>
		public GetSessionIDResponseType ApiResponse
		{ 
			get { return (GetSessionIDResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSessionIDRequestType.RuName"/> of type <see cref="string"/>.
		/// </summary>
		public string RuName
		{ 
			get { return ApiRequest.RuName; }
			set { ApiRequest.RuName = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSessionIDResponseType.SessionID"/> of type <see cref="string"/>.
		/// </summary>
		public string SessionID
		{ 
			get { return ApiResponse.SessionID; }
		}
		

		#endregion

		
	}
}

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
	public class GetClientAlertsAuthTokenCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetClientAlertsAuthTokenCall()
		{
			ApiRequest = new GetClientAlertsAuthTokenRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetClientAlertsAuthTokenCall(ApiContext ApiContext)
		{
			ApiRequest = new GetClientAlertsAuthTokenRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This is the base request type for the <b>GetClientAlertsAuthToken</b> call. This call retrieves a Client Alerts token for the user, which is required when the user makes a <b>GetUserAlerts</b> call (Client Alerts API).
		/// </summary>
		/// 
		public string GetClientAlertsAuthToken()
		{

			Execute();
			return ApiResponse.ClientAlertsAuthToken;
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
		/// Gets or sets the <see cref="GetClientAlertsAuthTokenRequestType"/> for this API call.
		/// </summary>
		public GetClientAlertsAuthTokenRequestType ApiRequest
		{ 
			get { return (GetClientAlertsAuthTokenRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetClientAlertsAuthTokenResponseType"/> for this API call.
		/// </summary>
		public GetClientAlertsAuthTokenResponseType ApiResponse
		{ 
			get { return (GetClientAlertsAuthTokenResponseType) AbstractResponse; }
		}

		
		
 		/// <summary>
		/// Gets the returned <see cref="GetClientAlertsAuthTokenResponseType.ClientAlertsAuthToken"/> of type <see cref="string"/>.
		/// </summary>
		public string ClientAlertsAuthToken
		{ 
			get { return ApiResponse.ClientAlertsAuthToken; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetClientAlertsAuthTokenResponseType.HardExpirationTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime HardExpirationTime
		{ 
			get { return ApiResponse.HardExpirationTime; }
		}
		

		#endregion

		
	}
}

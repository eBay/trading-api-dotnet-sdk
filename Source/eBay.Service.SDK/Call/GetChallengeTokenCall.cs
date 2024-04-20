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
	public class GetChallengeTokenCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetChallengeTokenCall()
		{
			ApiRequest = new GetChallengeTokenRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetChallengeTokenCall(ApiContext ApiContext)
		{
			ApiRequest = new GetChallengeTokenRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This is the base request type for the <b>GetChallengeToken</b> call. This call retrieves a botblock token and URLs for an image or audio clip that the user is to match.
		/// <br/><br/>
		/// This call does not have any call-specific input parameters.
		/// </summary>
		/// 
		public string GetChallengeToken()
		{

			Execute();
			return ApiResponse.ChallengeToken;
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
		/// Gets or sets the <see cref="GetChallengeTokenRequestType"/> for this API call.
		/// </summary>
		public GetChallengeTokenRequestType ApiRequest
		{ 
			get { return (GetChallengeTokenRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetChallengeTokenResponseType"/> for this API call.
		/// </summary>
		public GetChallengeTokenResponseType ApiResponse
		{ 
			get { return (GetChallengeTokenResponseType) AbstractResponse; }
		}

		
		
 		/// <summary>
		/// Gets the returned <see cref="GetChallengeTokenResponseType.ChallengeToken"/> of type <see cref="string"/>.
		/// </summary>
		public string ChallengeToken
		{ 
			get { return ApiResponse.ChallengeToken; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetChallengeTokenResponseType.ImageChallengeURL"/> of type <see cref="string"/>.
		/// </summary>
		public string ImageChallengeURL
		{ 
			get { return ApiResponse.ImageChallengeURL; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetChallengeTokenResponseType.AudioChallengeURL"/> of type <see cref="string"/>.
		/// </summary>
		public string AudioChallengeURL
		{ 
			get { return ApiResponse.AudioChallengeURL; }
		}
		

		#endregion

		
	}
}

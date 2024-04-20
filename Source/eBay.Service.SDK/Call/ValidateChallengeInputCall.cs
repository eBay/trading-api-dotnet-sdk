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
	public class ValidateChallengeInputCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ValidateChallengeInputCall()
		{
			ApiRequest = new ValidateChallengeInputRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ValidateChallengeInputCall(ApiContext ApiContext)
		{
			ApiRequest = new ValidateChallengeInputRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Validates the user response to a <b class="con">GetChallengeToken</b>
		/// botblock challenge.
		/// </summary>
		/// 
		/// <param name="ChallengeToken">
		/// Botblock token that was returned by <b>GetChallengeToken</b>.
		/// </param>
		///
		/// <param name="UserInput">
		/// User response to a bot block challenge.
		/// </param>
		///
		/// <param name="KeepTokenValid">
		/// This boolean field is included and set to 'true' if the challenge token should remain valid for up to two minutes.
		/// </param>
		///
		public bool ValidateChallengeInput(string ChallengeToken, string UserInput, bool KeepTokenValid)
		{
			this.ChallengeToken = ChallengeToken;
			this.UserInput = UserInput;
			this.KeepTokenValid = KeepTokenValid;

			Execute();
			return ApiResponse.ValidToken;
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
		/// Gets or sets the <see cref="ValidateChallengeInputRequestType"/> for this API call.
		/// </summary>
		public ValidateChallengeInputRequestType ApiRequest
		{ 
			get { return (ValidateChallengeInputRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ValidateChallengeInputResponseType"/> for this API call.
		/// </summary>
		public ValidateChallengeInputResponseType ApiResponse
		{ 
			get { return (ValidateChallengeInputResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ValidateChallengeInputRequestType.ChallengeToken"/> of type <see cref="string"/>.
		/// </summary>
		public string ChallengeToken
		{ 
			get { return ApiRequest.ChallengeToken; }
			set { ApiRequest.ChallengeToken = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ValidateChallengeInputRequestType.UserInput"/> of type <see cref="string"/>.
		/// </summary>
		public string UserInput
		{ 
			get { return ApiRequest.UserInput; }
			set { ApiRequest.UserInput = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ValidateChallengeInputRequestType.KeepTokenValid"/> of type <see cref="bool"/>.
		/// </summary>
		public bool KeepTokenValid
		{ 
			get { return ApiRequest.KeepTokenValid; }
			set { ApiRequest.KeepTokenValid = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="ValidateChallengeInputResponseType.ValidToken"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ValidToken
		{ 
			get { return ApiResponse.ValidToken; }
		}
		

		#endregion

		
	}
}

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
	public class ValidateTestUserRegistrationCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ValidateTestUserRegistrationCall()
		{
			ApiRequest = new ValidateTestUserRegistrationRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ValidateTestUserRegistrationCall(ApiContext ApiContext)
		{
			ApiRequest = new ValidateTestUserRegistrationRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Requests to enable a test user to sell items in the Sandbox environment.
		/// </summary>
		/// 
		/// <param name="FeedbackScore">
		/// Value for the feedback score of a user. If no value is passed in the request,
		/// or if the value is zero, the feedback score is unchanged. This element is not intended
		/// for regularly testing feedback because the feedback value can change after the request.
		/// </param>
		///
		/// <param name="RegistrationDate">
		/// Value for the date and time that a user's registration begins.
		/// </param>
		///
		/// <param name="SubscribeSA">
		/// This field is no longer applicable since the Seller Assistant feature is no longer available.
		/// </param>
		///
		/// <param name="SubscribeSAPro">
		/// This field is no longer applicable since the Seller Assistant Pro feature is no longer available.
		/// </param>
		///
		/// <param name="SubscribeSM">
		/// Indicates if a user subscribes to Selling Manager. You cannot
		/// request to subscribe a user to both Selling Manager and
		/// Selling Manager Pro. You cannot request to unsubscribe a user.
		/// </param>
		///
		/// <param name="SubscribeSMPro">
		/// Indicates if a user subscribes to Selling Manager Pro. You cannot
		/// request to subscribe a user to both Selling Manager and
		/// Selling Manager Pro. You cannot request to unsubscribe a user.
		/// </param>
		///
		public void ValidateTestUserRegistration(int FeedbackScore, DateTime RegistrationDate, bool SubscribeSM, bool SubscribeSMPro)
		{
			this.FeedbackScore = FeedbackScore;
			this.RegistrationDate = RegistrationDate;
			this.SubscribeSM = SubscribeSM;
			this.SubscribeSMPro = SubscribeSMPro;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void ValidateTestUserRegistration()
		{
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
		/// Gets or sets the <see cref="ValidateTestUserRegistrationRequestType"/> for this API call.
		/// </summary>
		public ValidateTestUserRegistrationRequestType ApiRequest
		{ 
			get { return (ValidateTestUserRegistrationRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ValidateTestUserRegistrationResponseType"/> for this API call.
		/// </summary>
		public ValidateTestUserRegistrationResponseType ApiResponse
		{ 
			get { return (ValidateTestUserRegistrationResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ValidateTestUserRegistrationRequestType.FeedbackScore"/> of type <see cref="int"/>.
		/// </summary>
		public int FeedbackScore
		{ 
			get { return ApiRequest.FeedbackScore; }
			set { ApiRequest.FeedbackScore = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ValidateTestUserRegistrationRequestType.RegistrationDate"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime RegistrationDate
		{ 
			get { return ApiRequest.RegistrationDate; }
			set { ApiRequest.RegistrationDate = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ValidateTestUserRegistrationRequestType.SubscribeSM"/> of type <see cref="bool"/>.
		/// </summary>
		public bool SubscribeSM
		{ 
			get { return ApiRequest.SubscribeSM; }
			set { ApiRequest.SubscribeSM = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ValidateTestUserRegistrationRequestType.SubscribeSMPro"/> of type <see cref="bool"/>.
		/// </summary>
		public bool SubscribeSMPro
		{ 
			get { return ApiRequest.SubscribeSMPro; }
			set { ApiRequest.SubscribeSMPro = value; }
		}
		
		

		#endregion

		
	}
}

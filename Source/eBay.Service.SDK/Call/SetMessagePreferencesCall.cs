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
	public class SetMessagePreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetMessagePreferencesCall()
		{
			ApiRequest = new SetMessagePreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetMessagePreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetMessagePreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to add custom Ask Seller a Question (ASQ) subjects to their
		/// Ask a Question page, or to reset any custom subjects to their default values.
		/// </summary>
		/// 
		/// <param name="ASQPreferences">
		/// This container can be used to set customized ASQ subjects, or it can be used to reset the ASQ subjects to the eBay defaults. Up to nine customized ASQ subjects can be set.
		/// </param>
		///
		public void SetMessagePreferences(ASQPreferencesType ASQPreferences)
		{
			this.ASQPreferences = ASQPreferences;

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
		/// Gets or sets the <see cref="SetMessagePreferencesRequestType"/> for this API call.
		/// </summary>
		public SetMessagePreferencesRequestType ApiRequest
		{ 
			get { return (SetMessagePreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetMessagePreferencesResponseType"/> for this API call.
		/// </summary>
		public SetMessagePreferencesResponseType ApiResponse
		{ 
			get { return (SetMessagePreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetMessagePreferencesRequestType.ASQPreferences"/> of type <see cref="ASQPreferencesType"/>.
		/// </summary>
		public ASQPreferencesType ASQPreferences
		{ 
			get { return ApiRequest.ASQPreferences; }
			set { ApiRequest.ASQPreferences = value; }
		}
		
		

		#endregion

		
	}
}

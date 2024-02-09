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
	public class GetNotificationPreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetNotificationPreferencesCall()
		{
			ApiRequest = new GetNotificationPreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetNotificationPreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetNotificationPreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the requesting application's notification preferences. Details are only returned for events for which a preference has been set. For example, if you enabled notification for the <b>EndOfAuction</b> event and later disabled it, the <b>GetNotificationPreferences</b> response would cite the <b>EndOfAuction</b> event preference as <b>Disabled</b>. Otherwise, no details would be returned regarding <b>EndOfAuction</b>.
		/// </summary>
		/// 
		/// <param name="PreferenceLevel">
		/// Specifies the type of preferences to retrieve. For example, preferences can be associated with a user, with
		/// an application, or with events.
		/// 
		/// </param>
		///
		public void GetNotificationPreferences(NotificationRoleCodeType PreferenceLevel)
		{
			this.PreferenceLevel = PreferenceLevel;

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
		/// Gets or sets the <see cref="GetNotificationPreferencesRequestType"/> for this API call.
		/// </summary>
		public GetNotificationPreferencesRequestType ApiRequest
		{ 
			get { return (GetNotificationPreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetNotificationPreferencesResponseType"/> for this API call.
		/// </summary>
		public GetNotificationPreferencesResponseType ApiResponse
		{ 
			get { return (GetNotificationPreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetNotificationPreferencesRequestType.PreferenceLevel"/> of type <see cref="NotificationRoleCodeType"/>.
		/// </summary>
		public NotificationRoleCodeType PreferenceLevel
		{ 
			get { return ApiRequest.PreferenceLevel; }
			set { ApiRequest.PreferenceLevel = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationPreferencesResponseType.ApplicationDeliveryPreferences"/> of type <see cref="ApplicationDeliveryPreferencesType"/>.
		/// </summary>
		public ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences
		{ 
			get { return ApiResponse.ApplicationDeliveryPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationPreferencesResponseType.DeliveryURLName"/> of type <see cref="string"/>.
		/// </summary>
		public string DeliveryURLName
		{ 
			get { return ApiResponse.DeliveryURLName; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationPreferencesResponseType.UserDeliveryPreferenceArray"/> of type <see cref="NotificationEnableTypeCollection"/>.
		/// </summary>
		public NotificationEnableTypeCollection UserDeliveryPreferenceList
		{ 
			get { return ApiResponse.UserDeliveryPreferenceArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationPreferencesResponseType.UserData"/> of type <see cref="NotificationUserDataType"/>.
		/// </summary>
		public NotificationUserDataType UserData
		{ 
			get { return ApiResponse.UserData; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationPreferencesResponseType.EventProperty"/> of type <see cref="NotificationEventPropertyTypeCollection"/>.
		/// </summary>
		public NotificationEventPropertyTypeCollection EventPropertyList
		{ 
			get { return ApiResponse.EventProperty; }
		}
		

		#endregion

		
	}
}

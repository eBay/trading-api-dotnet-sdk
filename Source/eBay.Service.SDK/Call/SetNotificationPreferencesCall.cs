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
	public class SetNotificationPreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetNotificationPreferencesCall()
		{
			ApiRequest = new SetNotificationPreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetNotificationPreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetNotificationPreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Manages notification and alert preferences for applications and users.
		/// </summary>
		/// 
		/// <param name="ApplicationDeliveryPreferences">
		/// Specifies application-level event preferences that have been enabled,
		/// including the URL to which notifications should be delivered and whether
		/// notifications should be enabled or disabled (although the
		/// <b>UserDeliveryPreferenceArray</b> input property specifies specific
		/// notification subscriptions).
		/// </param>
		///
		/// <param name="UserDeliveryPreferenceList">
		/// Specifies events and whether or not they are enabled.
		/// </param>
		///
		/// <param name="UserData">
		/// Specifies user data for notification settings, such as mobile phone number.
		/// </param>
		///
		/// <param name="EventPropertyList">
		/// Characteristics or details of an event such as type, name and value.
		/// Currently can only be set for wireless applications.
		/// </param>
		///
		/// <param name="DeliveryURLName">
		/// Specifies up to 25 ApplicationDeliveryPreferences.DeliveryURLDetails.DeliveryURLName to associate with a user token sent in a SetNotificationPreferences request. To specify multiple DeliveryURLNames, create separate instances of ApplicationDeliveryPreferences.DeliveryURLDetails.DeliveryURLName, and then enable up to 25 DeliveryURLNames by including them in comma-separated format in this field.
		/// </param>
		///
		public void SetNotificationPreferences(ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences, NotificationEnableTypeCollection UserDeliveryPreferenceList, NotificationUserDataType UserData, NotificationEventPropertyTypeCollection EventPropertyList, string DeliveryURLName)
		{
			this.ApplicationDeliveryPreferences = ApplicationDeliveryPreferences;
			this.UserDeliveryPreferenceList = UserDeliveryPreferenceList;
			this.UserData = UserData;
			this.EventPropertyList = EventPropertyList;
			this.DeliveryURLName = DeliveryURLName;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetNotificationPreferences(NotificationEnableTypeCollection UserDeliveryPreferenceList)
		{
			this.UserDeliveryPreferenceList = UserDeliveryPreferenceList;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetNotificationPreferences(ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences)
		{
			this.ApplicationDeliveryPreferences = ApplicationDeliveryPreferences;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetNotificationPreferences(ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences, NotificationEnableTypeCollection UserDeliveryPreferenceList)
		{
			this.ApplicationDeliveryPreferences = ApplicationDeliveryPreferences;
			this.UserDeliveryPreferenceList = UserDeliveryPreferenceList;

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
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType"/> for this API call.
		/// </summary>
		public SetNotificationPreferencesRequestType ApiRequest
		{ 
			get { return (SetNotificationPreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetNotificationPreferencesResponseType"/> for this API call.
		/// </summary>
		public SetNotificationPreferencesResponseType ApiResponse
		{ 
			get { return (SetNotificationPreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.ApplicationDeliveryPreferences"/> of type <see cref="ApplicationDeliveryPreferencesType"/>.
		/// </summary>
		public ApplicationDeliveryPreferencesType ApplicationDeliveryPreferences
		{ 
			get { return ApiRequest.ApplicationDeliveryPreferences; }
			set { ApiRequest.ApplicationDeliveryPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.UserDeliveryPreferenceArray"/> of type <see cref="NotificationEnableTypeCollection"/>.
		/// </summary>
		public NotificationEnableTypeCollection UserDeliveryPreferenceList
		{ 
			get { return ApiRequest.UserDeliveryPreferenceArray; }
			set { ApiRequest.UserDeliveryPreferenceArray = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.UserData"/> of type <see cref="NotificationUserDataType"/>.
		/// </summary>
		public NotificationUserDataType UserData
		{ 
			get { return ApiRequest.UserData; }
			set { ApiRequest.UserData = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.EventProperty"/> of type <see cref="NotificationEventPropertyTypeCollection"/>.
		/// </summary>
		public NotificationEventPropertyTypeCollection EventPropertyList
		{ 
			get { return ApiRequest.EventProperty; }
			set { ApiRequest.EventProperty = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetNotificationPreferencesRequestType.DeliveryURLName"/> of type <see cref="string"/>.
		/// </summary>
		public string DeliveryURLName
		{ 
			get { return ApiRequest.DeliveryURLName; }
			set { ApiRequest.DeliveryURLName = value; }
		}
		
		

		#endregion

		
	}
}

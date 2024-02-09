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
	public class GetNotificationsUsageCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetNotificationsUsageCall()
		{
			ApiRequest = new GetNotificationsUsageRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetNotificationsUsageCall(ApiContext ApiContext)
		{
			ApiRequest = new GetNotificationsUsageRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves usage information about platform notifications for a given application.
		/// You can use this notification information to troubleshoot issues with platform
		/// notifications. You can call this up to 50 times per hour for a given application.
		/// </summary>
		/// 
		/// <param name="StartTime">
		/// Specifies the start date and time for which notification information will be retrieved. <b>StartTime</b> is optional. If no <b>StartTime</b> is specified, the default value of 24 hours prior to the call time is used. If no <b>StartTime</b> is specified or if an invalid <b>StartTime</b> is specified, date range errors are returned in the response. For a <b>StartTime</b> to be valid, it must be no more than 72 hours before the time of the call, it cannot be more recent than the <b>EndTime</b>, and it cannot be later than the time of the call. If an invalid <b>StartTime</b> is specified, the default value is used.
		/// </param>
		///
		/// <param name="EndTime">
		/// Specifies the end date and time for which notification information will be retrieved. <b>EndTime</b> is optional. <br/><br/> If no <b>EndTime</b> is specified, the current time (the time the call is made) is used. If no <b>EndTime</b> is specified or if an invalid <b>EndTime</b> is specified, date range errors are returned in the response. For an <b>EndTime</b> to be valid, it must be no more than 72 hours before the time the of the call, it cannot be before the <b>StartTime</b>, and it cannot be later than the time of the call. If an invalid <b>EndTime</b> is specified, the current time is used.
		/// </param>
		///
		/// <param name="ItemID">
		/// Specifies an item ID for which detailed notification information will be retrieved. <b>ItemID</b> is optional. If no <b>ItemID</b> is specified, the response will not include any individual notification details.
		/// </param>
		///
		public void GetNotificationsUsage(DateTime StartTime, DateTime EndTime, string ItemID)
		{
			this.StartTime = StartTime;
			this.EndTime = EndTime;
			this.ItemID = ItemID;

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
		/// Gets or sets the <see cref="GetNotificationsUsageRequestType"/> for this API call.
		/// </summary>
		public GetNotificationsUsageRequestType ApiRequest
		{ 
			get { return (GetNotificationsUsageRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetNotificationsUsageResponseType"/> for this API call.
		/// </summary>
		public GetNotificationsUsageResponseType ApiResponse
		{ 
			get { return (GetNotificationsUsageResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetNotificationsUsageRequestType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTime
		{ 
			get { return ApiRequest.StartTime; }
			set { ApiRequest.StartTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetNotificationsUsageRequestType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTime
		{ 
			get { return ApiRequest.EndTime; }
			set { ApiRequest.EndTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetNotificationsUsageRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationsUsageResponseType.StartTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime StartTimeReturn
		{ 
			get { return ApiResponse.StartTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationsUsageResponseType.EndTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndTimeReturn
		{ 
			get { return ApiResponse.EndTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationsUsageResponseType.NotificationDetailsArray"/> of type <see cref="NotificationDetailsTypeCollection"/>.
		/// </summary>
		public NotificationDetailsTypeCollection NotificationDetailsList
		{ 
			get { return ApiResponse.NotificationDetailsArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationsUsageResponseType.MarkUpMarkDownHistory"/> of type <see cref="MarkUpMarkDownEventTypeCollection"/>.
		/// </summary>
		public MarkUpMarkDownEventTypeCollection MarkUpMarkDownHistoryList
		{ 
			get { return ApiResponse.MarkUpMarkDownHistory; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetNotificationsUsageResponseType.NotificationStatistics"/> of type <see cref="NotificationStatisticsType"/>.
		/// </summary>
		public NotificationStatisticsType NotificationStatistics
		{ 
			get { return ApiResponse.NotificationStatistics; }
		}
		

		#endregion

		
	}
}

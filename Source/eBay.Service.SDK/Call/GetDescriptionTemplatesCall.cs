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
	public class GetDescriptionTemplatesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetDescriptionTemplatesCall()
		{
			ApiRequest = new GetDescriptionTemplatesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetDescriptionTemplatesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetDescriptionTemplatesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This is the base request type for the <b>GetDescriptionTemplates</b> call. This call retrieves detailed information on the Listing Designer templates that are available for use by the seller.
		/// </summary>
		/// 
		/// <param name="CategoryID">
		/// A <b>CategoryID</b> value can be specified if the seller would like to only see the Listing Designer templates that are available for that eBay category. This field will be ignored if the <b>MotorVehicles</b> boolean field is also included in the call request and set to <code>true</code>.
		/// </param>
		///
		/// <param name="LastModifiedTime">
		/// This dateTime filter can be included and used if the user only wants to check for recently-added Listing Designer templates. If this filter is used, only the Listing Designer templates that have been added/modified after the specified timestamp will be returned in the response.
		/// <br/><br/>
		/// Typically, you will pass in the timestamp value that was returned the last time you refreshed the list of Listing Designer templates.
		/// </param>
		///
		/// <param name="MotorVehicles">
		/// This boolean field should be included and set to <code>true</code> if the user would only like to see the Listing Designer templates that are available for motor vehicle categories. This field will override any <b>CategoryID</b> value that is specified in the call request.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b>
		/// Motor vehicle-related Listing Designer templates are only available for eBay Motors on the US and Canada (English) marketplaces. To retrieve eBay US Motors Listing Designer templates, the <b>SITEID</b> HTTP header value must be set to <code>100</code>, which is the identifier of the eBay US Motors vertical (ebay.com/motors).
		/// </span>
		/// </param>
		///
		public DescriptionTemplateTypeCollection GetDescriptionTemplates(string CategoryID, DateTime LastModifiedTime, bool MotorVehicles)
		{
			this.CategoryID = CategoryID;
			this.LastModifiedTime = LastModifiedTime;
			this.MotorVehicles = MotorVehicles;

			Execute();
			return ApiResponse.DescriptionTemplate;
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
		/// Gets or sets the <see cref="GetDescriptionTemplatesRequestType"/> for this API call.
		/// </summary>
		public GetDescriptionTemplatesRequestType ApiRequest
		{ 
			get { return (GetDescriptionTemplatesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetDescriptionTemplatesResponseType"/> for this API call.
		/// </summary>
		public GetDescriptionTemplatesResponseType ApiResponse
		{ 
			get { return (GetDescriptionTemplatesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetDescriptionTemplatesRequestType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiRequest.CategoryID; }
			set { ApiRequest.CategoryID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetDescriptionTemplatesRequestType.LastModifiedTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime LastModifiedTime
		{ 
			get { return ApiRequest.LastModifiedTime; }
			set { ApiRequest.LastModifiedTime = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetDescriptionTemplatesRequestType.MotorVehicles"/> of type <see cref="bool"/>.
		/// </summary>
		public bool MotorVehicles
		{ 
			get { return ApiRequest.MotorVehicles; }
			set { ApiRequest.MotorVehicles = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetDescriptionTemplatesResponseType.DescriptionTemplate"/> of type <see cref="DescriptionTemplateTypeCollection"/>.
		/// </summary>
		public DescriptionTemplateTypeCollection DescriptionTemplateList
		{ 
			get { return ApiResponse.DescriptionTemplate; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetDescriptionTemplatesResponseType.LayoutTotal"/> of type <see cref="int"/>.
		/// </summary>
		public int LayoutTotal
		{ 
			get { return ApiResponse.LayoutTotal; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetDescriptionTemplatesResponseType.ObsoleteLayoutID"/> of type <see cref="Int32Collection"/>.
		/// </summary>
		public Int32Collection ObsoleteLayoutIDList
		{ 
			get { return ApiResponse.ObsoleteLayoutID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetDescriptionTemplatesResponseType.ObsoleteThemeID"/> of type <see cref="Int32Collection"/>.
		/// </summary>
		public Int32Collection ObsoleteThemeIDList
		{ 
			get { return ApiResponse.ObsoleteThemeID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetDescriptionTemplatesResponseType.ThemeGroup"/> of type <see cref="ThemeGroupTypeCollection"/>.
		/// </summary>
		public ThemeGroupTypeCollection ThemeGroupList
		{ 
			get { return ApiResponse.ThemeGroup; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetDescriptionTemplatesResponseType.ThemeTotal"/> of type <see cref="int"/>.
		/// </summary>
		public int ThemeTotal
		{ 
			get { return ApiResponse.ThemeTotal; }
		}
		

		#endregion

		
	}
}

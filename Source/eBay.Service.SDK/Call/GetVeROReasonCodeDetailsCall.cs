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
	public class GetVeROReasonCodeDetailsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetVeROReasonCodeDetailsCall()
		{
			ApiRequest = new GetVeROReasonCodeDetailsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetVeROReasonCodeDetailsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetVeROReasonCodeDetailsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves details for VeRO reason codes and their descriptions. You can specify a
		/// reason code ID to get details for a specific reason on the site specified in the
		/// request header. If <strong>ReasonCodeID</strong> is not passed in the request, all reason codes are
		/// returned. Set <strong>ReturnAllSites</strong> to <code>true</code> to retrieve reason codes for all sites.
		/// You must be a member of the Verified Rights Owner (VeRO) Program to use this call.
		/// </summary>
		/// 
		/// <param name="ReasonCodeID">
		/// Unique identifier for a reason code. If this <strong>ReasonCodeID</strong> field is passed in, only the details related to this <strong>ReasonCodeID</strong> will be returned. If no reason code is specified, all reason codes are returned.
		/// </param>
		///
		/// <param name="ReturnAllSites">
		/// Set to true to retrieve reason codes for all sites. If not specified, reason codes are returned for the site specified in the request header only. If a <strong>ReasonCodeID</strong> value is specified, this parameter is ignored.
		/// </param>
		///
		public VeROSiteDetailTypeCollection GetVeROReasonCodeDetails(long ReasonCodeID, bool ReturnAllSites)
		{
			this.ReasonCodeID = ReasonCodeID;
			this.ReturnAllSites = ReturnAllSites;

			Execute();
			return ApiResponse.VeROReasonCodeDetails;
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
		/// Gets or sets the <see cref="GetVeROReasonCodeDetailsRequestType"/> for this API call.
		/// </summary>
		public GetVeROReasonCodeDetailsRequestType ApiRequest
		{ 
			get { return (GetVeROReasonCodeDetailsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetVeROReasonCodeDetailsResponseType"/> for this API call.
		/// </summary>
		public GetVeROReasonCodeDetailsResponseType ApiResponse
		{ 
			get { return (GetVeROReasonCodeDetailsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReasonCodeDetailsRequestType.ReasonCodeID"/> of type <see cref="long"/>.
		/// </summary>
		public long ReasonCodeID
		{ 
			get { return ApiRequest.ReasonCodeID; }
			set { ApiRequest.ReasonCodeID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetVeROReasonCodeDetailsRequestType.ReturnAllSites"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ReturnAllSites
		{ 
			get { return ApiRequest.ReturnAllSites; }
			set { ApiRequest.ReturnAllSites = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetVeROReasonCodeDetailsResponseType.VeROReasonCodeDetails"/> of type <see cref="VeROSiteDetailTypeCollection"/>.
		/// </summary>
		public VeROSiteDetailTypeCollection VeROReasonCodeDetailList
		{ 
			get { return ApiResponse.VeROReasonCodeDetails; }
		}
		

		#endregion

		
	}
}

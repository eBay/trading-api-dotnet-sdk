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
	public class GeteBayOfficialTimeCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GeteBayOfficialTimeCall()
		{
			ApiRequest = new GeteBayOfficialTimeRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GeteBayOfficialTimeCall(ApiContext ApiContext)
		{
			ApiRequest = new GeteBayOfficialTimeRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Gets the official eBay system time in GMT.
		/// </summary>
		/// 
		public DateTime GeteBayOfficialTime()
		{

			Execute();
			return ApiResponse.Timestamp;
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
		/// Gets or sets the <see cref="GeteBayOfficialTimeRequestType"/> for this API call.
		/// </summary>
		public GeteBayOfficialTimeRequestType ApiRequest
		{ 
			get { return (GeteBayOfficialTimeRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GeteBayOfficialTimeResponseType"/> for this API call.
		/// </summary>
		public GeteBayOfficialTimeResponseType ApiResponse
		{ 
			get { return (GeteBayOfficialTimeResponseType) AbstractResponse; }
		}

		/// <summary>
		/// Gets the <see cref="AbstractResponseType.Timestamp"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EBayTime
		{ 
		   	get { return ApiResponse.Timestamp; }
		}
		

		#endregion

		
	}
}

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
	public class GetStoreCategoryUpdateStatusCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetStoreCategoryUpdateStatusCall()
		{
			ApiRequest = new GetStoreCategoryUpdateStatusRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetStoreCategoryUpdateStatusCall(ApiContext ApiContext)
		{
			ApiRequest = new GetStoreCategoryUpdateStatusRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call is used to retrieve the status of an eBay Store Category hierarchy change that was made with a <b>SetStoreCategories</b> call.
		/// </summary>
		/// 
		/// <param name="TaskID">
		/// The unique identifier of an eBay Store Category hierarchy change task. A <b>TaskID</b> value is returned in the response of a successful <b>SetStoreCategories</b> call.
		/// <br/><br/>
		/// <span class="tablenote"><b>Note: </b> Depending on the breadth of changes being made to an eBay Store Category hierarchy, it is is possible that the <b>SetStoreCategories</b> call will complete the task simultaneously with the call response. A seller will know if an eBay Store Category hierarchy task was completed simultaneously if the <b>TaskID</b> value is returned as <code>0</code>, and the <b>Status</b> field is returned with a value of <code>Complete</code>. If the task was not completely simultaneously, the <b>TaskID</b> value will be a positive integer, and the <b>Status</b> field will show a value of <code>InProgress</code> or <code>Pending</code>.
		/// </span>
		/// </param>
		///
		public TaskStatusCodeType GetStoreCategoryUpdateStatus(long TaskID)
		{
			this.TaskID = TaskID;

			Execute();
			return ApiResponse.Status;
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
		/// Gets or sets the <see cref="GetStoreCategoryUpdateStatusRequestType"/> for this API call.
		/// </summary>
		public GetStoreCategoryUpdateStatusRequestType ApiRequest
		{ 
			get { return (GetStoreCategoryUpdateStatusRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetStoreCategoryUpdateStatusResponseType"/> for this API call.
		/// </summary>
		public GetStoreCategoryUpdateStatusResponseType ApiResponse
		{ 
			get { return (GetStoreCategoryUpdateStatusResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetStoreCategoryUpdateStatusRequestType.TaskID"/> of type <see cref="long"/>.
		/// </summary>
		public long TaskID
		{ 
			get { return ApiRequest.TaskID; }
			set { ApiRequest.TaskID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetStoreCategoryUpdateStatusResponseType.Status"/> of type <see cref="TaskStatusCodeType"/>.
		/// </summary>
		public TaskStatusCodeType Status
		{ 
			get { return ApiResponse.Status; }
		}
		

		#endregion

		
	}
}

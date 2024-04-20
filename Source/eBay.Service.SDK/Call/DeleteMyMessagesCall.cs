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
	public class DeleteMyMessagesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public DeleteMyMessagesCall()
		{
			ApiRequest = new DeleteMyMessagesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public DeleteMyMessagesCall(ApiContext ApiContext)
		{
			ApiRequest = new DeleteMyMessagesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Removes selected messages for a given user.
		/// </summary>
		/// 
		/// <param name="AlertIDList">
		/// This field is deprecated.
		/// </param>
		///
		/// <param name="MessageIDList">
		/// Contains a list of up to 10 <b>MessageID</b> values.
		/// </param>
		///
		public void DeleteMyMessages(StringCollection AlertIDList, StringCollection MessageIDList)
		{
			this.MessageIDList = MessageIDList;
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
		/// Gets or sets the <see cref="DeleteMyMessagesRequestType"/> for this API call.
		/// </summary>
		public DeleteMyMessagesRequestType ApiRequest
		{ 
			get { return (DeleteMyMessagesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="DeleteMyMessagesResponseType"/> for this API call.
		/// </summary>
		public DeleteMyMessagesResponseType ApiResponse
		{ 
			get { return (DeleteMyMessagesResponseType) AbstractResponse; }
		}

 		/// <summary>
		/// Gets or sets the <see cref="DeleteMyMessagesRequestType.MessageIDs"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection MessageIDList
		{ 
			get { return ApiRequest.MessageIDs; }
			set { ApiRequest.MessageIDs = value; }
		}
		
		

		#endregion

		
	}
}

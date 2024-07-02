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
	public class ReviseMyMessagesFoldersCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ReviseMyMessagesFoldersCall()
		{
			ApiRequest = new ReviseMyMessagesFoldersRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ReviseMyMessagesFoldersCall(ApiContext ApiContext)
		{
			ApiRequest = new ReviseMyMessagesFoldersRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call can be used to add, remove, or rename a custom folder in <b>My eBay Messages</b>. Note that the Inbox and Sent folders cannot be removed or renamed in <b>My eBay Messages</b>.
		/// <br/><br/>
		/// A user can have up to 10 custom folders in <b>My eBay Messages</b>, and it is possible to add, remove, or rename up to 10 custom folders with one <b>ReviseMyMessagesFolders</b> call
		/// </summary>
		/// 
		/// <param name="Operation">
		/// This required field is used to indicate the type of operation to perform (add, remove, or rename a folder). See the enumeration descriptions below for more information on the usage, requirements, and limitations on each operation.
		/// </param>
		///
		/// <param name="FolderIDList">
		/// The eBay-generated unique identifier for a custom folder in <b>My eBay Messages</b>. The <b>FolderID</b> value is required for the 'Rename' and 'Remove' operations, but not for the 'Display' (add) operation. <b>FolderID</b> values can be retrieved by calling <b>GetMyMessages</b> with a <b>DetailLevel</b> value set to <code>ReturnSummary</code>, or the <b>FolderID</b> value for a <b>My eBay Messages</b> folder can be seen at the end of the browser's URL field when you navigate to that folder in <b>My eBay Messages</b>.
		/// <br/><br/>
		/// <span class="tablenote"><b>Note: </b> If multiple folders will be renamed with one call, the user must pay close attention to the order of the <b>FolderID</b> and <b>FolderName</b> fields, as eBay will process these requests in order according to the placement of the the <b>FolderID</b> and <b>FolderName</b> fields. So, the existing folder identified by the first <b>FolderID</b> field in the request payload will get renamed to the folder name passed into the first <b>FolderName</b> field in the request payload, and so on.
		/// </span>
		/// </param>
		///
		/// <param name="FolderNameList">
		/// The user-specified name of the <b>My eBay Messages</b> folder. The <b>FolderName</b> value is required for the 'Display' (add) and 'Rename' operations, but not for the 'Remove' operation. In a 'Display' (add) operation, the name passed into the <b>FolderName</b> field is the name of the new folder. In a 'Rename' operation, the name passed into the <b>FolderName</b> field will be the new name of the existing folder that is specified through the corresponding <b>FolderID</b> field.
		/// <br/><br/>
		/// <b>FolderName</b> values can be retrieved by calling <b>GetMyMessages</b> with a <b>DetailLevel</b> value set to <code>ReturnSummary</code>, or the <b>FolderName</b> value for a <b>My eBay Messages</b> folder can be seen when you navigate to <b>My eBay Messages</b>.
		/// <br/><br/>
		/// <span class="tablenote"><b>Note: </b> If multiple folders will be renamed with one call, the user must pay close attention to the order of the <b>FolderID</b> and <b>FolderName</b> fields, as eBay will process these requests in order according to the placement of the the <b>FolderID</b> and <b>FolderName</b> fields. So, the existing folder identified by the first <b>FolderID</b> field in the request payload will get renamed to the folder name passed into the first <b>FolderName</b> field in the request payload, and so on.
		/// </span>
		/// </param>
		///
		public void ReviseMyMessagesFolders(MyMessagesFolderOperationCodeType Operation, Int64Collection FolderIDList, StringCollection FolderNameList)
		{
			this.Operation = Operation;
			this.FolderIDList = FolderIDList;
			this.FolderNameList = FolderNameList;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void ReviseMyMessagesFolders(MyMessagesFolderOperationCodeType Operation, StringCollection FolderNameList, Int64Collection FolderIDList)
		{
			this.Operation = Operation;
			this.FolderNameList = FolderNameList;
			this.FolderIDList = FolderIDList;
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
		/// Gets or sets the <see cref="ReviseMyMessagesFoldersRequestType"/> for this API call.
		/// </summary>
		public ReviseMyMessagesFoldersRequestType ApiRequest
		{ 
			get { return (ReviseMyMessagesFoldersRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ReviseMyMessagesFoldersResponseType"/> for this API call.
		/// </summary>
		public ReviseMyMessagesFoldersResponseType ApiResponse
		{ 
			get { return (ReviseMyMessagesFoldersResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseMyMessagesFoldersRequestType.Operation"/> of type <see cref="MyMessagesFolderOperationCodeType"/>.
		/// </summary>
		public MyMessagesFolderOperationCodeType Operation
		{ 
			get { return ApiRequest.Operation; }
			set { ApiRequest.Operation = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseMyMessagesFoldersRequestType.FolderID"/> of type <see cref="Int64Collection"/>.
		/// </summary>
		public Int64Collection FolderIDList
		{ 
			get { return ApiRequest.FolderID; }
			set { ApiRequest.FolderID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ReviseMyMessagesFoldersRequestType.FolderName"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection FolderNameList
		{ 
			get { return ApiRequest.FolderName; }
			set { ApiRequest.FolderName = value; }
		}
		
		

		#endregion

		
	}
}

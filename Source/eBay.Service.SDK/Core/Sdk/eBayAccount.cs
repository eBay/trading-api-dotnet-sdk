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
#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// Used to store eBay user ID and password, normally as credentials needed for some 
    /// API calls. Normally, <see cref="ApiCredential.eBayToken"/> is used instead for
    /// API call access.
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class eBayAccount 
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public eBayAccount()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="UserName">The eBay UserId to use.</param>
		/// <param name="Password">The user's password.</param>
		public eBayAccount(string UserName, string Password)
		{
			mUserName = UserName;
			mPassword = Password;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the user's password of type <see cref="string"/>.
		/// </summary>
		public string Password
		{ 
			get { return mPassword; }
			set { mPassword = value; }
		}

		/// <summary>
		/// Gets or sets the user's id of type <see cref="string"/>.
		/// </summary>
		public string UserName
		{ 
			get { return mUserName; }
			set { mUserName = value; }
		}
		#endregion

		/// <summary>
		/// this will return the UserName only
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return mUserName;
		}

		#region Private Fields
		private string mPassword = "";
		private string mUserName = "";
		#endregion

	}
}

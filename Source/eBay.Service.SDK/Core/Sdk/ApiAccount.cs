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
	/// Optionally used to contain application ID, developer ID, and cert, formerly used by the API calls.
    /// This has now been replaced by the authorization (user) token stored in the 
    /// <see cref="ApiCredential.eBayToken"/> property. Note that if you use ApiCredential.eBayToken, the properties
    /// in the <see cref="ApiCredential.ApiAccount"/> property are not automatically set with any ID or cert information derived
    /// from the token.
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class ApiAccount 
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ApiAccount()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Developer">The <see cref="Developer"/> credential.</param>
		/// <param name="Application">The <see cref="Application"/> credential.</param>
		/// <param name="Certificate">The <see cref="Certificate"/> credential.</param>
		public ApiAccount(string Developer, string Application, string Certificate)
		{
			mDeveloper = Developer;
			mApplication = Application;
			mCertificate = Certificate;

		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the Application ID to use. The application ID for a developer
        /// application is manually obtained from the eBay developer account. 
		/// </summary>
		public string Application
		{ 
			get { return mApplication; }
			set { mApplication = value; }
		}

		/// <summary>
        /// Gets or sets the Certificate credential to use. The Certificate for a developer
        /// application is manually obtained from the eBay developer account. 
		/// </summary>
		public string Certificate
		{ 
			get { return mCertificate; }
			set { mCertificate = value; }
		}

		/// <summary>
        /// Gets or sets the Developer ID to use. The Developer ID is manually obtained 
        /// from the eBay developer account. 
		/// </summary>
		public string Developer
		{ 
			get { return mDeveloper; }
			set { mDeveloper = value; }
		}
		#endregion

		#region Private Fields
		private string mApplication = "";
		private string mCertificate = "";
		private string mDeveloper = "";
		#endregion

	}
}

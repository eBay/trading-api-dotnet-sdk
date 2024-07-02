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
using System.Web;
using System.Collections;
using eBay.Service.Core.Sdk;
using System.Runtime.InteropServices;
#endregion

namespace eBay.Service.Util
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class SdkUtility
	{

		#region Static Methods
		/// <summary>
		/// Launches the sign in page for using the  Authentication &amp; Authorization feature.
		/// </summary>
		/// <param name="Context">The <see cref="ApiContext"/> which defines the SignInUrl and RuName.</param>
		/// <param name="SessionID">The SessionID which is used by <see cref="eBay.Service.Call.FetchTokenCall"/> to retrieve the token.</param>
		public static void LaunchSignInPage(ApiContext Context, string SessionID)
		{
			if(Context == null)
				throw new SdkException("Please specify the Context.", new System.ArgumentNullException());
			
			if(Context.SignInUrl == null || Context.SignInUrl.ToString().Length == 0)
				throw new SdkException("Please specify the SignInUrl in the Context object.", new System.ArgumentNullException());

			if (Context.RuName == null || Context.RuName.Length == 0)
				throw new SdkException("Please specify a RuName.", new System.ArgumentNullException());

			// Go to the page.
			string finalUrl = Context.SignInUrl + "&RuName=" + Context.RuName;
			if(SessionID != null && SessionID.Length > 0 )
				finalUrl += "&SessID=" + HttpUtility.UrlEncode(SessionID);

            System.Diagnostics.Process.Start(finalUrl);
		}
		#endregion
	}
}










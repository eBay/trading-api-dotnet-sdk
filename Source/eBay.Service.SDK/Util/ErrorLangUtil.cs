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

using System;
using System.Collections;
using eBay.Service.Core.Soap;
using System.Runtime.InteropServices;

namespace eBay.Service.Util
{

	/// <summary>
	/// The default error language is the one used on the site being accessed in the 
    /// API call. You can change the default to any language, so that the error messages
    /// are displayed in the language of your choice.
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class ErrorLanguageUtility
	{
	
		#region Static Methods
		/// <summary>
		/// Gets the default numeric error language id associated with a <see cref="SiteCodeType"/>.
		/// </summary>
		/// <param name="SiteCodeType">The <see cref="SiteCodeType"/> to resolve.</param>
		/// <returns>The numeric language id.</returns>
		public static int GetDefaultErrorLanguageID(SiteCodeType SiteCodeType)
		{
			int siteID = SiteUtility.GetSiteID(SiteCodeType);
			if (!Enum.IsDefined(typeof(ErrorLanguageValueEnum), siteID))
				return 0;
			else
				return siteID;
		}

		/// <summary>
		/// Gets the <see cref="ErrorLanguageCodeType"/> associated with a <see cref="SiteCodeType"/>.
		/// </summary>
		/// <param name="SiteCodeType">The <see cref="SiteCodeType"/> to resolve.</param>
		/// <returns>The <see cref="ErrorLanguageCodeType"/>.</returns>
		public static ErrorLanguageCodeType GetDefaultErrorLanguageCodeType(SiteCodeType SiteCodeType)
		{
			int siteID = SiteUtility.GetSiteID(SiteCodeType);
			if (siteID == 100)
				return ErrorLanguageCodeType.en_US;
			else if (!Enum.IsDefined(typeof(ErrorLanguageValueEnum), siteID))
				return ErrorLanguageCodeType.CustomCode;
			else
				return (ErrorLanguageCodeType) Enum.Parse(typeof(ErrorLanguageCodeType), Enum.GetName(typeof(ErrorLanguageValueEnum), siteID));
		}

		/// <summary>
		/// Gets the <see cref="ErrorLanguageCodeType"/> associated with the numeric error language id.
		/// </summary>
		/// <param name="ErrorLanguageID">The numeric language id to resolve.</param>
		/// <returns>The <see cref="ErrorLanguageCodeType"/>.</returns>
		public static ErrorLanguageCodeType GetErrorLanguageCodeType(int ErrorLanguageID)
		{
			if (!Enum.IsDefined(typeof(ErrorLanguageValueEnum), ErrorLanguageID))
				return ErrorLanguageCodeType.CustomCode;
			else
				return((ErrorLanguageCodeType) Enum.Parse(typeof(ErrorLanguageCodeType), Enum.GetName(typeof(ErrorLanguageValueEnum), ErrorLanguageID)));
			
		}

		/// <summary>
		/// Gets the numeric error language id from the <see cref="ErrorLanguageCodeType"/>.
		/// </summary>
		/// <param name="ErrorLanguageCodeType">The <see cref="ErrorLanguageCodeType"/> to resolve.</param>
		/// <returns>The numeric error language id.</returns>
		public static int GetErrorLanguageID(ErrorLanguageCodeType ErrorLanguageCodeType)
		{
			if (!Enum.IsDefined(typeof(ErrorLanguageValueEnum), ErrorLanguageCodeType.ToString()))
				return 0;
			else
				return (int) Enum.Parse(typeof(ErrorLanguageValueEnum), Enum.GetName(typeof(ErrorLanguageCodeType), ErrorLanguageCodeType));


		}
		#endregion

		#region Private Enumerations
		/// <summary>
		/// 
		/// </summary>
		private enum ErrorLanguageValueEnum
		{
			de_AT = 16,
			de_CH = 193,
			de_DE = 77,
			en_AU = 15,
			en_CA = 2,
			en_GB = 3,
			en_HK = 201,
			en_IN = 203,
			en_MY = 207,
			en_PH = 211,
			en_SG = 216,
			en_US = 0,
			es_ES = 186,
			fr_BE = 23,
			fr_FR = 71,
			it_IT = 101,
			nl_BE = 123,
			nl_NL = 146,
			zh_CN = 223,
			zh_TW = 196,
		}
		#endregion

	}
}

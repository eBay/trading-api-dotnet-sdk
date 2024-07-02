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
using System.Configuration;
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;

namespace AllTestsSuite
{
	/// <summary>
	/// Summary description for ApiContextLoader.
	/// </summary>
	public class ApiContextLoader
	{
		public ApiContextLoader()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public static ApiContext LoadApiContext(string name)
		{
			ApiContext context = new ApiContext();
			
			context.ApiCredential.ApiAccount.Application = LoadAppConfig(name+"appid");
			context.ApiCredential.ApiAccount.Developer = LoadAppConfig(name+"devid");
			context.ApiCredential.ApiAccount.Certificate = LoadAppConfig(name+"cert");
			context.ApiCredential.eBayToken = LoadAppConfig(name+"token");
			context.SoapApiServerUrl = LoadAppConfig("soapurl");
			context.XmlApiServerUrl = LoadAppConfig("sdkurl");
			context.EPSServerUrl = LoadAppConfig("epsurl");
            string timeout = LoadAppConfig("timeout");
            if (timeout != null && string.Empty != timeout)
            {
                context.Timeout = int.Parse(timeout);
            }

			ApiLogManager Logger = new ApiLogManager();
			Logger.EnableLogging = true;

			string logfile = LoadAppConfig("logfile");
			if (logfile != "" && logfile != null)
				Logger.ApiLoggerList.Add(new FileLogger(logfile));
			else
				Logger.ApiLoggerList.Add(new ConsoleLogger());

			if (LoadAppConfig("logexception").ToUpper() == "TRUE")
				Logger.ApiLoggerList[0].LogExceptions = true;
			
			if (LoadAppConfig("logmessages").ToUpper() == "TRUE")
				Logger.ApiLoggerList[0].LogApiMessages = true;

			Logger.ApiLoggerList[0].LogInformations = true;
			context.ApiLogManager = Logger;

			return context;
		}

		public static string LoadAppConfig(string key)
		{
			return System.Configuration.ConfigurationManager.AppSettings.Get(key);
		}

	}
}

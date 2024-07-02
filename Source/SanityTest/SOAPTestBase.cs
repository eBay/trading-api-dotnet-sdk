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
using System.Reflection;
using System.Configuration;
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;

namespace AllTestsSuite
{
	public class SOAPTestBase : UnitTestBase
	{
		public SOAPTestBase()
		{
		}
		
		public ApiContext apiContext;
		public ApiLogManager Logger;
		public bool teststarted = false;

		[TestFixtureSetUp]
		public override void TestFixtureSetup()
		{
			base.TearDown();
			apiContext = ApiContextLoader.LoadApiContext("");
			Logger = apiContext.ApiLogManager;
		}

		[TestFixtureTearDown]
		public override void TestFixtureTearDown()
		{
		}

		[SetUp]
		public override void Setup()
		{
			string formatmsg = "******************** [Begin Test] ********************";
			Logger.RecordMessage(formatmsg);
		}

		[TearDown]
		public override void TearDown()
		{
			string formatmsg = "********************* [End Test] *********************";
			Logger.RecordMessage(formatmsg);
		}

		public string LoadAppConfig(string key)
		{
			return System.Configuration.ConfigurationManager.AppSettings.Get(key);
		}

		public void LogTestCaseStart(string name)
		{
			string formatmsg = String.Format("*******************************************\r\n[{0}]\r\n", name);
			Logger.RecordMessage(formatmsg, MessageType.Information, MessageSeverity.Informational);

		}
		public void LogTestCasePassed(string name)
		{
			string formatmsg = String.Format("[{0}: Passed]\r\n*******************************************\r\n", name);
			Logger.RecordMessage(formatmsg, MessageType.Information, MessageSeverity.Informational);

		}

		public void LogTestCaseFailed(string name)
		{
			string formatmsg = String.Format("[{0}: Failed]\r\n*******************************************\r\n", name);
			Logger.RecordMessage(formatmsg, MessageType.Exception, MessageSeverity.Error);

		}

		public void RunTest(MethodBase method)
		{
			try
			{
				LogTestCaseStart(method.Name);
				teststarted = true;
				method.Invoke(this, null);
				LogTestCasePassed(method.Name);
	
			}

			catch (TargetInvocationException aex)
			{
				Logger.RecordMessage(aex.InnerException.Message, MessageType.Exception, MessageSeverity.Error);
				LogTestCaseFailed(method.Name);

				throw aex.InnerException;
			}
			finally
			{
				teststarted = false;
			}
		}

	
	}
}

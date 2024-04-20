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
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
#endregion

namespace AllTestsSuite.T_020_OtherTestsSuite
{
	[TestFixture]
	public class T_260_GetChallengeTokenLibrary : SOAPTestBase
	{
		[Test]
		public void GetChallengeToken()
		{
			GetChallengeTokenCall api = new GetChallengeTokenCall(this.apiContext);
			// Make API call.
			ApiException gotException = null;
			try
			{
				api.Execute();
				TestData.AudioChallengeURL = api.AudioChallengeURL;
				TestData.ChallengeToken = api.ChallengeToken;
				TestData.ImageChallengeURL = api.ImageChallengeURL;
			}
			catch(ApiException ex)
			{
				gotException = ex;
			}
			Assert.IsTrue(gotException == null || gotException.containsErrorCode("517"));
		}
	}
}
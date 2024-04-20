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

namespace AllTestsSuite.T_010_MessageTestsSuite
{
	[TestFixture]
	public class T_090_AddMemberMessageRTQLibrary : SOAPTestBase
	{
		[Test]
		public void AddMemberMessageRTQ()
		{
			AddMemberMessageRTQCall api = new AddMemberMessageRTQCall(apiContext);

			MemberMessageType memberMsg = new MemberMessageType();
			memberMsg.Subject = "SDK Sanity Test ASQ";
			memberMsg.Body = "SDK sanity test body";
			memberMsg.DisplayToPublic = false; memberMsg.DisplayToPublicSpecified = true;
			memberMsg.EmailCopyToSender = false; memberMsg.EmailCopyToSenderSpecified = true;
			memberMsg.HideSendersEmailAddress = true; memberMsg.HideSendersEmailAddressSpecified = true;
			memberMsg.MessageType = MessageTypeCodeType.ContactEbayMember;
			memberMsg.QuestionType = QuestionTypeCodeType.General;
			memberMsg.RecipientID = new StringCollection();
			memberMsg.ParentMessageID = "1234";
			memberMsg.RecipientID.Add(TestData.ApiUserID);
			// Make API call.
			ApiException gotException = null;
			// Negative test.
			try {
			api.AddMemberMessageRTQ("1111111111", memberMsg);
			} catch (ApiException ex) {
				gotException = ex;
			}
			Assert.IsNotNull(gotException);
			
		}
	}
}
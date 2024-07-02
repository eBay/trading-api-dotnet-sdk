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
using UnitTests.Helper;
#endregion

namespace AllTestsSuite.T_050_ItemTestsSuite
{
	[TestFixture]
	public class T_040_SetUserNotesLibrary : SOAPTestBase
	{
		[Test]
		public void SetUserNotes()
		{
			Assert.IsNotNull(TestData.NewItem2, "Failed because no item available -- requires successful AddItem test");
			SetUserNotesCall api = new SetUserNotesCall(this.apiContext);
			api.Action = SetUserNotesActionCodeType.AddOrUpdate;
			api.ItemID = TestData.NewItem2.ItemID;
			api.NoteText = "Notes for eBay SDK sanity test.";

			DetailLevelCodeTypeCollection detailLevel=new DetailLevelCodeTypeCollection();
			DetailLevelCodeType type=DetailLevelCodeType.ReturnAll;
			detailLevel.Add(type);
			api.DetailLevelList=detailLevel;
			// Make API call.
			api.Execute();

			System.Threading.Thread.Sleep(3000);
			//check whether the call is success.
			//eBayNotes can not get by calling GetItemCall.
			Assert.IsTrue(api.ApiResponse.Ack==AckCodeType.Success || api.ApiResponse.Ack==AckCodeType.Warning,"do not success!");
		}
	}
}
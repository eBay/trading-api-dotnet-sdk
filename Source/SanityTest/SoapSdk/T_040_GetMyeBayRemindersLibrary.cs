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

namespace AllTestsSuite.T_060_MyeBayTestsSuite
{
	[TestFixture]
	public class T_040_GetMyeBayRemindersLibrary : SOAPTestBase
	{
		[Test]
		public void GetMyeBayReminders()
		{
			GetMyeBayRemindersCall api = new GetMyeBayRemindersCall(this.apiContext);
			ReminderCustomizationType rc = new ReminderCustomizationType();
			rc.Include = true; rc.IncludeSpecified = true;
			rc.DurationInDays = 7; rc.DurationInDaysSpecified = true;
			api.BuyingReminders = rc;
			rc = new ReminderCustomizationType();
			rc.Include = true; rc.IncludeSpecified = true;
			rc.DurationInDays = 7; rc.DurationInDaysSpecified = true;
			api.SellingReminders = rc;
			// Make API call.
			api.GetMyeBayReminders();
			RemindersType buying = api.ApiResponse.BuyingReminders;
			RemindersType selling = api.ApiResponse.SellingReminders;
			
		}
	}
}
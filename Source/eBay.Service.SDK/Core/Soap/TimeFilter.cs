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

namespace eBay.Service.Core.Soap
{

	/// <summary>
	/// This class enables specification of time values for DateTime fields.
	/// Information and tips about DateTime objects are available in the MSDN library. 
	/// This class contains properties for both local and GMT (UTC) time.
	/// If you use such properties of this class interchangably, the last property that is set overwrites the previous one.
	/// Note that if only the properties for local time are used, then the following can occur with an application: A local time (for example, 10 a.m.) is emitted by an application, and the API changes that time to GMT (for example, to 5 p.m.). And a GMT time from the API (for example, 1 p.m.) received by an application is converted to local time (for example, to 6 a.m.). 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class TimeFilter
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public TimeFilter()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="TimeFrom"></param>
		/// <param name="TimeTo"></param>
		public TimeFilter(DateTime TimeFrom, DateTime TimeTo)
		{
			mTimeFrom = TimeFrom;
			mTimeTo = TimeTo;
		}
		#endregion

		#region Properties
		/// <summary>
   	/// Specifies a "time from" value that uses local computer time, regardless of the .NET Framework version used by the client.
   	/// </summary>
		public DateTime TimeFrom
		{ 
			get { return mTimeFrom; }
			set { mTimeFrom = value; }
		}

		/// <summary>
		/// Specifies a "time to" value that uses local computer time, regardless of the .NET Framework version used by the client.
		/// </summary>
		public DateTime TimeTo
		{ 
			get { return mTimeTo; }
			set { mTimeTo = value; }
		}
		/// <summary>
   	/// Specifies a "time from" value that uses UTC (GMT) time, regardless of the .NET Framework version used by the client.
   	/// </summary>
		public DateTime TimeFromUTC
		{ 
			get { return mTimeFrom.ToUniversalTime(); }
			set { mTimeFrom = value.ToLocalTime(); }
		}

		/// <summary>
		/// Specifies a "time to" value that uses UTC (GMT) time, regardless of the .NET Framework version used by the client.
		/// </summary>
		public DateTime TimeToUTC
		{ 
			get { return mTimeTo.ToUniversalTime(); }
			set { mTimeTo = value.ToLocalTime(); }
		}
		#endregion

		#region Private Fields
		// Local time values stored internally.
		private DateTime mTimeFrom;
		private DateTime mTimeTo;
		#endregion

	}
}

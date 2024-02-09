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
using System.IO;
using System.Text;
using System.Xml;
#endregion

namespace eBay.Service.Util
{

	/// <summary>
	/// 
	/// </summary>
	public class ConsoleLogger : ApiLogger
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ConsoleLogger()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="LogInformations"></param>
		/// <param name="LogApiMessages"></param>
		/// <param name="LogExceptions"></param>
		public ConsoleLogger(bool LogInformations, bool LogApiMessages, bool LogExceptions)
		{
			this.LogApiMessages = LogApiMessages;
			this.LogInformations = LogInformations;
			this.LogExceptions = LogExceptions;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="Severity"></param>
		public override void RecordMessage(string Message, MessageSeverity Severity)
		{
			StringBuilder message = new StringBuilder();

			message.Append("["+DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentUICulture));
			message.Append(", " + Severity.ToString());
			message.Append("]\r\n" + Message + "\r\n");

			// Force the write to the underlying file
			Console.WriteLine(message);
		}
		#endregion

	}
}


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
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.IO;
#endregion

namespace eBay.Service.Util
{

	/// <summary>
	/// 
	/// </summary>
	public class EventLogger : ApiLogger
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public EventLogger()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="EventLogName"></param>
		/// <param name="EventLogSource"></param>
		/// <param name="MachineName"></param>
		public EventLogger(string EventLogName, string EventLogSource, string MachineName)
		{
			mEventLogName = EventLogName;
			mEventLogSource = EventLogSource;
			mMachineName = MachineName;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="EventLogName"></param>
		/// <param name="EventLogSource"></param>
		/// <param name="MachineName"></param>
		/// <param name="LogInformations"></param>
		/// <param name="LogApiMessages"></param>
		/// <param name="LogExceptions"></param>
		public EventLogger(string EventLogName, string EventLogSource, string MachineName, bool LogInformations, bool LogApiMessages, bool LogExceptions)
		{
			this.LogApiMessages = LogApiMessages;
			this.LogInformations = LogInformations;
			this.LogExceptions = LogExceptions;

			mEventLogName = EventLogName;
			mEventLogSource = EventLogSource;
			mMachineName = MachineName;
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
			System.Diagnostics.EventLog eventLog = 	new System.Diagnostics.EventLog();
         
			// Create the source if it does not already exist
			if( !System.Diagnostics.EventLog.SourceExists(mEventLogSource) )
			{
				System.Diagnostics.EventLog.CreateEventSource(mEventLogSource, mEventLogName);
			}
			eventLog.Source = mEventLogSource;
			eventLog.MachineName = mMachineName;
         
			// Determine what the EventLogEventType should be 
			// based on the LogSeverity passed in
			EventLogEntryType type = EventLogEntryType.Information;

			switch(Severity)
			{
				case MessageSeverity.Informational:
					type = EventLogEntryType.Information;
					break;
				case MessageSeverity.Failure:
					type = EventLogEntryType.FailureAudit;
					break;
				case MessageSeverity.Warning:
					type = EventLogEntryType.Warning;
					break;
				case MessageSeverity.Error:
					type = EventLogEntryType.Error;
					break;
			}


			message.Append("["+DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentUICulture));
			message.Append(", " + Severity.ToString());
			message.Append("]\r\n" + Message + "\r\n");

			eventLog.WriteEntry(message.ToString(), type);
		}
		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public string EventLogName
		{
			get { return mEventLogName; }
			set { mEventLogName = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		public string EventLogSource   
		{
			get { return mEventLogSource; }
			set { mEventLogSource = value; }
		}


		/// <summary>
		/// 
		/// </summary>
		public string MachineName
		{
			get { return mMachineName; }
			set { mMachineName = value; }
		}
		#endregion

		#region Private Fields
		private string mEventLogName = "eBayWebservice";
		private string mEventLogSource = "SoapSDK";
		private string mMachineName = Environment.MachineName;
		#endregion

	}
}


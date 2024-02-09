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
using System.Xml;
using System.IO;
using System.Collections;
using eBay.Service.Util;
#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// ApiLogManager is optional; it is used in an application if any file, console, or event logging 
    /// is needed. The ApiLogManager object is set in the application's <see cref="eBay.Service.Core.Sdk.ApiContext"/> object, logging is turned 
    /// on using the <see cref="EnableLogging"/> property, and then any individual loggers are added using 
    /// the <see cref="eBay.Service.Core.Sdk.ApiLogManager.ApiLoggerList"/> Add property. Notice that the level of detail that is logged is set by
    /// the individual file, console, or event loggers that are in the logger list; the detail level is not set 
    /// by the ApiLogManager. The individual loggers can be
    /// set to log error messages, and/or exceptions, and/or informational messages.
	/// </summary>
    /// <example>
    /// This snippet shows how to add a file logger using the ApiLogManager class, with everything logged,
    /// error messages, exceptions, and informational messages:
    /// <code>
    /// apiContext.ApiLogManager = new ApiLogManager();
    /// apiContext.ApiLogManager.ApiLoggerList.Add(new FileLogger("listing_log.txt", true, true, true));
    /// apiContext.ApiLogManager.EnableLogging = true;
    ///  </code>
    /// </example>
	public class ApiLogManager
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ApiLogManager()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public ApiLogManager(ApiLoggerCollection ApiLoggerList)
		{
			mApiLoggerList.AddRange(ApiLoggerList);
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Message"></param>
		public void RecordMessage(string Message)
		{
			this.RecordMessage(Message, MessageType.Information, MessageSeverity.Informational);
		}
		
		/// <summary>
		/// Log a message to all loggers enabled for this type of message.
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="Type"></param>
		/// <param name="Severity"></param>
		public void RecordMessage(string Message, MessageType Type, MessageSeverity Severity)
		{	if (!mEnableLogging)
				return;

			switch (Type)
			{
				case MessageType.Exception:
					foreach (ApiLogger logger in mApiLoggerList)
					{
						if (logger.LogExceptions)
							logger.RecordMessage(Message, Severity);
					}

					break;
				case MessageType.Information:
					foreach (ApiLogger logger in mApiLoggerList)
					{
						if (logger.LogInformations)
							logger.RecordMessage(Message, Severity);
					}

					break;

				case MessageType.ApiMessage:
					foreach (ApiLogger logger in mApiLoggerList)
					{
						if (logger.LogApiMessages)
							logger.RecordMessage(Message, Severity);
					}
				
					break;

			}
		}

		/// <summary>
		/// Used only for exception-based payload logging; variation of RecordMessage which takes an exception parameter.
		/// Calls RecordMessage if no exception is supplied, or if this is not an ApiMessage (i.e. payload message), or if
		/// no MessageLoggingFilter property is configured on the log manager.  Otherwise, the exception logic is applied: the 
		/// method will continue calling RecordMessage only if the exception matches the configured MessageLoggingFilter property.
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="Type"></param>
		/// <param name="Severity"></param>
		/// <param name="Ex"></param>
		public void RecordPayloadOnException(string Message, MessageType Type, MessageSeverity Severity, Exception Ex)
		{
			if (Type != MessageType.ApiMessage || mMessageLoggingFilter == null || mMessageLoggingFilter.Matches(Ex))
				RecordMessage(Message, Type, Severity);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the list of loggers to be used in the ApiLogManager. Type <see cref="ApiLoggerCollection"/>.
        /// The individual file, console, or event loggers are added to this list using <see cref="eBay.Service.Core.Sdk.ApiLogManager.ApiLoggerList"/> Add.
		/// </summary>
		public ApiLoggerCollection ApiLoggerList
		{ 
			get { return mApiLoggerList; }
			set { mApiLoggerList = value; }
		}
		
		/// <summary>
		/// If used as a getter, indicates whether logging is enabled (<b>true</b>) or not enabled (<b>false</b>).
        /// If used as a setter, a value of <b>true</b> enables logging, a value of <b>false</b> disables logging.
		/// </summary>
		public bool EnableLogging
		{ 
			get { return mEnableLogging; }
			set { mEnableLogging = value; }
		}

		/// <summary>
		/// Gets or sets a global message logging filter.  If this is set, all loggers will perform message logging 
		/// </summary>
		public ExceptionFilter MessageLoggingFilter
		{
			get { return mMessageLoggingFilter; }
			set { mMessageLoggingFilter = value; }
		}

		/// <summary>
		/// Get only - returns <b>true</b> if any logger is enabling message logging.
        /// The enabling (or not) of this feature for each invidual logger is done in the logger constructor.
		/// </summary>
		public bool LogApiMessages
		{ 
			get { 
				foreach (ApiLogger logger in mApiLoggerList)
				{
					if (logger.LogApiMessages)
						return true;
				}
				return false; 
			
			}
		}

		/// <summary>
		/// Get only - returns <b>true</b> if any logger is enabling logging of exception message strings.
        /// The enabling (or not) of this feature for each invidual logger is done in the logger constructor.
        /// 
		/// </summary>
		public bool LogExceptions
		{ 
			get 
			{ 
				foreach (ApiLogger logger in mApiLoggerList)
				{
					if (logger.LogExceptions)
						return true;
				}
				return false; 
			
			}		
		}

		/// <summary>
		/// Get only - returns <b>true</b> if any logger is enabling information logging.
        /// The enabling (or not) of this feature for each invidual logger is done in the logger constructor.
		/// </summary>
		public bool LogInformation
		{ 
			get 
			{ 
				foreach (ApiLogger logger in mApiLoggerList)
				{
					if (logger.LogInformations)
						return true;
				}
				return false; 
			
			}		
		}
		#endregion

		#region Private Fields
		private ApiLoggerCollection mApiLoggerList = new ApiLoggerCollection();
		private bool mEnableLogging = true;
		private ExceptionFilter mMessageLoggingFilter = null;
		#endregion

	}
}

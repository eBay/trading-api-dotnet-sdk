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
using System.Collections;
#endregion

namespace eBay.Service.Util
{

	#region Public Enumerations
	/// <summary>
	/// 
	/// </summary>
	public enum MessageSeverity
	{
		/// <value>Informational message</value>
		Informational = 1,
		/// <value>Failure audit message</value>
		Failure = 2,
		/// <value>Warning message</value>
		Warning = 3,
		/// <value>Error message</value>
		Error = 4
	}
	/// <summary>
	/// 
	/// </summary>
	public enum MessageType
	{
		/// <value>Informational message</value>
		ApiMessage = 1,
		/// <value>Failure audit message</value>
		Exception = 2,
		/// <value>Warning message</value>
		Information = 3,
	}
	#endregion

	/// <summary>
	/// Base class of the <see cref="FileLogger"/>, <see cref="EventLogger"/>, and
    /// <see cref="ConsoleLogger"/> classes. Typically, the individual classes that
    /// inherit from ApiLogger are used in the <see cref="eBay.Service.Core.Sdk.ApiLogManager.ApiLoggerList"/>
    /// to specify which loggers are to be used for logging.
	/// </summary>
	public abstract class ApiLogger
	{

		#region Constructors
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Message">The message to log of type <see cref="string"/>.</param>
		/// <param name="Severity">The severity of the message to log of type <see cref="MessageSeverity"/>.</param>
		public abstract void RecordMessage(string Message, MessageSeverity Severity);
		#endregion

		#region Protected Methods

		/// <summary>
		/// get directory path of eBay.Service.dll
		/// </summary>
		/// <returns></returns>
		protected string GetGetExecutingAssemblyDirectory()
		{
			string path=System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
			
			return path;
		}

		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets a property that determines if the API Call payloads should be logged.
		/// </summary>
		public bool LogApiMessages
		{ 
			get { return mLogApiMessages; }
			set { mLogApiMessages = value; }
		}

		/// <summary>
		/// Gets or sets a property that determines if the exceptions should be logged.
		/// </summary>
		public bool LogExceptions
		{ 
			get { return mLogExceptions; }
			set { mLogExceptions = value; }
		}
		
		/// <summary>
		/// Gets or sets a property that determines if informational messages should be logged.
		/// </summary>
		public bool LogInformations
		{ 
			get { return mLogInformations; }
			set { mLogInformations = value; }
		}
		#endregion

		#region Private Fields
		private bool mLogApiMessages = false;
		private bool mLogExceptions = false;
		private bool mLogInformations = false;
		#endregion	

	}
	#region ApiLoggerCollection
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public sealed class ApiLoggerCollection : System.Collections.CollectionBase 
	{
        
		/// <summary>
		/// 
		/// </summary>
		public ApiLoggerCollection() 
		{
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items">An array of loggers to log to of type <see cref="ApiLogger"/>.</param>
		public ApiLoggerCollection(ApiLogger[] items) 
		{
			this.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items">A collection of loggers to log to of type <see cref="ApiLoggerCollection"/>.</param>
		public ApiLoggerCollection(ApiLoggerCollection items) 
		{
			this.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		public ApiLogger this[int index] 
		{
			get 
			{
				return ((ApiLogger)(this.InnerList[index]));
			}
			set 
			{
				this.InnerList[index] = value;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public bool IsFixedSize 
		{
			get 
			{
				return this.InnerList.IsFixedSize;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public bool IsReadOnly 
		{
			get 
			{
				return this.InnerList.IsReadOnly;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public bool IsSynchronized 
		{
			get 
			{
				return this.InnerList.IsSynchronized;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public object SyncRoot 
		{
			get 
			{
				return this.InnerList.SyncRoot;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int Add(ApiLogger item) 
		{
			return this.InnerList.Add(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(ApiLogger[] items) 
		{
			this.InnerList.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(ApiLoggerCollection items) 
		{
			this.InnerList.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(ApiLogger item) 
		{
			return this.InnerList.Contains(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		/// <param name="index"></param>
		public void CopyTo(ApiLogger[] items, int index) 
		{
			this.InnerList.CopyTo(items, index);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(ApiLogger item) 
		{
			return this.InnerList.IndexOf(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void Insert(int index, ApiLogger item) 
		{
			this.InnerList.Insert(index, item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public ApiLogger ItemAt(int index) 
		{
			return ((ApiLogger)(this.InnerList[index]));
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Remove(ApiLogger item) 
		{
			this.InnerList.Remove(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public ApiLogger[] ToArray() 
		{
			return ((ApiLogger[])(this.InnerList.ToArray(typeof(ApiLogger))));
		}
	}
	#endregion

}    


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
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.XPath;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
#endregion

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	///  Wraps HTTP errors (unexpected return codes 300 - 499, 501-599) for SDK.
      ///  The HTTP status code is available in the StatusCode property.
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[Serializable()]
	public class HttpException: SdkException, ISerializable
	{

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public HttpException(): base()
		{
		}

		/// <summary>
		/// Construct an HttpException described by the specified message.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public HttpException(string message): base(message)
		{
		}

		/// <summary>
		/// Construct an HttpException wrapping the given exception, and described by the specified message.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="inner">The exception that is the cause of the current exception.</param>
		public HttpException(string message, Exception inner): base(message, inner)
		{
		}

		/// <summary>
		/// Construct an HttpException with the specified HTTP status code.
		/// </summary>
		/// <param name="code">The HTTP status code associated with the exception.</param>
		public HttpException(int code)
		{
			mCode = code;
		}

		/// <summary>
		/// Deserialize an HttpException from serialized state information.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		protected HttpException(SerializationInfo info, StreamingContext context):base(info, context)
		{
			mCode = (int) info.GetValue("mCode", typeof(int));
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Serialize an HttpException.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
		[SecurityPermissionAttribute(SecurityAction.Demand,SerializationFormatter=true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("mCode", mCode, typeof(int));
			base.GetObjectData(info, context);
		}
		#endregion

		#region Properties
		/// <summary>
		/// Read-only property providing the StatusCode of the HttpException.
		/// </summary>
		public int StatusCode 
		{
			get {return mCode;}
		}
		#endregion

		#region Private Fields
		private int mCode = 0;
		#endregion

	}
}

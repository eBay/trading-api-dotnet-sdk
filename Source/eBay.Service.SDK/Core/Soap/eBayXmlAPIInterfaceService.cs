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

using System;
using System.Net;
using System.Runtime.Serialization;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
using System.Xml;
using System.IO;

namespace eBay.Service.Core.Soap
{

    public partial class CustomSecurityHeaderType
    {
        private string moAuthToken;
        /// <summary>
        /// 
        /// </summary>
        public string oAuthToken
        {
            get
            {
                return this.moAuthToken;
            }
            set
            {
                this.moAuthToken = value;
            }
        }
    }

        

        /// <summary>
        ///
        /// </summary>
        [System.Diagnostics.DebuggerStepThroughAttribute()]
	public class eBayXmlAPIInterfaceService
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public eBayXmlAPIInterfaceService()
		{
			this.Url = "http://localhost:8080/ws/websvc/eBayAPI";

		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Makes an Xml request to eBay.
		/// </summary>
		/// <param name="Request">The Xml Request to make of type <see cref="XmlDocument"/>.</param>
		/// <returns>The <see cref="XmlDocument"/> response from the API call.</returns>
		public XmlDocument Invoke(XmlDocument Request) 
		{
			if (Request == null)
				throw new System.ArgumentNullException("Request", "Request reference not set.");
			if (RequesterCredentials == null)
				throw new System.ArgumentNullException("RequesterCredentials", "RequesterCredentials reference not set.");

			string encoding = ((XmlDeclaration)Request.FirstChild).Encoding;
			
			// Convert string to binary.
			mXmlRequestMsg = Request.InnerXml;
			int dataLen = System.Text.Encoding.GetEncoding(encoding).GetByteCount(mXmlRequestMsg);
			byte[] data = new byte[dataLen];
			System.Text.Encoding.UTF8.GetBytes(mXmlRequestMsg, 0, mXmlRequestMsg.Length, data, 0);
			
			// Remove lead bytes otherwise we'll mess with V3 server.
			if( data[0] != 0x3C )
			{
				byte[] noLeadBytes = new Byte[data.Length - 3];
				for(int n = 0; n < noLeadBytes.Length; n ++ )
					noLeadBytes[n] = data[n + 3];
			
				data = noLeadBytes;
			}
			
			
			HttpWebRequest http = (HttpWebRequest) WebRequest.Create(this.Url);
			http.Method = "POST";
			http.ContentType = "text/xml";
			http.ContentLength = data.Length;
			http.KeepAlive = false;
							
			// Old headers.
			http.Headers.Add("X-EBAY-API-SESSION-CERTIFICATE: " + this.RequesterCredentials.Credentials.DevId + ";" +
				this.RequesterCredentials.Credentials.AppId + ";" + this.RequesterCredentials.Credentials.AuthCert);
			http.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL: " + this.Version);
			
			// Values for gateway support.
			http.Headers.Add("X-EBAY-API-DEV-NAME", this.RequesterCredentials.Credentials.DevId);
			http.Headers.Add("X-EBAY-API-APP-NAME", this.RequesterCredentials.Credentials.AppId);
			http.Headers.Add("X-EBAY-API-CERT-NAME", this.RequesterCredentials.Credentials.AuthCert);
			http.Headers.Add("X-EBAY-API-CALL-NAME", XmlUtility.GetString(Request.CreateNavigator(), "/request/Verb"));
			http.Headers.Add("X-EBAY-API-SITEID", XmlUtility.GetString(Request.CreateNavigator(), "/request/SiteId"));
			http.Headers.Add("X-EBAY-API-DETAIL-LEVEL", XmlUtility.GetString(Request.CreateNavigator(), "/request/DetailLevel"));

            //Check for oAuth Token
            if (this.RequesterCredentials.oAuthToken != null && this.RequesterCredentials.oAuthToken.Length > 0)
            {
                if (this.RequesterCredentials.eBayAuthToken == null && this.RequesterCredentials.eBayAuthToken.Length <= 0)
                {

                    http.Headers.Add("X-EBAY-API-IAF-TOKEN", this.RequesterCredentials.oAuthToken);
                }
            }

            http.Timeout = this.Timeout;
			Stream str = http.GetRequestStream();
			str.Write(data, 0, data.Length);
			str.Close();
			
			System.Net.WebResponse wresp = http.GetResponse();
			
			str = wresp.GetResponseStream();
			
			// Convert output data to string.
			StreamReader sr = new StreamReader(str);
			mXmlResponseMsg = sr.ReadToEnd();
			sr.Close();
			str.Close();


			XmlDocument retdoc = new XmlDocument();
			retdoc.LoadXml(mXmlResponseMsg);
			
			return retdoc;
		}		
		#endregion

		#region Private Methods
		private string Pretty(string Message) 
		{
			System.Xml.XmlDocument Doc = new System.Xml.XmlDocument();
			System.IO.MemoryStream MemStr = new System.IO.MemoryStream();
			System.Xml.XmlTextWriter XmlWriter = new System.Xml.XmlTextWriter(MemStr, System.Text.Encoding.Unicode);
			XmlWriter.Formatting = System.Xml.Formatting.Indented;
			Doc.LoadXml(Message);
			Doc.WriteContentTo(XmlWriter);
			XmlWriter.Flush();
			MemStr.Flush();
			MemStr.Position = 0;
			string Ret = new System.IO.StreamReader(MemStr).ReadToEnd();
			MemStr.Close();
			XmlWriter.Close();
			return Ret;

		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets credential information that is used to set the required Http headers.
		/// </summary>
		/// <remarks>Only the AppId, DevId, and AuthCert are required.</remarks>
		public CustomSecurityHeaderType RequesterCredentials 
		{
			get 
			{
				return this.mRequesterCredentials;
			}
			set 
			{
				this.mRequesterCredentials = value;
			}
		}

		/// <summary>
		/// Gets or sets the Compatability Level of the API call.
		/// </summary>
		public string Version
		{ 
			get { return mVersion; }
			set { mVersion = value; }
		}

		/// <summary>
		/// Gets or sets the Url to send the API Call to.
		/// </summary>
		public string Url
		{ 
			get { return mUrl; }
			set { mUrl = value; }
		}

		/// <summary>
		/// Gets or sets the Timeout for the API call.
		/// </summary>
		public int Timeout
		{ 
			get { return mTimeout; }
			set { mTimeout = value; }
		}

		/// <summary>
		/// Gets the API Request of type <see cref="string"/>.
		/// </summary>
		public string XmlRequest
		{ 
			get 
			{
				try
				{
					return this.Pretty(mXmlRequestMsg);
				}
				catch(Exception)
				{
					return mXmlRequestMsg;
				}
			}
		}
		/// <summary>
		/// Gets the API Response of type <see cref="string"/>.
		/// </summary>
		public string XmlResponse
		{ 
			get 
			{
				try
				{
					return this.Pretty(mXmlResponseMsg);
				}
				catch(Exception)
				{
					return mXmlResponseMsg;
				}
			}
		}
		#endregion

		#region Private Fields
		private CustomSecurityHeaderType mRequesterCredentials;
		private string mXmlRequestMsg;
		private string mXmlResponseMsg;
		private string mUrl;
		private string mVersion;
		private int mTimeout = 30000;
		#endregion

	}
}

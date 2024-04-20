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
using System.IO;
using System.Xml;
using System.Text;
using System.Net;
using System.Collections;
using System.Xml.Serialization;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;

namespace eBay.Service.EPS
{
	/// <summary>
	/// Class to upload picture with schema xml call.
	/// EpsServerUrl:
	/// for production, use: http://api.ebay.com/ws/api.dll
	/// for sandbox, use: http://api.sandbox.ebay.com/ws/api.dll
	/// </summary>
	public class eBayPictureService
	{
		/// <summary>
		/// 
		/// </summary>
		public eBayPictureService(ApiContext apiContext)
		{
			this.ApiContext = apiContext;
		}

 		/// <summary>
		/// Method to upload one picture to eBay picture server, use this method
		/// if you want to operate on UploadSiteHostedPicture request/response directly
		/// </summary>
		/// <param name="request">UploadSiteHostedPicturesRequestType</param>
		/// <param name="fileName">full path of the picture file</param>
		/// <returns>UploadSiteHostedPicturesResponseType</returns>
		public UploadSiteHostedPicturesResponseType UpLoadSiteHostedPicture(UploadSiteHostedPicturesRequestType request, string fileName) 
		{
            UploadSiteHostedPicturesResponseType respObj = null;
            
            try
			{

				XmlDocument reqDoc = serializeToXmlDoc(request);

				fixEncoding(reqDoc);
			
				addApiCredentials(reqDoc);

				updateElementName(reqDoc, "UploadSiteHostedPicturesRequestType", "UploadSiteHostedPicturesRequest");

				string reqStr = reqDoc.OuterXml;

				string respStr = sendFile(fileName, reqStr);

				XmlDocument respDoc = new XmlDocument();
				respDoc.LoadXml(respStr);
				updateElementName(respDoc, "UploadSiteHostedPicturesResponse", "UploadSiteHostedPicturesResponseType");
			
				respStr = respDoc.OuterXml;

				respObj = (UploadSiteHostedPicturesResponseType)deserializeFromXml(respStr, typeof(UploadSiteHostedPicturesResponseType));

				if (respObj != null && respObj.Errors != null && respObj.Errors.Count > 0)
				{
					throw new ApiException(new ErrorTypeCollection(respObj.Errors));
				}

				return respObj;

			}
			catch(Exception ex)
			{
				ApiException mApiExcetpion = null;

				if (ex is ApiException)
				{
					mApiExcetpion = (ApiException)ex;
				} 
				else
				{
					mApiExcetpion = new ApiException(ex.Message, ex);
				}
				MessageSeverity svr = mApiExcetpion.SeverityErrorCount > 0 ? MessageSeverity.Error : MessageSeverity.Warning;
				LogMessage("EPS Exception : " + mApiExcetpion.Message, MessageType.Exception, svr);
				
				if (mApiExcetpion.SeverityErrorCount > 0)
					throw mApiExcetpion;
			}

			return respObj;
		}

		private void updateElementName(XmlDocument doc, String oldName, String newName) 
		{
			XmlElement oldElement = (XmlElement)doc.GetElementsByTagName(oldName)[0];
			XmlElement newElement = copyElementToName(oldElement, newName);
			doc.ReplaceChild(newElement,oldElement);
		}

		private XmlElement copyElementToName(XmlElement element, string tagName) 
		{
			XmlElement newElement = element.OwnerDocument.CreateElement(tagName);
			for (int i = 0; i < element.Attributes.Count; i++ )
			{
				newElement.SetAttributeNode((XmlAttribute)
					element.Attributes[i].CloneNode(true));

			}
			for (int i = 0; i < element.ChildNodes.Count; i++) 
			{
				newElement.AppendChild(element.ChildNodes[i].CloneNode(true));

			}
			return newElement;

		}

		/// <summary>
		/// Method to upload list of pictures to eBay picture server
		/// </summary>
		/// <param name="photoDisplay">PhotoDisplayCodeType</param>
		/// <param name="pictureFileList">picture file list</param>
		/// <returns>string[]</returns>
        public string[] UpLoadPictureFiles(string[] pictureFileList)
        {
            UploadSiteHostedPicturesRequestType request = new UploadSiteHostedPicturesRequestType();
            ArrayList epsList = new ArrayList();

            foreach (string pictureFile in pictureFileList)
            {
                UploadSiteHostedPicturesResponseType resp = this.UpLoadSiteHostedPicture(request, pictureFile);
                epsList.Add(resp.SiteHostedPictureDetails.FullURL);
            }
            return (string[])epsList.ToArray(typeof(string));

        }

		/// <summary>
		/// Method to upload one picture to eBay picture server
		/// </summary>
		/// <param name="photoDisplay">PhotoDisplayCodeType</param>
		/// <param name="pictureFile">string</param>
		/// <returns>string</returns>
        public string UpLoadPictureFile(string pictureFile)
        {
            string[] piclst = this.UpLoadPictureFiles(new string[] { pictureFile });
            return (string)piclst[0];
        }

 		/// <summary>
		/// Method to add eBay Api Credentials
		/// </summary>
		/// <param name="doc">xml document</param>
		/// <returns>void</returns>
		private void addApiCredentials(XmlDocument doc) 
		{
            XmlElement credElem = null; //= doc.CreateElement("RequesterCredentials", NAMESPACE);
            XmlElement tokenElem = null; //= doc.CreateElement("eBayAuthToken", NAMESPACE);
                                         //Check for UploadSiteHostedPictures.
                                         //Check for oAuth Token
            if (this.ApiContext.ApiCredential.oAuthToken != null && this.ApiContext.ApiCredential.oAuthToken.Length > 0)
            {
                if (this.ApiContext.ApiCredential.eBayToken != null && this.ApiContext.ApiCredential.eBayToken.Length > 0)
                {
                    tokenElem = doc.CreateElement("eBayAuthToken", NAMESPACE);
                    credElem = doc.CreateElement("RequesterCredentials", NAMESPACE);
                    tokenElem.InnerText = this.ApiContext.ApiCredential.eBayToken;
                }
            }
            else if (this.ApiContext.ApiCredential.eBayToken != null && this.ApiContext.ApiCredential.eBayToken.Length > 0)
            {
                tokenElem = doc.CreateElement("eBayAuthToken", NAMESPACE);
                credElem = doc.CreateElement("RequesterCredentials", NAMESPACE);
                tokenElem.InnerText = this.ApiContext.ApiCredential.eBayToken;
            }
            if (credElem != null)
            {
                credElem.AppendChild(tokenElem);

                doc.DocumentElement.InsertBefore(credElem, doc.DocumentElement.FirstChild);
            }
        }
 
 		/// <summary>
		/// Method to fix the encoding of the xml document
		/// </summary>
		/// <param name="doc">xml document</param>
		/// <returns>void</returns>
		private void fixEncoding(XmlDocument doc) 
		{
			if (doc.FirstChild.NodeType == XmlNodeType.XmlDeclaration) 
			{
				XmlDeclaration XmlDec = (XmlDeclaration)doc.FirstChild;
				XmlDec.Encoding = "utf-8";
			}
		}


		/// <summary>
		/// Method to post picture data with HttpWebRequest
		/// </summary>
		/// <param name="fileName">the full path of the picture file to be uploaded</param>
		/// <param name="requestXmlString">request xml string</param>
		/// <returns>response string</returns>
		
		private string sendFile(string fileName, string requestXmlString)
		{
			const string BOUNDARY = "MIME_boundary";
			const string CRLF = "\r\n";
			
			//get HttpWebRequest object
			HttpWebRequest req = (HttpWebRequest) WebRequest.Create(this.ApiContext.EPSServerUrl);
			req.Method = "POST";
			req.ProtocolVersion = HttpVersion.Version11;

            //set proxy server if necessary
            if (this.ApiContext.WebProxy != null)
            {
                req.Proxy = this.ApiContext.WebProxy;
            }

			//set http headers
			req.Headers.Add("X-EBAY-API-COMPATIBILITY-LEVEL", this.ApiContext.Version);    
			req.Headers.Add("X-EBAY-API-SITEID", SiteUtility.GetSiteID(this.ApiContext.Site).ToString());
			req.Headers.Add("X-EBAY-API-DETAIL-LEVEL", X_EBAY_API_DETAIL_LEVEL);
			req.Headers.Add("X-EBAY-API-CALL-NAME", X_EBAY_API_CALL_NAME);
			req.ContentType = "multipart/form-data; boundary=" + BOUNDARY;

            //Check for oAuth - Sree 11/14/2017.
            if (!String.IsNullOrEmpty(this.ApiContext.ApiCredential.oAuthToken))
            {
                req.Headers.Add("X-EBAY-API-IAF-TOKEN", this.ApiContext.ApiCredential.oAuthToken);
            }

            //read in the picture file
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
			fs.Seek(0, SeekOrigin.Begin);
			BinaryReader br = new BinaryReader(fs);
			byte[] image = br.ReadBytes((int)fs.Length);
			br.Close();
			fs.Close();

			//first part of the post body
			string	strReq1= "--" + BOUNDARY + CRLF
				+ "Content-Disposition: form-data; name=document" + CRLF
				+ "Content-Type: text/xml; charset=\"UTF-8\"" + CRLF + CRLF
				+ requestXmlString
				+ CRLF + "--" + BOUNDARY + CRLF
				+ "Content-Disposition: form-data; name=image; filename=image" + CRLF
				+ "Content-Transfer-Encoding: binary" + CRLF
				+ "Content-Type: application/octet-stream" + CRLF + CRLF;
			 
			//last part of the post body
			string strReq2 = CRLF + "--" + BOUNDARY + "--" + CRLF;

			//log request message to eps server
			string reqInfo = "UploadSiteHostedPicturesRequest to " +  this.ApiContext.EPSServerUrl;
			LogMessage(reqInfo, MessageType.Information, MessageSeverity.Informational);
			string reqMsg = Util.XmlUtility.FormatXml(requestXmlString) + CRLF + CRLF;
			reqMsg = System.Text.RegularExpressions.Regex.Replace(reqMsg, "<eBayAuthToken>.+</eBayAuthToken>", "<eBayAuthToken>******</eBayAuthToken>");
			LogMessage(reqMsg, MessageType.ApiMessage, MessageSeverity.Informational);

			//Convert string to byte array
			byte[] postDataBytes1 = System.Text.Encoding.ASCII.GetBytes(strReq1);
			byte[] postDataBytes2 = System.Text.Encoding.ASCII.GetBytes(strReq2);

			int len = postDataBytes1.Length + postDataBytes2.Length + image.Length;
			req.ContentLength= len;

			//post the payload
			Stream requestStream = req.GetRequestStream();
			requestStream.Write(postDataBytes1, 0, postDataBytes1.Length);
			requestStream.Write(image, 0, image.Length);
			requestStream.Write(postDataBytes2, 0, postDataBytes2.Length);
			requestStream.Close();

			//get response and write to console
			HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
			StreamReader responseReader = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);
			string response = responseReader.ReadToEnd();

			//log response message from eps server
			string respInfo = "UploadSiteHostedPicturesResponse from " + this.ApiContext.EPSServerUrl;
			LogMessage(respInfo, MessageType.Information, MessageSeverity.Informational);
			string respMsg = Util.XmlUtility.FormatXml(response) + CRLF + CRLF;
			LogMessage(respMsg, MessageType.ApiMessage, MessageSeverity.Informational);
			resp.Close();

			return response;
		}

		/// <summary>
		/// Log the message information under the specified type and severity.
		/// </summary>
		/// <param name="Message">The content to log of type <see cref="string"/>.</param>
		/// <param name="Type">The type of message to log of type <see cref="MessageType"/>.</param>
		/// <param name="Severity">The severity of the message of type <see cref="MessageSeverity"/>/</param>
		private void LogMessage(string Message, MessageType Type, MessageSeverity Severity)
		{
			if (Message == null || ApiContext == null || ApiContext.ApiLogManager == null || ApiContext.ApiLogManager.ApiLoggerList == null || ApiContext.ApiLogManager.ApiLoggerList.Count == 0)
				return;

			ApiContext.ApiLogManager.RecordMessage(Message, Type, Severity);
		}

		/// <summary>
		/// Method to convert a custom Object to XML Document
		/// </summary>
		/// <param name="obj">Object that is to be serialized to XmlDocument</param>
		/// <returns>XmlDocument</returns>
		private XmlDocument serializeToXmlDoc(object obj)
		{
			XmlSerializer xs = new XmlSerializer(obj.GetType(), NAMESPACE);
			MemoryStream memStream = new MemoryStream();
			xs.Serialize(memStream, obj);
			memStream.Seek(0, System.IO.SeekOrigin.Begin);
			XmlDocument doc = new XmlDocument();
			doc.Load(memStream);
			memStream.Close();
			return doc;
		}

		/// <summary>
		/// Method to reconstruct an Object from XML string
		/// </summary>
		/// <param name="pXmlizedString">xml string to be converted</param>
		/// <param name="type">type of the object</param>
		/// <returns>object</returns>
		private object deserializeFromXml(string pXmlizedString, Type type)
		{
			XmlSerializer xs = new XmlSerializer ( type, NAMESPACE );
			StringReader sReader = new StringReader(pXmlizedString);

			return xs.Deserialize( sReader );

		}

		/// <summary>
		/// Gets or sets the ApiContext of the call of type <see cref="ApiContext"/>. 
		/// </summary>
		public ApiContext ApiContext
		{ 
			get { return mApiContext; }
			set { mApiContext = value; }
		}


		private ApiContext mApiContext = new ApiContext();

		//private const string X_EBAY_API_COMPATIBILITY_LEVEL="515";
		private const string X_EBAY_API_CALL_NAME="UploadSiteHostedPictures";
		private const string X_EBAY_API_DETAIL_LEVEL="0";
		private const string NAMESPACE = "urn:ebay:apis:eBLBaseComponents";

	}
}

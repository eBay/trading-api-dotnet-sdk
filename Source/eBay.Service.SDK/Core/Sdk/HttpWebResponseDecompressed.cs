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
using System.IO.Compression;
using System.Net;

namespace eBay.Service.Core.Sdk
{
	/// <summary>
	/// Summary description for HttpWebResponseDecompressed.
	/// </summary>
	public class HttpWebResponseDecompressed : System.Net.WebResponse
	{
		private HttpWebResponse response;
		private ApiLogManager mLogger = null;

		/// <summary>
		/// 
		/// </summary>
		public ApiLogManager ApiLogManager
		{ 
			get { return mLogger; }
			set { mLogger = value; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="request"></param>
		public HttpWebResponseDecompressed(WebRequest request)
		{
			WebResponse webResponse = null;
			try
			{
				//request.Timeout = timeout;
				webResponse = request.GetResponse();
			}
			catch (WebException e)
			{
				if (e.Response == null)
				{
					throw e;
				}
				webResponse = e.Response;
			}			
			
			//response = (HttpWebResponse)request.GetResponse();
			this.response = (HttpWebResponse)webResponse;
		}

		/// <summary>
		/// 
		/// </summary>
		public HttpWebResponse CastToHttpWebResponse
		{
			get { return response; }
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Close()
		{
			response.Close();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override Stream GetResponseStream()
		{
            Stream responseStream = response.GetResponseStream();

            Stream decompressedStream = null;
            if (response.ContentEncoding.ToLower().Contains("gzip")) {
                decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress);
            }
            //else if (response.ContentEncoding.ToLower().Contains("deflate")) {
            //    decompressedStream = new DeflateStream(responseStream, CompressionMode.Decompress);
            //}

            if (decompressedStream != null)
            {
                // copy to memory stream
                MemoryStream memoryStream = new MemoryStream();
                int size = 2048;
                byte[] buf = new byte[2048];
                while (true)
                {
                    size = decompressedStream.Read(buf, 0, buf.Length);
                    if (size > 0)
                    {
                        memoryStream.Write(buf, 0, size);
                    }
                    else
                    {
                        break;
                    }
                }
                long originalSize = memoryStream.Position;
                memoryStream.Seek(0, SeekOrigin.Begin);

                if (this.mLogger != null)
                {
                    string msg = String.Format("Http Compression - decompressed {0}-encoded response data: CompressedSize={1} OriginalSize={2}",
                        response.ContentEncoding, this.ContentLength, originalSize);
                    this.mLogger.RecordMessage(msg);
                }

                return memoryStream;
            }

            return responseStream;
		}

		/// <summary>
		/// 
		/// </summary>
		public override long ContentLength
		{
			get { return response.ContentLength; }
		}

		/// <summary>
		/// 
		/// </summary>
		public override string ContentType
		{
			get { return response.ContentType; }
		}

		/// <summary>
		/// 
		/// </summary>
		public override System.Net.WebHeaderCollection Headers
		{
			get { return response.Headers; }
		}

		/// <summary>
		/// 
		/// </summary>
		public override System.Uri ResponseUri
		{
			get { return response.ResponseUri; }
		} 	
	}
}

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
using eBay.Service.Core.Soap;

namespace eBay.Service.Core.Sdk
{
	/// <summary>
	/// Enhanced eBayAPIInterfaceService with GZIP compression support.
	/// </summary>
	internal class eBayAPIInterfaceService2 : eBayAPIInterfaceService
	{
		private bool mEnableComression = false;
		private ApiLogManager mLogger = null;
		private CallMetricsEntry mCallMetrics = null;
        private IWebProxy mWebProxy = null;
        private string moAuthToken = null;

        public bool EnableComression
		{
			get { return this.mEnableComression; }
			set { this.mEnableComression = value; }
		}

		public ApiLogManager ApiLogManager
		{ 
			get { return mLogger; }
			set { mLogger = value; }
		}

		public CallMetricsEntry CallMetricsEntry
		{ 
			get { return mCallMetrics; }
			set { mCallMetrics = value; }
		}

        public IWebProxy WebProxy
        {
            get { return mWebProxy; }
            set { mWebProxy = value; }
        }

        //oAuth Implementation.

        public string OAuthToken
        {
            get { return moAuthToken; }
            set { moAuthToken = value; }
        }

        protected override  WebRequest GetWebRequest(Uri uri)
		{
            if (this.mEnableComression)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
                request.ProtocolVersion = HttpVersion.Version11;

                if (!String.IsNullOrEmpty(moAuthToken))
                {
                    request.Headers.Add("X-EBAY-API-IAF-TOKEN", this.OAuthToken);
                }

                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                if (mCallMetrics != null)
                {
                    mCallMetrics.NetworkSendStarted = DateTime.Now;
                    request.Headers.Add("X-EBAY-API-METRICS", "true");
                }
                if (mWebProxy != null)
                {
                    request.Proxy = mWebProxy;
                }
                return request;
            }
            else
            {
                WebRequest request = base.GetWebRequest(uri);

                if (!String.IsNullOrEmpty(OAuthToken))
                {
                    request.Headers.Add("X-EBAY-API-IAF-TOKEN", this.OAuthToken);
                }

                if (mCallMetrics != null)
                {
                    mCallMetrics.NetworkSendStarted = DateTime.Now;
                    request.Headers.Add("X-EBAY-API-METRICS", "true");
                }
                if (mWebProxy != null)
                {
                    request.Proxy = mWebProxy;
                }
                return request;
            }
        }

		protected override WebResponse GetWebResponse(WebRequest request)
		{

			if( this.mEnableComression )
			{
				HttpWebResponseDecompressed response = new HttpWebResponseDecompressed((HttpWebRequest)request);
				if (mCallMetrics != null) 
				{
					mCallMetrics.NetworkReceiveEnded = DateTime.Now;
					mCallMetrics.ServerProcessingTime = convertProcessingTime(response.Headers.Get("X-EBAY-API-PROCESS-TIME"));
				}
				response.ApiLogManager = this.mLogger;
				validate(response.CastToHttpWebResponse.StatusCode);
				return response;
			}
			else 
			{
				HttpWebResponse response = (HttpWebResponse) base.GetWebResponse(request);
				if (mCallMetrics != null)
				{
					mCallMetrics.NetworkReceiveEnded = DateTime.Now;
					mCallMetrics.ServerProcessingTime = convertProcessingTime(response.Headers.Get("X-EBAY-API-PROCESS-TIME"));
				}
				validate(response.StatusCode);
				return response;
			}
		}
		private void validate(HttpStatusCode code) 
		{
			int typecode = (int)code;
			if (typecode >= 300 && typecode <= 599 && typecode != 500)
				throw new HttpException(typecode);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		private long convertProcessingTime(String val) 
		{
			if (val == null)
				return 0;
			long retval = 0;
			try 
			{
				retval = (long) (float.Parse(val));
			} 
			catch (Exception) 
			{
			}
			return retval;
		}


	}
}

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
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;

namespace GetItemTester 
{

	public class eBayApi 
	{

		#region private fields
		
		private static string sSoapApiUrl = LoadAppConfig("soapurl");
		private static Form1 app;
		private static string token;
		private static ApiContext ctx;
		private static Mutex mCtx = new Mutex();
		private static CallRetry retry;
		private static Mutex mRetry = new Mutex();
		private static ApiLogger logger;

		#endregion

		#region constructor

		private eBayApi() {}

		#endregion

		#region static public method

		public static void Init(Form1 app, string token, ApiLogger logger) 
		{
			eBayApi.app = app;
			eBayApi.token = token;
			eBayApi.logger = logger;
		}

        public static void RampUp()
        {
            try
            {
                ApiContext ctx = GetContext();
                GeteBayOfficialTimeCall call = new GeteBayOfficialTimeCall(ctx);
                call.Site = SiteCodeType.US;
                call.Execute();
            }
            catch (Exception e)
            {
                ShowException("GeteBayOfficialTimeCall()", e);
            }
        }

		/// <summary>
		/// add an item
		/// </summary>
		/// <returns></returns>
		public static string AddItem(CallMetricsTable metrics)
		{
			try 
			{
				ApiContext ctx = GetContext();
				ctx.EnableMetrics = true;
				ctx.CallMetricsTable = metrics;
				AddItemCall call = new AddItemCall(ctx);
				call.Site = SiteCodeType.US;
				call.Item=ItemHelper.BuildItem();
				call.Execute();


				return CheckForErrors("AddItem", call) ?
				call.ApiResponse.ItemID : null;
			}
			catch (Exception e) 
			{
				ShowException("AddItem()", e);
				return null;
			}
		}

		/// <summary>
		/// get an item
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="metrics"></param>
		/// <returns></returns>
		public static ItemType GetItem(string itemId, CallMetricsTable metrics) 
		{
			Debug.Assert(itemId != null);
			Debug.Assert(itemId.Length > 0);

			try 
			{
				ApiContext ctx = GetContext();
				ctx.EnableMetrics = true;
				ctx.CallMetricsTable = metrics;
				GetItemCall call = new GetItemCall(ctx);
				call.Site = SiteCodeType.US;

				ItemType item = call.GetItem(itemId);
				return CheckForErrors("GetItem", call) ? item : null;
			}
			catch (Exception e) {
				ShowException("GetItem(" + itemId + ")", e);
				return null;
			}
		}

		/// <summary>
		/// revise an item
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="metrics"></param>
		public static void ReviseItem(ItemType item, CallMetricsTable metrics) 
		{
			Debug.Assert(item != null);
			Debug.Assert(item.ItemID != null);
			Debug.Assert(item.ItemID.Length > 0);
			
			try
			{
				ApiContext ctx = GetContext();
				ctx.EnableMetrics = true;
				ctx.CallMetricsTable = metrics;
				ReviseItemCall call = new ReviseItemCall(ctx);
				call.Site = SiteCodeType.US;
				ItemType itemToBeRevised = new ItemType();
				itemToBeRevised.ItemID = item.ItemID;
				call.Item=itemToBeRevised;
				itemToBeRevised.Description="Item has been modified!";

				call.Execute();

			}
			catch (Exception e) 
			{
				if(item==null)
				{
					ShowException("ReviseItem(null)", e);
				}
				else
				{
					ShowException("ReviseItem(" + item.ItemID + ")", e);
				}
			}
		}

		/// <summary>
		/// get context
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public static ApiContext GetContext(string token) 
		{
			ApiContext ctx = new ApiContext();

			ctx.SoapApiServerUrl = sSoapApiUrl;
			ctx.ApiCredential.eBayToken = token;
			ctx.Site = SiteCodeType.US;
			ctx.CallRetry = GetCallRetry();
			ctx.Timeout = 60000;
			
			ApiLogManager logManager = new ApiLogManager();
			logManager.EnableLogging = true;
			logManager.ApiLoggerList.Add(logger);
			logManager.ApiLoggerList[0].LogApiMessages = true;
			logManager.ApiLoggerList[0].LogExceptions = true;
			logManager.ApiLoggerList[0].LogInformations = true;
			ctx.ApiLogManager = logManager;

			return ctx;
		}

		#endregion

		#region private static method

		private static ApiContext GetContext() 
		{
			if (ctx != null)
				return ctx;

			Debug.Assert(token.Length > 0);

			try {
				mCtx.WaitOne();
				if (ctx != null)
					return ctx;

				ctx = GetContext(token);
				return ctx;
			}
			finally {
				mCtx.ReleaseMutex();
			}
		}

		
		private static CallRetry GetCallRetry() 
		{
			if (retry != null)
				return retry;

			try {
				mRetry.WaitOne();
				if (retry != null)
					return retry;

				retry = new CallRetry();
				retry.DelayTime = 1000;		// 1 second
				retry.MaximumRetries = 2;
				// retry.TriggerErrorCodes
				// retry.TriggerExceptions
				return retry;
			}
			finally {
				mRetry.ReleaseMutex();
			}
		}

		private static bool CheckForErrors(string function, ApiCall call) {
            // Warning out to not get Schema Out Of Date messages
			if (call.HasError /*|| call.HasWarning */) {
				ApiException exc = call.ApiException;
				Debug.Assert(exc != null);
				StringBuilder sb = new StringBuilder(function);
				sb.Append(":\n");
				foreach (ErrorType err in exc.Errors) {
					sb.AppendFormat("message: {0}, details: {1}\n",
						err.ShortMessage, err.LongMessage);
				}

				ShowMessage(sb.ToString());
			}

			return ! call.HasError;
		}

		private static void ShowException(string function, Exception e) {
			StringBuilder sbInfo = new StringBuilder();
			if (e is ApiException) {
				ApiException exc = e as ApiException;
				foreach (ErrorType err in exc.Errors) {
					sbInfo.AppendFormat("message: {0}, details: {1}\n",
						err.ShortMessage, err.LongMessage);
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0}: caught {1}\n", function,
				e.GetType().ToString());
			if (sbInfo.Length > 0)
				sb.AppendFormat("Info: {0}", sbInfo.ToString());
			sb.AppendFormat("Exception: {0}\n", e.ToString());
			/*
			if (e.InnerException != null)
				sb.AppendFormat("InnerException: {0}",
					e.InnerException.ToString());
			*/
			ShowMessage(sb.ToString());
		}

		
		private static string LoadAppConfig(string key)
		{
			return ConfigurationManager.AppSettings.Get(key);
		}

		public static void log(string msg)
		{
			logger.RecordMessage(msg, MessageSeverity.Informational);
		}
		
		private static void ShowMessage(string msg) 
		{
			log(msg);
		}

		#endregion

		#region delegate

		private delegate void ShowMessageDelegate(string msg);

		#endregion

	}
}

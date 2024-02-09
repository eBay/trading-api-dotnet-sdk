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
#endregion

using eBay.Service.Util;

namespace eBay.Service.Core.Sdk
{

	/// <summary>
	/// You use <see cref="CallMetricsTable"/> with the <see cref="ApiContext"/> object if you want to log all 
    /// API calls. Alternatively, you could use <see cref="CallMetricsEntry"/> to simply log specific calls. To do this, you 
    /// would create your API call wrapper object (for example, <see cref="eBay.Service.Call.GetUserCall"/>) then set its 
    /// CallMetricsEntry property to an instance of the CallMetricsEntry object. Execute the call and then invoke 
    /// <see cref="GenerateReport"/> on the call wrapper's CallMetricsEntry property.
	/// </summary>
    /// <example>
    /// The following snippet shows how to set up the use of the CallMetricsEntry:
    /// <code>
    ///GetUserCall apiCall = new GetUserCall(apiContext);
    ///apiCall.CallMetricsEntry = new CallMetricsEntry();
    ///apiCall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
    ///apiCall.Execute();
    ///piLogger MyLog = new FileLogger("entry_log.txt", true, true, true);
    ///apiCall.CallMetricsEntry.GenerateReport(MyLog);
    /// </code>
    /// </example>
	public class CallMetricsEntry
	{

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public CallMetricsEntry() 
		{
		}


		/// <summary>
		/// Initialize and set API call name on the entry so that it is ready to accumulate metrics..
		/// </summary>
		public CallMetricsEntry(string callname) 
		{
			Initialize(callname);
		}
		#endregion

		#region Properties
		/// <summary>
		/// The time at which the ApiCall object began setting up and issuing the call (beginning of SendRequest()).
		/// </summary>
		public System.DateTime ApiCallStarted
		{
			get { return mApiCallStarted; }
			set { mApiCallStarted = value; }
		}

		/// <summary>
		/// The time at which the ApiCall object finished issuing the call (end of SendRequest()).
		/// </summary>
		public System.DateTime ApiCallEnded
		{
			get { return mApiCallEnded; }
			set { mApiCallEnded = value; }
		}

		/// <summary>
		/// The time at which the serialized request message bgan to be sent over the network.
		/// </summary>
		public System.DateTime NetworkSendStarted
		{
			get { return mNetworkSendStarted; }
			set { mNetworkSendStarted = value; }
		}

		/// <summary>
		/// The time at which a response message was received from the network and became ready to deserialize.
		/// </summary>
		public System.DateTime NetworkReceiveEnded
		{
			get { return mNetworkReceiveEnded; }
			set { mNetworkReceiveEnded = value; }
		}

		/// <summary>
		/// The server-side processing time reported by the eBay server.
		/// </summary>
		public long ServerProcessingTime
		{
			get { return mServerProcessingTime; }
			set { mServerProcessingTime = value; }
		}

		/// <summary>
		/// The name of the call currently being tracked.
		/// </summary>
		public string CallName
		{
			get { return mCallName; }
			set { mCallName = value; }
		}

		/// <summary>
		/// Reference to the logger to be used for recording data.
		/// </summary>
		public static ApiLogger logger
		{
			get { return sLogger; }
			set { sLogger = value; }
		}
		/// <summary>
		/// Total time spent in ApiCall processing (ApiCallEnded - ApiCallStarted).
		/// </summary>
		public long TurnaroundTime
		{
			get { return GetTimeInterval(ApiCallStarted, ApiCallEnded); }
		}

		/// <summary>
		/// Time spent in setup, serialization, and/or compression before sending the request (NetworkSendStarted - ApiCallStarted).
		/// </summary>
		public long CallInitTime
		{
			get { return GetTimeInterval(ApiCallStarted, NetworkSendStarted); }
		}

		/// <summary>
		/// Time spent between send and receive, equal to the combination of transmission and server processing time 
		/// (NetworkReceiveEnded - NetworkSendStarted).
		/// </summary>
		public long NetworkAndServerTime
		{
			get { return GetTimeInterval(NetworkSendStarted, NetworkReceiveEnded); }
		}

		/// <summary>
		/// Time spent in decompression, deserialization, and final processing, after receiving the response (ApiCallEnded - NetworkReceiveEnded).
		/// </summary>
		public long CallFinishTime
		{
			get { return GetTimeInterval(NetworkReceiveEnded, ApiCallEnded); }
		}
	
		/// <summary>
		/// 
		/// </summary>
		public long NetworkTime
		{
			get { return NetworkAndServerTime - ServerProcessingTime; }
		}



		#endregion

		private long GetTimeInterval(System.DateTime start, System.DateTime end)
		{
			if (start.Equals(System.DateTime.MinValue) || end.Equals(System.DateTime.MinValue))
				return -1;
			System.TimeSpan diff = end - start;
			return (long) diff.TotalMilliseconds;
		}
	
		/// <summary>
		/// Generates the call metrics information about the API call that was made.
		/// </summary>
		public void GenerateReport(ApiLogger logger)
		{
//			logger.RecordMessage(FormatMsec(mApiCallStarted) +
//				FormatMsec(mNetworkSendStarted) +
//				FormatNumber(ServerProcessingTime > 0? ServerProcessingTime: -1) +
//				FormatMsec(mNetworkReceiveEnded) +
//				FormatMsec(mApiCallEnded) +
//				FormatString(ApiCallStarted.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"), 25),
//				MessageSeverity.Informational);
			logger.RecordMessage(FormatNumber(TurnaroundTime) +
				FormatNumber(CallInitTime) +
				FormatNumber(NetworkTime) +
				FormatNumber(ServerProcessingTime > 0? ServerProcessingTime: -1) +
				FormatNumber(CallFinishTime) +
				FormatString(ApiCallStarted.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'.'fff"), 25),
				MessageSeverity.Informational);
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="totals"></param>
		public void UpdateTotals(long[] totals)
		{
			totals[0] += TurnaroundTime;
			totals[1] += CallInitTime;
			totals[2] += NetworkTime;
			totals[3] += ServerProcessingTime;
			totals[4] += CallFinishTime;
		}

		/// <summary>
		/// 
		/// </summary>
		public void Initialize(string name)
		{
			CallName = name;
			mApiCallStarted = System.DateTime.MinValue;
			mNetworkSendStarted = System.DateTime.MinValue;
			mNetworkReceiveEnded = System.DateTime.MinValue;
			mApiCallEnded = System.DateTime.MinValue;
			mServerProcessingTime = 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="n"></param>
		public static string FormatNumber(long n)
		{
			string str;
			if (n == -1)
				str = "N/A";
			else
				str = n.ToString();
			str += SPACES.Substring(0, 10-str.Length);
			return str;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <param name="width"></param>
		public static string FormatString(string str, int width)
		{
			string str2 = str += SPACES.Substring(0, width-str.Length);
			return str2;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static string FormatMsec(System.DateTime d)
		{
			string str = d.ToString("ssfff");
			return FormatString(str, 10);
		}

		#region Private Fields
		private System.DateTime mApiCallStarted;
		private System.DateTime mNetworkSendStarted;
		private System.DateTime mNetworkReceiveEnded;
		private System.DateTime mApiCallEnded;
		private long mServerProcessingTime;
		private string mCallName;
		private static ApiLogger sLogger;
		private static string SPACES = "                                   ";
		#endregion

	}
}

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
using System.Diagnostics;
using System.Collections;
using System.Collections.Specialized;
using System.Threading;
using System.Configuration;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
using System.Windows.Forms;


namespace GetItemTester
{
	/// <summary>
	/// Summary description for ItemFetcher.
	/// </summary>
	public class ItemFetcher
	{
		#region private fields

		private Form1 app;
		private System.Collections.Specialized.StringCollection itemIDs;
		private int indexItemIDs = 0;
		private Mutex mItemIDs = new Mutex();
		private int numThreads;
		private int numCallsPerThread;
		private int numCalls;
		private string token;
		private ArrayList threads = new ArrayList();
		private bool stop = false;
		private static ApiLogger logger = new FileLogger(ConfigurationSettings.AppSettings.Get("logfile"));
		private CallMetricsTable mMetrics = new CallMetricsTable();
		private TextBox txtLogger;
        private bool rampUp = false;
		//this delegate enables asynchronous call for setting
		//the message to the textBox on the form
		private delegate void setMessageCallBack(string message);

		#endregion

		#region constructor

		/// <summary>
		/// 
		/// </summary>
		/// <param name="app"></param>
		/// <param name="txtLogger">a TextBox show message</param>
		/// <param name="numThreads">specify how many threads to be tested</param>
		/// <param name="numCalls">specify how many methods will be called for each thread</param>
		/// <param name="token"></param>
		public ItemFetcher(Form1 app, TextBox txtLogger ,int numThreads,int numCalls, string token, bool rampUp) 
		{
			this.app = app;
			this.numThreads = numThreads;
			this.numCallsPerThread = numCalls;
			this.numCalls = numCallsPerThread * numThreads;//total calls
			this.token = token;
			this.txtLogger=txtLogger;
            this.rampUp = rampUp;

			eBayApi.Init(app, token, logger);
			eBayApi.log("total calls: " + this.numCalls);

			for (int i = 0; i < numThreads; i++) 
			{
				//specify the handler to the thread
				ThreadStart ts = new ThreadStart(entryHandler);

				Thread thread = new Thread(ts);
				thread.Name = i.ToString();
				threads.Add(thread);
			}
		}

		#endregion

		#region Event

		public delegate void FetchCompleteDelegate(object sender, EventArgs e);

		public event FetchCompleteDelegate FetchCompleteEvent;

		#endregion

		#region public method

		/// <summary>
		/// all threads start executing 
		/// </summary>
		public void Start() 
		{
			foreach (Thread thread in threads) 
			{
				thread.Start();
			}
		}

		/// <summary>
		/// all threads stop executing
		/// </summary>
		public void Stop() 
		{
			stop = true;
			foreach (Thread thread in threads) 
			{
				if (thread.IsAlive)
					thread.Join(5000);
			}
		}

		#endregion

		#region private method

		/// <summary>
		/// entry handler for the thread
		/// </summary>
		private void entryHandler() 
		{
			string itemID;
			ItemType item=null;
			string threadname = Thread.CurrentThread.Name;

            if (this.rampUp)
            {
                eBayApi.RampUp();
            }


			for(int i = 0; i< this.numCallsPerThread; i++)
			{
				if(this.stop)
				{
					break;
				}
				//add an item and log all processing message
				string message=String.Format("Thread: {0} ,Begin adding an item...", threadname);
				logMessage(message);
				itemID=eBayApi.AddItem(mMetrics);
				if(itemID!=null&&itemID!=string.Empty)
				{
					message=String.Format("Thread: {0} ,Add item success: {1}", threadname, itemID.ToString());
				}
				else
				{
					message=String.Format("Thread: {0} ,Add item failure.", threadname);
				}
				logMessage(message);
			
				//get an item and log all processing message
				if(itemID!=null&&itemID!=string.Empty)
				{
					item=eBayApi.GetItem(itemID, mMetrics);
					message=String.Format("Thread: {0} ,Get an item success: {1}", threadname, itemID.ToString());
				}
				else
				{
					message=String.Format("Thread: {0} ,Get an item failure.", threadname);
				}
				logMessage(message);

				//revise an item and log all processing message
				if(itemID!=null&&itemID!=string.Empty)
				{
					eBayApi.ReviseItem(item, mMetrics);
					item=null;
					message=String.Format("Thread: {0} ,Revise an item success: {1}", threadname, itemID.ToString());
				}
				else
				{
					message=String.Format("Thread: {0} ,Revise an item failure.", threadname);
				}
				logMessage(message);
                string fmsg = String.Format("Thread: {0} finished.", threadname);
                logMessage(fmsg);

				if (Interlocked.Decrement(ref numCalls) == 0) 
				{
					mMetrics.GenerateReport(logger);
					if (FetchCompleteEvent != null)
						FetchCompleteEvent(this, new EventArgs());
				}
			}//close for loop
			
		}//close GetItemHandler method


		private string FetchItemID() 
		{
			try 
			{
				mItemIDs.WaitOne();
				if (itemIDs.Count == 0)
					return null;

				if (indexItemIDs >= itemIDs.Count)
					indexItemIDs = 0;		// wraparound

				return (string) itemIDs[indexItemIDs++];
			}
			finally 
			{
				mItemIDs.ReleaseMutex();
			}
		}//close FetchItemID method

		/// <summary>
		/// log message
		/// </summary>
		/// <param name="message"></param>
		private void logMessage(string message)
		{
            if (txtLogger.InvokeRequired)
            {
                //it is on the different thread, so use the Invoke method
                setMessageCallBack d = new setMessageCallBack(logMessageCallBack);
                app.Invoke(d, new object[] { message });
            }
            else
            {
                logMessageCallBack(message);
            }
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		private void logMessageCallBack(string message)
		{
			string msg=String.Format("{0}\t{1}",DateTime.Now.ToString(),message);
			eBayApi.log(String.Format("{0}{1}",msg,System.Environment.NewLine));

			txtLogger.Text=String.Format("{0}{1}{2}",msg,System.Environment.NewLine,txtLogger.Text);
		}

		#endregion

	}
}

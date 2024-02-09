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
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace GetItemTester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		#region control fields

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.NumericUpDown udNumThreads;
		private System.Windows.Forms.NumericUpDown udNumCalls;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbID;
		private System.Windows.Forms.TextBox txtLogger;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		#endregion
        private Button button1;
        private CheckBox rampUpCheckBox;

		#region private fields
		
		private ItemFetcher fetcher;

		#endregion

		#region private properties

		/// <summary>
		/// specify how many threads will be tested
		/// </summary>
		private int NumThreads 
		{
			get { return (int) udNumThreads.Value; }
		}

		/// <summary>
		/// 
		/// </summary>
		private int NumCalls 
		{
			get { return (int) udNumCalls.Value; }
		}

		/// <summary>
		/// specify eBay Token
		/// </summary>
		private string eBayToken 
		{
			get { return tbID.Text.Trim(); }
		}

		#endregion

		#region dispose method

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.rampUpCheckBox = new System.Windows.Forms.CheckBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.udNumCalls = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.udNumThreads = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtLogger = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udNumCalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udNumThreads)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rampUpCheckBox);
            this.panel1.Controls.Add(this.tbID);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.udNumCalls);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.udNumThreads);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 104);
            this.panel1.TabIndex = 0;
            // 
            // rampUpCheckBox
            // 
            this.rampUpCheckBox.AutoSize = true;
            this.rampUpCheckBox.Location = new System.Drawing.Point(96, 84);
            this.rampUpCheckBox.Name = "rampUpCheckBox";
            this.rampUpCheckBox.Size = new System.Drawing.Size(68, 17);
            this.rampUpCheckBox.TabIndex = 4;
            this.rampUpCheckBox.Text = "RampUp";
            this.rampUpCheckBox.UseVisualStyleBackColor = true;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(328, 16);
            this.tbID.Multiline = true;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(224, 72);
            this.tbID.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(264, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "eBay token:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(200, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "(1-50)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udNumCalls
            // 
            this.udNumCalls.Location = new System.Drawing.Point(96, 48);
            this.udNumCalls.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udNumCalls.Name = "udNumCalls";
            this.udNumCalls.Size = new System.Drawing.Size(96, 20);
            this.udNumCalls.TabIndex = 2;
            this.udNumCalls.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Num Calls:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // udNumThreads
            // 
            this.udNumThreads.Location = new System.Drawing.Point(96, 16);
            this.udNumThreads.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.udNumThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udNumThreads.Name = "udNumThreads";
            this.udNumThreads.Size = new System.Drawing.Size(96, 20);
            this.udNumThreads.TabIndex = 1;
            this.udNumThreads.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Num Threads:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(200, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "(1-100)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnStop);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 40);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(465, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(104, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtLogger);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 104);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(560, 254);
            this.panel3.TabIndex = 2;
            // 
            // txtLogger
            // 
            this.txtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogger.Location = new System.Drawing.Point(5, 5);
            this.txtLogger.Multiline = true;
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogger.Size = new System.Drawing.Size(550, 244);
            this.txtLogger.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 398);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetItem Tester";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udNumCalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udNumThreads)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region logic flow

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            this.tbID.Text = ConfigurationManager.AppSettings.Get("token");

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.Closing += new CancelEventHandler(Form1_Closing);
		}

		/// <summary>
		/// while the form is closing, stop all threads to execute
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Closing(object sender, CancelEventArgs e) 
		{
			btnStop_Click(sender, e);
		}

		private void btnStop_Click(object sender, System.EventArgs e) 
		{
			if (fetcher == null)
				return;
			btnStop.Enabled = false;
			fetcher.Stop();
			fetcher = null;
			btnStart.Enabled = true;
		}

		private void btnStart_Click(object sender, System.EventArgs e) 
		{
			if (fetcher != null)
				return;

			string token = eBayToken;
			if (token.Length == 0) 
			{
				MessageBox.Show("Please enter your eBay token.");
				return;
			}

			btnStart.Enabled = false;

			fetcher = new ItemFetcher(this, txtLogger, NumThreads, NumCalls, token, this.rampUpCheckBox.Checked);
			fetcher.FetchCompleteEvent += new GetItemTester.ItemFetcher.FetchCompleteDelegate(fetcher_FetchCompleteEvent);
			fetcher.Start();

			btnStop.Enabled = true;
		}

		private void fetcher_FetchCompleteEvent(object sender, EventArgs e) {
            if (btnStop.InvokeRequired)
            {
                SetButtonCallBack d = new SetButtonCallBack(SetButtonEnabled);
                this.Invoke(d, new object[] { btnStop, false });
            }
            else
            {
                btnStop.Enabled = false;

            }

			fetcher = null;

            if (btnStart.InvokeRequired)
            {
                SetButtonCallBack d = new SetButtonCallBack(SetButtonEnabled);
                this.Invoke(d, new object[] { btnStart, true });
            }
            else
            {
                btnStart.Enabled = true;
            }
		}

        private delegate void SetButtonCallBack(Button button, bool enabled);

        private void SetButtonEnabled(Button button, bool enabled)
        {
            button.Enabled = enabled;
        }

		#endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.txtLogger.Text = "";
        }
	}
}

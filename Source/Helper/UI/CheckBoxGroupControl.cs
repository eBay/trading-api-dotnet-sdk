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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Samples.Helper.UI
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class CheckBoxGroupControl : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private Panel panel;
		private CheckBox[] checkBoxes = null;
		int xOffset = 15;
		int yOffset = 15;
		int height = 35;
		int widthFactor = 5;

		/// <summary>
		/// 
		/// </summary>
		public int WidthFactor
		{
			set {this.widthFactor = value;}
			get {return this.widthFactor;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int XOffset 
		{
			set {this.xOffset = value;}
			get {return this.xOffset;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int YOffset 
		{
			set {this.yOffset = value;}
			get {return this.yOffset;}
		}

		/// <summary>
		/// 
		/// </summary>
		public int ItemHeight 
		{
			set {this.height = value;}
			get {return this.height;}
		}

		/// <summary>
		/// 
		/// </summary>
		public CheckBox[] CheckBoxes
		{
			get {return this.checkBoxes;}
		}
		
		/// <summary>
		/// 
		/// </summary>
		public ArrayList CheckedCheckBoxes
		{
			get {
				ArrayList list = new ArrayList();
				int len = this.checkBoxes.Length;
				for (int i = 0; i < len; i++) 
				{
					if (this.checkBoxes[i].Checked) 
					{
						list.Add(this.checkBoxes[i]);
					}
				}
				return list;
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		public CheckBoxGroupControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();			
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="names"></param>
		public void SetCheckBoxControls(string [] names)
		{
			Rectangle rect = this.DisplayRectangle;
			this.panel = new Panel();
			this.panel.Size = new System.Drawing.Size(rect.Width, rect.Height);
			this.Controls.Add(panel);
			this.checkBoxes = CheckBoxControlBuilder.CreateCheckBoxControls(this.panel, names, this.xOffset, this.yOffset, this.height, this.widthFactor);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public void SetCheckBoxControls(ControlTagItem[] items)
		{
			Rectangle rect = this.DisplayRectangle;
			this.panel = new Panel();
			this.panel.Size = new System.Drawing.Size(rect.Width, rect.Height);
			this.Controls.Add(panel);
			this.checkBoxes = CheckBoxControlBuilder.CreateCheckBoxControls(this.panel, items, this.xOffset, this.yOffset, this.height, this.widthFactor);
		}
	}
}

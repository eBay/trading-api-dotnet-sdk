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
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using eBay.Service.Core.Soap;
using eBay.Service.Util;

namespace Samples.Helper.UI
{
	/// <summary>
	/// Summary description for ShippingServiceListView.
	/// </summary>
	public class ShippingServiceListView : EditListView
	{
		/// <summary>
		/// 
		/// </summary>
		protected ComboBox cmbBox = new System.Windows.Forms.ComboBox();

		private string comboColumnName = "Shipping Service";
		private string [] strOptions;
		private ControlTagItem [] tagItemOptions;

		/// <summary>
		/// 
		/// </summary>
		public string ComboBoxColumnName 
		{
			set {this.comboColumnName = value;}
		}

		private HeaderInfo[] GetDefaultHeaderInfo()
		{
			HeaderInfo[] headerInfos = new HeaderInfo[3];
			headerInfos[0].name = "Shipping Service";
			headerInfos[0].width = 300;
			headerInfos[1].name = "Shipping Cost";
			headerInfos[1].width = 200;
			headerInfos[2].name = "Additional Cost";
			headerInfos[2].width = 200;
			return headerInfos;
		}

		/// <summary>
		/// 
		/// </summary>
		public string [] StringOptions 
		{
			set {this.strOptions = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public ControlTagItem [] TagItemOptions 
		{
			set {this.tagItemOptions = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public ShippingServiceListView()
		{
		}

		/// <summary>
		/// This method must be called to iniitialize the ListView.
		/// </summary>
		/// <param name="headerInfos"></param>
		override public void Initialize(HeaderInfo[] headerInfos)
		{
			if (headerInfos == null) 
			{
				headerInfos = GetDefaultHeaderInfo();
			}

			base.Initialize(headerInfos);
			InitComboBox();
			SetComboBoxOptions();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="headerInfos"></param>
		override protected void InitListView(HeaderInfo[] headerInfos)
		{
			base.InitListView(headerInfos);

			string[] s = {"", "", ""};
			this.Items.Add(new ListViewItem(s));
			this.Items.Add(new ListViewItem(s));
			this.Items.Add( new ListViewItem(s));
		}

		/// <summary>
		/// 
		/// </summary>
		public string ComboColumnName 
		{
			get {return this.comboColumnName;}
		}

		private void CmbKeyPress(object sender , System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( e.KeyChar == 13 || e.KeyChar == 27 )
			{
				this.cmbBox.Hide();
			}
		}

		private void CmbSelected(object sender , System.EventArgs e)
		{
			int sel = cmbBox.SelectedIndex;
			if ( sel >= 0 )
			{
				string itemSel = this.cmbBox.Items[sel].ToString();
				this.ListViewItemSelected.SubItems[this.SubItemSelectedIndex].Text = itemSel;
			}
		}

		private void CmbFocusOver(object sender , System.EventArgs e)
		{
			this.cmbBox.Hide() ;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public virtual ICollection GetShippingServiceOptions()
		{
			ShippingServiceOptionsTypeCollection ssos = new ShippingServiceOptionsTypeCollection();

			int row = this.Items.Count;
			int col = this.Items[0].SubItems.Count;

			int cnt = 0;
			for (int i = 0; i < row; i++) 
			{
				ListViewItem lvi = this.Items[i];
				//ShippingService
				string text = lvi.SubItems[0].Text;
				if (text.Length > 0) 
				{
					if (!text.Equals("NotSelected"))
					{
						cnt++;
						ShippingServiceOptionsType sso = new ShippingServiceOptionsType();
						sso.ShippingService = text;
						sso.ShippingServicePriority = cnt;
						ssos.Add(sso);
						if (col > 1) 
						{
							// ShippingServiceCost
							text = lvi.SubItems[1].Text;
							if (text.Length > 0) 
							{
								sso.ShippingServiceCost = CurrencyUtility.GetAmountType(text);
							}
							// ShippingServiceAdditioanlCost
							text = lvi.SubItems[2].Text;
							if (text.Length > 0) 
							{
								sso.ShippingServiceAdditionalCost = CurrencyUtility.GetAmountType(text);							
							}
						}
					}
				}
			}
			return ssos;
		}

		private void InitComboBox()
		{
			this.cmbBox.Size  = new System.Drawing.Size(0,0);
			this.cmbBox.Location = new System.Drawing.Point(0,0);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmbBox});			
			this.cmbBox.SelectedIndexChanged += new System.EventHandler(this.CmbSelected);
			this.cmbBox.LostFocus += new System.EventHandler(this.CmbFocusOver);
			this.cmbBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbKeyPress);
			this.cmbBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmbBox.BackColor = Color.LightYellow; 
			this.cmbBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.cmbBox.Hide();
		}

		/// <summary>
		/// 
		/// </summary>
		public void SetComboBoxOptions()
		{
			if (this.strOptions != null) 
			{
				this.cmbBox.Items.AddRange(this.strOptions);
			}
			else if (this.tagItemOptions != null) 
			{
				this.cmbBox.Items.AddRange(this.tagItemOptions);
			}
		}
	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="options"></param>
		public void SetComboBoxOptions(ControlTagItem[] options)
		{
			this.cmbBox.Items.AddRange(options);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="action"></param>
		/// <param name="spos"></param>
		/// <param name="epos"></param>
		override protected void ProcessDoubleClick(string action, int spos, int epos)
		{
			if (action == this.ComboColumnName) 
			{
				Rectangle r = new Rectangle(spos , this.ListViewItemSelected.Bounds.Y , epos , this.ListViewItemSelected.Bounds.Bottom);
				this.cmbBox.Size  = new System.Drawing.Size(epos - spos , this.ListViewItemSelected.Bounds.Bottom-this.ListViewItemSelected.Bounds.Top);
				this.cmbBox.Location = new System.Drawing.Point(spos , this.ListViewItemSelected.Bounds.Y);
				this.cmbBox.Show() ;
				this.cmbBox.Text = this.SubItemSelectedText;
				this.cmbBox.SelectAll() ;
				this.cmbBox.Focus();
			}
			else
			{
				base.ProcessDoubleClick(action, spos, epos);
			}
		}

		
	}
}

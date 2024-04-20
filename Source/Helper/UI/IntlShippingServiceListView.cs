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
	public class IntlShippingServiceListView : ShippingServiceListView
	{
		private string [] shipToLocations;
		private ControlTagItem[] shipToLocationControlTagItems;

		/// <summary>
		/// 
		/// </summary>
		protected ListBox  listBox = new System.Windows.Forms.ListBox();

		/// <summary>
		/// 
		/// </summary>
		public string [] ShipToLocations 
		{
			set {this.shipToLocations = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public ControlTagItem [] ShipToLocationControlTagItems 
		{
			set {this.shipToLocationControlTagItems = value;}
		}

		/// <summary>
		/// 
		/// </summary>
		public IntlShippingServiceListView()
		{
		}

		private HeaderInfo[] GetDefaultHeaderInfo()
		{
			HeaderInfo[] headerInfos = new HeaderInfo[5];
			headerInfos[0].name = "Shipping Service";
			headerInfos[0].width = 260;
			headerInfos[1].name = "Shipping Cost";
			headerInfos[1].width = 100;
			headerInfos[2].name = "Additional Cost";
			headerInfos[2].width = 110;
			headerInfos[3].name = "Ship To Locations";
			headerInfos[3].width = 120;
			headerInfos[4].name = "Import Charge";
			headerInfos[4].width = 100;
			return headerInfos;
		}

		/// <summary>
		/// This method must be called to iniitialize the ListView.
		/// </summary>
		/// <param name="headerInfos"></param>
		override public void Initialize(HeaderInfo[] headerInfos)
		{
			if (headerInfos == null) 
			{
				headerInfos = this.GetDefaultHeaderInfo();
			}
			base.Initialize(headerInfos);
			InitListBox();
			SetListBoxOptions();
		}

		private void InitListBox()
		{
			this.listBox.Size  = new System.Drawing.Size(0,0);
			this.listBox.Location = new System.Drawing.Point(0,0);
			this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.listBox});			
			this.listBox.Name = "listBox";

			this.listBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ListBoxOver);
			this.listBox.LostFocus += new System.EventHandler(this.ListBoxFocusOver);

			this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listBox.BackColor = Color.LightYellow; 
			this.listBox.BorderStyle = BorderStyle.Fixed3D;

			this.listBox.ScrollAlwaysVisible = true;

			this.listBox.Hide();
		}

		void SetListBoxOptions()
		{
			if (this.shipToLocations != null)
			{
				this.listBox.Items.AddRange(this.shipToLocations);
			}
			else if (this.shipToLocationControlTagItems != null) 
			{
				this.listBox.Items.AddRange(this.shipToLocationControlTagItems);
			}

			//for (int i = 0; i < options.Length; i++) 
			//{
			//	this.listBox.Items.Add(options[i]);	
			//}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="headerInfos"></param>
		override protected void InitListView(HeaderInfo[] headerInfos)
		{
			InitHeaderInfo(headerInfos);

			string[] s = {"", "", "", "", ""};;
			this.Items.Add(new ListViewItem(s));
			this.Items.Add(new ListViewItem(s));
			this.Items.Add( new ListViewItem(s));            

			this.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FullRowSelect = true;
			this.Name = "listView1";
			this.Size = new System.Drawing.Size(0,0);
			this.TabIndex = 0;
			this.View = System.Windows.Forms.View.Details;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ELVMouseDown);
			this.DoubleClick += new System.EventHandler(this.ELVDoubleClick);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ELVKeyDown);
			this.GridLines = true ;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="action"></param>
		/// <param name="spos"></param>
		/// <param name="epos"></param>
		override protected void ProcessDoubleClick(string action, int spos, int epos)
		{
			if (action == "Ship To Locations") 
			{
				this.listBox.Size  = new System.Drawing.Size(150, 60);
				this.listBox.Location = new System.Drawing.Point(spos , this.ListViewItemSelected.Bounds.Y);
				DeselectAll();
				this.listBox.Show();
				this.listBox.Focus();
			}
			else 
			{
				base.ProcessDoubleClick(action, spos, epos);
			}
		}

		private void ListBoxOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) 
			{
				this.ListViewItemSelected.SubItems[this.SubItemSelectedIndex].Text = GetSelectedItems();
				this.listBox.Hide();
			}
			else if (e.KeyChar == 27) 
			{
				this.listBox.Hide();
			}
			else 
			{
				this.OnKeyPress(e);
			}
		}

		private void ListBoxFocusOver(object sender, System.EventArgs e)
		{
			this.ListViewItemSelected.SubItems[this.SubItemSelectedIndex].Text =  GetSelectedItems();
			this.listBox.Hide();
		}

		private string GetSelectedItems()
		{
			ListBox.SelectedObjectCollection items = this.listBox.SelectedItems;
			int cnt = items.Count;
			string s = "";
			for (int i = 0; i < cnt; i++) 
			{
				if (i > 0) 
				{
					s += DELIMITER ;
				}
				s += items[i];
			}
			return s;
		}

		private void DeselectAll()
		{
			if (this.listBox.SelectedItems.Count > 0) 
			{
				int cnt = this.listBox.Items.Count;
				for (int i = 0; i < cnt; i++) 
				{
					this.listBox.SetSelected(i, false);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override ICollection GetShippingServiceOptions()
		{
			InternationalShippingServiceOptionsTypeCollection ssos = new InternationalShippingServiceOptionsTypeCollection();

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
						InternationalShippingServiceOptionsType sso = new InternationalShippingServiceOptionsType();
						sso.ShippingService = text;
						sso.ShippingServicePriority = ++cnt;
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
							// ShipToLocations
							text = lvi.SubItems[3].Text;
							if (text.Length > 0) 
							{
								sso.ShipToLocation = this.GetShipToLocationCollection(text);
							}
                            // Import charge
                            text = lvi.SubItems[4].Text;
                            if (text.Length > 0)
                            {
                                sso.ImportCharge = CurrencyUtility.GetAmountType(text);
                            }
						}
					}
				}
			}
			return ssos;
		}

		private StringCollection GetShipToLocationCollection(string text)
		{
			StringCollection sc = new StringCollection();
			string [] s = text.Split(DELIMITER.ToCharArray());
			int len = s.Length;
			for (int i = 0; i < len; i++) 
			{
				string code = GetShipToLocationCode(s[i]);
				if (code != null) 
				{
					sc.Add(code);
				}
			}
			return sc;
		}

		private string GetShipToLocationCode(string stl)
		{
			int len = this.shipToLocationControlTagItems.Length;
			for (int i = 0; i < len; i++) 
			{
				if (stl.Equals(this.shipToLocationControlTagItems[i].Text))
				{
					return this.shipToLocationControlTagItems[i].Tag.ToString();
				}
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		public static string DELIMITER = ",";
	}
}

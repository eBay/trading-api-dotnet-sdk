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

namespace Samples.Helper.UI
{
	/// <summary>
	/// 
	/// </summary>
	public struct HeaderInfo 
	{
		/// <summary>
		/// 
		/// </summary>
		public string name;

		/// <summary>
		/// 
		/// </summary>
		public int width;
	}

	/// <summary>
	/// 
	/// </summary>
	public class EditListView : ListView 
	{
		private System.Windows.Forms.ColumnHeader [] columnHeaders;

		private int x = 0;
		private int y = 0;
		private ListViewItem listViewItemSelected;
		private int listViewItemSelectedIndex = -1;
		private string subItemSelectedText;
		private int subItemSelectedIndex = 0 ; 

		/// <summary>
		/// 
		/// </summary>
		protected TextBox editBox = new System.Windows.Forms.TextBox();

		/// <summary>
		/// 
		/// </summary>
		public EditListView()
		{
			InitializeComponent();
			this.Scrollable = false;
		}

		private void EditOver(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if ( e.KeyChar == 13 ) 
			{
				this.listViewItemSelected.SubItems[subItemSelectedIndex].Text = editBox.Text;
				this.editBox.Hide();
			}

			if ( e.KeyChar == 27 ) 
				this.editBox.Hide();
		}

		private void EditFocusOver(object sender, System.EventArgs e)
		{
			this.listViewItemSelected.SubItems[this.subItemSelectedIndex].Text = editBox.Text;
			this.editBox.Hide();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public  void ELVDoubleClick(object sender, System.EventArgs e)
		{
			int nStart = this.x ;
			int spos = 0 ; 
			int epos = 0;
			for ( int i=0; i < this.Columns.Count ; i++)
			{
				epos += this.Columns[i].Width;
				if ( nStart > spos && nStart < epos ) 
				{
					subItemSelectedIndex = i ;
					break; 
				}
				
				spos = epos ; 
			}

			this.subItemSelectedText = this.listViewItemSelected.SubItems[this.subItemSelectedIndex].Text ;

			string colName = this.Columns[this.subItemSelectedIndex].Text ;

			ProcessDoubleClick(colName, spos, epos);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ELVKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete) 
			{
				if (this.listViewItemSelected != null) 
				{
					ListViewItem.ListViewSubItemCollection subItems = this.listViewItemSelected.SubItems;
					for (int i = 0; i < subItems.Count; i++) 
					{
						subItems[i].Text = "";
					}
					this.listViewItemSelected = null;
				}
			}
			else if (e.KeyCode == Keys.Up) 
			{
				if (this.listViewItemSelectedIndex > 0) 
				{
					this.listViewItemSelected = this.Items[--this.listViewItemSelectedIndex];
				}
			}
			else if (e.KeyCode == Keys.Down) 
			{
				if (this.listViewItemSelectedIndex < (this.Items.Count - 1)) 
				{
					this.listViewItemSelected = this.Items[++this.listViewItemSelectedIndex];
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void ELVMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.listViewItemSelected = this.GetItemAt(e.X , e.Y);
			if (this.listViewItemSelected != null) 
			{
				this.listViewItemSelectedIndex = this.listViewItemSelected.Index;
			}
			this.x = e.X ;
			this.y = e.Y ;
		}

		/// <summary>
		/// This method must be called to iniitialize the ListView.
		/// </summary>
		/// <param name="infos"></param>
		virtual public void Initialize(HeaderInfo[] infos)
		{
			InitListView(infos);
			InitEditBox();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="headerInfos"></param>
		protected void InitHeaderInfo(HeaderInfo[] headerInfos) 
		{
			if (headerInfos != null) 
			{
				int cnt = headerInfos.Length;
				if (cnt > 0) 
				{
					this.columnHeaders = new ColumnHeader[cnt];
					for (int i = 0; i < cnt; i++) 
					{
						this.columnHeaders[i] = new ColumnHeader();
						this.columnHeaders[i].Text = headerInfos[i].name;
						this.columnHeaders[i].Width = headerInfos[i].width;
					}
					this.Columns.AddRange(this.columnHeaders);
				}
			}
			else 
			{
				this.HeaderStyle = ColumnHeaderStyle.None;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="headerInfos"></param>
		virtual protected void InitListView(HeaderInfo[] headerInfos)
		{
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

			InitHeaderInfo(headerInfos);
		}

		private void InitEditBox()
		{
			this.editBox.Size  = new System.Drawing.Size(0,0);
			this.editBox.Location = new System.Drawing.Point(0,0);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.editBox});			

			this.editBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EditOver);
			this.editBox.LostFocus += new System.EventHandler(this.EditFocusOver);
			this.editBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.editBox.BackColor = Color.LightYellow; 
			this.editBox.BorderStyle = BorderStyle.Fixed3D;
			this.editBox.Hide();
			this.editBox.Text = "";
		}

		private void InitializeComponent()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		public ListViewItem ListViewItemSelected 
		{
			get{return this.listViewItemSelected;}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="action"></param>
		/// <param name="spos"></param>
		/// <param name="epos"></param>
		virtual protected void ProcessDoubleClick(string action, int spos, int epos)
		{
			this.editBox.Size  = new System.Drawing.Size(epos - spos , this.listViewItemSelected.Bounds.Bottom-this.listViewItemSelected.Bounds.Top);
			this.editBox.Location = new System.Drawing.Point(spos , this.listViewItemSelected.Bounds.Y);
			this.editBox.Show();
			this.editBox.Text = this.subItemSelectedText;
			this.editBox.SelectAll() ;
			this.editBox.Focus();
		}

		/// <summary>
		/// 
		/// </summary>
		public ListViewItem SelectedListViewItem
		{
			get 
			{
				return this.listViewItemSelected;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public ListViewItem.ListViewSubItem SelectedListViewSubItem
		{
			get 
			{
				if (this.listViewItemSelected != null) 
				{
					return this.listViewItemSelected.SubItems[this.subItemSelectedIndex];
				}
				else 
				{
					return null;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public int SubItemSelectedIndex 
		{
			get {return this.subItemSelectedIndex;}
		}

		/// <summary>
		/// 
		/// </summary>
		public string SubItemSelectedText 
		{
			get {return this.subItemSelectedText;}
		}
	}
}

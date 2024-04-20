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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
using Samples.Helper;
using Samples.Helper.UI;
using Samples.Helper.Cache;

namespace SampleShippingServiceApplication
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
		ApiContext apiContext;
		private ShippingServiceListView  listViewCalcShippingService;
		private ShippingServiceListView  listViewDomesticShippingService;
		private IntlShippingServiceListView  listViewIntlShippingService;
		private Hashtable listingType2DurationTable;
		private string selectedCategoryID;
		private ControlTagItem[] domesticShippingServiceCache;
		private ControlTagItem[] internationalShippingServiceCache;
		private ControlTagItem[] calculatedShippingServiceCache;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtItemId;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.TextBox txtStartPrice;
		private System.Windows.Forms.ComboBox cbxDuration;
		private System.Windows.Forms.TextBox txtReservePrice;
		private System.Windows.Forms.TextBox txtBinPrice;
		private System.Windows.Forms.TextBox txtDesc;
		private System.Windows.Forms.TextBox txtLocation;
		private System.Windows.Forms.TextBox txtError;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btnAddItem;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbtnFlatShippingRates;
		private System.Windows.Forms.RadioButton rbtnCalculatedShippingRates;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ComboBox cbxSalesTaxState;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtTaxPercent;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Panel panelFlatRateShippingBase;
		private System.Windows.Forms.Panel panelCalculateRateShippingBase;
		private System.Windows.Forms.ComboBox cbxPackageSize;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.TextBox txtDepth;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.TextBox txtLength;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.TextBox txtWidth;
		private System.Windows.Forms.TextBox txtPackgingHandingFee;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox txtOriginatingZipCode;
		private System.Windows.Forms.Label lbWeightMajor;
		private System.Windows.Forms.TextBox txtWeightMajor;
		private System.Windows.Forms.Label lbWeightMinor;
		private System.Windows.Forms.TextBox txtWeightMinor;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.ComboBox cbxWeightMeasurement;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txteBayTime;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelPackageInfo;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label lbShippingType;
		private System.Windows.Forms.CheckBox chkApplyShippingDiscount;
		private System.Windows.Forms.CheckBox chkApplySalesTaxToTotal;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lbEditInfo;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.GroupBox groupBox11;
		private Samples.Helper.UI.CheckBoxGroupControl shipToLocationsControl;
		private Samples.Helper.UI.ShippingServiceControl shippingServiceControlFlatRate;
		private Samples.Helper.UI.InternationalShippingServiceControl internationalShippingServiceControl;
		private Samples.Helper.UI.ShippingServiceControl shippingServiceControlCalcRate;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.ComboBox cbxListingType;
		private System.Windows.Forms.ComboBox cmbCategoryList;
		private System.Windows.Forms.Label label8;

		public FormMain()
		{
			Form progressBar = new ProgressBar();
			try
			{
				progressBar.StartPosition = FormStartPosition.CenterScreen;
				progressBar.Show();
				progressBar.Update();
				
				//
				// Required for Windows Form Designer support
				//	
				InitializeComponent();

				//
				// TODO: Add any constructor code after InitializeComponent call
				//
				InitSessionContext();
				SetDefaultInputs();
				CustomInit();
				SetFormStartPosition();
				bindEvent();
				progressBar.Hide();
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message);
			}
			finally
			{
				progressBar.Dispose();
			}

		}


		private void bindEvent()
		{
			this.cmbCategoryList.SelectedIndexChanged += new System.EventHandler(this.cmbCategoryList_SelectedIndexChanged);
			this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
		}

		private void CustomInit()
		{
			populateCategories();
			//update listing tyep/listing duration/payment methods
			InitCategoryFeatureOptions();
			getAllShippingService();
			InitShippingServiceOptions();
			//InitShippingInsuranceOptions();
			InitShippingPackageOptions();
			InitSalesTaxOptions();
			InitShipToLocationOptiions();
		}

		void InitShipToLocationOptiions()
		{
			ControlTagItem[] items = getItemShipToLocationControlTags();
			this.shipToLocationsControl.SetCheckBoxControls(items);
		}

		private void InitCategoryFeatureOptions()
		{
			CategoryFeatureManager.GetAllCategoriesFeatures(apiContext);//need only once
			UpdateCategoryFeatures();
			populateListingTypeFields();
			populateListingDuration();
			cbxListingType.SelectedItem=cbxListingType.Items[0];
			cbxDuration.SelectedItem=cbxDuration.Items[0];
		}

		private void InitShippingServiceOptions()
		{
			// Calculated rate shipping
			this.listViewCalcShippingService = this.shippingServiceControlCalcRate.EditListView;
			this.listViewCalcShippingService.TagItemOptions = calculatedShippingServiceCache;
			//Override default list header settings
			HeaderInfo[] headerInfos = new HeaderInfo[3];
			headerInfos[0].name = "Shipping Service";
			headerInfos[0].width = 300;
			this.listViewCalcShippingService.Initialize(headerInfos);

			// Flat rate shipping
			this.listViewDomesticShippingService = this.shippingServiceControlFlatRate.EditListView;
			this.listViewDomesticShippingService.TagItemOptions = domesticShippingServiceCache;
			//Use default list header settings
			this.listViewDomesticShippingService.Initialize(null);

			// Flat rate - international shipping			
			this.listViewIntlShippingService = this.internationalShippingServiceControl.EditListView;
			this.listViewIntlShippingService.TagItemOptions = internationalShippingServiceCache;
			this.listViewIntlShippingService.ShipToLocationControlTagItems = getItemShipToLocationControlTags();
			//Use default list header settings
			this.listViewIntlShippingService.Initialize(null);
		}

		/*private void InitShippingInsuranceOptions()
		{
			ControlTagItem[] insuranceOptions = ShippingServiceHelper.GetInstance().GetInsuranceOptionControlTagItems(SiteCodeType.US);
			this.cbxShippingInsurance.Items.AddRange(insuranceOptions);
			this.cbxShippingInsurance.SelectedIndex = 0;
		}*/

		private void InitShippingPackageOptions()
		{
			ControlTagItem[] packageSize = ShippingServiceHelper.GetInstance().GetShippingPackSizeControlTagItems(SiteCodeType.US);
			this.cbxPackageSize.Items.AddRange(packageSize);
			this.cbxPackageSize.SelectedIndex = 0;

			ControlTagItem[] units = new ControlTagItem[] {
															  new ControlTagItem("English", "pounds"), new ControlTagItem("Metric", "Kilograms")
														  };
			this.cbxWeightMeasurement.Items.AddRange(units);
			this.cbxWeightMeasurement.SelectedIndex = 0;
		}

		private void InitSalesTaxOptions()
		{
			ControlTagItem[] states = ShippingServiceHelper.GetInstance().GetStateControlTagItems(SiteCodeType.US);
			this.cbxSalesTaxState.Items.AddRange(states);
			this.cbxSalesTaxState.SelectedIndex = 0;
		}

		//get domestic shipping service and international shipping service
		private void getAllShippingService()
		{
			ShippingServiceDetailsTypeCollection shippingServiceCol = CategoryFeatureManager.GetShippingServices(apiContext).ShippingServiceDetails;
			ArrayList domesticShippingService=new ArrayList();
			ArrayList internationalShippingServie=new ArrayList();
			ArrayList calculatedShippingService=new ArrayList();

			if(shippingServiceCol!=null)
			{
				foreach(ShippingServiceDetailsType shippingService in shippingServiceCol)
				{
					//the following loop algorithm is for flat rate shipping only
					if(shippingService.ShippingServiceID>50000)
					{
						internationalShippingServie.Add(shippingService.ShippingService);
					}
					else
					{
						domesticShippingService.Add(shippingService.ShippingService);
					}

					//the following loop algorithm is for calculated rate shipping only
					//the valid shipping service should be calculated and domestic
					if(shippingService.ShippingServiceID<=50000
						&& shippingService.ServiceType!=null)
					{
						foreach(ShippingTypeCodeType serviceType in shippingService.ServiceType)
						{
							if(serviceType==ShippingTypeCodeType.Calculated)
							{
								calculatedShippingService.Add(shippingService.ShippingService);
							}
						}
					}
				}
			}
			
			//cache all shipping details
			domesticShippingServiceCache=populateToControlTag(domesticShippingService);
			internationalShippingServiceCache = populateToControlTag(internationalShippingServie);
			calculatedShippingServiceCache=populateToControlTag(calculatedShippingService);
		}

		//populate all shipping service to array
		private ControlTagItem[] populateToControlTag(ArrayList list)
		{
			if(list==null)
				return null;

			ControlTagItem[] controlTagItemArr=new ControlTagItem[list.Count];
			int index=0;
			foreach(object item in list)
			{
				controlTagItemArr[index++]=new ControlTagItem(item.ToString(),item.ToString());
			}

			return controlTagItemArr;
		}

		private void SetFormStartPosition()
		{
			this.StartPosition = FormStartPosition.CenterScreen;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtStartPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxDuration = new System.Windows.Forms.ComboBox();
            this.txtReservePrice = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBinPrice = new System.Windows.Forms.TextBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.shipToLocationsControl = new Samples.Helper.UI.CheckBoxGroupControl();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbxListingType = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbCategoryList = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelFlatRateShippingBase = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.internationalShippingServiceControl = new Samples.Helper.UI.InternationalShippingServiceControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.shippingServiceControlFlatRate = new Samples.Helper.UI.ShippingServiceControl();
            this.panelCalculateRateShippingBase = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelPackageInfo = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxPackageSize = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxWeightMeasurement = new System.Windows.Forms.ComboBox();
            this.txtWeightMajor = new System.Windows.Forms.TextBox();
            this.txtWeightMinor = new System.Windows.Forms.TextBox();
            this.lbWeightMinor = new System.Windows.Forms.Label();
            this.lbWeightMajor = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.shippingServiceControlCalcRate = new Samples.Helper.UI.ShippingServiceControl();
            this.txtOriginatingZipCode = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPackgingHandingFee = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.rbtnCalculatedShippingRates = new System.Windows.Forms.RadioButton();
            this.rbtnFlatShippingRates = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lbShippingType = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtTaxPercent = new System.Windows.Forms.TextBox();
            this.cbxSalesTaxState = new System.Windows.Forms.ComboBox();
            this.chkApplySalesTaxToTotal = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chkApplyShippingDiscount = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txteBayTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lbEditInfo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelFlatRateShippingBase.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelCalculateRateShippingBase.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelPackageInfo.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "eBay Item ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(112, 56);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.ReadOnly = true;
            this.txtItemId.Size = new System.Drawing.Size(152, 20);
            this.txtItemId.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(88, 24);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(344, 20);
            this.txtTitle.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Title:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(472, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Category:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(88, 48);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(72, 20);
            this.txtQuantity.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(20, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "Quantity:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(476, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Duration:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStartPrice
            // 
            this.txtStartPrice.Location = new System.Drawing.Point(88, 80);
            this.txtStartPrice.Name = "txtStartPrice";
            this.txtStartPrice.Size = new System.Drawing.Size(72, 20);
            this.txtStartPrice.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Start Price:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(476, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "BIN Price:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(88, 108);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(584, 96);
            this.txtDesc.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(12, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Description:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(88, 212);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(584, 20);
            this.txtLocation.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(24, 212);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "Location:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxDuration
            // 
            this.cbxDuration.Location = new System.Drawing.Point(548, 46);
            this.cbxDuration.Name = "cbxDuration";
            this.cbxDuration.Size = new System.Drawing.Size(121, 21);
            this.cbxDuration.TabIndex = 12;
            // 
            // txtReservePrice
            // 
            this.txtReservePrice.Location = new System.Drawing.Point(304, 80);
            this.txtReservePrice.Name = "txtReservePrice";
            this.txtReservePrice.Size = new System.Drawing.Size(124, 20);
            this.txtReservePrice.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(204, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 23);
            this.label15.TabIndex = 29;
            this.label15.Text = "Reserve Price:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBinPrice
            // 
            this.txtBinPrice.Location = new System.Drawing.Point(548, 78);
            this.txtBinPrice.Name = "txtBinPrice";
            this.txtBinPrice.Size = new System.Drawing.Size(120, 20);
            this.txtBinPrice.TabIndex = 35;
            // 
            // txtError
            // 
            this.txtError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtError.Location = new System.Drawing.Point(376, 20);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtError.Size = new System.Drawing.Size(288, 56);
            this.txtError.TabIndex = 37;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(91, 22);
            this.tabControl1.Location = new System.Drawing.Point(12, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 440);
            this.tabControl1.TabIndex = 46;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(717, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "    Item Details    ";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.shipToLocationsControl);
            this.groupBox11.Location = new System.Drawing.Point(4, 268);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(701, 136);
            this.groupBox11.TabIndex = 37;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = " Ship To Locations ";
            // 
            // shipToLocationsControl
            // 
            this.shipToLocationsControl.ItemHeight = 35;
            this.shipToLocationsControl.Location = new System.Drawing.Point(12, 20);
            this.shipToLocationsControl.Name = "shipToLocationsControl";
            this.shipToLocationsControl.Size = new System.Drawing.Size(640, 112);
            this.shipToLocationsControl.TabIndex = 0;
            this.shipToLocationsControl.WidthFactor = 12;
            this.shipToLocationsControl.XOffset = 15;
            this.shipToLocationsControl.YOffset = 10;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbxListingType);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.cbxDuration);
            this.groupBox10.Controls.Add(this.txtStartPrice);
            this.groupBox10.Controls.Add(this.txtReservePrice);
            this.groupBox10.Controls.Add(this.label9);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.label10);
            this.groupBox10.Controls.Add(this.txtTitle);
            this.groupBox10.Controls.Add(this.txtBinPrice);
            this.groupBox10.Controls.Add(this.txtDesc);
            this.groupBox10.Controls.Add(this.label3);
            this.groupBox10.Controls.Add(this.label11);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.txtLocation);
            this.groupBox10.Controls.Add(this.txtQuantity);
            this.groupBox10.Controls.Add(this.label13);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.label26);
            this.groupBox10.Controls.Add(this.cmbCategoryList);
            this.groupBox10.Location = new System.Drawing.Point(4, 8);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(701, 252);
            this.groupBox10.TabIndex = 36;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = " Item ";
            // 
            // cbxListingType
            // 
            this.cbxListingType.Location = new System.Drawing.Point(304, 52);
            this.cbxListingType.Name = "cbxListingType";
            this.cbxListingType.Size = new System.Drawing.Size(128, 21);
            this.cbxListingType.TabIndex = 36;
            this.cbxListingType.SelectedValueChanged += new System.EventHandler(this.cbxListingType_SelectedValueChanged);
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(212, 48);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 23);
            this.label26.TabIndex = 10;
            this.label26.Text = "ListingType:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategoryList
            // 
            this.cmbCategoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryList.Location = new System.Drawing.Point(548, 18);
            this.cmbCategoryList.Name = "cmbCategoryList";
            this.cmbCategoryList.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoryList.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelFlatRateShippingBase);
            this.tabPage2.Controls.Add(this.panelCalculateRateShippingBase);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(717, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "    Shipping Details - Shipping Services   ";
            // 
            // panelFlatRateShippingBase
            // 
            this.panelFlatRateShippingBase.Controls.Add(this.groupBox4);
            this.panelFlatRateShippingBase.Controls.Add(this.groupBox3);
            this.panelFlatRateShippingBase.Location = new System.Drawing.Point(8, 64);
            this.panelFlatRateShippingBase.Name = "panelFlatRateShippingBase";
            this.panelFlatRateShippingBase.Size = new System.Drawing.Size(701, 324);
            this.panelFlatRateShippingBase.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.internationalShippingServiceControl);
            this.groupBox4.Location = new System.Drawing.Point(4, 164);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(700, 152);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " International Shipping";
            // 
            // internationalShippingServiceControl
            // 
            this.internationalShippingServiceControl.Location = new System.Drawing.Point(8, 16);
            this.internationalShippingServiceControl.Name = "internationalShippingServiceControl";
            this.internationalShippingServiceControl.Size = new System.Drawing.Size(686, 128);
            this.internationalShippingServiceControl.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.shippingServiceControlFlatRate);
            this.groupBox3.Location = new System.Drawing.Point(4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 136);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Domestic Shipping ";
            // 
            // shippingServiceControlFlatRate
            // 
            this.shippingServiceControlFlatRate.Location = new System.Drawing.Point(8, 16);
            this.shippingServiceControlFlatRate.Name = "shippingServiceControlFlatRate";
            this.shippingServiceControlFlatRate.Size = new System.Drawing.Size(680, 112);
            this.shippingServiceControlFlatRate.TabIndex = 0;
            // 
            // panelCalculateRateShippingBase
            // 
            this.panelCalculateRateShippingBase.Controls.Add(this.groupBox1);
            this.panelCalculateRateShippingBase.Controls.Add(this.groupBox5);
            this.panelCalculateRateShippingBase.Controls.Add(this.txtOriginatingZipCode);
            this.panelCalculateRateShippingBase.Controls.Add(this.label24);
            this.panelCalculateRateShippingBase.Controls.Add(this.label20);
            this.panelCalculateRateShippingBase.Controls.Add(this.txtPackgingHandingFee);
            this.panelCalculateRateShippingBase.Location = new System.Drawing.Point(8, 60);
            this.panelCalculateRateShippingBase.Name = "panelCalculateRateShippingBase";
            this.panelCalculateRateShippingBase.Size = new System.Drawing.Size(704, 344);
            this.panelCalculateRateShippingBase.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelPackageInfo);
            this.groupBox1.Location = new System.Drawing.Point(4, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 168);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // panelPackageInfo
            // 
            this.panelPackageInfo.Controls.Add(this.label19);
            this.panelPackageInfo.Controls.Add(this.cbxPackageSize);
            this.panelPackageInfo.Controls.Add(this.label18);
            this.panelPackageInfo.Controls.Add(this.cbxWeightMeasurement);
            this.panelPackageInfo.Controls.Add(this.txtWeightMajor);
            this.panelPackageInfo.Controls.Add(this.txtWeightMinor);
            this.panelPackageInfo.Controls.Add(this.lbWeightMinor);
            this.panelPackageInfo.Controls.Add(this.lbWeightMajor);
            this.panelPackageInfo.Controls.Add(this.txtWidth);
            this.panelPackageInfo.Controls.Add(this.label23);
            this.panelPackageInfo.Controls.Add(this.txtLength);
            this.panelPackageInfo.Controls.Add(this.label22);
            this.panelPackageInfo.Controls.Add(this.txtDepth);
            this.panelPackageInfo.Controls.Add(this.label21);
            this.panelPackageInfo.Controls.Add(this.label17);
            this.panelPackageInfo.Location = new System.Drawing.Point(4, 12);
            this.panelPackageInfo.Name = "panelPackageInfo";
            this.panelPackageInfo.Size = new System.Drawing.Size(632, 144);
            this.panelPackageInfo.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(12, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(152, 20);
            this.label19.TabIndex = 3;
            this.label19.Text = "Package Size:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxPackageSize
            // 
            this.cbxPackageSize.Location = new System.Drawing.Point(184, 104);
            this.cbxPackageSize.Name = "cbxPackageSize";
            this.cbxPackageSize.Size = new System.Drawing.Size(188, 21);
            this.cbxPackageSize.TabIndex = 5;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(12, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 20);
            this.label18.TabIndex = 2;
            this.label18.Text = "Weight Measurements: ";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxWeightMeasurement
            // 
            this.cbxWeightMeasurement.Location = new System.Drawing.Point(184, 64);
            this.cbxWeightMeasurement.Name = "cbxWeightMeasurement";
            this.cbxWeightMeasurement.Size = new System.Drawing.Size(112, 21);
            this.cbxWeightMeasurement.TabIndex = 19;
            this.cbxWeightMeasurement.SelectedIndexChanged += new System.EventHandler(this.cbxWeightMeasurement_SelectedIndexChanged);
            // 
            // txtWeightMajor
            // 
            this.txtWeightMajor.Location = new System.Drawing.Point(396, 64);
            this.txtWeightMajor.Name = "txtWeightMajor";
            this.txtWeightMajor.Size = new System.Drawing.Size(84, 20);
            this.txtWeightMajor.TabIndex = 16;
            // 
            // txtWeightMinor
            // 
            this.txtWeightMinor.Location = new System.Drawing.Point(552, 60);
            this.txtWeightMinor.Name = "txtWeightMinor";
            this.txtWeightMinor.Size = new System.Drawing.Size(68, 20);
            this.txtWeightMinor.TabIndex = 18;
            // 
            // lbWeightMinor
            // 
            this.lbWeightMinor.Location = new System.Drawing.Point(488, 64);
            this.lbWeightMinor.Name = "lbWeightMinor";
            this.lbWeightMinor.Size = new System.Drawing.Size(52, 16);
            this.lbWeightMinor.TabIndex = 17;
            this.lbWeightMinor.Text = "Ounces:";
            this.lbWeightMinor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbWeightMajor
            // 
            this.lbWeightMajor.Location = new System.Drawing.Point(312, 60);
            this.lbWeightMajor.Name = "lbWeightMajor";
            this.lbWeightMajor.Size = new System.Drawing.Size(72, 24);
            this.lbWeightMajor.TabIndex = 15;
            this.lbWeightMajor.Text = "Pounds:";
            this.lbWeightMajor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(552, 20);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(68, 20);
            this.txtWidth.TabIndex = 11;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(488, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 24);
            this.label23.TabIndex = 10;
            this.label23.Text = "Width:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(396, 20);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(60, 20);
            this.txtLength.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(344, 20);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(44, 20);
            this.label22.TabIndex = 8;
            this.label22.Text = "Length:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(232, 20);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(64, 20);
            this.txtDepth.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(180, 20);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 20);
            this.label21.TabIndex = 6;
            this.label21.Text = "Depth:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(12, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(156, 24);
            this.label17.TabIndex = 1;
            this.label17.Text = "Package Dimensions (inch):";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.shippingServiceControlCalcRate);
            this.groupBox5.Location = new System.Drawing.Point(4, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(318, 116);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Calculated Rate Shipping";
            // 
            // shippingServiceControlCalcRate
            // 
            this.shippingServiceControlCalcRate.Location = new System.Drawing.Point(8, 16);
            this.shippingServiceControlCalcRate.Name = "shippingServiceControlCalcRate";
            this.shippingServiceControlCalcRate.Size = new System.Drawing.Size(300, 92);
            this.shippingServiceControlCalcRate.TabIndex = 0;
            // 
            // txtOriginatingZipCode
            // 
            this.txtOriginatingZipCode.Location = new System.Drawing.Point(536, 48);
            this.txtOriginatingZipCode.Name = "txtOriginatingZipCode";
            this.txtOriginatingZipCode.Size = new System.Drawing.Size(96, 20);
            this.txtOriginatingZipCode.TabIndex = 14;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(392, 48);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(120, 20);
            this.label24.TabIndex = 13;
            this.label24.Text = "Originating Zip Code:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(372, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(140, 16);
            this.label20.TabIndex = 4;
            this.label20.Text = "Packaging && Handing Fee:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPackgingHandingFee
            // 
            this.txtPackgingHandingFee.Location = new System.Drawing.Point(536, 96);
            this.txtPackgingHandingFee.Name = "txtPackgingHandingFee";
            this.txtPackgingHandingFee.Size = new System.Drawing.Size(80, 20);
            this.txtPackgingHandingFee.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.rbtnCalculatedShippingRates);
            this.groupBox2.Controls.Add(this.rbtnFlatShippingRates);
            this.groupBox2.Location = new System.Drawing.Point(12, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(16, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(148, 20);
            this.label25.TabIndex = 2;
            this.label25.Text = "Choose a Shipping Type:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbtnCalculatedShippingRates
            // 
            this.rbtnCalculatedShippingRates.Location = new System.Drawing.Point(488, 16);
            this.rbtnCalculatedShippingRates.Name = "rbtnCalculatedShippingRates";
            this.rbtnCalculatedShippingRates.Size = new System.Drawing.Size(144, 20);
            this.rbtnCalculatedShippingRates.TabIndex = 1;
            this.rbtnCalculatedShippingRates.Text = "Calculate Rate Shipping";
            this.rbtnCalculatedShippingRates.CheckedChanged += new System.EventHandler(this.rbtnCalculatedShippingRates_CheckedChanged);
            // 
            // rbtnFlatShippingRates
            // 
            this.rbtnFlatShippingRates.Location = new System.Drawing.Point(272, 12);
            this.rbtnFlatShippingRates.Name = "rbtnFlatShippingRates";
            this.rbtnFlatShippingRates.Size = new System.Drawing.Size(120, 24);
            this.rbtnFlatShippingRates.TabIndex = 0;
            this.rbtnFlatShippingRates.Text = "Flat Rate Shipping";
            this.rbtnFlatShippingRates.CheckedChanged += new System.EventHandler(this.rbtnFlatShippingRates_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lbShippingType);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.chkApplyShippingDiscount);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(717, 410);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Shipping Details - Insurance and Taxes";
            // 
            // lbShippingType
            // 
            this.lbShippingType.Location = new System.Drawing.Point(260, 72);
            this.lbShippingType.Name = "lbShippingType";
            this.lbShippingType.Size = new System.Drawing.Size(208, 28);
            this.lbShippingType.TabIndex = 13;
            this.lbShippingType.Text = "Flat Rate Shipping";
            this.lbShippingType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtTaxPercent);
            this.groupBox7.Controls.Add(this.cbxSalesTaxState);
            this.groupBox7.Controls.Add(this.chkApplySalesTaxToTotal);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Location = new System.Drawing.Point(96, 178);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(472, 100);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            // 
            // txtTaxPercent
            // 
            this.txtTaxPercent.Location = new System.Drawing.Point(304, 20);
            this.txtTaxPercent.Name = "txtTaxPercent";
            this.txtTaxPercent.Size = new System.Drawing.Size(68, 20);
            this.txtTaxPercent.TabIndex = 7;
            // 
            // cbxSalesTaxState
            // 
            this.cbxSalesTaxState.Location = new System.Drawing.Point(144, 20);
            this.cbxSalesTaxState.Name = "cbxSalesTaxState";
            this.cbxSalesTaxState.Size = new System.Drawing.Size(136, 21);
            this.cbxSalesTaxState.TabIndex = 5;
            // 
            // chkApplySalesTaxToTotal
            // 
            this.chkApplySalesTaxToTotal.Location = new System.Drawing.Point(40, 68);
            this.chkApplySalesTaxToTotal.Name = "chkApplySalesTaxToTotal";
            this.chkApplySalesTaxToTotal.Size = new System.Drawing.Size(412, 20);
            this.chkApplySalesTaxToTotal.TabIndex = 10;
            this.chkApplySalesTaxToTotal.Text = "Apply Sales Tax to the Total which Includes Shipping && Handling.";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(36, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Sales Tax:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(376, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 20);
            this.label16.TabIndex = 8;
            this.label16.Text = "%";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkApplyShippingDiscount
            // 
            this.chkApplyShippingDiscount.Location = new System.Drawing.Point(108, 134);
            this.chkApplyShippingDiscount.Name = "chkApplyShippingDiscount";
            this.chkApplyShippingDiscount.Size = new System.Drawing.Size(460, 28);
            this.chkApplyShippingDiscount.TabIndex = 9;
            this.chkApplyShippingDiscount.Text = "Applying Shipping Discoutn when Item is Combined into a Combined Payment Order.";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.txtError);
            this.groupBox8.Controls.Add(this.txteBayTime);
            this.groupBox8.Controls.Add(this.txtItemId);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Location = new System.Drawing.Point(12, 456);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(725, 96);
            this.groupBox8.TabIndex = 36;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " Call Results";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(316, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 24);
            this.label8.TabIndex = 39;
            this.label8.Text = "Status:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txteBayTime
            // 
            this.txteBayTime.BackColor = System.Drawing.SystemColors.Control;
            this.txteBayTime.Location = new System.Drawing.Point(112, 24);
            this.txteBayTime.Name = "txteBayTime";
            this.txteBayTime.ReadOnly = true;
            this.txteBayTime.Size = new System.Drawing.Size(152, 20);
            this.txteBayTime.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 37;
            this.label2.Text = "eBay Time:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddItem
            // 
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Location = new System.Drawing.Point(770, 472);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(72, 24);
            this.btnAddItem.TabIndex = 48;
            this.btnAddItem.Text = "AddItem";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(770, 507);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 49;
            this.btnCancel.Text = "Close";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lbEditInfo);
            this.groupBox9.Location = new System.Drawing.Point(743, 24);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(120, 421);
            this.groupBox9.TabIndex = 50;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = " Help ";
            // 
            // lbEditInfo
            // 
            this.lbEditInfo.Location = new System.Drawing.Point(8, 24);
            this.lbEditInfo.Name = "lbEditInfo";
            this.lbEditInfo.Size = new System.Drawing.Size(104, 328);
            this.lbEditInfo.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(875, 561);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox8);
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sample Shipping Application";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panelFlatRateShippingBase.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panelCalculateRateShippingBase.ResumeLayout(false);
            this.panelCalculateRateShippingBase.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panelPackageInfo.ResumeLayout(false);
            this.panelPackageInfo.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormMain_Load(object sender, System.EventArgs e)
		{
			SetFormInfo();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private ItemType GetItem()
		{
			ItemType item = new ItemType();
			item.Currency = this.DEFAULT_CURRENCY;
			item.Country = this.DEFAULT_COUNTRY;
			setPaymentMethods(item);
			return item;
		}

		//hard code some payment methods
		private void setPaymentMethods(ItemType item)
		{
			BuyerPaymentMethodCodeTypeCollection paymentMethods=new BuyerPaymentMethodCodeTypeCollection();

			if(defaultPayMethods.Contains(BuyerPaymentMethodCodeType.PayPal))
			{
				paymentMethods.Add(BuyerPaymentMethodCodeType.PayPal);
				item.PayPalEmailAddress="me@paypal.com";
			}

			if(defaultPayMethods.Contains(BuyerPaymentMethodCodeType.VisaMC))
			{
				paymentMethods.Add(BuyerPaymentMethodCodeType.VisaMC);
			}
			
			if(defaultPayMethods.Contains(BuyerPaymentMethodCodeType.CashOnPickup))
			{
				paymentMethods.Add(BuyerPaymentMethodCodeType.CashOnPickup);
			}

			item.PaymentMethods=paymentMethods;
		}

		private void SetItemDetails(ItemType item)
		{
			string text = this.txtBinPrice.Text;
			if (text.Length > 0) 
			{
				item.BuyItNowPrice = CurrencyUtility.GetAmountType(text);
			}

			text = this.txtReservePrice.Text;
			if (text.Length > 0) 
			{
				item.ReservePrice = CurrencyUtility.GetAmountType(text);
			}

			text = this.txtStartPrice.Text;
			if (text.Length > 0) 
			{
				item.StartPrice = CurrencyUtility.GetAmountType(text);
			}

			item.PrimaryCategory = new CategoryType();
			item.PrimaryCategory.CategoryID = this.cmbCategoryList.SelectedItem.ToString();
			item.Description = this.txtDesc.Text.Trim();
			item.Location = this.txtLocation.Text.Trim();

			text = this.txtQuantity.Text;
			if (text.Length > 0)
			{
				item.Quantity = Convert.ToInt32(text);
			}
			
			item.Title = this.txtTitle.Text.Trim();
			if (this.cbxDuration.SelectedItem != null)
			{
				item.ListingDuration = (string)this.cbxDuration.SelectedItem;
			}

			if (this.cbxListingType.SelectedItem!=null)
			{
				item.ListingType=(ListingTypeCodeType)Enum.Parse(typeof(ListingTypeCodeType),cbxListingType.SelectedItem.ToString());
				if(item.ListingType.Equals(ListingTypeCodeType.LeadGeneration))
				{
					item.ListingSubtype2=ListingSubtypeCodeType.ClassifiedAd;
				}
			}
			//handling time
			item.DispatchTimeMax =1;
			
			bool returnPolicyEnabled;
			string catid = this.cmbCategoryList.SelectedItem.ToString();

			//get return policy enabled feature.
			//workaroud set to true
			returnPolicyEnabled=true;

			if(returnPolicyEnabled)
			{
				//add policy
				item.ReturnPolicy=GetPolicyForUS();
			}
		}

		
		
		/// <summary>
		/// get a policy for us site only.
		/// </summary>
		/// <returns></returns>
		public static ReturnPolicyType GetPolicyForUS()
		{
			ReturnPolicyType policy=new ReturnPolicyType();
			policy.Refund="MoneyBack";
			policy.ReturnsWithinOption="Days_14";
			policy.ReturnsAcceptedOption="ReturnsAccepted";
			policy.ShippingCostPaidByOption="Buyer";

			return policy;
		}


		private void SetItemShipToLocations(ItemType item)
		{
			ArrayList list = this.shipToLocationsControl.CheckedCheckBoxes;
			int len = list.Count;
			if (len > 0) 
			{
				StringCollection coll = new StringCollection();
				item.ShipToLocations = coll;
				for (int i = 0; i < len; i++) 
				{
					CheckBox cb = (CheckBox)list[i];
					coll.Add(cb.Name);
				}
			}
		}

		private void SetOtherShippingInfo(ItemType item)
		{
			item.ShippingDetails.ApplyShippingDiscount = this.chkApplyShippingDiscount.Checked;
		}

		/*private void SetInsuranceOptions(ItemType item)
		{
			item.ShippingDetails.InsuranceOption = (InsuranceOptionCodeType)((ControlTagItem)this.cbxShippingInsurance.SelectedItem).Tag;
			if (this.rbtnFlatShippingRates.Checked) 
			{
				item.ShippingDetails.InsuranceFee = CurrencyUtility.GetAmountType(this.txtInsuranceFee.Text);
			}
		}*/

		private void SetCalculatedShippingDetails(ItemType item)
		{
			CalculatedShippingRateType csr = new CalculatedShippingRateType();
			item.ShippingDetails.CalculatedShippingRate = csr;
			

			string unit = ((ControlTagItem)this.cbxWeightMeasurement.SelectedItem).Tag.ToString();
			string text = this.txtWeightMajor.Text;
			//if (text.Length > 0) 
			//{
			//	csr.WeightMajor = new MeasureType();
			//	csr.WeightMajor.unit = unit;
			//	csr.WeightMajor.Value = decimal.Parse(text);
			//}

			text = this.txtWeightMinor.Text;
			//if (text.Length > 0) 
			//{
			//	csr.WeightMinor = new MeasureType();
			//	csr.WeightMinor.unit = unit;			

			//	csr.WeightMinor.Value = decimal.Parse(text);
			//}

			unit = "English";

			text = this.txtDepth.Text;
			//if (text.Length > 0) 
			//{
			//	csr.PackageDepth = new MeasureType();
			//	csr.PackageDepth.unit = unit;
			//	csr.PackageDepth.Value = decimal.Parse(text);
			//}

			//text = this.txtLength.Text;
			//if (text.Length > 0) 
			//{
			//	csr.PackageLength = new MeasureType();
			//	csr.PackageLength.unit = unit;
			//	csr.PackageLength.Value = decimal.Parse(this.txtLength.Text);
			//}

			//text = this.txtWidth.Text;
			//if (text.Length > 0) 
			//{
			//	csr.PackageWidth = new MeasureType();
			//	csr.PackageWidth.unit = unit;
			//	csr.PackageWidth.Value = decimal.Parse(this.txtWidth.Text);
			//}

			text = this.txtPackgingHandingFee.Text;
			if (text.Length > 0) 
			{
				csr.PackagingHandlingCosts = CurrencyUtility.GetAmountType(text);
			}

			csr.OriginatingPostalCode = this.txtOriginatingZipCode.Text;
		}

		private void SetShippingServiceOptions(ItemType item)
		{
			ShippingDetailsType sd = new ShippingDetailsType();
			item.ShippingDetails = sd;

			if (this.rbtnFlatShippingRates.Checked) 
			{
				sd.ShippingServiceOptions = 
					(ShippingServiceOptionsTypeCollection)this.listViewDomesticShippingService.GetShippingServiceOptions();
				sd.InternationalShippingServiceOption = 
					(InternationalShippingServiceOptionsTypeCollection)this.listViewIntlShippingService.GetShippingServiceOptions();
			}
			else if (this.rbtnCalculatedShippingRates.Checked) 
			{
				sd.ShippingServiceOptions = 
					(ShippingServiceOptionsTypeCollection)this.listViewCalcShippingService.GetShippingServiceOptions();
			}
		}

		private void SetSalesTaxInfo(ItemType item)
		{
			string salesTaxState = ((ControlTagItem)this.cbxSalesTaxState.SelectedItem).Tag.ToString();
			if (!salesTaxState.Equals("No Sales Tax")) 
			{
				SalesTaxType salesTax = new SalesTaxType();
				item.ShippingDetails.SalesTax = salesTax;
				salesTax.SalesTaxState = salesTaxState;
				salesTax.SalesTaxPercent = float.Parse(this.txtTaxPercent.Text);
				salesTax.ShippingIncludedInTax = this.chkApplySalesTaxToTotal.Checked;
			}
		}

		private void InitSessionContext()
		{
			this.apiContext = AppSettingHelper.GetApiContext();
			this.apiContext.Site = SiteCodeType.US;

            string logFile = System.Configuration.ConfigurationManager.AppSettings.Get(AppSettingHelper.LOG_FILE_NAME);
			if (logFile != null) 
			{
				ApiLogManager apiLogManager = new ApiLogManager();
				apiLogManager.ApiLoggerList.Add(new eBay.Service.Util.FileLogger(logFile, true, true, true));
				apiLogManager.EnableLogging = true;
				this.apiContext.ApiLogManager = apiLogManager;
			}
		}

		private void SetFormInfo()
		{
			switch (this.tabControl1.SelectedIndex) 
			{
				case 1:
					string info = "Double click the cell of the Shipping Service List View to add/edit a property of the \"Shipping Service\".\n\n" +
						"Use key \"Delete\" to remove a selected \"Shipping Service\".";
					if (this.rbtnCalculatedShippingRates.Checked) 
					{
						info = info + "\n\n" + "Dimensions are required for certain Package Sizes for \"Calculated Rate Shippings\".";
					}
					this.lbEditInfo.Text = info;
					break;
				case 2:
					this.lbEditInfo.Text = "All inputs on this page are optional.";
					break;
				default:
					this.lbEditInfo.Text = "All inputs on this page are required except for the followings:\n\n (1) Reserve Price\n (2) BIN Price \n (3) Ship To Locations";
					break;
			}
		}

		private void btnAddItem_Click(object sender, System.EventArgs e)
		{
			this.txteBayTime.Text = "";
			this.txtError.Text = "In progress...";
			this.txtItemId.Text = "";

			AddItemCall api = null;

			try
			{
				ItemType item = GetItem();
				
				SetItemDetails(item);
				SetItemShipToLocations(item);
				this.SetShippingServiceOptions(item);

				//set insurance and tax for both flat and calculated type
				//SetInsuranceOptions(item);
				SetSalesTaxInfo(item);
				if (this.rbtnCalculatedShippingRates.Checked) 
				{
					SetCalculatedShippingDetails(item);
				}

				api = new AddItemCall(this.apiContext);
				api.AddItem(item);

				if (api.HasError) 
				{
					this.txtError.Text = api.ApiException.Message.ToString();
				}
				else 
				{
					this.txtItemId.Text = api.Item.ItemID;
					this.txtError.Text = api.ApiResponse.Ack.ToString();
				}
				
			}
			catch (Exception ex)
			{
				if (api != null) 
				{
					this.txtError.Text = api.ApiException.Message.ToString();
				}
				else 
				{
					this.txtError.Text = ex.Message.ToString();
				}
			}
			finally 
			{
				if (api != null && api.ApiResponse != null) 
				{
					this.txteBayTime.Text = api.ApiResponse.Timestamp.ToString();
				}
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide();
			this.Dispose();
		}

		private void rbtnFlatShippingRates_CheckedChanged(object sender, System.EventArgs e)
		{
			this.panelFlatRateShippingBase.Visible = true;
			this.panelCalculateRateShippingBase.Visible = false;
			//this.txtInsuranceFee.Enabled = true;
			this.lbShippingType.Text = "Flat Rate Shipping";
			SetFormInfo();
		}

		private void rbtnCalculatedShippingRates_CheckedChanged(object sender, System.EventArgs e)
		{
			this.panelFlatRateShippingBase.Visible = false;
			this.panelCalculateRateShippingBase.Visible = true;
			//this.txtInsuranceFee.Enabled = false;
			this.lbShippingType.Text = "Calculated Rate Shipping";			
			SetFormInfo();
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetFormInfo();
			if (this.tabControl1.SelectedIndex == 1) 
			{
				if (!this.rbtnCalculatedShippingRates.Checked && !this.rbtnFlatShippingRates.Checked) 
				{
					this.rbtnFlatShippingRates.Checked = true;
				}
			}
		}

		private void cbxWeightMeasurement_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.tabControl1.SelectedIndex == 1) 
			{
				if (this.cbxWeightMeasurement.SelectedIndex == 0) 
				{
					this.lbWeightMajor.Text = "Pounds:";
					this.lbWeightMinor.Text = "Ounces:";
				}
				else 
				{
					this.lbWeightMajor.Text = "Kilograms:";
					this.lbWeightMinor.Text = "Grams:";
				}
			}
          /*else if (this.tabControl1.SelectedIndex == 2) 
			{
				if (this.rbtnFlatShippingRates.Checked) 
				{
					this.txtInsuranceFee.Enabled = true;
				}
				else 
				{
					this.txtInsuranceFee.Enabled = false;
				}
			}*/
		}

		private void SetDefaultInputs()
		{
			this.txtDesc.Text = "Item Description";
			this.txtLocation.Text = "San Jose, CA";
			this.txtQuantity.Text = "1";
			this.txtTitle.Text = "Item Title";
			this.txtStartPrice.Text = "1";
		}
		
		
		private void cmbCategoryList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//has the categoryId changed.
			if(!selectedCategoryID.Equals(this.cmbCategoryList.SelectedItem.ToString()))
			{
				selectedCategoryID = this.cmbCategoryList.SelectedItem.ToString();
				UpdateCategoryFeatures();
				populateListingTypeFields();
				populateListingDuration();
				cbxListingType.SelectedItem=cbxListingType.Items[0];
				cbxDuration.SelectedItem=cbxDuration.Items[0];
			}
		
		}

		//change listingDuration while listingType changed
		private void cbxListingType_SelectedValueChanged(object sender, System.EventArgs e)
		{
			populateListingDuration();
			cbxDuration.SelectedItem=cbxDuration.Items[0];
		}

		private void UpdateCategoryFeatures()
		{
			string catid = this.cmbCategoryList.SelectedItem.ToString();
			listingType2DurationTable = CategoryFeatureManager.getListingType2DurationTable(catid);
			//pay methods
			defaultPayMethods = CategoryFeatureManager.getCatPaymentMethods(catid);
		}

		//get shippingToLocations controlTag
		private ControlTagItem[] getItemShipToLocationControlTags()
		{
			ShippingLocationDetailsTypeCollection shippingLocationCol =CategoryFeatureManager.GetShippingServices(apiContext).ShippingLocationDetails;
			ControlTagItem[] shippingLocations=null;

			if (shippingLocationCol!=null)
			{
				shippingLocations=new ControlTagItem[shippingLocationCol.Count];
				int index=0;

				foreach (ShippingLocationDetailsType shippingLocation in shippingLocationCol)
				{
					shippingLocations[index]=new ControlTagItem(shippingLocation.ShippingLocation,shippingLocation.ShippingLocation);
					index++;
				}
			}
			else
			{
				this.txtError.Text+="\nshippingToLocations data is empty!";
			}

			return shippingLocations;
		}

		//populate listingTypeFields
		private void populateListingTypeFields()
		{
			if (listingType2DurationTable!=null)
			{
				IDictionaryEnumerator myEnumerator=listingType2DurationTable.GetEnumerator();
				cbxListingType.Items.Clear();
				while (myEnumerator.MoveNext())
				{
                    if (myEnumerator.Key.Equals("Dutch")) continue;
                    if (myEnumerator.Key.Equals("PersonalOffer")) continue;
                    if (myEnumerator.Key.Equals("StoresFixedPrice")) continue;
					cbxListingType.Items.Add(myEnumerator.Key);
				}
			}
		}

		//populate listingDurationFields based on listingType fields
		private void populateListingDuration()
		{
			if (listingType2DurationTable!=null)
			{
				if (cbxListingType.SelectedItem!=null)
				{
					string key = cbxListingType.SelectedItem.ToString();
					StringCollection listingDurations=(StringCollection)listingType2DurationTable[key];
				
					cbxDuration.Items.Clear();
					foreach (string listingDuration in listingDurations)
					{
						cbxDuration.Items.Add(listingDuration);
					}
				}
			}
		}


		private void populateCategories()
		{
			//get all categories
			CategoryTypeCollection catCol = CategoryFeatureManager.GetAllCategories(apiContext);
			//sort the categories
			CategoryTypeCollection sortedCatCol = CategoryFeatureManager.SortCategories(catCol);

			foreach(CategoryType cat in sortedCatCol)
			{
				this.cmbCategoryList.Items.Add(cat.CategoryID);
			}

			//set default category
			this.cmbCategoryList.SelectedItem=this.cmbCategoryList.Items[0];
			selectedCategoryID = this.cmbCategoryList.SelectedItem.ToString();
		}

		private CurrencyCodeType DEFAULT_CURRENCY = CurrencyCodeType.USD;
		private CountryCodeType DEFAULT_COUNTRY = CountryCodeType.US;
		private BuyerPaymentMethodCodeTypeCollection defaultPayMethods;   
	}
}

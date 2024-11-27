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
using eBay.Service.Core.Soap;
using Samples.Helper.UI;

namespace Samples.Helper
{
	/// <summary>
	/// Summary description for ShippingServiceHelper.
	/// </summary>
	public class ShippingServiceHelper
	{
		private static ShippingServiceHelper _helper = new ShippingServiceHelper();

		Hashtable htFlatRateShippingServiceControlTagItems = new Hashtable();
		Hashtable htCalcRateShippingServiceControlTagItems = new Hashtable();
		Hashtable htIntlShippingServiceControlTagItems = new Hashtable();
		Hashtable htShippingPackageSizeControlTagItems = new Hashtable();
		Hashtable htInsuranceOptionControlTagItems = new Hashtable();
		Hashtable htStateControlTagItems = new Hashtable();
		Hashtable htItemShipToLocationControlTagItems = new Hashtable();
		Hashtable htServiceShipToLocationControlTagItems = new Hashtable();

		private ShippingServiceHelper()
		{
			Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static ShippingServiceHelper GetInstance()
		{
			return _helper;
		}

		private void Init()
		{
			InitShipToLocations();
			InitShippingServiceOptions();
			InitIntlShippingServiceOptions();
			InitPackageSizeOptions();
			InitSalesTaxStateOptions();
		}

		private void InitPackageSizeOptions()
		{
			ShippingPackageCodeType[] options = new ShippingPackageCodeType[]
			{
				ShippingPackageCodeType.None,
				ShippingPackageCodeType.LargeEnvelope,
				ShippingPackageCodeType.Letter,
				ShippingPackageCodeType.PackageThickEnvelope,
				ShippingPackageCodeType.UPSLetter,
				ShippingPackageCodeType.USPSFlatRateEnvelope,
				ShippingPackageCodeType.USPSLargePack,
				ShippingPackageCodeType.VeryLargePack
			};
			int len = options.Length;
			ControlTagItem[] items = new ControlTagItem[len];
			for (int i = 0; i < len; i++) 
			{
				items[i] = new ControlTagItem(options[i].ToString(), options[i]);
			}

			this.htShippingPackageSizeControlTagItems.Add(SiteCodeType.US, items);
		}

		private void InitShippingServiceOptions()
		{
			ShippingServiceCodeType[] options = 
				new ShippingServiceCodeType[] {
												  ShippingServiceCodeType.UPSGround,
												  ShippingServiceCodeType.UPS3rdDay,
												  ShippingServiceCodeType.UPS2ndDay,
												  ShippingServiceCodeType.UPSNextDay,
												  ShippingServiceCodeType.USPSPriority,
												  ShippingServiceCodeType.USPSParcel,
												  ShippingServiceCodeType.USPSMedia,
												  ShippingServiceCodeType.USPSFirstClass,
												  ShippingServiceCodeType.ShippingMethodStandard,
												  ShippingServiceCodeType.ShippingMethodExpress,
												  ShippingServiceCodeType.USPSExpressMail,
												  ShippingServiceCodeType.UPSNextDayAir,
												  ShippingServiceCodeType.UPS2DayAirAM,
												  ShippingServiceCodeType.LocalDelivery,
												  ShippingServiceCodeType.Other};
	
			int len = options.Length;
			ControlTagItem[] items = new ControlTagItem[len];
			for (int i = 0; i < len; i++) 
			{
				items[i] = new ControlTagItem(options[i].ToString(), options[i]);
			}
			this.htFlatRateShippingServiceControlTagItems.Add(SiteCodeType.US, items);
			this.htCalcRateShippingServiceControlTagItems.Add(SiteCodeType.US, items);
		}

		private void InitIntlShippingServiceOptions()
		{
			ShippingServiceCodeType[] options = 
				new ShippingServiceCodeType[] {
												  ShippingServiceCodeType.StandardInternational,
												  ShippingServiceCodeType.ExpeditedInternational,
												  ShippingServiceCodeType.USPSGlobalExpress,
												  ShippingServiceCodeType.USPSGlobalPriority,
												  ShippingServiceCodeType.USPSEconomyParcel,
												  ShippingServiceCodeType.USPSEconomyLetter,
												  ShippingServiceCodeType.USPSAirmailLetter,
												  ShippingServiceCodeType.USPSAirmailParcel,
												  ShippingServiceCodeType.UPSWorldWideExpressPlus,
												  ShippingServiceCodeType.UPSWorldWideExpress,
												  ShippingServiceCodeType.UPSWorldWideExpedited,
												  ShippingServiceCodeType.UPSStandardToCanada,
												  ShippingServiceCodeType.OtherInternational
											  };

			int len = options.Length;
			ControlTagItem[] items = new ControlTagItem[len];
			for (int i = 0; i < len; i++) 
			{
				items[i] = new ControlTagItem(options[i].ToString(), options[i]);
			}
			this.htIntlShippingServiceControlTagItems.Add(SiteCodeType.US, items);
		}

		private void InitSalesTaxStateOptions()
		{
			string [] options = new string[] {
												"No Sales Tax", "No Sales Tax",
												"Alabama", "AL",
												"Alaska", "AK",
												"Arizona", "AZ",
												"Arkansas", "AR",
												"California", "CA",
												"Colorado", "CO",
												"Connecticut", "CT",
												"Delaware", "DE",
												"Dist Columbia", "DC",
												"Florida", "FL",
												"Georgia", "GA",
												"Hawaii", "HI",
												"Idaho", "ID",
												"Illinois", "IL",
												"Indiana", "IN",
												"Iowa", "IA",
												"Kansas", "KS",
												"Kentucky", "KY",
												"Louisiana", "LA",
												"Maine", "ME",
												"Maryland", "MD",
												"Massachusetts", "MA",
												"Michigan", "MI",
												"Minnesota", "MN",
												"Mississippi", "MS",
												"Missouri", "MO",
												"Montana", "NT",
												"Nebraska", "NE",
												"Nevada", "NV",
												"New Hampshire", "NH",
												"New Jersey", "NJ",
												"New Mexico", "NM",
												"New York", "NY",
												"North Carolina", "NC",
												"North Dakota", "ND",
												"Ohio", "OH",
												"Oklahoma", "OK",
												"Oregon", "OR",
												"Pennsylvania", "PA",
												"Rhode Island", "RI",
												"South Carolina","SC",
												"South Dakota", "SD",
												"Tennessee", "TN",
												"Texas", "TX",
												"Utah", "UT",
												"Vermont", "VT",
												"Virginia", "VA",
												"Washington", "WA",
												"West Virginia", "WV",
												"Wisconsin", "WI",
												"Wyoming", "WY"};
			int len = options.Length/2;
			ControlTagItem[] items = new ControlTagItem[len];
			for (int i = 0; i < len; i++) 
			{
				items[i] = new ControlTagItem(options[i*2], options[i*2 + 1]);
			}
			this.htStateControlTagItems.Add(SiteCodeType.US, items);
		}

		/// <summary>
		/// 
		/// </summary>
		public void InitShipToLocations()
		{
			ControlTagItem[] items = 
				new ControlTagItem[] {new ControlTagItem("Worldwide","Worldwide"),
										 new ControlTagItem("Americas","Americas"),
										 new ControlTagItem("Europe","Europe"),
										 new ControlTagItem("Asia","Asia"),
										 new ControlTagItem("Canada","CA"),
										 new ControlTagItem("United Kingdom","GB"),
										 new ControlTagItem("Australia","AU"),
										 new ControlTagItem("Mexico","MX"),
										 new ControlTagItem("Germany","DE"),
										 new ControlTagItem("Japan","JP"),
										 new ControlTagItem("Will Not Ship","None")};

			this.htItemShipToLocationControlTagItems.Add(SiteCodeType.US, items);

			items = 
				new ControlTagItem[] {new ControlTagItem("Worldwide","Worldwide"),
										 new ControlTagItem("Americas","Americas"),
										 new ControlTagItem("Europe","Europe"),
										 new ControlTagItem("Asia","Asia"),
										 new ControlTagItem("Canada","CA"),
										 new ControlTagItem("United Kingdom","GB"),
										 new ControlTagItem("Australia","AU"),
										 new ControlTagItem("Mexico","MX"),
										 new ControlTagItem("Germany","DE"),
										 new ControlTagItem("Japan","JP")};

			this.htServiceShipToLocationControlTagItems.Add(SiteCodeType.US, items);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public ControlTagItem [] GetShippingServiceControlTagItems(SiteCodeType site, ShippingTypeCodeType type)
		{
			if (type == ShippingTypeCodeType.Calculated) 
			{
				return (ControlTagItem[])this.htCalcRateShippingServiceControlTagItems[site];
			}
			else 
			{
				return (ControlTagItem[])this.htFlatRateShippingServiceControlTagItems[site];
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <returns></returns>
		public ControlTagItem[] GetInternationalShippingServiceControlTagItems(SiteCodeType site)
		{
			return (ControlTagItem[])this.htIntlShippingServiceControlTagItems[site];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <returns></returns>
		public ControlTagItem[] GetInsuranceOptionControlTagItems(SiteCodeType site)
		{
			return (ControlTagItem[])this.htInsuranceOptionControlTagItems[site];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <returns></returns>
		public ControlTagItem[] GetShippingPackSizeControlTagItems(SiteCodeType site)
		{
			return (ControlTagItem[])this.htShippingPackageSizeControlTagItems[site];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <returns></returns>
		public ControlTagItem[] GetStateControlTagItems(SiteCodeType site)
		{
			return (ControlTagItem[])this.htStateControlTagItems[site];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <returns></returns>
		public ControlTagItem[] GetItemShipToLocationControlTagItems(SiteCodeType site)
		{
			return (ControlTagItem[])this.htItemShipToLocationControlTagItems[site];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <returns></returns>
		public ControlTagItem[] GetServiceShipToLocationControlTagItems(SiteCodeType site)
		{
			return (ControlTagItem[])this.htServiceShipToLocationControlTagItems[site];
		}
	}
}

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
	/// Summary description for PaymentServiceHelper.
	/// </summary>
	public class PaymentServiceHelper
	{
		private static PaymentServiceHelper _helper = new PaymentServiceHelper();

		Hashtable htPaymentMethods = new Hashtable();

		private PaymentServiceHelper()
		{
			Init();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static PaymentServiceHelper GetInstance()
		{
			return _helper;
		}

		private void Init()
		{
			InitPaymentMethods();
		}

		private void InitPaymentMethods()
		{
			ControlTagItem[] items = new ControlTagItem[] {
																  new ControlTagItem("Money Order or Cashier's Check", BuyerPaymentMethodCodeType.MOCC),
																  new ControlTagItem("Personal Check", BuyerPaymentMethodCodeType.PersonalCheck),
																  new ControlTagItem("Visa or Master Card", BuyerPaymentMethodCodeType.VisaMC),
																  new ControlTagItem("American Express", BuyerPaymentMethodCodeType.AmEx),
																  new ControlTagItem("Discover Card", BuyerPaymentMethodCodeType.Discover),
																  new ControlTagItem("Payment Option See Description", BuyerPaymentMethodCodeType.PaymentSeeDescription),
																  new ControlTagItem("PayPal", BuyerPaymentMethodCodeType.PayPal)};	
			this.htPaymentMethods.Add(SiteCodeType.US, items);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="site"></param>
		/// <returns></returns>
		public ControlTagItem[] GetPaymentMethods(SiteCodeType site)
		{
			return (ControlTagItem[])this.htPaymentMethods[site];
		}
	}
}

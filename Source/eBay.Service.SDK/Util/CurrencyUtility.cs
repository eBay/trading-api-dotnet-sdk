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
using System;
using System.Collections;
using eBay.Service.Core.Soap;
using System.Runtime.InteropServices;
#endregion

namespace eBay.Service.Util
{

    /// <summary>
    /// 
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class CurrencyUtility
    {

        #region Static Methods

        /// <summary>
        /// Gets the currency symbol from the CurrencyCodeType
        /// </summary>
        /// <param name="currency">a CurrencyCodeType to get symbol from</param>
        /// <returns>a currency symbol</returns>
        public static string GetCurrencySymbol(CurrencyCodeType currency)
        {
            switch (currency)
            {
                case CurrencyCodeType.USD:
                    return "$";
                default:
                    return "(" + Enum.GetName(typeof(CurrencyCodeType), currency) + ")";
            }
        }

        /// <summary>
        /// return the string representation of the AmountType
        /// </summary>
        /// <param name="amt">amount</param>
        /// <returns>string representation of the amount</returns>
        public static string GetAmountString(AmountType amt)
        {
            if (amt == null) return "";
            string currencySymbol = GetCurrencySymbol(amt.currencyID);
            return currencySymbol + amt.Value;
        }

        /// <summary>
        /// return the AmountType object from an amount string in following format:
        ///		$amt or (LBP)amt
        /// </summary>
        /// <param name="amtStr">an amount string</param>
        /// <returns>an AmountType</returns>
        public static AmountType GetAmountType(string amtStr)
        {
            if (amtStr == null || amtStr.Trim().Length == 0)
                return null;
            if (amtStr.StartsWith("$"))
            {
                string v = amtStr.Substring(1, amtStr.Length - 1);
                AmountType amt = new AmountType();
                amt.currencyID = CurrencyCodeType.USD;
                amt.Value = Convert.ToDouble(v);
                return amt;
            }
            else
            {
                int idx = amtStr.IndexOf(")");
                if (idx > 0)
                {
                    string v = amtStr.Substring(idx + 1, amtStr.Length - idx - 1);
                    AmountType amt = new AmountType();
                    string symbol = amtStr.Substring(1, idx - 1);
                    amt.currencyID = (CurrencyCodeType)Enum.Parse(typeof(CurrencyCodeType), symbol);
                    amt.Value = Convert.ToDouble(v);
                    return amt;
                }
                else
                {
                    AmountType amt = new AmountType();
                    amt.currencyID = CurrencyCodeType.USD;
                    amt.Value = Convert.ToDouble(amtStr);
                    return amt;
                }
            }
        }

        /// <summary>
        /// Gets the default <see cref="CurrencyCodeType"/> associated with a site.
        /// </summary>
        /// <param name="SiteCodeType">The <see cref="SiteCodeType"/>.</param>
        /// <returns>The <see cref="CurrencyCodeType"/>.</returns>
        public static CurrencyCodeType GetDefaultCurrencyCodeType(SiteCodeType SiteCodeType)
        {
            CurrencyCodeType curr;
            switch (SiteCodeType)
            {
                case SiteCodeType.US:
                case SiteCodeType.eBayMotors:
                    curr = CurrencyCodeType.USD;
                    break;
                case SiteCodeType.UK:
                    curr = CurrencyCodeType.GBP;
                    break;
                case SiteCodeType.Canada:
                    curr = CurrencyCodeType.CAD;
                    break;
                case SiteCodeType.Australia:
                    curr = CurrencyCodeType.AUD;
                    break;
                case SiteCodeType.Taiwan:
                    curr = CurrencyCodeType.TWD;
                    break;
                case SiteCodeType.Switzerland:
                    curr = CurrencyCodeType.CHF;
                    break;
                case SiteCodeType.HongKong:
                    curr = CurrencyCodeType.HKD;
                    break;
                case SiteCodeType.Singapore:
                    curr = CurrencyCodeType.SGD;
                    break;
                case SiteCodeType.Malaysia:
                    curr = CurrencyCodeType.MYR;
                    break;
                case SiteCodeType.Philippines:
                    curr = CurrencyCodeType.PHP;
                    break;
                case SiteCodeType.China:
                    curr = CurrencyCodeType.CNY;
                    break;
                case SiteCodeType.India:
                    curr = CurrencyCodeType.INR;
                    break;
                case SiteCodeType.France:
                case SiteCodeType.Germany:
                case SiteCodeType.Italy:
                case SiteCodeType.Netherlands:
                case SiteCodeType.Belgium_Dutch:
                case SiteCodeType.Belgium_French:
                case SiteCodeType.Austria:
                case SiteCodeType.Spain:
                case SiteCodeType.Ireland:
                    curr = CurrencyCodeType.EUR;
                    break;
                case SiteCodeType.Poland:
                    curr = CurrencyCodeType.PLN;
                    break;

                default:
                    curr = CurrencyCodeType.USD;
                    break;
            }
            return curr;
        }


        /// <summary>
        /// Gets the <see cref="CurrencyCodeType"/> associated with a numeric currency id.
        /// </summary>
        /// <param name="CurrencyID">The numeric currency id.</param>
        /// <returns>The <see cref="CurrencyCodeType"/>.</returns>
        public static CurrencyCodeType GetCurrencyCodeType(int CurrencyID)
        {
            if (!Enum.IsDefined(typeof(CurrencyValueEnum), CurrencyID))
                return CurrencyCodeType.CustomCode;
            else
                return ((CurrencyCodeType)Enum.Parse(typeof(CurrencyCodeType), Enum.GetName(typeof(CurrencyValueEnum), CurrencyID)));

        }

        /// <summary>
        /// Gets the numeric currency id of a <see cref="CurrencyCodeType"/>.
        /// </summary>
        /// <param name="CurrencyCodeType">The <see cref="CurrencyCodeType"/>.</param>
        /// <returns>The numeric id associated with the <see cref="CurrencyCodeType"/>.</returns>
        public static int GetCurrencyID(CurrencyCodeType CurrencyCodeType)
        {
            if (!Enum.IsDefined(typeof(CurrencyValueEnum), CurrencyCodeType.ToString()))
                return -1;
            else
                return (int)Enum.Parse(typeof(CurrencyValueEnum), Enum.GetName(typeof(CurrencyCodeType), CurrencyCodeType));

        }
        #endregion

        #region Private Enumerations
        /// <summary>
        /// 
        /// </summary>
        private enum CurrencyValueEnum
        {
            AUD = 5,
            CAD = 2,
            CHF = 13,
            CNY = 14,
            EUR = 7,
            GBP = 3,
            HKD = 39,
            INR = 44,
            MYR = 46,
            PHP = 34,
            SGD = 22,
            TWD = 41,
            USD = 1,
        }
        #endregion

    }
}










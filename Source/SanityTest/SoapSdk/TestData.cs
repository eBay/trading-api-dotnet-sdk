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
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
#endregion

namespace AllTestsSuite
{

	public class TestData 
	{

		public static ItemType NewItem = null;
		public static ItemType NewFixedPriceItem = null;
		public static ItemType NewItem2 = null;//it is new, this item contains more information than NewItem.
		public static ItemType EndedItem = null;
		public static ItemType EndedFixedPriceItem = null;
		public static ItemType EndedItem2 = null; //it is new, it is used for ending NewItem2.
		public static ItemType WatchedItem = null;
		public static ItemType ChineseAuctionItem = null;// it is new, it is used for Dutch Action
		public static ItemType AdFormatItem = null;// it is new, it is used for Dutch Action

		public static CategoryTypeCollection Categories = null;
		public static CategoryTypeCollection Category2CS = null;
		public static CategoryType Category2CS2 = null;//It is new.
		public static ItemTypeCollection CategoryListings = null;

		public static StoreType Store = null;

		public static GetUserPreferencesResponseType UserPreferencesResponse = null;

		public static TaxJurisdictionTypeCollection TaxTable = null;

		public static GetNotificationPreferencesResponseType NotificationPreferencesResponse = null;

		public static MemberMessageExchangeTypeCollection MemberMessages = null;

		public static TransactionTypeCollection SellerTransactions = null;

		//public static PictureManagerDetailsType PictureManagerDetails = null; This call is deprecated - By Devanathan 9th Apr 2013

        //public static PromotionRuleType ItemPromotionRule = null;

        //public static ProductSearchPageTypeCollection ProductSearchPages = null;
        //public static ProductSearchPageTypeCollection ProductSearchPages2 = null;// It is new

        public static StringCollection itemIds = null;//cache ids which return from AddItems call 

        //public static ProductSearchResultTypeCollection ProductSearchResults = null;
        //public static ProductSearchResultTypeCollection ProductSearchResults2 = null;// it is new
		public static string AudioChallengeURL = null;
		public static string ChallengeToken = null;
		public static string ImageChallengeURL = null;
		public static long CartID = 0;

		public static string ApiUserID="apitest11";
        public static string BuyerToken = "AgAAAA**AQAAAA**aAAAAA**FcP3Sg**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wJnY+gD5iFoA+dj6x9nY+seQ**tgAAAA**AAMAAA**B+c0eBpWnTZH6Y/MMuij7Zd1ySMgPzJt+wN7gWp3S7UuD8q+9rgaGJ2LUx3xYzG76BHvf++YNXCIaMLjuoC509GpkLwFhALZcwby7ak9JIxdhrLcVlu7sp9bo/dGqwhRaYYT7Dk6MzLvK7dQmqAGP6ON+tS96KXQzeGffSHwSfPIh/f5Wbcb3JazL9Ot10+jyV354wdOF+tdDs2zUNBKmKQkGzsyXvW40kvhD6Ia9Bj7aWhEzYjd1vf7fVUxMUg0PRBb1yaZhXlhuN+L6hnK9XxMtewrOu9QyjNMOqHp99EOfWMo8uINoNXzafw+u4luJ99wdOmhmKYc7hGaFO1MGirV52tOjWHT87ZmLmplnQFZjO5EeMKnAnOjTjeldSJPLTNGFBKFQPHWwA91W27ze7LzqN/53/f9L/cokA+AEhx8awNSqFAg2usihGWusghq10qCN9bjbe+2ReTVh9naU9SU1VGhwPRmZwxhqfyziZQrb/r5+eYRX2kKG1q25DmpyXEc4uvdFgaH4d3eSRlW+aKEDRzjTo2n6umuvV62DXvPin0uWaJ4ZQRR6wJ6P/AlCTR7tEvuONIWfNo7yE9EYXQQNSgldn4l57mRLP1K/9lNOOGeU8PhOFY91GHH8tVynvCtEO6hoQ0p/El+CYIUs5owgGZ7fJOd3OhlmdNWS/eMxVgD/avT+apevYAhzALNv6LbD/2xtzB9QoMeAyNtqbSRpJGsEQE1586ORIoas6UjR3GUPtFRlax0sVueBGac";

		#region static fields & properties for selling manager

		private static long folder_id1 = long.MinValue;
		public static long Folder_id1
		{
			get
			{
				return folder_id1;
			}
			set
			{
				folder_id1=value;
			}
		}

		private static long folder_id2 = long.MinValue;
		public static long Folder_id2
		{
			get
			{
				return folder_id2;
			}
			set
			{
				folder_id2=value;
			}
		}

		private static long saleTemplateId = long.MinValue;
		public static long SaleTemplateId
		{
			get
			{
				return saleTemplateId;
			}
			set
			{
				saleTemplateId=value;
			}
		}

		private static long productId = long.MinValue;
		public static long ProductId
		{
			get
			{
				return productId;
			}
			set
			{
				productId=value;
			}
		}

		private static string itemId = string.Empty;
		public static string ItemId
		{
			get
			{
				return itemId;
			}
			set
			{
				itemId=value;
			}
		}

		private static string soldItemId = string.Empty;
		public static string SoldItemId
		{
			get
			{
				return soldItemId;
			}
			set
			{
				soldItemId=value;
			}
		}

		#endregion
	}
}

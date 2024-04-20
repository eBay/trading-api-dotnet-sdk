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
using System.Runtime.InteropServices;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.EPS;
using eBay.Service.Util;

#endregion

namespace eBay.Service.Call
{

	/// <summary>
	/// 
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class GetAccountCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetAccountCall()
		{
			ApiRequest = new GetAccountRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetAccountCall(ApiContext ApiContext)
		{
			ApiRequest = new GetAccountRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Returns a seller's invoice data for their eBay account, including the account's
		/// summary data.
		/// </summary>
		/// 
		/// <param name="AccountHistorySelection">
		/// Specifies the report format in which to return account entries.
		/// </param>
		///
		/// <param name="InvoiceDate">
		/// This field is used to retrieve all account entries from a specific invoice, which is identified through this <b>InvoiceDate</b> field with the timestamp of the account invoice. This field is only applicable if the  <b>AccountHistorySelection</b> value is set to 'SpecifiedInvoice'; otherwise, this field will be ignored.
		/// </param>
		///
		/// <param name="BeginDate">
		/// This field is used to retrieve all account entries dating back to the timestamp passed into this <b>BeginDate</b> field up until the timestamp passed into the <b>EndDate</b> field. The <b>BeginDate</b> value can not be set back any further than four months into the past.
		/// <br/><br/>
		/// The allowed date formats are <em>YYYY-MM-DD</em> and <em>YYYY-MM-DD HH:mm:ss</em> The <b>BeginDate</b> value must be less than or equal to the <b>EndDate</b> value. The user might use the same values in both fields if that user wanted to retrieve all account entries from a specific day (if <em>YYYY-MM-DD</em> format used) or wanted to retrieve a specific account entry (if <em>YYYY-MM-DD HH:mm:ss</em> format used).
		/// <br/><br/>
		/// This field is only applicable if the  <b>AccountHistorySelection</b> value is set to 'BetweenSpecifiedDates'; otherwise, this field will be ignored. fiedDates' is used, both the <b>BeginDate</b> and <b>EndDate</b> must be included.
		/// </param>
		///
		/// <param name="EndDate">
		/// This field is used to retrieve all account entries dating up to the timestamp passed into this <b>EndDate</b> field dating back to the timestamp passed into the <b>BeginDate</b> field. The <b>EndDate</b> value can not be set for a future date.
		/// <br/><br/>
		/// The allowed date formats are <em>YYYY-MM-DD</em> and <em>YYYY-MM-DD HH:mm:ss</em> The <b>EndDate</b> value must be more than or equal to the <b>BeginDate</b> value. The user might use the same values in both fields if that user wanted to retrieve all account entries from a specific day (if <em>YYYY-MM-DD</em> format used) or wanted to retrieve a specific account entry (if <em>YYYY-MM-DD HH:mm:ss</em> format used).
		/// <br/><br/>
		/// This field is only applicable if the  <b>AccountHistorySelection</b> value is set to 'BetweenSpecifiedDates'; otherwise, this field will be ignored. If 'BetweenSpecifiedDates' is used, both the <b>BeginDate</b> and <b>EndDate</b> must be included.
		/// </param>
		///
		/// <param name="Pagination">
		/// This container is used to control how many account entries are returned on each page of data in the response. <b>PaginationType</b> is used by numerous Trading API calls, and the default and maximum values for the <b>EntriesPerPage</b> field differs with each call. For the <b>GetAccount</b> call, the default value is 500 (account entries) per page, and maximum allowed value is 2000 (account entries) per page.
		/// </param>
		///
		/// <param name="ExcludeBalance">
		/// By default, the current balance of the user's account will not be returned in the call response. To retrieve the current balance of their account, the user should include the <b>ExcludeBalance</b> flag in the request and set its value to 'false'. The current balance on the account will be shown in the <b>AccountSummary.CurrentBalance</b> field in the call response.
		/// </param>
		///
		/// <param name="ExcludeSummary">
		/// Specifies whether to return account summary information in an
		/// AccountSummary node. Default is true, to return AccountSummary.
		/// </param>
		///
		/// <param name="IncludeConversionRate">
		/// Specifies whether to retrieve the rate used for the currency conversion for usage transactions.
		/// </param>
		///
		/// <param name="AccountEntrySortType">
		/// Specifies how account entries should be sorted in the response, by an
		/// element and then in ascending or descending order.
		/// </param>
		///
		/// <param name="Currency">
		/// Specifies the currency used in the account report. Do not specify Currency
		/// in the request unless the following conditions are met. First, the user has
		/// or had multiple accounts under the same UserID. Second, the account
		/// identified in the request uses the currency you specify in the request. An
		/// error is returned if no account is found that uses the currency you specify
		/// in the request.
		/// </param>
		///
		/// <param name="ItemID">
		/// Specifies the item ID for which to return account entries. If ItemID is
		/// used, all other filters in the request are ignored. If the specified item
		/// does not exist or if the requesting user is not the seller of the item, an
		/// error is returned.
		/// </param>
		///
		/// <param name="OrderID">
		/// The unique identifier of an eBay order. This field must be included if the value of the <b>AccountHistorySelection</b> filter is set to <code>OrderId</code>. A user can filter by order ID to see if there specific account entries related to a specific eBay order.
		/// 
		/// It is possible that no account entries will be found directly related to the specified order ID, and if this is the case, no <b>AccountEntries</b> container will be returned, and the <b>ack</b> value will still be <code>Success</code>.
		/// 
		/// <span class="tablenote"><b>Note: </b> In June 2019, eBay introduced a new order ID format to both legacy (including Trading API) and REST-based APIs. At this time, both old and new format order IDs will be accepted in legacy API request payloads to identify orders. In legacy API response payloads, order IDs will appear in the new format if the user is using a Trading WSDL version of '1113' (or newer), or if the user sets the <code>X-EBAY-API-COMPATIBILITY-LEVEL</code> HTTP header to a value of '1113' (or newer). If the Trading WSDL version or compatibility level is less/older than '1113', old format order IDs will be returned in legacy API response payloads. Beginning as soon as March 2020, only new format order IDs will be returned regardless of version number.
		/// </span>
		/// </param>
		///
		public AccountEntryTypeCollection GetAccount(AccountHistorySelectionCodeType AccountHistorySelection, DateTime InvoiceDate, DateTime BeginDate, DateTime EndDate, PaginationType Pagination, bool ExcludeBalance, bool ExcludeSummary, bool IncludeConversionRate, AccountEntrySortTypeCodeType AccountEntrySortType, CurrencyCodeType Currency, string ItemID, string OrderID)
		{
			this.AccountHistorySelection = AccountHistorySelection;
			this.InvoiceDate = InvoiceDate;
			this.BeginDate = BeginDate;
			this.EndDate = EndDate;
			this.Pagination = Pagination;
			this.ExcludeBalance = ExcludeBalance;
			this.ExcludeSummary = ExcludeSummary;
			this.IncludeConversionRate = IncludeConversionRate;
			this.AccountEntrySortType = AccountEntrySortType;
			this.Currency = Currency;
			this.ItemID = ItemID;
			this.OrderID = OrderID;

			Execute();
			return ApiResponse.AccountEntries.AccountEntry;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public AccountEntryTypeCollection GetAccount(AccountHistorySelectionCodeType AccountHistorySelection)
		{
			this.AccountHistorySelection = AccountHistorySelection;
			Execute();
			return AccountEntryList;
		}

		#endregion




		#region Properties
		/// <summary>
		/// The base interface object.
		/// </summary>
		/// <remarks>This property is reserved for users who have difficulty querying multiple interfaces.</remarks>
		public ApiCall ApiCallBase
		{
			get { return this; }
		}

		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType"/> for this API call.
		/// </summary>
		public GetAccountRequestType ApiRequest
		{ 
			get { return (GetAccountRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetAccountResponseType"/> for this API call.
		/// </summary>
		public GetAccountResponseType ApiResponse
		{ 
			get { return (GetAccountResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.AccountHistorySelection"/> of type <see cref="AccountHistorySelectionCodeType"/>.
		/// </summary>
		public AccountHistorySelectionCodeType AccountHistorySelection
		{ 
			get { return ApiRequest.AccountHistorySelection; }
			set { ApiRequest.AccountHistorySelection = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.InvoiceDate"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime InvoiceDate
		{ 
			get { return ApiRequest.InvoiceDate; }
			set { ApiRequest.InvoiceDate = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.BeginDate"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime BeginDate
		{ 
			get { return ApiRequest.BeginDate; }
			set { ApiRequest.BeginDate = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.EndDate"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime EndDate
		{ 
			get { return ApiRequest.EndDate; }
			set { ApiRequest.EndDate = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.Pagination"/> of type <see cref="PaginationType"/>.
		/// </summary>
		public PaginationType Pagination
		{ 
			get { return ApiRequest.Pagination; }
			set { ApiRequest.Pagination = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.ExcludeBalance"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ExcludeBalance
		{ 
			get { return ApiRequest.ExcludeBalance; }
			set { ApiRequest.ExcludeBalance = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.ExcludeSummary"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ExcludeSummary
		{ 
			get { return ApiRequest.ExcludeSummary; }
			set { ApiRequest.ExcludeSummary = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.IncludeConversionRate"/> of type <see cref="bool"/>.
		/// </summary>
		public bool IncludeConversionRate
		{ 
			get { return ApiRequest.IncludeConversionRate; }
			set { ApiRequest.IncludeConversionRate = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.AccountEntrySortType"/> of type <see cref="AccountEntrySortTypeCodeType"/>.
		/// </summary>
		public AccountEntrySortTypeCodeType AccountEntrySortType
		{ 
			get { return ApiRequest.AccountEntrySortType; }
			set { ApiRequest.AccountEntrySortType = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.Currency"/> of type <see cref="CurrencyCodeType"/>.
		/// </summary>
		public CurrencyCodeType Currency
		{ 
			get { return ApiRequest.Currency; }
			set { ApiRequest.Currency = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiRequest.OrderID; }
			set { ApiRequest.OrderID = value; }
		}
				/// <summary>
		/// Gets or sets the <see cref="GetAccountRequestType.BeginDate"/> and <see cref="GetAccountRequestType.EndDate"/> of type <see cref="TimeFilter"/>.
		/// </summary>
		public TimeFilter StartTimeFilter
		{ 
			get 
			{ 
				return new TimeFilter(ApiRequest.BeginDate, ApiRequest.EndDate); 
			}
			set 
			{ 
				if (value.TimeFrom > DateTime.MinValue)
					ApiRequest.BeginDate = value.TimeFrom;

				if (value.TimeTo > DateTime.MinValue)
					ApiRequest.EndDate = value.TimeTo;
			}
		}
		
		/// <summary>
		/// Gets the <see cref="GetAccountResponseType.AccountEntries.AccountEntry"/> of type <see cref="AccountEntryList"/>.
		/// </summary>
		public AccountEntryTypeCollection AccountEntryList
		{ 
			get 
			{
				if (ApiResponse.AccountEntries != null)
					return ApiResponse.AccountEntries.AccountEntry; 
				else
					return null;
			}
		}


		
 		/// <summary>
		/// Gets the returned <see cref="GetAccountResponseType.AccountID"/> of type <see cref="string"/>.
		/// </summary>
		public string AccountID
		{ 
			get { return ApiResponse.AccountID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAccountResponseType.AccountSummary"/> of type <see cref="AccountSummaryType"/>.
		/// </summary>
		public AccountSummaryType AccountSummary
		{ 
			get { return ApiResponse.AccountSummary; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAccountResponseType.AccountEntries"/> of type <see cref="AccountEntriesType"/>.
		/// </summary>
		public AccountEntriesType AccountEntries
		{ 
			get { return ApiResponse.AccountEntries; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAccountResponseType.PaginationResult"/> of type <see cref="PaginationResultType"/>.
		/// </summary>
		public PaginationResultType PaginationResult
		{ 
			get { return ApiResponse.PaginationResult; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAccountResponseType.HasMoreEntries"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HasMoreEntries
		{ 
			get { return ApiResponse.HasMoreEntries; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAccountResponseType.EntriesPerPage"/> of type <see cref="int"/>.
		/// </summary>
		public int EntriesPerPage
		{ 
			get { return ApiResponse.EntriesPerPage; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetAccountResponseType.PageNumber"/> of type <see cref="int"/>.
		/// </summary>
		public int PageNumber
		{ 
			get { return ApiResponse.PageNumber; }
		}
		

		#endregion

		
	}
}

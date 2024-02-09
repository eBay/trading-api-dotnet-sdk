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
	public class GetMyeBaySellingCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetMyeBaySellingCall()
		{
			ApiRequest = new GetMyeBaySellingRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetMyeBaySellingCall(ApiContext ApiContext)
		{
			ApiRequest = new GetMyeBaySellingRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves information regarding the user's selling activity, such as items that the user is currently selling (the Active list), auction listings that have bids, sold items, and unsold items.
		/// </summary>
		/// 
		/// <param name="ScheduledList">
		/// Include this container and set the <b>ScheduledList.Include</b> field to <code>true</code> to return the list of items that are scheduled to become active listings on eBay.com at a future date/time.
		/// 
		/// The user also has the option of using pagination and sorting for the list of Scheduled listings that will be returned.
		/// </param>
		///
		/// <param name="ActiveList">
		/// Include this container and set the <b>ActiveList.Include</b> field to <code>true</code> to return the list of active listings on eBay.com.
		/// 
		/// The user also has the option of using pagination and sorting for the list of active listings that will be returned.
		/// </param>
		///
		/// <param name="SoldList">
		/// Include this container and set the <b>SoldList.Include</b> field to <code>true</code> to return the list of sold order line items.
		/// 
		/// The user also has the option of using pagination and sorting for the list of sold items that will be returned.
		/// </param>
		///
		/// <param name="UnsoldList">
		/// Include this container and set the <b>UnsoldList.Include</b> field to <code>true</code> to return the listings that have ended without a purchase.
		/// 
		/// The user also has the option of using pagination and sorting for the list of unsold items that will be returned.
		/// </param>
		///
		/// <param name="BidList">
		/// This container is deprecated as a Bid List is no longer returned in <b>GetMyeBaySelling</b>.
		/// </param>
		///
		/// <param name="DeletedFromSoldList">
		/// Include this container and set the <b>DeletedFromSoldList.Include</b> field to <code>true</code> to return the list of sold order line items that have since been deleted from the seller's My eBay page.
		/// 
		/// The user also has the option of using pagination and sorting for the list of deleted, sold items that will be returned.
		/// </param>
		///
		/// <param name="DeletedFromUnsoldList">
		/// Include this container and set the <b>DeletedFromUnsoldList.Include</b> field to <code>true</code> to return the list of unsold order line items that have since been deleted from the seller's My eBay page.
		/// 
		/// The user also has the option of using pagination and sorting for the list of deleted, unsold items that will be returned.
		/// </param>
		///
		/// <param name="SellingSummary">
		/// Include this container and set the <b>SellingSummary.Include</b> field to <code>true</code> to return the <b>SellingSummary</b> container in the response. The <b>SellingSummary</b> container consists of selling activity counts and values.
		/// </param>
		///
		/// <param name="HideVariations">
		/// If this field is included and set to <code>true</code>, the <b>Variations</b> node (and all variation data) is omitted for all multiple-variation listings in the response. If this field is omitted or set to <code>false</code>, the <b>Variations</b> node is returned for all multiple-variation listings in the response.
		/// 
		/// </param>
		///
		public SellingSummaryType GetMyeBaySelling(ItemListCustomizationType ScheduledList, ItemListCustomizationType ActiveList, ItemListCustomizationType SoldList, ItemListCustomizationType UnsoldList, ItemListCustomizationType BidList, ItemListCustomizationType DeletedFromSoldList, ItemListCustomizationType DeletedFromUnsoldList, ItemListCustomizationType SellingSummary, bool HideVariations)
		{
			this.ScheduledList = ScheduledList;
			this.ActiveList = ActiveList;
			this.SoldList = SoldList;
			this.UnsoldList = UnsoldList;
			this.DeletedFromSoldList = DeletedFromSoldList;
			this.DeletedFromUnsoldList = DeletedFromUnsoldList;
			this.SellingSummary = SellingSummary;
			this.HideVariations = HideVariations;
			Execute();
			return ApiResponse.SellingSummary;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void GetMyeBaySelling()
		{
			Execute();
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
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType"/> for this API call.
		/// </summary>
		public GetMyeBaySellingRequestType ApiRequest
		{ 
			get { return (GetMyeBaySellingRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetMyeBaySellingResponseType"/> for this API call.
		/// </summary>
		public GetMyeBaySellingResponseType ApiResponse
		{ 
			get { return (GetMyeBaySellingResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.ScheduledList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType ScheduledList
		{ 
			get { return ApiRequest.ScheduledList; }
			set { ApiRequest.ScheduledList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.ActiveList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType ActiveList
		{ 
			get { return ApiRequest.ActiveList; }
			set { ApiRequest.ActiveList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.SoldList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType SoldList
		{ 
			get { return ApiRequest.SoldList; }
			set { ApiRequest.SoldList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.UnsoldList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType UnsoldList
		{ 
			get { return ApiRequest.UnsoldList; }
			set { ApiRequest.UnsoldList = value; }
		}
 		 
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.DeletedFromSoldList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType DeletedFromSoldList
		{ 
			get { return ApiRequest.DeletedFromSoldList; }
			set { ApiRequest.DeletedFromSoldList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.DeletedFromUnsoldList"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType DeletedFromUnsoldList
		{ 
			get { return ApiRequest.DeletedFromUnsoldList; }
			set { ApiRequest.DeletedFromUnsoldList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.SellingSummary"/> of type <see cref="ItemListCustomizationType"/>.
		/// </summary>
		public ItemListCustomizationType SellingSummary
		{ 
			get { return ApiRequest.SellingSummary; }
			set { ApiRequest.SellingSummary = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetMyeBaySellingRequestType.HideVariations"/> of type <see cref="bool"/>.
		/// </summary>
		public bool HideVariations
		{ 
			get { return ApiRequest.HideVariations; }
			set { ApiRequest.HideVariations = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.SellingSummary"/> of type <see cref="SellingSummaryType"/>.
		/// </summary>
		public SellingSummaryType SellingSummaryReturn
		{ 
			get { return ApiResponse.SellingSummary; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.ScheduledList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType ScheduledListReturn
		{ 
			get { return ApiResponse.ScheduledList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.ActiveList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType ActiveListReturn
		{ 
			get { return ApiResponse.ActiveList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.SoldList"/> of type <see cref="PaginatedOrderTransactionArrayType"/>.
		/// </summary>
		public PaginatedOrderTransactionArrayType SoldListReturn
		{ 
			get { return ApiResponse.SoldList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.UnsoldList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType UnsoldListReturn
		{ 
			get { return ApiResponse.UnsoldList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.Summary"/> of type <see cref="MyeBaySellingSummaryType"/>.
		/// </summary>
		public MyeBaySellingSummaryType Summary
		{ 
			get { return ApiResponse.Summary; }
		}

 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.DeletedFromSoldList"/> of type <see cref="PaginatedOrderTransactionArrayType"/>.
		/// </summary>
		public PaginatedOrderTransactionArrayType DeletedFromSoldListReturn
		{ 
			get { return ApiResponse.DeletedFromSoldList; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetMyeBaySellingResponseType.DeletedFromUnsoldList"/> of type <see cref="PaginatedItemArrayType"/>.
		/// </summary>
		public PaginatedItemArrayType DeletedFromUnsoldListReturn
		{ 
			get { return ApiResponse.DeletedFromUnsoldList; }
		}
		

		#endregion

		
	}
}

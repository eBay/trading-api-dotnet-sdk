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
	public class VerifyAddFixedPriceItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public VerifyAddFixedPriceItemCall()
		{
			ApiRequest = new VerifyAddFixedPriceItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public VerifyAddFixedPriceItemCall(ApiContext ApiContext)
		{
			ApiRequest = new VerifyAddFixedPriceItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to test the definition of a new fixed-price listing by
		/// submitting the definition to eBay without creating an actual listing.
		/// </summary>
		/// 
		/// <param name="Item">
		/// Root container holding all values that define a new
		/// fixed-price listing.
		/// </param>
		///
		public FeeTypeCollection VerifyAddFixedPriceItem(ItemType Item)
		{
			this.Item = Item;

			Execute();
			return ApiResponse.Fees;
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Execute()
		{

			if (Item != null)
			{

				if ((Item.UUID == null || Item.UUID.Length == 0) && AutoSetItemUUID)
				{
					Item.UUID = NewUUID();
				}

				if (ApiContext.EPSServerUrl != null && PictureFileList != null && PictureFileList.Count > 0)
				{
					if (Item.PictureDetails == null)
					{
						Item.PictureDetails = new PictureDetailsType();
						//Item.PictureDetails.PhotoDisplay = PhotoDisplayCodeType.None;
					} 
                    //else if (!Item.PictureDetails.PhotoDisplaySpecified || Item.PictureDetails.PhotoDisplay == PhotoDisplayCodeType.CustomCode)
                    //{
                    //    Item.PictureDetails.PhotoDisplay = PhotoDisplayCodeType.None;
                    //}

					string[] pics = new string[mPictureFileList.Count];

					Item.PictureDetails.PictureURL = new StringCollection();
					Item.PictureDetails.PictureURL.AddRange(pics);

					
				}		
			}

			base.Execute();

			if (ApiResponse.CategoryID != null && ApiResponse.CategoryID.Length > 0)
			{
				if (Item.PrimaryCategory == null)
					Item.PrimaryCategory = new CategoryType();

				Item.PrimaryCategory.CategoryID = ApiResponse.CategoryID;
			}
			if (ApiResponse.Category2ID != null && ApiResponse.Category2ID.Length > 0)
			{
				if (Item.SecondaryCategory == null)
					Item.SecondaryCategory = new CategoryType();

				Item.SecondaryCategory.CategoryID = ApiResponse.Category2ID;
			}
		}


		#endregion



		#region Static Methods
		/// <summary>
		/// Generates a universal unique identifier.
		/// </summary>
		/// <returns>A universal unique identifier of type <see cref="string"/></returns>
		public static string NewUUID()
		{
			return System.Guid.NewGuid().ToString().Replace("-", "").ToString();
		}

		/// <summary>
		/// Sets or overwrites the <see cref="ItemType.UUID"/>.
		/// </summary>
		/// <param name="Item">The item to assign a universal unique identifier to.</param>
		public static void ResetItemUUID(ItemType Item)
		{
			Item.UUID = NewUUID();
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
		/// Gets or sets the <see cref="VerifyAddFixedPriceItemRequestType"/> for this API call.
		/// </summary>
		public VerifyAddFixedPriceItemRequestType ApiRequest
		{ 
			get { return (VerifyAddFixedPriceItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="VerifyAddFixedPriceItemResponseType"/> for this API call.
		/// </summary>
		public VerifyAddFixedPriceItemResponseType ApiResponse
		{ 
			get { return (VerifyAddFixedPriceItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyAddFixedPriceItemRequestType.Item"/> of type <see cref="ItemType"/>.
		/// </summary>
		public ItemType Item
		{ 
			get { return ApiRequest.Item; }
			set { ApiRequest.Item = value; }
		}
		/// <summary>
		///
		/// </summary>
		public bool AutoSetItemUUID
		{ 
			get { return mAutoSetItemUUID; }
			set { mAutoSetItemUUID = value; }
		}
		/// <summary>
		///
		/// </summary>
										public StringCollection PictureFileList
		{ 
			get { return mPictureFileList; }
			set { mPictureFileList = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddFixedPriceItemResponseType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiResponse.ItemID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddFixedPriceItemResponseType.SKU"/> of type <see cref="string"/>.
		/// </summary>
		public string SKU
		{ 
			get { return ApiResponse.SKU; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddFixedPriceItemResponseType.Fees"/> of type <see cref="FeeTypeCollection"/>.
		/// </summary>
		public FeeTypeCollection FeeList
		{ 
			get { return ApiResponse.Fees; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddFixedPriceItemResponseType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiResponse.CategoryID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddFixedPriceItemResponseType.Category2ID"/> of type <see cref="string"/>.
		/// </summary>
		public string Category2ID
		{ 
			get { return ApiResponse.Category2ID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddFixedPriceItemResponseType.DiscountReason"/> of type <see cref="DiscountReasonCodeTypeCollection"/>.
		/// </summary>
		public DiscountReasonCodeTypeCollection DiscountReasonList
		{ 
			get { return ApiResponse.DiscountReason; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddFixedPriceItemResponseType.ListingRecommendations"/> of type <see cref="ListingRecommendationsType"/>.
		/// </summary>
        //public ListingRecommendationsType ListingRecommendations
        //{ 
        //    get { return ApiResponse.ListingRecommendations; }
        //}
		

		#endregion

		#region Private Fields
		private bool mAutoSetItemUUID = false;
		private StringCollection mPictureFileList = new StringCollection();
		#endregion
		
	}
}

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
	public class VerifyAddItemCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public VerifyAddItemCall()
		{
			ApiRequest = new VerifyAddItemRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public VerifyAddItemCall(ApiContext ApiContext)
		{
			ApiRequest = new VerifyAddItemRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Enables a seller to specify the definition of a new item and submit the definition to eBay without creating a listing.
		/// 
		/// Sellers who engage in cross-border trade on sites that require a recoupment agreement, must agree to the
		/// recoupment terms before adding or verifying items. This agreement allows eBay to reimburse
		/// a buyer during a dispute and then recoup the cost from the seller. The US site is a recoupment site, and
		/// the agreement is located <a href="https://scgi.ebay.com/ws/eBayISAPI.dll?CBTRecoupAgreement">here</a>.
		/// The list of the sites where a user has agreed to the recoupment terms is returned by the GetUser response.
		/// </summary>
		/// 
		/// <param name="Item">
		/// Root container holding all values that define a new
		/// listing.
		/// </param>
		///
		public FeeTypeCollection VerifyAddItem(ItemType Item)
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
					} 

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

		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		//public FeeTypeCollection VerifyAddItem(ItemType Item)
		//{
		//	this.Item = Item;
		//	this.Execute();
		//	return FeeList;
		//}
		///// <summary>
		///// For backward compatibility with old wrappers.
		///// </summary>
		//public FeeTypeCollection VerifyAddItem(ItemType Item, ExternalProductIDType ExternalProductID)
		//{
		//	this.Item = Item;
		//	this.ExternalProductID = ExternalProductID;

		//	Execute();
		//	return ApiResponse.Fees;
		//}

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
		/// Gets or sets the <see cref="VerifyAddItemRequestType"/> for this API call.
		/// </summary>
		public VerifyAddItemRequestType ApiRequest
		{ 
			get { return (VerifyAddItemRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="VerifyAddItemResponseType"/> for this API call.
		/// </summary>
		public VerifyAddItemResponseType ApiResponse
		{ 
			get { return (VerifyAddItemResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="VerifyAddItemRequestType.Item"/> of type <see cref="ItemType"/>.
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
		/// Gets the returned <see cref="VerifyAddItemResponseType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiResponse.ItemID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.Fees"/> of type <see cref="FeeTypeCollection"/>.
		/// </summary>
		public FeeTypeCollection FeeList
		{ 
			get { return ApiResponse.Fees; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.ExpressListing"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ExpressListing
		{ 
			get { return ApiResponse.ExpressListing; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.ExpressItemRequirements"/> of type <see cref="ExpressItemRequirementsType"/>.
		/// </summary>
		public ExpressItemRequirementsType ExpressItemRequirements
		{ 
			get { return ApiResponse.ExpressItemRequirements; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.CategoryID"/> of type <see cref="string"/>.
		/// </summary>
		public string CategoryID
		{ 
			get { return ApiResponse.CategoryID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.Category2ID"/> of type <see cref="string"/>.
		/// </summary>
		public string Category2ID
		{ 
			get { return ApiResponse.Category2ID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.DiscountReason"/> of type <see cref="DiscountReasonCodeTypeCollection"/>.
		/// </summary>
		public DiscountReasonCodeTypeCollection DiscountReasonList
		{ 
			get { return ApiResponse.DiscountReason; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.ProductSuggestions"/> of type <see cref="ProductSuggestionsType"/>.
		/// </summary>
		public ProductSuggestionsType ProductSuggestions
		{ 
			get { return ApiResponse.ProductSuggestions; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="VerifyAddItemResponseType.ListingRecommendations"/> of type <see cref="ListingRecommendationsType"/>.
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

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
	public class SetUserPreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetUserPreferencesCall()
		{
			ApiRequest = new SetUserPreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetUserPreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new SetUserPreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call allows an eBay user to set/modify numerous seller account preferences.
		/// </summary>
		/// 
		/// <param name="BidderNoticePreferences">
		/// This container is included if the seller wishes to receive contact information for unsuccessful bidders. This preference is only applicable for auction listings.
		/// </param>
		///
		/// <param name="CombinedPaymentPreferences">
		/// This container is included if the seller wishes to set the preference for allowing Combined Invoice orders for cases where the buyer has multiple unpaid order line items from the same seller.
		/// </param>
		///
		/// <param name="CrossPromotionPreferences">
		/// This container is deprecated.
		/// </param>
		///
		/// <param name="SellerPaymentPreferences">
		/// This container is included if the seller wishes to set various payment preferences. One or more preferences may be set or modified under this container. Payment preferences specified in a <b>SetUserPreferences</b> call override the settings in My eBay payment preferences.
		/// </param>
		///
		/// <param name="SellerFavoriteItemPreferences">
		/// This container is included if the seller wishes to set preferences for displaying items on a buyer's Favorite Sellers' Items page or Favorite Sellers' Items digest. One or more preferences may be set or modified under this container.
		/// </param>
		///
		/// <param name="EndOfAuctionEmailPreferences">
		/// This container is included if the seller wishes to set preferences for the end-of-auction email sent to the winning bidder. These preferences allow the seller to customize the Email that is sent to buyer at the end of the auction. One or more preferences may be set or modified under this container. These preferences are only applicable for auction listings.
		/// </param>
		///
		/// <param name="EmailShipmentTrackingNumberPreference">
		/// This field is included and set to <code>true</code> if the seller wishes to email the shipment's tracking number to the buyer.
		/// </param>
		///
		/// <param name="RequiredShipPhoneNumberPreference">
		/// This field is included and set to <code>true</code> if the seller wishes to require the buyer to provide a shipping phone number upon checkout. Some shipping carriers require the receiver's phone number.
		/// </param>
		///
		/// <param name="UnpaidItemAssistancePreferences">
		/// This container is included if the seller wishes to set Unpaid Item Assistant preferences. The Unpaid Item Assistant automatically opens an Unpaid Item case on the behalf of the seller if the buyer has not paid for the order after a specified number of days. One or more preferences may be set or modified under this container.
		/// </param>
		///
		/// <param name="PurchaseReminderEmailPreferences">
		/// This container is included if the seller wishes to set the preference for sending a purchase reminder email to buyers.
		/// </param>
		///
		/// <param name="SellerThirdPartyCheckoutDisabled">
		/// This field is no longer applicable, as third-party checkout on eBay is no longer possible.
		/// </param>
		///
		/// <param name="DispatchCutoffTimePreference">
		/// This container is included if the seller wishes to set the order cut off time for same-day shipping. If the seller specifies a value of <code>0</code> in <strong>Item.DispatchTimeMax</strong> to offer same day handling when listing an item, the seller's shipping time commitment depends on the order cut off time set for the listing site, as indicated by the <strong>DispatchCutoffTimePreference.CutoffTime</strong> field.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> This field is not applicable for sellers who have opted into the Handling Time Option of eBay Guaranteed Delivery, as this field only shows a single order cutoff time, but with the Handling Time Option, a seller can set a different order cutoff time for each business day. Currently, eBay Guaranteed Delivery is only available in the US.</span>
		/// </param>
		///
		/// <param name="GlobalShippingProgramListingPreference">
		/// If this flag is included and set to <code>true</code>, the seller's new listings will enable the Global Shipping Program by default.
		/// <br/><br/>
		/// <span class="tablenote">
		/// <strong>Note:</strong> This field is ignored for sellers who are not opted in to the Global Shipping Program (when GetUserPreferences returns <strong>OfferGlobalShippingProgramPreference</strong> with a value of <code>false</code>).
		/// </span>
		/// </param>
		///
		/// <param name="OverrideGSPserviceWithIntlService">
		/// If this flag is included and set to <code>true</code>, and the seller specifies an international shipping service to a particular country for a given listing, the specified service will take precedence and be the listing's default international shipping option for buyers in that country, rather than the Global Shipping Program. The Global Shipping Program will still be the listing's default option for shipping to any Global Shipping-eligible country for which the seller does <em>not</em> specify an international shipping service.
		/// <br/><br/>
		/// If this flag is set to <code>false</code>, the Global Shipping Program will be each Global Shipping-eligible listing's default option for shipping to any Global Shipping-eligible country, regardless of any international shipping service that the seller specifies for the listing.
		/// </param>
		///
		/// <param name="OutOfStockControlPreference">
		/// If this flag is included and set to <code>true</code>, it enables the Out-of-Stock feature. A seller would use this feature to keep Fixed-Price GTC (Good 'Til Canceled) listings alive even when the "quantity available" value goes to 0 (zero). This is useful when waiting for additional stock and eliminates the need to end the listing and then recreating it when stock arrives. <br/><br/>
		/// While the "quantity available" value is 0, the listing would be hidden from eBay search and if that item was specifically searched for with <b>GetItem</b> (or related call), the element <b>HideFromSearch</b> would be returned as 'true' and <b>ReasonHideFromSearch</b> would be returned as 'OutOfStock'.
		/// <br/><br/>
		/// When stock is available, the seller can use the <b>Revise</b> calls to update the inventory of the item (through the <b>Item.Quantity</b> or <b>Item.Variations.Variation.Quantity</b> fields) and the listing would appear again.
		/// <br/><br/>
		/// You can return the value of this flag using the <a href="GetUserPreferences.html#Request.ShowOutOfStockControlPreference">GetUserPreferences</a> call and setting the <b>ShowOutOfStockControlPreference</b> field to 'true'. <br/><br/>
		/// <span class="tablenote"><b>IMPORTANT: </b> When a listing using the Out-of-Stock feature has zero quantity, the seller has 90 days to add inventory without incurring a listing fee. Fees are changed at the end of each the billing cycle but are then refunded if the item is out-of-stock for an entire billing period. See <a href="../../../../guides/features-guide/default.html#development/Listings-UseOutOfStock.html#FeesForaListingWithZeroQuantity">Fees For a Listing With Zero Quantity</a> for details. </span>
		/// </param>
		///
		public void SetUserPreferences(BidderNoticePreferencesType BidderNoticePreferences, CombinedPaymentPreferencesType CombinedPaymentPreferences, CrossPromotionPreferencesType CrossPromotionPreferences, SellerPaymentPreferencesType SellerPaymentPreferences, SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences, EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences, bool EmailShipmentTrackingNumberPreference, bool RequiredShipPhoneNumberPreference, UnpaidItemAssistancePreferencesType UnpaidItemAssistancePreferences, PurchaseReminderEmailPreferencesType PurchaseReminderEmailPreferences, bool SellerThirdPartyCheckoutDisabled, DispatchCutoffTimePreferencesType DispatchCutoffTimePreference, bool GlobalShippingProgramListingPreference, bool OverrideGSPserviceWithIntlService, bool OutOfStockControlPreference)
		{
			this.BidderNoticePreferences = BidderNoticePreferences;
			this.CombinedPaymentPreferences = CombinedPaymentPreferences;
			this.CrossPromotionPreferences = CrossPromotionPreferences;
			this.SellerPaymentPreferences = SellerPaymentPreferences;
			this.SellerFavoriteItemPreferences = SellerFavoriteItemPreferences;
			this.EndOfAuctionEmailPreferences = EndOfAuctionEmailPreferences;
			this.EmailShipmentTrackingNumberPreference = EmailShipmentTrackingNumberPreference;
			this.RequiredShipPhoneNumberPreference = RequiredShipPhoneNumberPreference;
			this.UnpaidItemAssistancePreferences = UnpaidItemAssistancePreferences;
			this.PurchaseReminderEmailPreferences = PurchaseReminderEmailPreferences;
			this.SellerThirdPartyCheckoutDisabled = SellerThirdPartyCheckoutDisabled;
			this.DispatchCutoffTimePreference = DispatchCutoffTimePreference;
			this.GlobalShippingProgramListingPreference = GlobalShippingProgramListingPreference;
			this.OverrideGSPserviceWithIntlService = OverrideGSPserviceWithIntlService;
			this.OutOfStockControlPreference = OutOfStockControlPreference;

			Execute();
			
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetUserPreferences()
		{
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void SetUserPreferences(BidderNoticePreferencesType BidderNoticePreferences, CombinedPaymentPreferencesType CombinedPaymentPreferences, CrossPromotionPreferencesType CrossPromotionPreferences, SellerPaymentPreferencesType SellerPaymentPreferences, SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences, EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences)
		{
			this.BidderNoticePreferences = BidderNoticePreferences;
			this.CombinedPaymentPreferences = CombinedPaymentPreferences;
			this.CrossPromotionPreferences = CrossPromotionPreferences;
			this.SellerPaymentPreferences = SellerPaymentPreferences;
			this.SellerFavoriteItemPreferences = SellerFavoriteItemPreferences;
			this.EndOfAuctionEmailPreferences = EndOfAuctionEmailPreferences;

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
		/// Gets or sets the <see cref="SetUserPreferencesRequestType"/> for this API call.
		/// </summary>
		public SetUserPreferencesRequestType ApiRequest
		{ 
			get { return (SetUserPreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetUserPreferencesResponseType"/> for this API call.
		/// </summary>
		public SetUserPreferencesResponseType ApiResponse
		{ 
			get { return (SetUserPreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.BidderNoticePreferences"/> of type <see cref="BidderNoticePreferencesType"/>.
		/// </summary>
		public BidderNoticePreferencesType BidderNoticePreferences
		{ 
			get { return ApiRequest.BidderNoticePreferences; }
			set { ApiRequest.BidderNoticePreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.CombinedPaymentPreferences"/> of type <see cref="CombinedPaymentPreferencesType"/>.
		/// </summary>
		public CombinedPaymentPreferencesType CombinedPaymentPreferences
		{ 
			get { return ApiRequest.CombinedPaymentPreferences; }
			set { ApiRequest.CombinedPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.CrossPromotionPreferences"/> of type <see cref="CrossPromotionPreferencesType"/>.
		/// </summary>
		public CrossPromotionPreferencesType CrossPromotionPreferences
		{ 
			get { return ApiRequest.CrossPromotionPreferences; }
			set { ApiRequest.CrossPromotionPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.SellerPaymentPreferences"/> of type <see cref="SellerPaymentPreferencesType"/>.
		/// </summary>
		public SellerPaymentPreferencesType SellerPaymentPreferences
		{ 
			get { return ApiRequest.SellerPaymentPreferences; }
			set { ApiRequest.SellerPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.SellerFavoriteItemPreferences"/> of type <see cref="SellerFavoriteItemPreferencesType"/>.
		/// </summary>
		public SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences
		{ 
			get { return ApiRequest.SellerFavoriteItemPreferences; }
			set { ApiRequest.SellerFavoriteItemPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.EndOfAuctionEmailPreferences"/> of type <see cref="EndOfAuctionEmailPreferencesType"/>.
		/// </summary>
		public EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences
		{ 
			get { return ApiRequest.EndOfAuctionEmailPreferences; }
			set { ApiRequest.EndOfAuctionEmailPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.EmailShipmentTrackingNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool EmailShipmentTrackingNumberPreference
		{ 
			get { return ApiRequest.EmailShipmentTrackingNumberPreference; }
			set { ApiRequest.EmailShipmentTrackingNumberPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.RequiredShipPhoneNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool RequiredShipPhoneNumberPreference
		{ 
			get { return ApiRequest.RequiredShipPhoneNumberPreference; }
			set { ApiRequest.RequiredShipPhoneNumberPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.UnpaidItemAssistancePreferences"/> of type <see cref="UnpaidItemAssistancePreferencesType"/>.
		/// </summary>
		public UnpaidItemAssistancePreferencesType UnpaidItemAssistancePreferences
		{ 
			get { return ApiRequest.UnpaidItemAssistancePreferences; }
			set { ApiRequest.UnpaidItemAssistancePreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.PurchaseReminderEmailPreferences"/> of type <see cref="PurchaseReminderEmailPreferencesType"/>.
		/// </summary>
		public PurchaseReminderEmailPreferencesType PurchaseReminderEmailPreferences
		{ 
			get { return ApiRequest.PurchaseReminderEmailPreferences; }
			set { ApiRequest.PurchaseReminderEmailPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.SellerThirdPartyCheckoutDisabled"/> of type <see cref="bool"/>.
		/// </summary>
		public bool SellerThirdPartyCheckoutDisabled
		{ 
			get { return ApiRequest.SellerThirdPartyCheckoutDisabled; }
			set { ApiRequest.SellerThirdPartyCheckoutDisabled = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.DispatchCutoffTimePreference"/> of type <see cref="DispatchCutoffTimePreferencesType"/>.
		/// </summary>
		public DispatchCutoffTimePreferencesType DispatchCutoffTimePreference
		{ 
			get { return ApiRequest.DispatchCutoffTimePreference; }
			set { ApiRequest.DispatchCutoffTimePreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.GlobalShippingProgramListingPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool GlobalShippingProgramListingPreference
		{ 
			get { return ApiRequest.GlobalShippingProgramListingPreference; }
			set { ApiRequest.GlobalShippingProgramListingPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.OverrideGSPserviceWithIntlService"/> of type <see cref="bool"/>.
		/// </summary>
		public bool OverrideGSPserviceWithIntlService
		{ 
			get { return ApiRequest.OverrideGSPserviceWithIntlService; }
			set { ApiRequest.OverrideGSPserviceWithIntlService = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="SetUserPreferencesRequestType.OutOfStockControlPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool OutOfStockControlPreference
		{ 
			get { return ApiRequest.OutOfStockControlPreference; }
			set { ApiRequest.OutOfStockControlPreference = value; }
		}
		
		

		#endregion

		
	}
}

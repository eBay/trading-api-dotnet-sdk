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
	public class GetUserPreferencesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetUserPreferencesCall()
		{
			ApiRequest = new GetUserPreferencesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetUserPreferencesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetUserPreferencesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Retrieves the specified user preferences for the authenticated caller.
		/// </summary>
		/// 
		/// <param name="ShowBidderNoticePreferences">
		/// If included and set to <code>true</code>, the seller's preference for receiving contact information for unsuccessful bidders is returned in the response.
		/// </param>
		///
		/// <param name="ShowCombinedPaymentPreferences">
		/// If included and set to <code>true</code>, the seller's combined invoice preferences are returned in the response. These preferences are used to allow Combined Invoice orders.
		/// 
		/// </param>
		///
		/// <param name="ShowCrossPromotionPreferences">
		/// This field is deprecated.
		/// </param>
		///
		/// <param name="ShowSellerPaymentPreferences">
		/// If included and set to <code>true</code>, the seller's payment preferences are returned in the response.
		/// </param>
		///
		/// <param name="ShowEndOfAuctionEmailPreferences">
		/// If included and set to <code>true</code>, the seller's preferences for the end-of-auction email sent to the winning bidder is returned in the response. These preferences are only applicable for auction listings.
		/// </param>
		///
		/// <param name="ShowSellerFavoriteItemPreferences">
		/// If included and set to <code>true</code>, the seller's favorite item preferences are returned in the response.
		/// </param>
		///
		/// <param name="ShowProStoresPreferences">
		/// This field is deprecated.
		/// </param>
		///
		/// <param name="ShowEmailShipmentTrackingNumberPreference">
		/// If included and set to <code>true</code>, the seller's preference for sending an email to the buyer with the shipping tracking number is returned in the response.
		/// </param>
		///
		/// <param name="ShowRequiredShipPhoneNumberPreference">
		/// If included and set to <code>true</code>, the seller's preference for requiring that the buyer supply a shipping phone number upon checkout is returned in the response. Some shipping carriers require the receiver's phone number.
		/// </param>
		///
		/// <param name="ShowSellerExcludeShipToLocationPreference">
		/// If included and set to <code>true</code>, all of the seller's excluded shipping locations are returned in the response. The returned list mirrors the seller's current Exclude shipping locations list in My eBay's Shipping Preferences. An excluded shipping location in My eBay can be an entire geographical region (such as Middle East) or only an individual country (such as Iraq). Sellers can override these default settings for an individual listing by using the <b>Item.ShippingDetails.ExcludeShipToLocation</b> field in the <b>AddItem</b> family of calls.
		/// </param>
		///
		/// <param name="ShowUnpaidItemAssistancePreference">
		/// If included and set to <code>true</code>, the seller's Unpaid Item Assistant preferences are returned in the response. The Unpaid Item Assistant automatically opens an Unpaid Item dispute on the behalf of the seller.  <span class="tablenote"><strong>Note:</strong> To return the list of buyers excluded from the Unpaid Item Assistant mechanism, the <b>ShowUnpaidItemAssistanceExclusionList</b> field must also be included and set to <code>true</code> in the request. Excluded buyers can be viewed in the <b>UnpaidItemAssistancePreferences.ExcludedUser</b> field. </span>
		/// </param>
		///
		/// <param name="ShowPurchaseReminderEmailPreferences">
		/// If included and set to <code>true</code>, the seller's preference for sending a purchase reminder email to buyers is returned in the response.
		/// </param>
		///
		/// <param name="ShowUnpaidItemAssistanceExclusionList">
		/// If included and set to <code>true</code>, the list of eBay user IDs on the Unpaid Item Assistant Excluded User list is returned through the <b>UnpaidItemAssistancePreferences.ExcludedUser</b> field in the response. <br/><br/> For excluded users, an Unpaid Item dispute is not automatically filed through the UPI Assistance mechanism. The Excluded User list is managed through the <b>SetUserPreferences</b> call.  <span class="tablenote"><strong>Note:</strong> To return the list of buyers excluded from the Unpaid Item Assistant mechanism, the <b>ShowUnpaidItemAssistancePreference</b> field must also be included and set to <b>true</b> in the request. </span>
		/// </param>
		///
		/// <param name="ShowSellerProfilePreferences">
		/// If this flag is included and set to <code>true</code>, the seller's Business Policies profile information is returned in the response. This information includes a flag that indicates whether or not the seller has opted into Business Policies, as well as Business Policies profiles (payment, shipping, and return policy) active on the seller's account.
		/// </param>
		///
		/// <param name="ShowSellerReturnPreferences">
		/// If this flag is included and set to <code>true</code>, the <b>SellerReturnPreferences</b> container is returned in the response and indicates whether or not the seller has opted in to eBay Managed Returns.
		/// 
		/// eBay Managed Returns are currently only available on the US, UK, DE, AU, and CA (English and French) sites.
		/// </param>
		///
		/// <param name="ShowGlobalShippingProgramPreference">
		/// If this flag is included and set to <code>true</code>, the seller's preference for offering the Global Shipping Program to international buyers will be returned in <strong>OfferGlobalShippingProgramPreference</strong>.
		/// </param>
		///
		/// <param name="ShowDispatchCutoffTimePreferences">
		/// If included and set to <code>true</code>, the seller's same-day handling cutoff time is returned in <strong>DispatchCutoffTimePreference.CutoffTime</strong>.
		/// 
		/// 
		/// <span class="tablenote"><b>Note:</b> This field is not applicable for sellers who have opted into the Handling Time Option of eBay Guaranteed Delivery, as this field only shows a single order cutoff time, but with the Handling Time Option, a seller can set a different order cutoff time for each business day. Currently, eBay Guaranteed Delivery is only available in the US.</span>
		/// 
		/// </param>
		///
		/// <param name="ShowGlobalShippingProgramListingPreference">
		/// If included and set to <code>true</code>, the <strong>GlobalShippingProgramListingPreference</strong> field is returned. A returned value of <code>true</code> indicates that the seller's new listings will enable the Global Shipping Program by default.
		/// </param>
		///
		/// <param name="ShowOverrideGSPServiceWithIntlServicePreference">
		/// If included and set to <code>true</code>, the <strong>OverrideGSPServiceWithIntlServicePreference</strong> field is returned. A returned value of <code>true</code> indicates that for the seller's listings that specify an international shipping service for any Global Shipping-eligible country, the specified service will take precedence and be the listing's default international shipping option for buyers in that country, rather than the Global Shipping Program.
		/// <br/><br/>
		/// A returned value of <code>false</code> indicates that the Global Shipping program will take precedence over any international shipping service as the default option in Global Shipping-eligible listings for shipping to any Global Shipping-eligible country.
		/// </param>
		///
		/// <param name="ShowPickupDropoffPreferences">
		/// If included and set to <code>true</code>, the <strong>PickupDropoffSellerPreference</strong> field is returned. A returned value of <code>true</code> indicates that the seller's new listings will by default be eligible to be evaluated for the Click and Collect feature.
		/// <br/><br/>
		/// With the Click and Collect feature, a buyer can purchase certain items on eBay and collect them at a local store. Buyers are notified by eBay once their items are available. The Click and Collect feature is only available to large merchants on the eBay UK (site ID 3), eBay Australia (Site ID 15), and eBay Germany (Site ID 77) sites.
		/// <br/><br/>
		/// <span class="tablenote"><b>Note:</b> The Click and Collect program no longer allows sellers to set the Click and Collect preference at the listing level.
		/// </span>
		/// </param>
		///
		/// <param name="ShowOutOfStockControlPreference">
		/// If included and set to <code>true</code>, the seller's preferences related to the Out-of-Stock feature will be returned. This feature is set using the <a href="SetUserPreferences.html#Request.OutOfStockControlPreference">SetUserPreferences</a> call.
		/// </param>
		///
		/// <param name="ShoweBayPLUSPreference">
		/// To determine whether a seller can offer eBay Plus in qualified listings, include this field and set it to <code>true</code>.
		/// <br/><br/>
		/// eBay Plus is a premium account option for buyers, which provides benefits such as fast free domestic shipping and free returns on selected items. Top Rated eBay sellers must opt in to eBay Plus, and can offer the program on a per-listing basis.
		/// <br/><br/>
		/// The <strong>eBayPLUSPreference</strong> container is returned in the response with information about each country where the seller is eligible to offer eBay Plus on listings (one <strong>eBayPLUSPreference</strong> container per country), as well as the seller's opt-in status and listing preference for each country.
		/// <br/><br/>
		/// <span class="tablenote">
		/// <strong>Note:</strong> Currently, eBay Plus is available only to buyers in Germany, Austria, and Australia.
		/// </span>
		/// </param>
		///
		public BidderNoticePreferencesType GetUserPreferences(bool ShowBidderNoticePreferences, bool ShowCombinedPaymentPreferences, bool ShowCrossPromotionPreferences, bool ShowSellerPaymentPreferences, bool ShowEndOfAuctionEmailPreferences, bool ShowSellerFavoriteItemPreferences, bool ShowProStoresPreferences, bool ShowEmailShipmentTrackingNumberPreference, bool ShowRequiredShipPhoneNumberPreference, bool ShowSellerExcludeShipToLocationPreference, bool ShowUnpaidItemAssistancePreference, bool ShowPurchaseReminderEmailPreferences, bool ShowUnpaidItemAssistanceExclusionList, bool ShowSellerProfilePreferences, bool ShowSellerReturnPreferences, bool ShowGlobalShippingProgramPreference, bool ShowDispatchCutoffTimePreferences, bool ShowGlobalShippingProgramListingPreference, bool ShowOverrideGSPServiceWithIntlServicePreference, bool ShowPickupDropoffPreferences, bool ShowOutOfStockControlPreference, bool ShoweBayPLUSPreference)
		{
			this.ShowBidderNoticePreferences = ShowBidderNoticePreferences;
			this.ShowCombinedPaymentPreferences = ShowCombinedPaymentPreferences;
			this.ShowSellerPaymentPreferences = ShowSellerPaymentPreferences;
			this.ShowEndOfAuctionEmailPreferences = ShowEndOfAuctionEmailPreferences;
			this.ShowSellerFavoriteItemPreferences = ShowSellerFavoriteItemPreferences;
			this.ShowEmailShipmentTrackingNumberPreference = ShowEmailShipmentTrackingNumberPreference;
			this.ShowRequiredShipPhoneNumberPreference = ShowRequiredShipPhoneNumberPreference;
			this.ShowSellerExcludeShipToLocationPreference = ShowSellerExcludeShipToLocationPreference;
			this.ShowUnpaidItemAssistancePreference = ShowUnpaidItemAssistancePreference;
			this.ShowPurchaseReminderEmailPreferences = ShowPurchaseReminderEmailPreferences;
			this.ShowUnpaidItemAssistanceExclusionList = ShowUnpaidItemAssistanceExclusionList;
			this.ShowSellerProfilePreferences = ShowSellerProfilePreferences;
			this.ShowSellerReturnPreferences = ShowSellerReturnPreferences;
			this.ShowGlobalShippingProgramPreference = ShowGlobalShippingProgramPreference;
			this.ShowDispatchCutoffTimePreferences = ShowDispatchCutoffTimePreferences;
			this.ShowGlobalShippingProgramListingPreference = ShowGlobalShippingProgramListingPreference;
			this.ShowOverrideGSPServiceWithIntlServicePreference = ShowOverrideGSPServiceWithIntlServicePreference;
			this.ShowPickupDropoffPreferences = ShowPickupDropoffPreferences;
			this.ShowOutOfStockControlPreference = ShowOutOfStockControlPreference;
			this.ShoweBayPLUSPreference = ShoweBayPLUSPreference;

			Execute();
			return ApiResponse.BidderNoticePreferences;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public void GetUserPreferences(bool ShowBidderNoticePreferences, bool ShowCombinedPaymentPreferences, bool ShowCrossPromotionPreferences, bool ShowSellerPaymentPreferences, bool ShowSellerFavoriteItemPreferences)
		{
			this.ShowBidderNoticePreferences = ShowBidderNoticePreferences;
			this.ShowCombinedPaymentPreferences = ShowCombinedPaymentPreferences;
			this.ShowSellerPaymentPreferences = ShowSellerPaymentPreferences;
			this.ShowSellerFavoriteItemPreferences = ShowSellerFavoriteItemPreferences;
			Execute();
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public BidderNoticePreferencesType GetUserPreferences(bool ShowBidderNoticePreferences, bool ShowCombinedPaymentPreferences, bool ShowCrossPromotionPreferences, bool ShowSellerPaymentPreferences, bool ShowEndOfAuctionEmailPreferences, bool ShowSellerFavoriteItemPreferences)
		{
			this.ShowBidderNoticePreferences = ShowBidderNoticePreferences;
			this.ShowCombinedPaymentPreferences = ShowCombinedPaymentPreferences;
			this.ShowSellerPaymentPreferences = ShowSellerPaymentPreferences;
			this.ShowEndOfAuctionEmailPreferences = ShowEndOfAuctionEmailPreferences;
			this.ShowSellerFavoriteItemPreferences = ShowSellerFavoriteItemPreferences;

			Execute();
			return ApiResponse.BidderNoticePreferences;
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
		/// Gets or sets the <see cref="GetUserPreferencesRequestType"/> for this API call.
		/// </summary>
		public GetUserPreferencesRequestType ApiRequest
		{ 
			get { return (GetUserPreferencesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetUserPreferencesResponseType"/> for this API call.
		/// </summary>
		public GetUserPreferencesResponseType ApiResponse
		{ 
			get { return (GetUserPreferencesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowBidderNoticePreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowBidderNoticePreferences
		{ 
			get { return ApiRequest.ShowBidderNoticePreferences; }
			set { ApiRequest.ShowBidderNoticePreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowCombinedPaymentPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowCombinedPaymentPreferences
		{ 
			get { return ApiRequest.ShowCombinedPaymentPreferences; }
			set { ApiRequest.ShowCombinedPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerPaymentPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerPaymentPreferences
		{ 
			get { return ApiRequest.ShowSellerPaymentPreferences; }
			set { ApiRequest.ShowSellerPaymentPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowEndOfAuctionEmailPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowEndOfAuctionEmailPreferences
		{ 
			get { return ApiRequest.ShowEndOfAuctionEmailPreferences; }
			set { ApiRequest.ShowEndOfAuctionEmailPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerFavoriteItemPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerFavoriteItemPreferences
		{ 
			get { return ApiRequest.ShowSellerFavoriteItemPreferences; }
			set { ApiRequest.ShowSellerFavoriteItemPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowEmailShipmentTrackingNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowEmailShipmentTrackingNumberPreference
		{ 
			get { return ApiRequest.ShowEmailShipmentTrackingNumberPreference; }
			set { ApiRequest.ShowEmailShipmentTrackingNumberPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowRequiredShipPhoneNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowRequiredShipPhoneNumberPreference
		{ 
			get { return ApiRequest.ShowRequiredShipPhoneNumberPreference; }
			set { ApiRequest.ShowRequiredShipPhoneNumberPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerExcludeShipToLocationPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerExcludeShipToLocationPreference
		{ 
			get { return ApiRequest.ShowSellerExcludeShipToLocationPreference; }
			set { ApiRequest.ShowSellerExcludeShipToLocationPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowUnpaidItemAssistancePreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowUnpaidItemAssistancePreference
		{ 
			get { return ApiRequest.ShowUnpaidItemAssistancePreference; }
			set { ApiRequest.ShowUnpaidItemAssistancePreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowPurchaseReminderEmailPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowPurchaseReminderEmailPreferences
		{ 
			get { return ApiRequest.ShowPurchaseReminderEmailPreferences; }
			set { ApiRequest.ShowPurchaseReminderEmailPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowUnpaidItemAssistanceExclusionList"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowUnpaidItemAssistanceExclusionList
		{ 
			get { return ApiRequest.ShowUnpaidItemAssistanceExclusionList; }
			set { ApiRequest.ShowUnpaidItemAssistanceExclusionList = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerProfilePreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerProfilePreferences
		{ 
			get { return ApiRequest.ShowSellerProfilePreferences; }
			set { ApiRequest.ShowSellerProfilePreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowSellerReturnPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowSellerReturnPreferences
		{ 
			get { return ApiRequest.ShowSellerReturnPreferences; }
			set { ApiRequest.ShowSellerReturnPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowGlobalShippingProgramPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowGlobalShippingProgramPreference
		{ 
			get { return ApiRequest.ShowGlobalShippingProgramPreference; }
			set { ApiRequest.ShowGlobalShippingProgramPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowDispatchCutoffTimePreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowDispatchCutoffTimePreferences
		{ 
			get { return ApiRequest.ShowDispatchCutoffTimePreferences; }
			set { ApiRequest.ShowDispatchCutoffTimePreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowGlobalShippingProgramListingPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowGlobalShippingProgramListingPreference
		{ 
			get { return ApiRequest.ShowGlobalShippingProgramListingPreference; }
			set { ApiRequest.ShowGlobalShippingProgramListingPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowOverrideGSPServiceWithIntlServicePreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowOverrideGSPServiceWithIntlServicePreference
		{ 
			get { return ApiRequest.ShowOverrideGSPServiceWithIntlServicePreference; }
			set { ApiRequest.ShowOverrideGSPServiceWithIntlServicePreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowPickupDropoffPreferences"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowPickupDropoffPreferences
		{ 
			get { return ApiRequest.ShowPickupDropoffPreferences; }
			set { ApiRequest.ShowPickupDropoffPreferences = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShowOutOfStockControlPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShowOutOfStockControlPreference
		{ 
			get { return ApiRequest.ShowOutOfStockControlPreference; }
			set { ApiRequest.ShowOutOfStockControlPreference = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserPreferencesRequestType.ShoweBayPLUSPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool ShoweBayPLUSPreference
		{ 
			get { return ApiRequest.ShoweBayPLUSPreference; }
			set { ApiRequest.ShoweBayPLUSPreference = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.BidderNoticePreferences"/> of type <see cref="BidderNoticePreferencesType"/>.
		/// </summary>
		public BidderNoticePreferencesType BidderNoticePreferences
		{ 
			get { return ApiResponse.BidderNoticePreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.CombinedPaymentPreferences"/> of type <see cref="CombinedPaymentPreferencesType"/>.
		/// </summary>
		public CombinedPaymentPreferencesType CombinedPaymentPreferences
		{ 
			get { return ApiResponse.CombinedPaymentPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerPaymentPreferences"/> of type <see cref="SellerPaymentPreferencesType"/>.
		/// </summary>
		public SellerPaymentPreferencesType SellerPaymentPreferences
		{ 
			get { return ApiResponse.SellerPaymentPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerFavoriteItemPreferences"/> of type <see cref="SellerFavoriteItemPreferencesType"/>.
		/// </summary>
		public SellerFavoriteItemPreferencesType SellerFavoriteItemPreferences
		{ 
			get { return ApiResponse.SellerFavoriteItemPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.EndOfAuctionEmailPreferences"/> of type <see cref="EndOfAuctionEmailPreferencesType"/>.
		/// </summary>
		public EndOfAuctionEmailPreferencesType EndOfAuctionEmailPreferences
		{ 
			get { return ApiResponse.EndOfAuctionEmailPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.EmailShipmentTrackingNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool EmailShipmentTrackingNumberPreference
		{ 
			get { return ApiResponse.EmailShipmentTrackingNumberPreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.RequiredShipPhoneNumberPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool RequiredShipPhoneNumberPreference
		{ 
			get { return ApiResponse.RequiredShipPhoneNumberPreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.UnpaidItemAssistancePreferences"/> of type <see cref="UnpaidItemAssistancePreferencesType"/>.
		/// </summary>
		public UnpaidItemAssistancePreferencesType UnpaidItemAssistancePreferences
		{ 
			get { return ApiResponse.UnpaidItemAssistancePreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerExcludeShipToLocationPreferences"/> of type <see cref="SellerExcludeShipToLocationPreferencesType"/>.
		/// </summary>
		public SellerExcludeShipToLocationPreferencesType SellerExcludeShipToLocationPreferences
		{ 
			get { return ApiResponse.SellerExcludeShipToLocationPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.PurchaseReminderEmailPreferences"/> of type <see cref="PurchaseReminderEmailPreferencesType"/>.
		/// </summary>
		public PurchaseReminderEmailPreferencesType PurchaseReminderEmailPreferences
		{ 
			get { return ApiResponse.PurchaseReminderEmailPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerProfilePreferences"/> of type <see cref="SellerProfilePreferencesType"/>.
		/// </summary>
		public SellerProfilePreferencesType SellerProfilePreferences
		{ 
			get { return ApiResponse.SellerProfilePreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.SellerReturnPreferences"/> of type <see cref="SellerReturnPreferencesType"/>.
		/// </summary>
		public SellerReturnPreferencesType SellerReturnPreferences
		{ 
			get { return ApiResponse.SellerReturnPreferences; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.OfferGlobalShippingProgramPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool OfferGlobalShippingProgramPreference
		{ 
			get { return ApiResponse.OfferGlobalShippingProgramPreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.DispatchCutoffTimePreference"/> of type <see cref="DispatchCutoffTimePreferencesType"/>.
		/// </summary>
		public DispatchCutoffTimePreferencesType DispatchCutoffTimePreference
		{ 
			get { return ApiResponse.DispatchCutoffTimePreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.GlobalShippingProgramListingPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool GlobalShippingProgramListingPreference
		{ 
			get { return ApiResponse.GlobalShippingProgramListingPreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.OverrideGSPServiceWithIntlServicePreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool OverrideGSPServiceWithIntlServicePreference
		{ 
			get { return ApiResponse.OverrideGSPServiceWithIntlServicePreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.PickupDropoffSellerPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool PickupDropoffSellerPreference
		{ 
			get { return ApiResponse.PickupDropoffSellerPreference; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserPreferencesResponseType.OutOfStockControlPreference"/> of type <see cref="bool"/>.
		/// </summary>
		public bool OutOfStockControlPreference
		{ 
			get { return ApiResponse.OutOfStockControlPreference; }
		}

		#endregion

		
	}
}

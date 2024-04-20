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
	public class GetItemShippingCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetItemShippingCall()
		{
			ApiRequest = new GetItemShippingRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetItemShippingCall(ApiContext ApiContext)
		{
			ApiRequest = new GetItemShippingRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This is the base request type of the <b>GetItemShipping</b> call. This call takes an <b>ItemID</b> value for an item that has yet to be shipped, and then returns estimated shipping costs for every shipping service that the seller has offered with the listing. This call will also return <b>PickUpInStoreDetails.EligibleForPickupDropOff</b> and <b>PickUpInStoreDetails.EligibleForPickupInStore</b> flags if the item is available for buyer pick-up through the In-Store Pickup or Click and Collect features.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// The unique identifier of the eBay listing for which to retrieve estimated shipping costs for all offered shipping service options. The <b>ItemID</b> value passed into this field should be for an listing that offers at least one calculated shipping service option, and for an item that has yet to be shipped.
		/// </param>
		///
		/// <param name="QuantitySold">
		/// This field is used to specify the quantity of the item. The <b>QuantitySold</b> value defaults to <code>1</code> if not specified. If a value greater than <code>1</code> is specified in this field, the shipping service costs returned in the response will reflect the expense to ship multiple quantity of an item.
		/// 
		/// </param>
		///
		/// <param name="DestinationPostalCode">
		/// The destination postal code (or zip code for US) is supplied in this field. <b>GetItemShipping</b> requires the destination of the shipment. Some countries will require both the <b>DestinationPostalCode</b> and the lt;b>DestinationCountryCode</b>, and some countries will accept either one or the other.
		/// </param>
		///
		/// <param name="DestinationCountryCode">
		/// The destination country code is supplied in this field. <b>GetItemShipping</b> requires the destination of the shipment. Some countries will require both the <b>DestinationPostalCode</b> and the lt;b>DestinationCountryCode</b>, and some countries will accept either one or the other.
		/// 
		/// Two-digit country codes can be found in <a href="types/CountryCodeType.html">CountryCodeType</a>.
		/// 
		/// </param>
		///
		public ShippingDetailsType GetItemShipping(string ItemID, int QuantitySold, string DestinationPostalCode, CountryCodeType DestinationCountryCode)
		{
			this.ItemID = ItemID;
			this.QuantitySold = QuantitySold;
			this.DestinationPostalCode = DestinationPostalCode;
			this.DestinationCountryCode = DestinationCountryCode;

			Execute();
			return ApiResponse.ShippingDetails;
		}


		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ShippingDetailsType GetItemShipping(string ItemID, string DestinationPostalCode)
		{
			this.ItemID = ItemID;
			this.DestinationPostalCode = DestinationPostalCode;
			Execute();
			return ShippingDetails;
		}
		/// <summary>
		/// For backward compatibility with old wrappers.
		/// </summary>
		public ShippingDetailsType GetItemShipping(string ItemID, string DestinationPostalCode, CountryCodeType DestinationCountryCode)
		{
			this.DestinationCountryCode = DestinationCountryCode;
			this.ItemID = ItemID;
			this.DestinationPostalCode = DestinationPostalCode;
			Execute();
			return ShippingDetails;
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
		/// Gets or sets the <see cref="GetItemShippingRequestType"/> for this API call.
		/// </summary>
		public GetItemShippingRequestType ApiRequest
		{ 
			get { return (GetItemShippingRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetItemShippingResponseType"/> for this API call.
		/// </summary>
		public GetItemShippingResponseType ApiResponse
		{ 
			get { return (GetItemShippingResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemShippingRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemShippingRequestType.QuantitySold"/> of type <see cref="int"/>.
		/// </summary>
		public int QuantitySold
		{ 
			get { return ApiRequest.QuantitySold; }
			set { ApiRequest.QuantitySold = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemShippingRequestType.DestinationPostalCode"/> of type <see cref="string"/>.
		/// </summary>
		public string DestinationPostalCode
		{ 
			get { return ApiRequest.DestinationPostalCode; }
			set { ApiRequest.DestinationPostalCode = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetItemShippingRequestType.DestinationCountryCode"/> of type <see cref="CountryCodeType"/>.
		/// </summary>
		public CountryCodeType DestinationCountryCode
		{ 
			get { return ApiRequest.DestinationCountryCode; }
			set { ApiRequest.DestinationCountryCode = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemShippingResponseType.ShippingDetails"/> of type <see cref="ShippingDetailsType"/>.
		/// </summary>
		public ShippingDetailsType ShippingDetails
		{ 
			get { return ApiResponse.ShippingDetails; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetItemShippingResponseType.PickUpInStoreDetails"/> of type <see cref="PickupInStoreDetailsType"/>.
		/// </summary>
		public PickupInStoreDetailsType PickUpInStoreDetails
		{ 
			get { return ApiResponse.PickUpInStoreDetails; }
		}
		

		#endregion

		
	}
}

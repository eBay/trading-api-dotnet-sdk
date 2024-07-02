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
	public class GetUserContactDetailsCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetUserContactDetailsCall()
		{
			ApiRequest = new GetUserContactDetailsRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetUserContactDetailsCall(ApiContext ApiContext)
		{
			ApiRequest = new GetUserContactDetailsRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call is used to retrieve contact information for a specified eBay user, given that a bidding relationship (as either a buyer or seller) exists between the caller and the user.
		/// </summary>
		/// 
		/// <param name="ItemID">
		/// A unique identifier for the eBay listing that the caller and order partner have in common.
		/// </param>
		///
		/// <param name="ContactID">
		/// An eBay user ID that uniquely identifies a given user for whom the caller is seeking information. Either a seller's or bidder's/buyer's user ID can be specified here, as long as an bidding/order relationship exists between the requester and the user specified by this field. That is, a bidder must be bidding on the seller's active auction item, or a prospective buyer has proposed a Best Offer on a listing.
		/// </param>
		///
		/// <param name="RequesterID">
		/// An eBay user ID that uniquely identifies the person who is making the call. Either a seller's or bidder's/buyer's user ID can be specified here, as long as a bidding/order relationship exists between the requester and the user for whom information is being requested.
		/// </param>
		///
		public string GetUserContactDetails(string ItemID, string ContactID, string RequesterID)
		{
			this.ItemID = ItemID;
			this.ContactID = ContactID;
			this.RequesterID = RequesterID;

			Execute();
			return ApiResponse.UserID;
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
		/// Gets or sets the <see cref="GetUserContactDetailsRequestType"/> for this API call.
		/// </summary>
		public GetUserContactDetailsRequestType ApiRequest
		{ 
			get { return (GetUserContactDetailsRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetUserContactDetailsResponseType"/> for this API call.
		/// </summary>
		public GetUserContactDetailsResponseType ApiResponse
		{ 
			get { return (GetUserContactDetailsResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserContactDetailsRequestType.ItemID"/> of type <see cref="string"/>.
		/// </summary>
		public string ItemID
		{ 
			get { return ApiRequest.ItemID; }
			set { ApiRequest.ItemID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserContactDetailsRequestType.ContactID"/> of type <see cref="string"/>.
		/// </summary>
		public string ContactID
		{ 
			get { return ApiRequest.ContactID; }
			set { ApiRequest.ContactID = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="GetUserContactDetailsRequestType.RequesterID"/> of type <see cref="string"/>.
		/// </summary>
		public string RequesterID
		{ 
			get { return ApiRequest.RequesterID; }
			set { ApiRequest.RequesterID = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserContactDetailsResponseType.UserID"/> of type <see cref="string"/>.
		/// </summary>
		public string UserID
		{ 
			get { return ApiResponse.UserID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserContactDetailsResponseType.ContactAddress"/> of type <see cref="AddressType"/>.
		/// </summary>
		public AddressType ContactAddress
		{ 
			get { return ApiResponse.ContactAddress; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetUserContactDetailsResponseType.RegistrationDate"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime RegistrationDate
		{ 
			get { return ApiResponse.RegistrationDate; }
		}
		

		#endregion

		
	}
}

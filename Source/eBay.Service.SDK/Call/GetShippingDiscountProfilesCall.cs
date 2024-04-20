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
	public class GetShippingDiscountProfilesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetShippingDiscountProfilesCall()
		{
			ApiRequest = new GetShippingDiscountProfilesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetShippingDiscountProfilesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetShippingDiscountProfilesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call retrieves all shipping discount profiles currently defined by the user, along with other Combined Invoice-related details such as packaging and handling costs.
		/// </summary>
		/// 
		public CurrencyCodeType GetShippingDiscountProfiles()
		{

			Execute();
			return ApiResponse.CurrencyID;
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
		/// Gets or sets the <see cref="GetShippingDiscountProfilesRequestType"/> for this API call.
		/// </summary>
		public GetShippingDiscountProfilesRequestType ApiRequest
		{ 
			get { return (GetShippingDiscountProfilesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetShippingDiscountProfilesResponseType"/> for this API call.
		/// </summary>
		public GetShippingDiscountProfilesResponseType ApiResponse
		{ 
			get { return (GetShippingDiscountProfilesResponseType) AbstractResponse; }
		}

		
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.CurrencyID"/> of type <see cref="CurrencyCodeType"/>.
		/// </summary>
		public CurrencyCodeType CurrencyID
		{ 
			get { return ApiResponse.CurrencyID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.FlatShippingDiscount"/> of type <see cref="FlatShippingDiscountType"/>.
		/// </summary>
		public FlatShippingDiscountType FlatShippingDiscount
		{ 
			get { return ApiResponse.FlatShippingDiscount; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.CalculatedShippingDiscount"/> of type <see cref="CalculatedShippingDiscountType"/>.
		/// </summary>
		public CalculatedShippingDiscountType CalculatedShippingDiscount
		{ 
			get { return ApiResponse.CalculatedShippingDiscount; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.PromotionalShippingDiscount"/> of type <see cref="bool"/>.
		/// </summary>
		public bool PromotionalShippingDiscount
		{ 
			get { return ApiResponse.PromotionalShippingDiscount; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.CalculatedHandlingDiscount"/> of type <see cref="CalculatedHandlingDiscountType"/>.
		/// </summary>
		public CalculatedHandlingDiscountType CalculatedHandlingDiscount
		{ 
			get { return ApiResponse.CalculatedHandlingDiscount; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.PromotionalShippingDiscountDetails"/> of type <see cref="PromotionalShippingDiscountDetailsType"/>.
		/// </summary>
		public PromotionalShippingDiscountDetailsType PromotionalShippingDiscountDetails
		{ 
			get { return ApiResponse.PromotionalShippingDiscountDetails; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.ShippingInsurance"/> of type <see cref="ShippingInsuranceType"/>.
		/// </summary>
        //public ShippingInsuranceType ShippingInsurance
        //{ 
        //    get { return ApiResponse.ShippingInsurance; }
        //}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.InternationalShippingInsurance"/> of type <see cref="ShippingInsuranceType"/>.
		/// </summary>
        //public ShippingInsuranceType InternationalShippingInsurance
        //{ 
        //    get { return ApiResponse.InternationalShippingInsurance; }
        //}
		
 		/// <summary>
		/// Gets the returned <see cref="GetShippingDiscountProfilesResponseType.CombinedDuration"/> of type <see cref="CombinedPaymentPeriodCodeType"/>.
		/// </summary>
		public CombinedPaymentPeriodCodeType CombinedDuration
		{ 
			get { return ApiResponse.CombinedDuration; }
		}
		

		#endregion

		
	}
}

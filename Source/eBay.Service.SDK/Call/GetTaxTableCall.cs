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
	public class GetTaxTableCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetTaxTableCall()
		{
			ApiRequest = new GetTaxTableRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetTaxTableCall(ApiContext ApiContext)
		{
			ApiRequest = new GetTaxTableRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The base request type of the <b>GetTaxTable</b> call, which retrieves information on the seller's Sales Tax Table. This information includes all of the site's tax jurisdictions, a boolean field to indicate if sales tax is applied to shipping and handling charges, and the sales tax rate for each jurisdiction (if a sales tax rate is set for that jurisdiction).
		/// <br/><br/>
		/// Sales tax tables are only supported on the eBay US and Candada marketplaces.
		/// </summary>
		/// 
		public TaxJurisdictionTypeCollection GetTaxTable()
		{

			Execute();
			return ApiResponse.TaxTable;
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
		/// Gets or sets the <see cref="GetTaxTableRequestType"/> for this API call.
		/// </summary>
		public GetTaxTableRequestType ApiRequest
		{ 
			get { return (GetTaxTableRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetTaxTableResponseType"/> for this API call.
		/// </summary>
		public GetTaxTableResponseType ApiResponse
		{ 
			get { return (GetTaxTableResponseType) AbstractResponse; }
		}

		
		
 		/// <summary>
		/// Gets the returned <see cref="GetTaxTableResponseType.LastUpdateTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime LastUpdateTime
		{ 
			get { return ApiResponse.LastUpdateTime; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetTaxTableResponseType.TaxTable"/> of type <see cref="TaxJurisdictionTypeCollection"/>.
		/// </summary>
		public TaxJurisdictionTypeCollection TaxTableList
		{ 
			get { return ApiResponse.TaxTable; }
		}
		

		#endregion

		
	}
}

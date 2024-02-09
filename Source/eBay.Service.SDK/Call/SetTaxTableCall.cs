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
	public class SetTaxTableCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public SetTaxTableCall()
		{
			ApiRequest = new SetTaxTableRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public SetTaxTableCall(ApiContext ApiContext)
		{
			ApiRequest = new SetTaxTableRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call allows you to add or modify sales tax rates for one or more tax jurisdictions within the specified site. Any additions or modifications made with this call is saved in the seller's Sales Tax Table in My eBay.
		/// <br/><br/>
		/// Sales Tax Tables are only supported on the US and Canada (English and French versions) sites, so this call is only applicable to those sites. To view their current Sales Tax Table, a seller may go to the Sales Tax Table in My eBay, or they can make a <b>GetTaxTable</b> call.
		/// </summary>
		/// 
		/// <param name="TaxTableList">
		/// This table is used to set or modify sales tax rates for one or more tax jurisdictions within that country. A <b>TaxJurisdiction</b> container is required for each tax jurisdiction that is being added/updated.
		/// </param>
		///
		public void SetTaxTable(TaxJurisdictionTypeCollection TaxTableList)
		{
			this.TaxTableList = TaxTableList;

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
		/// Gets or sets the <see cref="SetTaxTableRequestType"/> for this API call.
		/// </summary>
		public SetTaxTableRequestType ApiRequest
		{ 
			get { return (SetTaxTableRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="SetTaxTableResponseType"/> for this API call.
		/// </summary>
		public SetTaxTableResponseType ApiResponse
		{ 
			get { return (SetTaxTableResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="SetTaxTableRequestType.TaxTable"/> of type <see cref="TaxJurisdictionTypeCollection"/>.
		/// </summary>
		public TaxJurisdictionTypeCollection TaxTableList
		{ 
			get { return ApiRequest.TaxTable; }
			set { ApiRequest.TaxTable = value; }
		}
		
		

		#endregion

		
	}
}

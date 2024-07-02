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
	public class GetSuggestedCategoriesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public GetSuggestedCategoriesCall()
		{
			ApiRequest = new GetSuggestedCategoriesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public GetSuggestedCategoriesCall(ApiContext ApiContext)
		{
			ApiRequest = new GetSuggestedCategoriesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// This call returns a list of up to 10 eBay categories that have the highest percentage of listings whose listing titles or descriptions contain the keywords you specify.
		/// </summary>
		/// 
		/// <param name="Query">
		/// This field is used to specify the search query, consisting of one or
		/// more keywords to search for in listing titles and descriptions.
		/// The words "and" and "or" are treated like any other
		/// word.
		/// </param>
		///
		public SuggestedCategoryTypeCollection GetSuggestedCategories(string Query)
		{
			this.Query = Query;

			Execute();
			return (ApiResponse.SuggestedCategoryArray==null?null:ApiResponse.SuggestedCategoryArray.SuggestedCategory);
		}


		/// <summary>
		/// Gets the <see cref="SuggestedCategoryArrayType.SuggestedCategory"/> of type <see cref="SuggestedCategoryTypeCollection"/>.
		/// </summary>
		public SuggestedCategoryTypeCollection SuggestedCategoryList
		{ 
			get {
				if (ApiResponse.SuggestedCategoryArray == null)
					return null;
				return ApiResponse.SuggestedCategoryArray.SuggestedCategory; }
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
		/// Gets or sets the <see cref="GetSuggestedCategoriesRequestType"/> for this API call.
		/// </summary>
		public GetSuggestedCategoriesRequestType ApiRequest
		{ 
			get { return (GetSuggestedCategoriesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="GetSuggestedCategoriesResponseType"/> for this API call.
		/// </summary>
		public GetSuggestedCategoriesResponseType ApiResponse
		{ 
			get { return (GetSuggestedCategoriesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="GetSuggestedCategoriesRequestType.Query"/> of type <see cref="string"/>.
		/// </summary>
		public string Query
		{ 
			get { return ApiRequest.Query; }
			set { ApiRequest.Query = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="GetSuggestedCategoriesResponseType.SuggestedCategoryArray"/> of type <see cref="SuggestedCategoryArrayType"/>.
		/// </summary>
		public SuggestedCategoryArrayType SuggestedCategoryArray
		{ 
			get { return ApiResponse.SuggestedCategoryArray; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="GetSuggestedCategoriesResponseType.CategoryCount"/> of type <see cref="int"/>.
		/// </summary>
		public int CategoryCount
		{ 
			get { return ApiResponse.CategoryCount; }
		}
		

		#endregion

		
	}
}

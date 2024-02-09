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
	public class ExtendSiteHostedPicturesCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public ExtendSiteHostedPicturesCall()
		{
			ApiRequest = new ExtendSiteHostedPicturesRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public ExtendSiteHostedPicturesCall(ApiContext ApiContext)
		{
			ApiRequest = new ExtendSiteHostedPicturesRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// By default, unpublished pictures uploaded to eBay Picture Services (EPS) via the <b>UploadSiteHostedPictures</b> call will be kept on the server for five days before being purged. The <b>ExtendSiteHostedPictures</b> call is used to extend this expiration date by the number of days specified in the call. This restricted call gives approved sellers the ability to extend the default expiration date of pictures uploaded to EPS but not immediately published in an eBay listing.
		/// </summary>
		/// 
		/// <param name="PictureURLList">
		/// The URL of the image hosted by eBay Picture Services. This URL is returned in the <b>SiteHostedPictureDetails.FullURL</b> field of the <b>UploadSiteHostedPictures</b> response.
		/// </param>
		///
		/// <param name="ExtensionInDays">
		/// The number of days by which to extend the expiration date for the
		/// specified image.
		/// </param>
		///
		public StringCollection ExtendSiteHostedPictures(StringCollection PictureURLList, int ExtensionInDays)
		{
			this.PictureURLList = PictureURLList;
			this.ExtensionInDays = ExtensionInDays;

			Execute();
			return ApiResponse.PictureURL;
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
		/// Gets or sets the <see cref="ExtendSiteHostedPicturesRequestType"/> for this API call.
		/// </summary>
		public ExtendSiteHostedPicturesRequestType ApiRequest
		{ 
			get { return (ExtendSiteHostedPicturesRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="ExtendSiteHostedPicturesResponseType"/> for this API call.
		/// </summary>
		public ExtendSiteHostedPicturesResponseType ApiResponse
		{ 
			get { return (ExtendSiteHostedPicturesResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="ExtendSiteHostedPicturesRequestType.PictureURL"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection PictureURLList
		{ 
			get { return ApiRequest.PictureURL; }
			set { ApiRequest.PictureURL = value; }
		}
		
 		/// <summary>
		/// Gets or sets the <see cref="ExtendSiteHostedPicturesRequestType.ExtensionInDays"/> of type <see cref="int"/>.
		/// </summary>
		public int ExtensionInDays
		{ 
			get { return ApiRequest.ExtensionInDays; }
			set { ApiRequest.ExtensionInDays = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="ExtendSiteHostedPicturesResponseType.PictureURL"/> of type <see cref="StringCollection"/>.
		/// </summary>
		public StringCollection PictureURLListReturn
		{ 
			get { return ApiResponse.PictureURL; }
		}
		

		#endregion

		
	}
}

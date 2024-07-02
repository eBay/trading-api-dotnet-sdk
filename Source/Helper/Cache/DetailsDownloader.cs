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


using System;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
using eBay.Service.Call;


namespace Samples.Helper.Cache
{
    /// <summary>
    /// Helper class with cache function for GeteBayDetails call
    /// </summary>
    public class DetailsDownloader : BaseDownloader
    {
        #region constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public DetailsDownloader(ApiContext context)
        {
            this.context = context;
            //must initialize some super class fields
            this.filePrefix = "EBayDetails";
            this.fileSuffix = "eds";
            this.objType = typeof(GeteBayDetailsResponseType);
        }

        #endregion

        #region public methods

        /// <summary>
        /// Get eBay details
        /// </summary>
        public GeteBayDetailsResponseType GeteBayDetails()
        {
            object obj = getObject();
            return (GeteBayDetailsResponseType)obj;
        }

        #endregion


        #region private methods

        /// <summary>
        /// get last update time from site
        /// </summary>
        /// <returns>string</returns>
        protected override string getLastUpdateTime()
        {
            GeteBayDetailsCall api = new GeteBayDetailsCall(context);
            //set output selector
            api.ApiRequest.OutputSelector = new StringCollection(new String[] { "UpdateTime" });

            //execute call
            DetailNameCodeTypeCollection dns = this.getDetailsNames();
            api.GeteBayDetails(dns);

            DateTime updateTime = api.ApiResponse.UpdateTime;

            return updateTime.ToString("yyyy-MM-dd-hh-mm-ss");
        }

        private DetailNameCodeTypeCollection getDetailsNames()
        {
        	DetailNameCodeTypeCollection names=new DetailNameCodeTypeCollection();
			names.Add(DetailNameCodeType.ShippingLocationDetails);
			names.Add(DetailNameCodeType.ShippingServiceDetails);
			names.Add(DetailNameCodeType.ReturnPolicyDetails);
            return names;
        }


        /// <summary>
        /// call GeteBayDetails to get eBay details for a given site
        /// </summary>
        /// <returns>generic object</returns>
        protected override object callApi()
        {
            GeteBayDetailsCall api = new GeteBayDetailsCall(context);
            DetailNameCodeTypeCollection dns = this.getDetailsNames();
            api.GeteBayDetails(dns);

            return api.ApiResponse;
        }


        #endregion


    }
}

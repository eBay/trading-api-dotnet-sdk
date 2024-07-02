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
using System.Configuration;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;

using System.Net;

using System.Net.Security;

using System.Security.Cryptography.X509Certificates;


namespace HelloWorld
{
    /// <summary>
    /// A helloworld type of sample, 
    /// showing how to call eBay API using eBay SDK.
    /// </summary>
    class Program
    {
        private static ApiContext apiContext = null;

        static void Main(string[] args)
        {

            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +");
            Console.WriteLine("+ - HelloWorld                        +");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");

            //[Step 1] Initialize eBay ApiContext object
            ApiContext apiContext = GetApiContext();


            //[Step 2] Create Call object and execute the Call
            GeteBayOfficialTimeCall apiCall = new GeteBayOfficialTimeCall(apiContext);
            Console.WriteLine("Begin to call eBay API, please wait ...");
            DateTime officialTime = apiCall.GeteBayOfficialTime();
            Console.WriteLine("End to call eBay API, show call result:");

            //[Step 3] Handle the result returned
            Console.WriteLine("eBay official Time: " + officialTime);
            Console.WriteLine();
            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();

        }


        /// <summary>
        /// Populate eBay SDK ApiContext object with data from application configuration file
        /// </summary>
        /// <returns>ApiContext</returns>
        static ApiContext GetApiContext()
        {
            //apiContext is a singleton,
            //to avoid duplicate configuration reading
            if (apiContext != null)
            {
                return apiContext;
            }
            else
            {
                apiContext = new ApiContext();

                //set Api Server Url
                apiContext.SoapApiServerUrl = 
                    ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
                //set Api Token to access eBay Api Server
                ApiCredential apiCredential = new ApiCredential();
                apiCredential.eBayToken = 
                    ConfigurationManager.AppSettings["UserAccount.ApiToken"];
                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to US
                apiContext.Site = SiteCodeType.US;

                return apiContext;
            }
        }
        
    }
}

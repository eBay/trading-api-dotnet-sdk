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
using System.Collections.Generic;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using eBay.Service.Util;
using System.IO;
using eBay.Service.EPS;

namespace UploadSiteHostedPicturesBinaryFile
{
    class Program
    {
        private static ApiContext apiContext = null;
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("+ Welcome to eBay SDK for .Net Sample +");
                Console.WriteLine("+ - ConsoleGetItemUsingOAuth      +");
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++");

                //Initialize eBay ApiContext object
                ApiContext apiContext = GetApiContext();

                System.Net.WebClient webClient = new System.Net.WebClient();
                byte[] byteFile = webClient.DownloadData(@"https://www.wikihow.com/images/9/91/Get-the-URL-for-Pictures-Step-1.jpg");

                //byte[] byteFile = File.ReadAllBytes(@"https://www.wikihow.com/images/9/91/Get-the-URL-for-Pictures-Step-1.jpg");
                Base64BinaryType b = new Base64BinaryType();
                b.Value = byteFile;
                eBay.Service.EPS.eBayPictureService eps = new eBayPictureService(GetApiContext());
                UploadSiteHostedPicturesRequestType req = new UploadSiteHostedPicturesRequestType();
                req.PictureName = "Gall";
                req.PictureData = b;
                
                eps.UpLoadSiteHostedPicture(req, @"https://www.wikihow.com/images/9/91/Get-the-URL-for-Pictures-Step-1.jpg");

                Console.WriteLine("Begin to call eBay API, please wait ...");

                Console.WriteLine("End to call eBay API, show call result ...");
                Console.WriteLine();
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to get submit data : " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();

        }

        /// <summary>
        /// Populate eBay SDK ApiContext object with data from application configuration file
        /// </summary>
        /// <returns>ApiContext object</returns>
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
                apiContext.EPSServerUrl = ConfigurationManager.AppSettings["Environment.EPSServerURL"];
                apiCredential.eBayToken =
                    ConfigurationManager.AppSettings["UserAccount.ApiToken"];
                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to US
                apiContext.Site = SiteCodeType.US;
                apiContext.Version = "1027";

                //set Api logging
                apiContext.ApiLogManager = new ApiLogManager();
                apiContext.ApiLogManager.ApiLoggerList.Add(
                    new FileLogger("listing_log.txt", true, true, true)
                    );
                apiContext.ApiLogManager.EnableLogging = true;


                return apiContext;
            }
        }
    }
}

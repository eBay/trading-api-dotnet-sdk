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
using System.Net;
using System.IO;
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
using eBay.Service.EPS;
#endregion

namespace AllTestsSuite.T_020_OtherTestsSuite
{
    [TestFixture]
    public class T_400_SiteHostedPictures :SOAPTestBase
    {

        private string GetPicture()
        {
            string fileName = "eBayLogoTM.gif";

            string picPath = Directory.GetCurrentDirectory() + "\\" + fileName;
            Console.WriteLine("\nGot picture file from :\n\t" + picPath);

            return picPath;
        }

        [Test]
        public void UploadSiteHostedPictures()
        {
            //test UploadSiteHostedPictures
            string pic = GetPicture();
            eBayPictureService eps = new eBayPictureService(this.apiContext);
            UploadSiteHostedPicturesRequestType request = new UploadSiteHostedPicturesRequestType();
            request.PictureWatermark = new PictureWatermarkCodeTypeCollection();
            request.PictureWatermark.Add(PictureWatermarkCodeType.User);
            UploadSiteHostedPicturesResponseType response = eps.UpLoadSiteHostedPicture(request, pic);
            Console.WriteLine("Picture is uploaded to : " + response.SiteHostedPictureDetails.FullURL);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.Ack != AckCodeType.Failure);

            Assert.IsNotNull(response.SiteHostedPictureDetails);
            string picUrl = response.SiteHostedPictureDetails.FullURL;
            Assert.IsTrue(picUrl.Length > 0);

            ExtendSiteHostedPicturesCall eshpCall = new ExtendSiteHostedPicturesCall(this.apiContext);
            eshpCall.PictureURLList = new StringCollection(new String[] { picUrl });
            eshpCall.ExtensionInDays = 10;
            eshpCall.Execute();
            StringCollection picURLList = eshpCall.PictureURLListReturn;
        }
    }
}


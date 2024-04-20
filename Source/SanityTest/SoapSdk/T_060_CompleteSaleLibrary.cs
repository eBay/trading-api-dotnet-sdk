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
using NUnit.Framework;
using eBay.Service.Call;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
#endregion

namespace AllTestsSuite.T_080_TransactionTestsSuite
{
	[TestFixture]
	public class T_060_CompleteSaleLibrary : SOAPTestBase
	{
		[Test]
		public void CompleteSale()
		{
			CompleteSaleCall api = new CompleteSaleCall(this.apiContext);
			TransactionType tran = null;
			if( TestData.SellerTransactions != null && TestData.SellerTransactions.Count > 0 )
			tran = TestData.SellerTransactions[0];
			// Make API call.
			ApiException gotException = null;
			// Negative test.
			try
			{
			if( tran != null )
			{
			api.ItemID = tran.Item.ItemID;
			api.TransactionID = tran.TransactionID;
			PaymentStatusCodeType pStatus = tran.Status.eBayPaymentStatus;
			api.Paid = (pStatus == PaymentStatusCodeType.NoPaymentFailure)
			&& (tran.PaidTimeSpecified);
			}
			else
			api.ItemID = "TestID";
			api.Execute();
			}
			catch(ApiException ex)
			{
				gotException = ex;
			}
			if( gotException != null )
			Assert.IsNull(tran);
			
		}

        [Test]
        public void CompleteSale2()
        {
            CompleteSaleCall call = new CompleteSaleCall(this.apiContext);
            call.OrderID = "436095409011";
            call.Shipment = new ShipmentType();

            ShipmentTrackingDetailsType shipmentTrackingDetails = new ShipmentTrackingDetailsType();
            shipmentTrackingDetails.ShippingCarrierUsed = "DHL";
            shipmentTrackingDetails.ShipmentTrackingNumber = "6KH8F75870W5916";
            call.Shipment.ShipmentTrackingDetails = new ShipmentTrackingDetailsTypeCollection();
            call.Shipment.ShipmentTrackingDetails.Add(shipmentTrackingDetails);
            call.Shipment.ShippedTime = DateTime.Now;
            call.Shipped = true;

            try
            {
                call.Execute();
            }
            catch (Exception ex)
            {
                bool err = call.ApiException.containsErrorCode("55");
                Assert.IsFalse(err);
            }
        }
	}
}
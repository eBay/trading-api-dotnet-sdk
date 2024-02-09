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
	public class AddOrderCall : ApiCall
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public AddOrderCall()
		{
			ApiRequest = new AddOrderRequestType();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ApiContext">The <see cref="ApiCall.ApiContext"/> for this API Call of type <see cref="ApiContext"/>.</param>
		public AddOrderCall(ApiContext ApiContext)
		{
			ApiRequest = new AddOrderRequestType();
			this.ApiContext = ApiContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// The <b>AddOrder</b> call can be used by a seller to combine two or more unpaid, single line item orders from the same buyer into one 'Combined Invoice' order with multiple line items. Once multiple line items are combined into one order, the buyer can make one single payment for multiple line item order. If possible and agreed to, the seller can then ship multiple line items in the same shipping package, saving on shipping costs, and possibly passing that savings down to the buyer through Combined Shipping Discount rules set up in My eBay.
		/// </summary>
		/// 
		/// <param name="Order">
		/// The root container of the <b>AddOrder</b> request. In this call, the seller identifies two or more unpaid order line items from the same buyer through the <b>TransactionArray</b> container, specifies one or more accepted payment methods through the <b>PaymentMethods</b> field(s), and specifies available shipping services and other shipping details through the <b>ShippingDetails</b> container.
		/// </param>
		///
		public string AddOrder(OrderType Order)
		{
			this.Order = Order;

			Execute();
			return ApiResponse.OrderID;
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Execute()
		{
			base.Execute();
			Order.OrderID = ApiResponse.OrderID;
			Order.CreatedTime = ApiResponse.CreatedTime;
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
		/// Gets or sets the <see cref="AddOrderRequestType"/> for this API call.
		/// </summary>
		public AddOrderRequestType ApiRequest
		{ 
			get { return (AddOrderRequestType) AbstractRequest; }
			set { AbstractRequest = value; }
		}

		/// <summary>
		/// Gets the <see cref="AddOrderResponseType"/> for this API call.
		/// </summary>
		public AddOrderResponseType ApiResponse
		{ 
			get { return (AddOrderResponseType) AbstractResponse; }
		}

		
 		/// <summary>
		/// Gets or sets the <see cref="AddOrderRequestType.Order"/> of type <see cref="OrderType"/>.
		/// </summary>
		public OrderType Order
		{ 
			get { return ApiRequest.Order; }
			set { ApiRequest.Order = value; }
		}
		
		
 		/// <summary>
		/// Gets the returned <see cref="AddOrderResponseType.OrderID"/> of type <see cref="string"/>.
		/// </summary>
		public string OrderID
		{ 
			get { return ApiResponse.OrderID; }
		}
		
 		/// <summary>
		/// Gets the returned <see cref="AddOrderResponseType.CreatedTime"/> of type <see cref="DateTime"/>.
		/// </summary>
		public DateTime CreatedTime
		{ 
			get { return ApiResponse.CreatedTime; }
		}
		

		#endregion

		
	}
}

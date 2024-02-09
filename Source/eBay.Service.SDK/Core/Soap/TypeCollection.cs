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

using System.Diagnostics;
using System.Xml.Serialization;
using System;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.Services;
using System.Collections;
using System.Xml;

namespace eBay.Service.Core.Soap
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable()]
	public sealed class TypeCollection : System.Collections.CollectionBase 
	{
        
		/// <summary>
		/// 
		/// </summary>
		public TypeCollection() 
		{
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public TypeCollection(Type[] items) 
		{
			this.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public TypeCollection(TypeCollection items) 
		{
			this.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		public Type this[int index] 
		{
			get 
			{
				return ((Type)(this.InnerList[index]));
			}
			set 
			{
				this.InnerList[index] = value;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public bool IsFixedSize 
		{
			get 
			{
				return this.InnerList.IsFixedSize;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public bool IsReadOnly 
		{
			get 
			{
				return this.InnerList.IsReadOnly;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public bool IsSynchronized 
		{
			get 
			{
				return this.InnerList.IsSynchronized;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		public object SyncRoot 
		{
			get 
			{
				return this.InnerList.SyncRoot;
			}
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int Add(Type item) 
		{
			return this.InnerList.Add(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(Type[] items) 
		{
			this.InnerList.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(TypeCollection items) 
		{
			this.InnerList.AddRange(items);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(Type item) 
		{
			return this.InnerList.Contains(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="items"></param>
		/// <param name="index"></param>
		public void CopyTo(Type[] items, int index) 
		{
			this.InnerList.CopyTo(items, index);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(Type item) 
		{
			return this.InnerList.IndexOf(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <param name="item"></param>
		public void Insert(int index, Type item) 
		{
			this.InnerList.Insert(index, item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public Type ItemAt(int index) 
		{
			return ((Type)(this.InnerList[index]));
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		public void Remove(Type item) 
		{
			this.InnerList.Remove(item);
		}
        
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public Type[] ToArray() 
		{
			return ((Type[])(this.InnerList.ToArray(typeof(Type))));
		}
	}
}

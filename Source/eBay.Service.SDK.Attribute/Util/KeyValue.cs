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
using System.Collections;
using System.Runtime.InteropServices;

namespace eBay.Service.SDK.Util
{
	//----------------------------------------------------------------

	/// <summary>
	/// Defines key/value string pair object.
	/// </summary>
	public interface IKeyValue
	{
		/// <summary>
		/// Name of the key.
		/// </summary>
		string Key
		{ get; set; }

		/// <summary>
		/// Value for the key.
		/// </summary>
		string Value
		{ get; set; }
	}

	//----------------------------------------------------------------

	/// <summary>
	/// Implements <c>IKeyValue</c>.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[Serializable]
	public class KeyValue : IKeyValue
	{
		private string mKey;
		private string mValue;

		/// <summary>
		/// Constructor.
		/// </summary>
		public KeyValue()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="key">Name of the key.</param>
		/// <param name="val">Value for the key.</param>
		public KeyValue(string key, string val)
		{
			this.mKey = key;
			this.mValue = val;
		}

		/// <summary>
		/// Name of the key.
		/// </summary>
		public string Key
		{ 
			get { return mKey; }
			set { mKey = value; }
		}

		/// <summary>
		/// Value for the key.
		/// </summary>
		public string Value
		{ 
			get { return mValue; }
			set { mValue = value; }
		}
	}


	//--------------------------------------------------------------------

	/// <summary>
	/// IKeyValue collection. This interface simulates <c>System.Collectionis.Specialized.NameValueCollection</c>
	/// but it's COM-friendly that can be called from any language.
	/// </summary>
	public interface IKeyValueCollection : IList, ICollection, IEnumerable
	{
		// ==== Strong typed methods ====

		/// <summary>
		/// Gets an element at the specified index in the collection.
		/// </summary>
		new IKeyValue this[int index]
		{
			get; set;
		}

		/// <summary>
		/// Add element.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		int Add(IKeyValue value);

		/// <summary>
		/// Add an array of IKeyValue.
		/// </summary>
		/// <param name="items"></param>
		void AddRange(IKeyValue[] items);

		/// <summary>
		/// Adds the contents of the specified IKeyValueCollection 
		/// to the end of the collection.
		/// </summary>
		/// <param name="items"></param>
		void AddRange(IKeyValueCollection items);

		/// <summary>
		/// Indicates whether a specified object is contained in the list.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		bool Contains(IKeyValue value);

		/// <summary>
		/// Copies the collection objects to a one-dimensional Array 
		/// instance beginning at the specified index.
		/// </summary>
		/// <param name="array"></param>
		/// <param name="index"></param>
		void CopyTo(
			IKeyValue[] array,
			int index
			);

		/// <summary>
		/// Get index of an element.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		int IndexOf(IKeyValue value);

		/// <summary>
		/// Insert element to list.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		void Insert(int index, IKeyValue value);

		/// <summary>
		/// Returns number of items in the collection.
		/// </summary>
		/// <returns>Number of items.</returns>
		int ItemCount();

		/// <summary>
		/// Returns item by index. 
		/// </summary>
		IKeyValue ItemAt(int index);

		/// <summary>
		/// Remove element from list.
		/// </summary>
		/// <param name="value"></param>
		void Remove(IKeyValue value);

		/// <summary>
		/// Search node by key.
		/// </summary>
		/// <param name="key">The key string to search.</param>
		/// <returns>null means not found.</returns>
		IKeyValue Find(string key);
	}

	//--------------------------------------------------------------------

	/// <summary>
	/// Strong typed IKeyValue collection
	/// </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[Serializable]
	public sealed class KeyValueCollection : CollectionBase, IKeyValueCollection
	{
		/// <summary>
		/// Default constructor.
		/// </summary>
		public KeyValueCollection()
		{
		}

		/// <summary>
		/// Initializes a new instance containing the specified array 
		/// of IKeyValue objects
		/// </summary>
		/// <param name="value"></param>
		public KeyValueCollection(
			IKeyValue[] value
			)
		{
			AddRange(value);
		}

		/// <summary>
		/// Initializes a new instance containing the elements of 
		/// the specified source collection.
		/// </summary>
		/// <param name="value"></param>
		public KeyValueCollection(
			IKeyValueCollection value
			)
		{
			AddRange(value);
		}

		// ======== IKeyValueCollection ========

		/// <summary>
		/// Gets an element at the specified index in the collection.
		/// </summary>
		public IKeyValue this[int index]
		{
			get { return (IKeyValue)InnerList[index]; }
			set { InnerList[index] = value; }
		}

		/// <summary>
		/// Add element.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int Add(IKeyValue value)
		{
			return InnerList.Add(value);
		}

		/// <summary>
		/// Add an array of IKeyValue.
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(IKeyValue[] items)
		{
			InnerList.AddRange(items);
		}

		/// <summary>
		/// Adds the contents of the specified IKeyValueCollection 
		/// to the end of the collection.
		/// </summary>
		/// <param name="items"></param>
		public void AddRange(IKeyValueCollection items)
		{
			InnerList.AddRange(items);
		}

		/// <summary>
		/// Indicates whether a specified object is contained in the list.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public bool Contains(IKeyValue value)
		{
			return InnerList.Contains(value);
		}

		/// <summary>
		/// Copies the collection objects to a one-dimensional Array 
		/// instance beginning at the specified index.
		/// </summary>
		/// <param name="array"></param>
		/// <param name="index"></param>
		public void CopyTo(
			IKeyValue[] array,
			int index
			)
		{
			InnerList.CopyTo(array, index);
		}

		/// <summary>
		/// Get index of an element.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public int IndexOf(IKeyValue value)
		{
			return InnerList.IndexOf(value);
		}

		/// <summary>
		/// Insert element to list.
		/// </summary>
		/// <param name="index"></param>
		/// <param name="value"></param>
		public void Insert(int index, IKeyValue value)
		{
			InnerList.Insert(index, value);
		}

		/// <summary>
		/// Returns number of items in the collection.
		/// </summary>
		/// <returns>Number of items.</returns>
		public int ItemCount()
		{
			return InnerList.Count;
		}

		/// <summary>
		/// Returns item by index. 
		/// </summary>
		public IKeyValue ItemAt(int index)
		{
			return (IKeyValue)InnerList[index];
		}

		/// <summary>
		/// Remove element from list.
		/// </summary>
		/// <param name="value"></param>
		public void Remove(IKeyValue value)
		{
			InnerList.Remove(value);
		}

		/// <summary>
		/// Search node by key.
		/// </summary>
		/// <param name="key">The key string to search.</param>
		/// <returns>null means not found.</returns>
		public IKeyValue Find(string key)
		{
			IKeyValue found = null;
			foreach(IKeyValue kv in this.InnerList)
			{
				if( kv.Key == key )
				{
					found = kv;
					break;
				}
			}
			
			return found;
		}
	}
}

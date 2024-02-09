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
using System.Runtime.InteropServices;

namespace Samples.Helper.UI
{
	/// <summary>
	/// Defines object to associate object with string.
	/// </summary>
	public interface IControlTagItem
	{
		/// <summary>
		/// The string.
		/// </summary>
		string Text
		{
			get; set;
		}

		/// <summary>
		/// The object that is associated with the string.
		/// </summary>
		object Tag
		{
			get; set;
		}
	}

	/// <summary>
	/// A helper class for associate string with an object.
	/// </summary>
	[ClassInterface(ClassInterfaceType.None)]
	[Serializable]
	public class ControlTagItem : IControlTagItem
	{
		private string mText;
		private object mTag;

		/// <summary>
		/// Constructor.
		/// </summary>
		public ControlTagItem()
		{
		}

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="text"></param>
		/// <param name="tag"></param>
		public ControlTagItem(string text, object tag)
		{
			this.Text = text;
			this.Tag = tag;
		}

		/// <summary>
		/// The string.
		/// </summary>
		public string Text
		{
			get { return mText; }
			set { mText = value; }
		}

		/// <summary>
		/// The object that is associated with the string.
		/// </summary>
		public object Tag
		{
			get { return mTag; }
			set { mTag = value; }
		}

		/// <summary>
		/// Overrided ToString().
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.Text;
		}
	}
}

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
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.XPath;
using System.Collections;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Globalization;
#endregion

namespace eBay.Service.Util
{

	/// <summary>
	/// 
	/// </summary>
	[ComVisible(false)]
	public class XmlUtility
	{

		#region Static Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName)
		{
			XmlNode child = Document.CreateElement(NodeName);
			Parent.AppendChild(child);
			return child;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <param name="Data"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName, string Data)
		{
			XmlNode child = Document.CreateElement(NodeName);
			child.InnerText = Data;
			Parent.AppendChild(child);

			return child;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <param name="Data"></param>
		/// <param name="UseCData"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName, string Data, bool UseCData)
		{
			XmlNode child;
			if (!UseCData)
			{
				child = AddChild(Document, Parent, NodeName, Data);
			}
			else
			{
				child = Document.CreateElement(NodeName);
				XmlNode cData = Document.CreateCDataSection(Data);
				child.AppendChild(cData);
				Parent.AppendChild(child);
			}

			return child;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <param name="Data"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName, bool Data)
		{
			return AddChild(Document, Parent, NodeName, Data ? "1" : "0");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <param name="Data"></param>
		/// <param name="UseDateOnly"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName, DateTime Data, bool UseDateOnly)
		{
			if (UseDateOnly)
			{
				return AddChild(Document, Parent, NodeName, ToEBayDate(Data));
			}
			else 
			{
				return AddChild(Document, Parent, NodeName, ToEBayTime(Data));
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <param name="Data"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName, decimal Data)
		{
			return AddChild(Document, Parent, NodeName, Data.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <param name="Data"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName, double Data)
		{
			return AddChild(Document, Parent, NodeName, Data.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="NodeName"></param>
		/// <param name="Data"></param>
		/// <returns></returns>
		public static XmlNode AddChild(XmlDocument Document, XmlNode Parent, string NodeName, long Data)
		{
			return AddChild(Document, Parent, NodeName, Data.ToString(CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="Parent"></param>
		/// <param name="AttributeName"></param>
		/// <param name="AttributeValue"></param>
		/// <returns></returns>
		public static XmlNode AddAttributeNode(XmlDocument Document, XmlNode Parent, string AttributeName, object AttributeValue)
		{
			XmlAttribute attr = Document.CreateAttribute(AttributeName);
			attr.Value = AttributeValue.ToString();
			Parent.Attributes.Append(attr);
			return attr;
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static bool GetBoolean(XPathNavigator Navigator, string NodeName)
		{
			string val = GetString(Navigator, NodeName).Trim().ToUpper(CultureInfo.InvariantCulture);
			return (val == "1" || val == "YES" || val == "TRUE");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static bool GetBoolean(XPathNavigator Navigator, XPathExpression XPath)
		{
			string val = GetString(Navigator, XPath).Trim().ToUpper(CultureInfo.InvariantCulture);
			return (val == "1" || val == "YES" || val == "TRUE");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static bool GetBoolean(XmlNode Node, string NodeName)
		{
			string val = GetString(Node, NodeName).Trim().ToUpper(CultureInfo.InvariantCulture);
			return (val == "1" || val == "YES");
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static DateTime GetDateTime(XPathNavigator Navigator, string NodeName)
		{
			DateTime result = new DateTime(0);
			string s = GetString(Navigator, NodeName).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = ParseEBayTime(s);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static DateTime GetDateTime(XPathNavigator Navigator, XPathExpression XPath)
		{
			DateTime result = new DateTime(0);
			string s = GetString(Navigator, XPath).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = ParseEBayTime(s);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static DateTime GetDateTime(XmlNode Node, string NodeName)
		{
			DateTime result = new DateTime(0);
			string s = GetString(Node, NodeName).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = ParseEBayTime(s);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
			}
			return result;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static decimal GetDecimal(XPathNavigator Navigator, string NodeName)
		{
			decimal result = -1.0m;
			string s = GetString(Navigator, NodeName).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = Decimal.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static decimal GetDecimal(XPathNavigator Navigator, XPathExpression XPath)
		{
			decimal result = -1.0m;
			string s = GetString(Navigator, XPath).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = Decimal.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static decimal GetDecimal(XmlNode Node, string NodeName)
		{
			decimal result = -1.0m;
			string s = GetString(Node, NodeName).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = Decimal.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static double GetDouble(XPathNavigator Navigator, string NodeName)
		{
			double result = -1.0;
			string s = GetString(Navigator, NodeName).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = Double.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static double GetDouble(XPathNavigator Navigator, XPathExpression XPath)
		{
			double result = -1.0;
			string s = GetString(Navigator, XPath).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = Double.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static double GetDouble(XmlNode Node, string NodeName)
		{
			double result = -1.0;
			string s = GetString(Node, NodeName).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = Double.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (FormatException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static int GetInteger(XPathNavigator Navigator, string NodeName)
		{
			int result = -1;
			string s = GetString(Navigator, NodeName).Trim();
			if (s.Length != 0)
			{
				try
				{
					result = Int32.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static int GetInteger(XPathNavigator Navigator, XPathExpression XPath)
		{
			int result = -1;
			string s = GetString(Navigator, XPath).Trim();
			if (s.Length != 0)
			{
				try
				{
					result = Int32.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static int GetInteger(XmlNode Node, string NodeName)
		{
			int result = -1;
			string s = GetString(Node, NodeName).Trim();
			if (s.Length > 0)
			{
				try
				{
					result = Int32.Parse(s, CultureInfo.InvariantCulture);
				}
				catch (ArgumentNullException)
				{
				}
				catch (OverflowException)
				{
				}
			}
			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static string GetString(XPathNavigator Navigator, string NodeName)
		{
			XPathNodeIterator i = Navigator.Select(NodeName);
			if (i.MoveNext())
			{
				return i.Current.Value;
			}
			else
			{
				return "";
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static string GetString(XPathNavigator Navigator, XPathExpression XPath)
		{
			XPathNodeIterator i = Navigator.Select(XPath);
			if (i.MoveNext())
			{
				return i.Current.Value;
			}
			else
			{
				return "";
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static string GetString(XmlNode Node, string NodeName)
		{
			XmlNode fnode = Node.SelectSingleNode(NodeName);
			if ( fnode != null )
				return fnode.InnerText;
			else
				return "";
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static XmlNode GetChildNode(XPathNavigator Navigator, string NodeName)
		{
			try
			{
				XPathNodeIterator i = Navigator.Select(NodeName);
				if (i.MoveNext())
					return ((IHasXmlNode)i.Current).GetNode();
				else
					return null;
			}
			catch (ArgumentException)
			{
				return null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static XmlNode GetChildNode(XPathNavigator Navigator, XPathExpression XPath)
		{
			try
			{
				XPathNodeIterator i = Navigator.Select(XPath);
				if (i.MoveNext())
					return ((IHasXmlNode)i.Current).GetNode();
				else
					return null;
			}
			catch (ArgumentException)
			{
				return null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static XmlNode GetChildNode(XmlNode Node, string NodeName)
		{

			return(Node.SelectSingleNode(NodeName));
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static bool NodeExists(XPathNavigator Navigator, string NodeName)
		{
			XPathNodeIterator i = Navigator.Select(NodeName);
			return i.MoveNext();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Navigator"></param>
		/// <param name="XPath"></param>
		/// <returns></returns>
		public static bool NodeExists(XPathNavigator Navigator, XPathExpression XPath)
		{
			XPathNodeIterator i = Navigator.Select(XPath);
			return i.MoveNext();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Node"></param>
		/// <param name="NodeName"></param>
		/// <returns></returns>
		public static bool NodeExists(XmlNode Node, string NodeName)
		{
			return (Node.SelectSingleNode(NodeName) != null);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Time"></param>
		/// <returns></returns>
		public static DateTime ParseEBayTime(string Time)
		{
			return DateTime.ParseExact(Time, EBAY_TIME_FORMAT, DateFormatProvider);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Time"></param>
		/// <returns></returns>
		public static string ToEBayTime(DateTime Time)
		{
			return Time.ToString(EBAY_TIME_FORMAT, DateFormatProvider);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Date"></param>
		/// <returns></returns>
		public static DateTime ParseEBayDate(string Date)
		{
			return DateTime.ParseExact(Date, EBAY_DATE_FORMAT, DateFormatProvider);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="Date"></param>
		/// <returns></returns>
		public static string ToEBayDate(DateTime Date)
		{
			return Date.ToString(EBAY_DATE_FORMAT, DateFormatProvider);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="Document"></param>
		/// <param name="writer"></param>
		public static void Display(XmlDocument Document, TextWriter writer)
		{
			MemoryStream str = new MemoryStream();
			XmlTextWriter tw = new XmlTextWriter(str,
				Encoding.GetEncoding(((XmlDeclaration) Document.FirstChild).Encoding));
			tw.Formatting = Formatting.Indented;
			tw.Indentation = 2;
			Document.Save(tw);
			tw.Flush();

			str.Position = 0;
			StreamReader sr = new StreamReader(str);
			writer.Write(sr.ReadToEnd());
		}

		/// <summary>
		/// Returns formatted xml string (indent and newlines) from unformatted XML
		/// </summary>
		/// <param name="sUnformattedXml">Unformatted xml string.</param>
		/// <returns>Formatted xml string and any exceptions that occur.</returns>
		public static string FormatXml(string sUnformattedXml)
		{
			XmlDocument xd = new XmlDocument();
			xd.LoadXml(sUnformattedXml);
			StringBuilder sb = new StringBuilder();
			StringWriter sw = new StringWriter(sb);

			XmlTextWriter xtw = null;
			try
			{
				xtw = new XmlTextWriter(sw);
				xtw.Formatting = Formatting.Indented;
				xd.WriteTo(xtw);
			}
			finally
			{
				//clean up even if error
				if (xtw != null)
					xtw.Close();
			}

			return sb.ToString();
		}
		#endregion

		#region Internal Fields
		internal static IFormatProvider DateFormatProvider = new System.Globalization.CultureInfo("en-US");
		internal const string EBAY_TIME_FORMAT = "yyyy'-'MM'-'dd HH':'mm':'ss";
		internal const string EBAY_DATE_FORMAT = "yyyy'-'MM'-'dd";
		#endregion

	}
}

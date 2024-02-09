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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Xml;
#endregion

namespace eBay.Service.Util
{

	/// <summary>
	/// 
	/// </summary>
	public class FileLogger : ApiLogger
	{

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		public FileLogger()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="FileName"></param>
		public FileLogger(string FileName)
		{
			mFileName = FileName;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="FileName"></param>
		/// <param name="LogInformations"></param>
		/// <param name="LogApiMessages"></param>
		/// <param name="LogExceptions"></param>
		public FileLogger(string FileName, bool LogInformations, bool LogApiMessages, bool LogExceptions)
		{
			this.LogApiMessages = LogApiMessages;
			this.LogInformations = LogInformations;
			this.LogExceptions = LogExceptions;
			mFileName = FileName;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Message"></param>
		/// <param name="Severity"></param>
		public override void RecordMessage(string Message, MessageSeverity Severity)
		{
			FileStream fileStream = null;
			StreamWriter writer = null;
			StringBuilder message = new StringBuilder();

 
			// Create the message
			message.Append("["+DateTime.Now.ToString(System.Globalization.CultureInfo.CurrentUICulture));
			message.Append(", " + Severity.ToString());
			message.Append("]\r\n" + Message + "\r\n");

			lock(this) 
			{
				string filePath = getAbsoluteFilePath();
				fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
				using (writer = new StreamWriter(fileStream))
				{
					// Set the file pointer to the end of the file
					writer.BaseStream.Seek(0, SeekOrigin.End); 
				
					// Force the write to the underlying file
					writer.WriteLine(message.ToString());
					writer.Flush();
					if( writer != null ) writer.Close();
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public void Close()
		{
		}

		#endregion

		#region private methods

		/// <summary>
		/// 1. for relative path
		/// If the fileName is specified as an relative path such as "log.txt", the current excuting path will be changed while
		/// selecting a picture. The current excuting path need to be reseted by adding an prifix with dll's location.
		/// 2. for absolute path
		/// If the fileName is specified as an absolute path, there is no need to change it.
		/// </summary>
		/// <returns></returns>
		private string getAbsoluteFilePath()
		{
			bool isAbsolute = isAbsolutePath(mFileName);

			if(isAbsolute)//absolute path
			{
				return mFileName;
			}
			else//relative path
			{
				string uriString = GetGetExecutingAssemblyDirectory() + Path.DirectorySeparatorChar + mFileName;
				return convertUriToDirectoryPathFormat(uriString);
			}
		}

		/// <summary>
		/// convert an uri string to a local directory path format
		/// </summary>
		/// <param name="uriString"></param>
		/// <returns></returns>
		private string convertUriToDirectoryPathFormat(string uriString)
		{
			Uri uri=new Uri(uriString);
            
            return Uri.UnescapeDataString(uri.LocalPath + uri.Fragment);
		}


		/// <summary>
		/// Gets whether the specified path is a valid absolute file path.
		/// </summary>
		/// <param name="path">Any path. OK if null or empty.</param>
		public bool isAbsolutePath( string path )
		{
			Regex r = new Regex( @"^(([a-zA-Z]\:)|(\\))(\\{1}|((\\{1})[^\\]([^/:*?<>""|]*))+)$" );
			return r.IsMatch( path );
		}

		#endregion

		#region Properties
		/// <summary>
		/// 
		/// </summary>
		public string FileName
		{
			get { return mFileName; }
			set { mFileName = value; }
		}
		#endregion

		#region Private Fields
		private string mFileName = "Log.txt";
		#endregion

	}
}


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
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using eBay.Service.Core.Soap;
using eBay.Service.Core.Sdk;
using eBay.Service.Util;
using eBay.Service.Call;
namespace Samples.Helper.Cache
{
	/// <summary>
	///  
	///  Base class for meta-data cache
	/// 
	/// </summary>
	public abstract class BaseDownloader
	{
		#region fields

		//root directory for meta-data cache
        private readonly string rootDir = "C:\\TEMP";
		/// <summary>
		/// cached file prefix, must be explicitly set by subclass.
		/// </summary>
		protected string filePrefix = "";
		/// <summary>
		/// cached file suffix, must be explicitly set by subclass.
		/// </summary>
		protected string fileSuffix = "";
		/// <summary>
		/// object type of the cached data, must be explicitly set by subclass
		/// </summary>
		protected Type objType = null;
		//the latest update time of the meta-data
		private string lastUpdateTime;
		/// <summary>
		/// ApiContext object
		/// </summary>
		protected ApiContext context;

		#endregion


		#region private methods
		private string getFullFileName() 
		{
			string fileName = this.filePrefix + "_" + this.context.Site + "_" + this.lastUpdateTime;
			string fullFileName = this.rootDir + System.IO.Path.DirectorySeparatorChar + fileName + "." + this.fileSuffix;
			return fullFileName;
		}

		//find all data files with specified prefix and suffix in the root directory
		private string[] getDataFileNames() 
		{
			if(!Directory.Exists(this.rootDir)) 
			{
				Directory.CreateDirectory(this.rootDir);
			}
			
			string fileNamePattern = this.filePrefix + "_" + this.context.Site + "*." + this.fileSuffix;
			string[] fileNames = Directory.GetFiles(this.rootDir, fileNamePattern);
			
			return fileNames;
		}

		//find the latest cached file
		private String findLatestFileName(string[] dataFileNames) 
		{
			foreach(String fName in dataFileNames)
			{
				if(fName.IndexOf(this.lastUpdateTime) > 0)
				{
					return fName;
				}						
			}
			return null;
		}

		//search latest file in the root directory
		private string searchFile() 
		{
			string[] fNames = getDataFileNames();
			return findLatestFileName(fNames);
		}

		//initialize lastUdateTime
		private void syncUpdateTime()
		{
			this.lastUpdateTime = this.getLastUpdateTime();
		}

		/// <summary>
		/// cache object as disk file
		/// </summary>
		/// <param name="obj"></param>
		private void saveToDisk(object obj)
		{
			string fileName = this.getFullFileName();

			StreamWriter stream = new StreamWriter(fileName);

			try
			{
				XmlSerializer serializer = new XmlSerializer(obj.GetType());
				serializer.Serialize(stream, obj);
			}
			catch
			{
				throw;
			}
			finally
			{
				stream.Close();
			}
		}

		/// <summary>
		/// get object from cached data file
		/// </summary>
		/// <returns></returns>
		private object getFromFile(string fileName)
		{	
			StreamReader reader = new StreamReader(fileName);
			object obj=null;

			try
			{
				XmlSerializer serializer = new XmlSerializer(this.objType);
				obj=serializer.Deserialize(reader);
			}
			catch
			{
				throw;
			}
			finally
			{
				reader.Close();
			}

			return obj;
		}

		//get object from eBay site
		private object getFromSite()
		{
			//call eBay API to get data
			object obj = callApi();
			//cache the object
			saveToDisk(obj);
			return obj;

		}

		#endregion

		#region protected methods

		/// <summary>
		/// get object from xml data
		/// </summary>
		/// <returns>generic object</returns>
		protected object getObject() 
		{
			syncUpdateTime();
			string fileName = searchFile();
			object obj;
			//if the file is not cached, get live data from eBay site
			if (fileName == null)
			{
				obj = getFromSite();
			} 
			else 
			{
				//if the file is cached, get cached data
				obj = getFromFile(fileName);
			}
			return obj;

	}

		#endregion

		#region abstract methods
		

		/// <summary>
		/// subclass should implement specific API call
		/// </summary>
		protected abstract object callApi();
		/// <summary>
		/// ssubclass should implement specific API call to get last update time
		/// </summary>
		protected abstract string getLastUpdateTime();
		
		#endregion
	}
}

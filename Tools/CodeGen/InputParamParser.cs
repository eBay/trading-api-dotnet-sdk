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

using System.Collections;

namespace CodeGen
{
	public class InputParamParser
	{
		private static Hashtable _keys = null;

		public static Hashtable getInputParams(string[] args)
		{
			if (null == _keys) 
			{
				init();
			}

			int plen = args.Length;

			if (plen % 2 > 0) 
			{
				throw new System.Exception("Input params should be in key/value pairs !");
			}

			Hashtable retHash = new Hashtable();
			string opt;

			for (int i = 0; i < plen; i++) 
			{
				opt = args[i];
				opt = opt.Trim();
				if (_keys.Contains(opt)) 
				{
					retHash.Add(opt, args[++i]);
				}
				else 
				{
					i++;
				}
			}

			return retHash;
		}

		private static void init()
		{
			if (null == _keys) 
			{
				 _keys = new Hashtable();
				 _keys.Add(F, "output file name");
				 _keys.Add(H, "help message");
				 _keys.Add(L, "language");
				 _keys.Add(M, "output file mode");
				 _keys.Add(N, "namespace");
				 _keys.Add(P, "output path");
				 _keys.Add(W, "wsdl file path");
			}
		}

		public static void setInputParamKeys(Hashtable keys) 
		{
		  _keys = keys;
		}

		public static string F = "-f";
		public static string H = "-h";
		public static string L = "-l";
		public static string M = "-m";
		public static string N = "-n";
		public static string P = "-p";
		public static string W = "-w";
	}
}
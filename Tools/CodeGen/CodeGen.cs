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
using System.Collections;
using eBay.WebService.CodeGenerator;

namespace CodeGen
{
    /// <summary>
    /// Summary description
    /// </summary>
    class CodeGen
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string[] inputs = {
                "-f", "WebService.cs",
                "-l", "language",
                "-m", "1",
                "-n", "eBay.Service.Core.Soap",
                "-p" , @"/Users/lrishi/Documents/TradingAPISDK-.NET/Source/eBay.Service.SDK/Core/Soap",
                "-w",  "https://developer.ebay.com/webservices/latest/eBaySvc.wsdl"
            };
            args = inputs;

            Hashtable ht = null;
            bool inputError = false;
            try
            {
                ht = InputParamParser.getInputParams(args);
            }
            catch
            {
                inputError = true;
            }

            object obj = ht[InputParamParser.H];

            if (inputError || ht.Count == 0 || obj != null)
            {
                Console.WriteLine("Usage:  CodeGen -f outputFile -l language -m outputMode [1 = one file, 0 = multiple files] -n namespace -p outputPath -w wsdlPath");
                return;
            }

            string ns = null;
            string fileName = null;
            string lang = "cs";
            string wsdl = null;
            bool oneFile = false;
            string outputPath = null;

            obj = ht[InputParamParser.F];
            if (obj != null)
            {
                fileName = obj.ToString();
            }

            obj = ht[InputParamParser.L];
            if (obj != null)
            {
                lang = obj.ToString();
            }

            string ONE = "1";
            obj = ht[InputParamParser.M];
            if (obj != null && ONE.Equals(obj.ToString()))
            {
                oneFile = true;
            }

            obj = ht[InputParamParser.N];
            if (obj != null)
            {
                ns = obj.ToString();
            }

            obj = ht[InputParamParser.P];
            if (obj != null)
            {
                string path = obj.ToString();
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                outputPath = path;
            }

            obj = ht[InputParamParser.W];
            if (obj != null)
            {
                wsdl = obj.ToString();
            }

            if (wsdl == null || wsdl.Length == 0)
            {
                Console.WriteLine("Please provide a valid wsdl path.");
                return;
            }

            eBayCodeGenerator codeGen = new eBayCodeGenerator();

            if (oneFile)
            {
                if (fileName == null || fileName.Length == 0)
                {
                    Console.WriteLine("Please provide a valid output file name.");
                    return;
                }
            }
            codeGen.SetOutputOneFileOption(oneFile);

            if (outputPath == null)
            {
                Console.WriteLine("Please provide a valid output path.");
                return;
            }

            codeGen.SetCodeLanguage(lang);
            if (ns != null)
            {
                codeGen.SetNamespace(ns);
            }
            codeGen.SetOutputPath(outputPath);
            string fileContent = String.Format(WSDL, wsdl);
            codeGen.Generate(fileName, fileContent);
            Console.ReadKey();
        }

        private static string WSDL = "<?xml version=\"1.0\" encoding=\"utf-8\"?><configuration><WSDLFile>{0}</WSDLFile></configuration>";
    }
}

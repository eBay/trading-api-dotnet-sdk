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
using System.Xml;

using System.IO;
using System.Collections;
using System.CodeDom;
using System.CodeDom.Compiler;

using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Web.Services.Protocols;

using System.Net;
using System.Text;
using System.Xml.Schema;
using System.Reflection;
using System.Diagnostics;

using CustomToolGenerator;

namespace eBay.WebService.CodeGenerator
{
#if VS2008
    [Guid("6E980693-1BB8-490b-845F-575F77C57CEF")]
#else
    [Guid("B7FA0A84-909C-45c8-AD94-4EDB7F0E1695")]
#endif
    [CustomTool("eBayCodeGenerator", "eBay Code Generator")]
	public class eBayCodeGenerator : CustomToolBase
	{
		private EnvDTE.ProjectItem mProjItem;
		private EnvDTE.OutputWindowPane mOutLog;
		private string mLang = "cs";
		private bool mOutputOneFileOption = true;
		private string mOutputPath = "./";
		private string mNamespace = "eBay.Service.Core.Soap";

		public byte[] Generate(string fileName, string FileContents)
		{
			return GenerateCode(fileName, FileContents);
		}

		protected override byte[] GenerateCode(string fileName, string FileContents)
		{
			InitializeTool();
			try
			{
				if (mOutLog != null) 
				{
					mOutLog.Clear();
				}
				string DefaultNameSpace = this.GetDefaultNameSpace(fileName);

				// Load FileContents into XML Doc
				XmlDocument inXDoc = new XmlDocument();

				inXDoc.PreserveWhitespace = false;
				inXDoc.LoadXml(FileContents);
                       
				// Get the path to the WSDL
				XmlNode wsdln = inXDoc.DocumentElement.SelectSingleNode("//WSDLFile/text()");
				if (wsdln == null || wsdln.Value == String.Empty)
				{
					//Console.WriteLine("WSDL not found in Document <configuration><WSDLFile>http://value.wsdl</WSDLFile></configuration>\n");
					if (mOutLog != null) 
					{
						mOutLog.OutputString("WSDL not found in Document <configuration><WSDLFile>http://value.wsdl</WSDLFile></configuration>\n");
					}
					else 
					{
						Console.WriteLine("WSDL not found in Document <configuration><WSDLFile>http://value.wsdl</WSDLFile></configuration>\n");
					}
					return null;
				}

				string WSDLPath = wsdln.Value;
				if (mOutLog != null) 
				{
					mOutLog.OutputString("Generating Proxy Class File\n");
					mOutLog.OutputString("NameSpace: " + DefaultNameSpace + "\n");
					mOutLog.OutputString("WSDL Path: " + WSDLPath + "\n");
				}
				else 
				{
					Console.WriteLine("Generating Proxy Class File\n");
					Console.WriteLine("NameSpace: " + DefaultNameSpace + "\n");
					Console.WriteLine("WSDL Path: " + WSDLPath + "\n");
				}

				// Load WSDL
                XmlTextReader xtr = new XmlTextReader(WSDLPath);
                ServiceDescription serviceDescription = ServiceDescription.Read(xtr);
                //BindingCollection bcObject = serviceDescription.Bindings;
                //bcObject.Remove(bcObject[0]);

                //Binding myBinding = new Binding();
                //myBinding.Name = "service1soap";

				CodeCompileUnit codeUnit = new CodeCompileUnit();

				CodeNamespace codeNamespace = new CodeNamespace(DefaultNameSpace);
				codeUnit.Namespaces.Add(codeNamespace);

				codeNamespace.Comments.Add(new CodeCommentStatement("Generator version 1.1"));
				codeNamespace.Comments.Add(new CodeCommentStatement(""));
				codeNamespace.Comments.Add(new CodeCommentStatement("Copyright: ?2000-2008 eBay Inc."));
				codeNamespace.Comments.Add(new CodeCommentStatement(""));
				codeNamespace.Comments.Add(new CodeCommentStatement("Date: " + DateTime.Now.ToString()));
				codeNamespace.Comments.Add(new CodeCommentStatement(""));

				//
				// Set up the service importer that eventually generate the DOM
				// for client proxy.
				//
				ServiceDescriptionImporter serviceImporter = new ServiceDescriptionImporter();
			
				// Resolve any Imports
				
                DiscoveryClientProtocol dcp = new DiscoveryClientProtocol();
				dcp.DiscoverAny(WSDLPath);
				dcp.ResolveAll();

				foreach (object osd in dcp.Documents.Values)
				{
					if (osd is ServiceDescription) serviceImporter.AddServiceDescription((ServiceDescription)osd, String.Empty, String.Empty);;
					if (osd is XmlSchema) serviceImporter.Schemas.Add((XmlSchema)osd);
				}

				// Configure the Importer
				serviceImporter.ProtocolName = "Soap";
				serviceImporter.Style = ServiceDescriptionImportStyle.Client;

                //serviceImporter.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.EnableDataBinding
                //                                      | serviceImporter.CodeGenerationOptions;
            
				ServiceDescriptionImportWarnings warnings = serviceImporter.Import(codeNamespace, codeUnit);

				if (mOutLog != null) 
				{
					if ((warnings & ServiceDescriptionImportWarnings.NoMethodsGenerated) != 0)
						mOutLog.OutputString("Warning: no methods were generated.\n");
					if ((warnings & ServiceDescriptionImportWarnings.OptionalExtensionsIgnored) != 0)
						mOutLog.OutputString("Warning: one or more optional WSDL extension elements were ignored.\n");
					if ((warnings & ServiceDescriptionImportWarnings.OptionalExtensionsIgnored) != 0)
						mOutLog.OutputString("Warning: one or more optional WSDL extension elements were ignored.\n");
					if ((warnings & ServiceDescriptionImportWarnings.RequiredExtensionsIgnored) != 0)
						mOutLog.OutputString("Warning: one or more required WSDL extension elements were ignored.\n");
					if ((warnings & ServiceDescriptionImportWarnings.UnsupportedBindingsIgnored) != 0)
						mOutLog.OutputString("Warning: one or more bindings were skipped.\n");
					if ((warnings & ServiceDescriptionImportWarnings.UnsupportedOperationsIgnored) != 0)
						mOutLog.OutputString("one or more operations were skipped.\n");
					if ((warnings & ServiceDescriptionImportWarnings.NoCodeGenerated) != 0)
					{
						mOutLog.OutputString("Warning: no classes were generated.\n");
						return null;
					}
					if (warnings != 0)
						mOutLog.OutputString("Warnings were encountered. Review generated source comments for more details.\n");
				}
				else 
				{
					if ((warnings & ServiceDescriptionImportWarnings.NoMethodsGenerated) != 0)
						Console.WriteLine("Warning: no methods were generated.\n");
					if ((warnings & ServiceDescriptionImportWarnings.OptionalExtensionsIgnored) != 0)
						Console.WriteLine("Warning: one or more optional WSDL extension elements were ignored.\n");
					if ((warnings & ServiceDescriptionImportWarnings.OptionalExtensionsIgnored) != 0)
						Console.WriteLine("Warning: one or more optional WSDL extension elements were ignored.\n");
					if ((warnings & ServiceDescriptionImportWarnings.RequiredExtensionsIgnored) != 0)
						Console.WriteLine("Warning: one or more required WSDL extension elements were ignored.\n");
					if ((warnings & ServiceDescriptionImportWarnings.UnsupportedBindingsIgnored) != 0)
						Console.WriteLine("Warning: one or more bindings were skipped.\n");
					if ((warnings & ServiceDescriptionImportWarnings.UnsupportedOperationsIgnored) != 0)
						Console.WriteLine("one or more operations were skipped.\n");
					if ((warnings & ServiceDescriptionImportWarnings.NoCodeGenerated) != 0)
					{
						Console.WriteLine("Warning: no classes were generated.\n");
						return null;
					}
					if (warnings != 0)
						Console.WriteLine("Warnings were encountered. Review generated source comments for more details.\n");
				}

                // change the base class
                CodeTypeDeclaration ctDecl = codeNamespace.Types[0];
                codeNamespace.Types.Remove(ctDecl);
                ctDecl.BaseTypes[0] = new CodeTypeReference(DefaultNameSpace + ".SoapHttpClientProtocolEx");
                codeNamespace.Types.Add(ctDecl);

                codeNamespace.Imports.Add(new CodeNamespaceImport("System.Collections"));
                CodeTypeDeclarationCollection codeTypeColl = new CodeTypeDeclarationCollection();
                ArrayList colList = new ArrayList();
                ArrayList allMembers = new ArrayList();

                //added by william, workaround to fix the code
                FixCode(codeNamespace);

                foreach (CodeTypeDeclaration codeType in codeNamespace.Types)
                {

                    allMembers.Clear();
                    foreach (CodeTypeMember codeMember in codeType.Members)
                    {
                        allMembers.Add(codeMember.Name);
                    }

                    CodeTypeMemberCollection codeMemberColl = new CodeTypeMemberCollection();

                    //
                    // Collect the public fields of the type.
                    //

                    foreach (CodeTypeMember codeMember in codeType.Members)
                    {
                        CodeMemberMethod codeMethod = codeMember as CodeMemberMethod;

                        if (codeMethod != null)
                        {
                            if ((codeMethod.Attributes & MemberAttributes.Public) == MemberAttributes.Public)
                            {
                                foreach (CodeAttributeDeclaration cadt in codeMethod.CustomAttributes)
                                {
                                    if (cadt.Name.EndsWith("SoapDocumentMethodAttribute"))
                                    {
                                        codeMethod.CustomAttributes.Add(new CodeAttributeDeclaration(DefaultNameSpace + ".SoapExtensionExAttribute"));
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            CodeMemberField codeField = codeMember as CodeMemberField;
                            if (codeField != null)
                            {   
                                if ((codeField.Attributes & MemberAttributes.Public) == MemberAttributes.Public)
                                {
                                    codeField.Comments.Clear();

                                    CodeTypeReference codeFieldRef = codeField.Type.ArrayElementType as CodeTypeReference;

                                    //skip 'System.Byte'
                                    if (codeFieldRef != null && !"System.Byte".Equals(codeFieldRef.BaseType))
                                    {
                                        string name = codeFieldRef.BaseType;
                                        //Debug.WriteLine("Array BaseType name : " + name);

                                        string[] splstr = name.Split('.');

                                        if (splstr.Length > 1)
                                        {
                                            string ns = String.Join(".", splstr, 0, splstr.Length - 1);
                                            codeNamespace.Imports.Add(new CodeNamespaceImport(ns));
                                            name = (string)splstr.GetValue(splstr.Length - 1);
                                        }

                                        if (!colList.Contains(name))
                                        {
                                            codeTypeColl.Add(this.CreateCollectionType(name));
                                            colList.Add(name);
                                        }
                                        codeField.Type = new CodeTypeReference(name + "Collection");

                                    }

                                    int val = allMembers.IndexOf(codeField.Name + "Specified");
                                    codeMemberColl.Add(this.CreateProperty(codeField, val != -1));
                                }
                            }
                        }
                    }

                    // add the newly created public properties
                    codeType.Members.AddRange(codeMemberColl);
                }

                codeNamespace.Types.AddRange(codeTypeColl);
                codeNamespace.Types.Add(CreateSoapHttpClientProtocolEx());
                codeNamespace.Types.Add(CreateSoapExtensionExAttribute());
                codeNamespace.Types.Add(CreateSoapExtensionEx());

				if (this.mProjItem != null) 
				{
					MemoryStream mem = new MemoryStream();
					StreamWriter outputWriter = new StreamWriter(mem);
					CodeProvider.GenerateCodeFromCompileUnit(codeUnit, outputWriter, new CodeGeneratorOptions());
                    outputWriter.Flush();
					mOutLog.OutputString("Code Generation Completed Successfully\n");
					return mem.ToArray();
				}
				else 
				{
                    CodeDomProvider generator = null;
					string fileExt = null;
					if (mLang.Equals(VB))
					{
						generator = new Microsoft.VisualBasic.VBCodeProvider();
						fileExt = VB;
					}
						//j# is not available.
						//else if (mLang.Equals(JS))
						//{	
						//	generator = new Microsoft.JScript.JScriptCodeProvider().CreateGenerator();
						//}
					else 
					{
						generator = new Microsoft.CSharp.CSharpCodeProvider();
						fileExt = CS;
					}

					if (mOutputOneFileOption == true) 
					{
						MemoryStream mem = new MemoryStream();
						StreamWriter outputWriter = new StreamWriter(mem);
						CodeGeneratorOptions options = new CodeGeneratorOptions();
						options.BlankLinesBetweenMembers = false;
						generator.GenerateCodeFromCompileUnit(codeUnit, outputWriter, options);;
						outputWriter.Flush();

						byte [] output = mem.ToArray();
						BinaryWriter writer = new BinaryWriter(File.Open(mOutputPath + fileName, FileMode.Create));
						writer.Write(output);	
						writer.Close();
					}
					else
					{
						CodeTypeDeclarationCollection coll = new CodeTypeDeclarationCollection();
						coll.AddRange(codeNamespace.Types);

						foreach (CodeTypeDeclaration codeType in coll) 
						{
							codeNamespace.Types.Clear();				
							CodeTypeDeclarationCollection types = new CodeTypeDeclarationCollection();
							codeNamespace.Types.Add(codeType);
							MemoryStream mem = new MemoryStream();
							StreamWriter outputWriter = new StreamWriter(mem);

							CodeGeneratorOptions options = new CodeGeneratorOptions();
							options.BlankLinesBetweenMembers = false;
							generator.GenerateCodeFromCompileUnit(codeUnit, outputWriter, options);;
							outputWriter.Flush();

							byte [] output = mem.ToArray();
							string clsName = codeType.Name + "." + fileExt;
							BinaryWriter writer = new BinaryWriter(File.Open(mOutputPath + clsName, FileMode.Create));
							writer.Write(output);	
							writer.Close();
						}
					}
					Console.WriteLine("Code Generation Completed Successfully\n");
					return null;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message + "\n");
				return null;
			}
		}

        //workaround to fix the code
        private void FixCode(CodeNamespace codeNamespace)
        {
			//fix base64Binary issue
			/*foreach (CodeTypeDeclaration ctd in codeNamespace.Types)
			{
				if ("Base64BinaryType".Equals(ctd.Name))
				{
					CodeTypeMemberCollection ctmc = new CodeTypeMemberCollection();
					foreach (CodeMemberField cmf in ctd.Members)
					{
						if ("Value".Equals(cmf.Name))
						{
							ctmc.Add(cmf);
						}
					}

					foreach(CodeTypeMember ctm in ctmc)
					{
						ctd.Members.Remove(ctm);
					}

				    ctd.Members.Add(new CodeSnippetTypeMember("        private byte[] mValue;" + Environment.NewLine + Environment.NewLine));
                    ctd.Members.Add(new CodeSnippetTypeMember("        ///<summary></summary>" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("        [System.Xml.Serialization.XmlTextAttribute(DataType=\"base64Binary\")]" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("        public byte[] Value {" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("            get {" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("                return this.mValue;" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("            }" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("            set {" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("                this.mValue = value;" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("            }" + Environment.NewLine));
					ctd.Members.Add(new CodeSnippetTypeMember("        }" + Environment.NewLine + Environment.NewLine));
				}
			}*/
			
			
			//UploadSiteHostedPictures related data types should be generated for
			//EPS usage
			/*
			//remove UploadSiteHostedPictures related types
            CodeTypeDeclarationCollection ctdc = new CodeTypeDeclarationCollection();
            foreach (CodeTypeDeclaration ctd in codeNamespace.Types)
            {
                if (ctd.Name.IndexOf("UploadSiteHostedPictures") != -1)
                {
                    ctdc.Add(ctd);
                }
            }
            foreach (CodeTypeDeclaration ctd in ctdc)
            {
                codeNamespace.Types.Remove(ctd);
            }

            //remove UploadSiteHostedPictures related attributes
            foreach (CodeTypeDeclaration ctd in codeNamespace.Types)
            {
                if (ctd.Name.IndexOf("Abstract") == 0)
                {
                    CodeAttributeDeclarationCollection cadc = new CodeAttributeDeclarationCollection();
                    foreach (CodeAttributeDeclaration cad in ctd.CustomAttributes)
                    {
                        foreach (CodeAttributeArgument caa in cad.Arguments)
                        {
                            CodeTypeOfExpression ctoe = (caa.Value) as CodeTypeOfExpression;
                            if (ctoe != null && ctoe.Type.BaseType.IndexOf("UploadSiteHostedPictures") != -1)
                            {
                                cadc.Add(cad);
                            }
                        }
                    }
                    foreach (CodeAttributeDeclaration cad in cadc)
                    {
                        ctd.CustomAttributes.Remove(cad);
                    }
                }
            }*/

            //add summary comments on some constructors
            foreach (CodeTypeDeclaration ctd in codeNamespace.Types)
            {
                foreach (CodeTypeMember ctm in ctd.Members)
                {
                    if ((ctm is CodeConstructor) && ctm.Comments.Count == 0)
                    {
                        ctm.Comments.AddRange(this.GetSummaryStatements());
                    }
                }
            }

            //remove UploadSiteHostedPictures related methods
            foreach (CodeTypeDeclaration ctd in codeNamespace.Types)
            {
                CodeTypeMemberCollection ctmc = new CodeTypeMemberCollection();
                foreach (CodeTypeMember ctm in ctd.Members)
                {
                    CodeMemberMethod cmm = ctm as CodeMemberMethod;
                    if (cmm != null && cmm.Name.IndexOf("UploadSiteHostedPictures") != -1)
                    {
                        ctmc.Add(ctm);
                    }
                }
                foreach (CodeTypeMember ctm in ctmc)
                {
                    ctd.Members.Remove(ctm);
                }
            }
        }

		private void InitializeTool()
		{
			mOutLog = null;
			mProjItem = (EnvDTE.ProjectItem)GetService(typeof(EnvDTE.ProjectItem));
			
			string tooln = "eBayWebServiceGenerator";
			if (mProjItem == null || mProjItem.Name == String.Empty)
			{
				tooln = "eBayWebServiceGenerator";
			}
			else 
			{
				tooln = mProjItem.Name;

				EnvDTE.Window win = mProjItem.DTE.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
				EnvDTE.OutputWindow ow = (EnvDTE.OutputWindow) win.Object;
				foreach (EnvDTE.OutputWindowPane owPane in ow.OutputWindowPanes)
				{
					if (owPane.Name == tooln)
					{
						mOutLog = owPane;
						break;
					}
				}
		
				if (mOutLog == null)
				{
					mOutLog = ow.OutputWindowPanes.Add(tooln);
				}
				mOutLog.Activate();
			}
		}

		private string RemoveSystemNameSpace(string name)
		{
			string retname = name;
			if (name.IndexOf(".", 0, name.Length) != -1)
			{
				int ct = name.LastIndexOf(".");
				retname = name.Remove(0, ct + 1);

			}
			return retname;
		}

		private CodeMemberProperty CreateProperty(CodeMemberField codeField, bool spec)
		{
			
			CodeMemberProperty codeProperty = new CodeMemberProperty();
			codeProperty.Type = codeField.Type;
			codeProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			codeProperty.Comments.AddRange(this.GetSummaryStatements());
					
			if (codeField.CustomAttributes.Count > 0)
			{
				codeProperty.CustomAttributes.AddRange(codeField.CustomAttributes);
				codeField.CustomAttributes.Clear();
			}

			codeProperty.Name = codeField.Name;
			
			// Change the Field to Private
			codeField.Name = "m" + codeField.Name;
			codeField.Attributes = MemberAttributes.Private;

			codeProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), codeField.Name)));
			codeProperty.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), codeField.Name), new CodePropertySetValueReferenceExpression()));
			
			if (spec)
				codeProperty.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), codeField.Name + "Specified"), new CodePrimitiveExpression(true)));


			return codeProperty;
		}

		private CodeTypeDeclaration CreateCollectionType(string name)
		{
			string classname = name + "Collection";
			CodeTypeReference ctrClass = new CodeTypeReference(name);
			CodeTypeReference ctrArray = new CodeTypeReference(name + "[]");
			CodeTypeReference ctrCollection = new CodeTypeReference(classname);
			CodeThisReferenceExpression ctrethis = new CodeThisReferenceExpression();

			CodeVariableReferenceExpression cvreItem = new CodeVariableReferenceExpression();
			cvreItem.VariableName = "item";

			CodeVariableReferenceExpression cvreItems = new CodeVariableReferenceExpression();
			cvreItems.VariableName = "items";

			CodeVariableReferenceExpression cvreIndex = new CodeVariableReferenceExpression();
			cvreIndex.VariableName = "index";

			// String[] items
			CodeParameterDeclarationExpression cpdeItemsArray = new CodeParameterDeclarationExpression();
			cpdeItemsArray.Name = cvreItems.VariableName;
			cpdeItemsArray.Type = ctrArray;
			cpdeItemsArray.Direction = FieldDirection.In;

			// StringCollection items
			CodeParameterDeclarationExpression cpdeItemsCollection = new CodeParameterDeclarationExpression();
			cpdeItemsCollection.Name = cvreItems.VariableName;
			cpdeItemsCollection.Type = ctrCollection;
			cpdeItemsCollection.Direction = FieldDirection.In;

			// String item
			CodeParameterDeclarationExpression cpdeItem = new CodeParameterDeclarationExpression();
			cpdeItem.Name = cvreItem.VariableName;
			cpdeItem.Type = ctrClass;
			cpdeItem.Direction = FieldDirection.In;

			// int Index
			CodeParameterDeclarationExpression cpdeIndex = new CodeParameterDeclarationExpression();
			cpdeIndex.Name = cvreIndex.VariableName;
			cpdeIndex.Type = new CodeTypeReference(typeof(System.Int32));
			cpdeIndex.Direction = FieldDirection.In;

			
			// Class Declaration
			CodeTypeDeclaration ctd = new CodeTypeDeclaration();
			ctd.TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed;
			ctd.Comments.AddRange(GetSummaryStatements());
			ctd.Name = classname;
			CodeAttributeDeclaration cadSerializable = new CodeAttributeDeclaration();
			cadSerializable.Name = "Serializable";
			ctd.CustomAttributes.Add(cadSerializable);
			ctd.BaseTypes.Add(typeof(System.Collections.CollectionBase));
	
			
			//constructors
			// Base Constructor
			CodeConstructor ccDefault = new CodeConstructor();
			ccDefault.Attributes = MemberAttributes.Public;
			ccDefault.Comments.AddRange(GetSummaryStatements());
			ctd.Members.Add(ccDefault);
						
			// Array Constructor
			CodeConstructor ccArray = new CodeConstructor();
			ccArray.Attributes = MemberAttributes.Public;
			ccArray.Comments.AddRange(GetSummaryStatements());
			ccArray.Comments.Add(new CodeCommentStatement("<param name=\"items\"></param>", true));
			ccArray.Parameters.Add(cpdeItemsArray);
			CodeMethodInvokeExpression cmieAddRange = new CodeMethodInvokeExpression(ctrethis, "AddRange", cvreItems);
			ccArray.Statements.Add(cmieAddRange);
			ctd.Members.Add(ccArray);

			// Collection Constructor
			CodeConstructor ccCollection = new CodeConstructor();
			ccCollection.Attributes = MemberAttributes.Public;
			ccCollection.Comments.AddRange(GetSummaryStatements());
			ccCollection.Comments.Add(new CodeCommentStatement("<param name=\"items\"></param>", true));
			ccCollection.Parameters.Add(cpdeItemsCollection);
			ccCollection.Statements.Add(cmieAddRange);
			ctd.Members.Add(ccCollection);

			// Public Methods
			// Add
			CodeMemberMethod cmmAdd = new CodeMemberMethod();    
			cmmAdd.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmAdd.Comments.AddRange(GetSummaryStatements());
			cmmAdd.Comments.Add(new CodeCommentStatement("<param name=\"item\"></param>", true));
			cmmAdd.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmAdd.Name = "Add";
			cmmAdd.ReturnType = new CodeTypeReference(typeof(System.Int32));
			CodeParameterDeclarationExpression cpdeValue = new CodeParameterDeclarationExpression();
			cpdeValue.Type = ctrClass;
			cpdeValue.Name = cvreItem.VariableName;
			cpdeValue.Direction = FieldDirection.In;
			cmmAdd.Parameters.Add(cpdeValue);
			CodeMethodInvokeExpression cmieInnerListAddRangeItem = new CodeMethodInvokeExpression(ctrethis, "InnerList.Add", cvreItem);
			cmmAdd.Statements.Add(new CodeMethodReturnStatement(cmieInnerListAddRangeItem));
			ctd.Members.Add(cmmAdd);

			// AddRange
			CodeMemberMethod cmmAddRangeArray = new CodeMemberMethod();    
			cmmAddRangeArray.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmAddRangeArray.Comments.AddRange(GetSummaryStatements());
			cmmAddRangeArray.Comments.Add(new CodeCommentStatement("<param name=\"items\"></param>", true));
			cmmAddRangeArray.Name = "AddRange";
			cmmAddRangeArray.Parameters.Add(cpdeItemsArray);
			CodeMethodInvokeExpression cmieInnerListAddRangeItems = new CodeMethodInvokeExpression(ctrethis, "InnerList.AddRange", cvreItems);
			cmmAddRangeArray.Statements.Add(cmieInnerListAddRangeItems);
			ctd.Members.Add(cmmAddRangeArray);

			// AddRange
			CodeMemberMethod cmmAddRangeCollection = new CodeMemberMethod();    
			cmmAddRangeCollection.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmAddRangeCollection.Comments.AddRange(GetSummaryStatements());
			cmmAddRangeCollection.Comments.Add(new CodeCommentStatement("<param name=\"items\"></param>", true));
			cmmAddRangeCollection.Name = "AddRange";
			cmmAddRangeCollection.Parameters.Add(cpdeItemsCollection);
			cmmAddRangeCollection.Statements.Add(cmieInnerListAddRangeItems);
			ctd.Members.Add(cmmAddRangeCollection);

			// Contains
			CodeMemberMethod cmmContains = new CodeMemberMethod();    
			cmmContains.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmContains.Comments.AddRange(GetSummaryStatements());
			cmmContains.Comments.Add(new CodeCommentStatement("<param name=\"item\"></param>", true));
			cmmContains.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmContains.Name = "Contains";
			cmmContains.ReturnType = new CodeTypeReference(typeof(System.Boolean));
			cmmContains.Parameters.Add(cpdeItem);
			CodeMethodInvokeExpression cmieInnerListContains = new CodeMethodInvokeExpression(ctrethis, "InnerList.Contains", cvreItem);
			cmmContains.Statements.Add(new CodeMethodReturnStatement(cmieInnerListContains));
			ctd.Members.Add(cmmContains);

			// CopyTo
			CodeMemberMethod cmmCopyTo = new CodeMemberMethod();    
			cmmCopyTo.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmCopyTo.Comments.AddRange(GetSummaryStatements());
			cmmCopyTo.Comments.Add(new CodeCommentStatement("<param name=\"items\"></param>", true));
			cmmCopyTo.Comments.Add(new CodeCommentStatement("<param name=\"index\"></param>", true));
			cmmCopyTo.Name = "CopyTo";
			cmmCopyTo.Parameters.Add(cpdeItemsArray);
			cmmCopyTo.Parameters.Add(cpdeIndex);
			CodeMethodInvokeExpression cmieInnerListCopyTo = new CodeMethodInvokeExpression(ctrethis, "InnerList.CopyTo", new CodeExpression[] { cvreItems,  cvreIndex});
			cmmCopyTo.Statements.Add(cmieInnerListCopyTo);
			ctd.Members.Add(cmmCopyTo);

			// IndexOf
			CodeMemberMethod cmmIndexOf = new CodeMemberMethod();    
			cmmIndexOf.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmIndexOf.Comments.AddRange(GetSummaryStatements());
			cmmIndexOf.Comments.Add(new CodeCommentStatement("<param name=\"item\"></param>", true));
			cmmIndexOf.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmIndexOf.Name = "IndexOf";
			cmmIndexOf.ReturnType = new CodeTypeReference(typeof(System.Int32));
			cmmIndexOf.Parameters.Add(cpdeItem);
			CodeMethodInvokeExpression cmieInnerListIndexOf = new CodeMethodInvokeExpression(ctrethis, "InnerList.IndexOf", cvreItem);
			cmmIndexOf.Statements.Add(new CodeMethodReturnStatement(cmieInnerListIndexOf));
			ctd.Members.Add(cmmIndexOf);


			// Insert
			CodeMemberMethod cmmInsert = new CodeMemberMethod();    
			cmmInsert.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmInsert.Comments.AddRange(GetSummaryStatements());
			cmmInsert.Comments.Add(new CodeCommentStatement("<param name=\"index\"></param>", true));
			cmmInsert.Comments.Add(new CodeCommentStatement("<param name=\"item\"></param>", true));
			cmmInsert.Name = "Insert";
			cmmInsert.Parameters.Add(cpdeIndex);
			cmmInsert.Parameters.Add(cpdeItem);
			CodeMethodInvokeExpression cmieInnerListInsert = new CodeMethodInvokeExpression(ctrethis, "InnerList.Insert", new CodeExpression[] { cvreIndex,  cvreItem});
			cmmInsert.Statements.Add(cmieInnerListInsert);
			ctd.Members.Add(cmmInsert);

			// ItemAt
			CodeMemberMethod cmmItemAt = new CodeMemberMethod();    
			cmmItemAt.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmItemAt.Comments.AddRange(GetSummaryStatements());
			cmmItemAt.Comments.Add(new CodeCommentStatement("<param name=\"index\"></param>", true));
			cmmItemAt.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmItemAt.Name = "ItemAt";
			cmmItemAt.ReturnType = ctrClass;
			cmmItemAt.Parameters.Add(cpdeIndex);
			CodeArrayIndexerExpression caieInnerList = new CodeArrayIndexerExpression(new CodePropertyReferenceExpression(ctrethis ,"InnerList"), cvreIndex);
			cmmItemAt.Statements.Add(new CodeMethodReturnStatement(new CodeCastExpression(ctrClass,caieInnerList )));
			ctd.Members.Add(cmmItemAt);

			// Remove
			CodeMemberMethod cmmRemove = new CodeMemberMethod();    
			cmmRemove.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmRemove.Comments.AddRange(GetSummaryStatements());
			cmmRemove.Comments.Add(new CodeCommentStatement("<param name=\"item\"></param>", true));
			cmmRemove.Name = "Remove";
			cmmRemove.Parameters.Add(cpdeItem);
			CodeMethodInvokeExpression cmieInnerListRemove = new CodeMethodInvokeExpression(ctrethis, "InnerList.Remove", cvreItem);
			cmmRemove.Statements.Add(cmieInnerListRemove);
			ctd.Members.Add(cmmRemove);


			// ToArray
			CodeMemberMethod cmmToArray = new CodeMemberMethod();    
			cmmToArray.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmmToArray.Comments.AddRange(GetSummaryStatements());
			cmmToArray.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmToArray.Name = "ToArray";
			cmmToArray.ReturnType = ctrArray;
			CodeMethodInvokeExpression cmieInnerListToArray = new CodeMethodInvokeExpression(ctrethis, "InnerList.ToArray",  new CodeTypeOfExpression(ctrClass));
			cmmToArray.Statements.Add(new CodeMethodReturnStatement(new CodeCastExpression(ctrArray,cmieInnerListToArray )));
			ctd.Members.Add(cmmToArray);


			// this
			CodeMemberProperty cmpThisIndexer = new CodeMemberProperty();
			cmpThisIndexer.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpThisIndexer.Comments.AddRange(GetSummaryStatements());
			cmpThisIndexer.Name = "Item";
			cmpThisIndexer.Parameters.Add(new CodeParameterDeclarationExpression(typeof(System.Int32), cvreIndex.VariableName));
			cmpThisIndexer.Type = ctrClass;
			CodeIndexerExpression cieIndexer = new CodeIndexerExpression(new CodePropertyReferenceExpression(ctrethis, "InnerList"), cvreIndex);
			cmpThisIndexer.GetStatements.Add( new CodeMethodReturnStatement( new CodeCastExpression(name, cieIndexer)));
			cmpThisIndexer.SetStatements.Add( new CodeAssignStatement(cieIndexer, new CodePropertySetValueReferenceExpression()));
			ctd.Members.Add(cmpThisIndexer);

			// IsFixedSize
			CodeMemberProperty cmpIsFixedSize = new CodeMemberProperty();
			cmpIsFixedSize.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpIsFixedSize.Comments.AddRange(GetSummaryStatements());
			cmpIsFixedSize.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpIsFixedSize.Name = "IsFixedSize";
			cmpIsFixedSize.Type = new CodeTypeReference(typeof(System.Boolean));
			CodePropertyReferenceExpression cpreInnerListIsFixedSize = new CodePropertyReferenceExpression(ctrethis, "InnerList.IsFixedSize");
			cmpIsFixedSize.GetStatements.Add( new CodeMethodReturnStatement(cpreInnerListIsFixedSize));
			ctd.Members.Add(cmpIsFixedSize);


			// IsReadOnly
			CodeMemberProperty cmpIsReadOnly = new CodeMemberProperty();
			cmpIsReadOnly.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpIsReadOnly.Comments.AddRange(GetSummaryStatements());
			cmpIsReadOnly.Name = "IsReadOnly";
			cmpIsReadOnly.Type = new CodeTypeReference(typeof(System.Boolean));
			CodePropertyReferenceExpression cpreInnerListIsReadOnly = new CodePropertyReferenceExpression(ctrethis, "InnerList.IsReadOnly");
			cmpIsReadOnly.GetStatements.Add( new CodeMethodReturnStatement(cpreInnerListIsReadOnly));
			ctd.Members.Add(cmpIsReadOnly);

			// IsSynchronized
			CodeMemberProperty cmpIsSynchronized = new CodeMemberProperty();
			cmpIsSynchronized.Comments.AddRange(GetSummaryStatements());
			cmpIsSynchronized.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpIsSynchronized.Name = "IsSynchronized";
			cmpIsSynchronized.Type = new CodeTypeReference("System.Boolean");
			CodePropertyReferenceExpression cpreInnerListIsSynchronized = new CodePropertyReferenceExpression(ctrethis, "InnerList.IsSynchronized");
			cmpIsSynchronized.GetStatements.Add( new CodeMethodReturnStatement(cpreInnerListIsSynchronized));
			ctd.Members.Add(cmpIsSynchronized);

			// IsSynchronized
			CodeMemberProperty cmpSyncRoot = new CodeMemberProperty();
			cmpSyncRoot.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpSyncRoot.Comments.AddRange(GetSummaryStatements());
			cmpSyncRoot.Name = "SyncRoot";
			cmpSyncRoot.Type = new CodeTypeReference(typeof(System.Object));
			CodePropertyReferenceExpression cpreInnerListSyncRoot = new CodePropertyReferenceExpression(ctrethis, "InnerList.SyncRoot");
			cmpSyncRoot.GetStatements.Add( new CodeMethodReturnStatement(cpreInnerListSyncRoot));
			ctd.Members.Add(cmpSyncRoot);

			return ctd;
		}

		private CodeTypeDeclaration CreateSoapHttpClientProtocolEx()
		{
			CodeTypeDeclaration ctd = new CodeTypeDeclaration();
			ctd.Name = "SoapHttpClientProtocolEx";
			ctd.Comments.AddRange(GetSummaryStatements());
			ctd.BaseTypes.Add(typeof(System.Web.Services.Protocols.SoapHttpClientProtocol));

			// Base Constructor
			CodeConstructor ccDefault = new CodeConstructor();
			ccDefault.Attributes = MemberAttributes.Public;
			ccDefault.Comments.AddRange(GetSummaryStatements());
			ctd.Members.Add(ccDefault);

			// Field mSoapRequestMsg
			CodeMemberField cmfSoapRequestMsg = new CodeMemberField();
			cmfSoapRequestMsg.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmfSoapRequestMsg.Name = "mSoapRequestMsg";
			cmfSoapRequestMsg.Type = new CodeTypeReference(typeof(System.String));
			ctd.Members.Add(cmfSoapRequestMsg);

			// Field mSoapResponseMsg
			CodeMemberField cmfSoapResponseMsg = new CodeMemberField();
			cmfSoapResponseMsg.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmfSoapResponseMsg.Name = "mSoapResponseMsg";
			cmfSoapResponseMsg.Type = new CodeTypeReference(typeof(System.String));
			ctd.Members.Add(cmfSoapResponseMsg);

			// Reference to the created field mSoaprequestMsg
			CodeFieldReferenceExpression cfreSoapRequestMsg = new CodeFieldReferenceExpression(null, cmfSoapRequestMsg.Name);
			// Reference to the created field mSoapResponseMsg
			CodeFieldReferenceExpression cfreSoapResponseMsg = new CodeFieldReferenceExpression(null, cmfSoapResponseMsg.Name);


			// Properties SoapRequest
			CodeMemberProperty cmpSoapRequest = new CodeMemberProperty();
			cmpSoapRequest.Comments.AddRange(GetSummaryStatements());
			cmpSoapRequest.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpSoapRequest.Name = "SoapRequest";
			cmpSoapRequest.Type = new CodeTypeReference(typeof(System.String));

			CodeTryCatchFinallyStatement ctcfsRequestMsg = new CodeTryCatchFinallyStatement();
			ctcfsRequestMsg.TryStatements.Add(new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Pretty", cfreSoapRequestMsg)));
			CodeCatchClause cccExceptionReq = new CodeCatchClause();
			cccExceptionReq.CatchExceptionType = new CodeTypeReference(typeof(System.Exception));
			cccExceptionReq.Statements.Add(new CodeMethodReturnStatement(cfreSoapRequestMsg));
			ctcfsRequestMsg.CatchClauses.Add(cccExceptionReq);
			cmpSoapRequest.GetStatements.Add(ctcfsRequestMsg);
			cmpSoapRequest.SetStatements.Add( new CodeAssignStatement(cfreSoapRequestMsg, new CodePropertySetValueReferenceExpression()));
			ctd.Members.Add(cmpSoapRequest);
	
			// Properties SoapResponse
			CodeMemberProperty cmpSoapResponset = new CodeMemberProperty();
			cmpSoapResponset.Comments.AddRange(GetSummaryStatements());
			cmpSoapResponset.Attributes = MemberAttributes.Public | MemberAttributes.Final;
			cmpSoapResponset.Name = "SoapResponse";
			cmpSoapResponset.Type = new CodeTypeReference(typeof(System.String));
		
			CodeTryCatchFinallyStatement ctcfsResponseMsg = new CodeTryCatchFinallyStatement();
			ctcfsResponseMsg.TryStatements.Add(new CodeMethodReturnStatement(new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Pretty", cfreSoapResponseMsg)));
			CodeCatchClause cccExceptionRes = new CodeCatchClause();
			cccExceptionRes.CatchExceptionType = new CodeTypeReference(typeof(System.Exception));
			cccExceptionRes.Statements.Add(new CodeMethodReturnStatement(cfreSoapResponseMsg));
			ctcfsResponseMsg.CatchClauses.Add(cccExceptionRes);
			cmpSoapResponset.GetStatements.Add(ctcfsResponseMsg);
			cmpSoapResponset.SetStatements.Add( new CodeAssignStatement(cfreSoapResponseMsg, new CodePropertySetValueReferenceExpression()));
			ctd.Members.Add(cmpSoapResponset);
		
			// Pretty
			CodeTypeReference ctrString = new CodeTypeReference(typeof(System.String));
			CodeVariableReferenceExpression cvreMessage = new CodeVariableReferenceExpression();
			cvreMessage.VariableName = "Message";
			CodeMemberMethod cmmPretty = new CodeMemberMethod();    
			cmmPretty.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmmPretty.Comments.AddRange(GetSummaryStatements());
			cmmPretty.Comments.Add(new CodeCommentStatement("<param name=\"Message\"></param>", true));
			cmmPretty.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmPretty.Name = "Pretty";
			cmmPretty.ReturnType = ctrString;
			CodeParameterDeclarationExpression cpdeMessage = new CodeParameterDeclarationExpression();
			cpdeMessage.Name = cvreMessage.VariableName;
			cpdeMessage.Type = ctrString;
			cpdeMessage.Direction = FieldDirection.In;
			cmmPretty.Parameters.Add(cpdeMessage);
			CodeVariableReferenceExpression cvreRet = new CodeVariableReferenceExpression();
			cvreRet.VariableName = "Ret";
			CodeVariableReferenceExpression cvreDoc = new CodeVariableReferenceExpression();
			cvreDoc.VariableName = "Doc";
			CodeVariableReferenceExpression cvreStr = new CodeVariableReferenceExpression();
			cvreStr.VariableName = "MemStr";
			CodeVariableReferenceExpression cvreXmlWriter = new CodeVariableReferenceExpression();
			cvreXmlWriter.VariableName = "XmlWriter";
			CodeVariableDeclarationStatement cvdsDoc = new CodeVariableDeclarationStatement();
			cvdsDoc.Name = cvreDoc.VariableName;
			cvdsDoc.Type = new CodeTypeReference(typeof(System.Xml.XmlDocument));;
			cvdsDoc.InitExpression = new CodeObjectCreateExpression(typeof(System.Xml.XmlDocument), new CodeExpression[] {});
			CodeVariableDeclarationStatement cvdsStr = new CodeVariableDeclarationStatement();
			cvdsStr.Name = cvreStr.VariableName;
			cvdsStr.Type = new CodeTypeReference(typeof(System.IO.MemoryStream));;
			cvdsStr.InitExpression = new CodeObjectCreateExpression(typeof(System.IO.MemoryStream), new CodeExpression[] {});
			CodeVariableDeclarationStatement cvdsXmlWriter = new CodeVariableDeclarationStatement();
			cvdsXmlWriter.Name = cvreXmlWriter.VariableName;
			cvdsXmlWriter.Type = new CodeTypeReference(typeof(System.Xml.XmlTextWriter));;
			cvdsXmlWriter.InitExpression = new CodeObjectCreateExpression(typeof(System.Xml.XmlTextWriter), new CodeExpression[] {cvreStr, new CodePropertyReferenceExpression(null, "System.Text.Encoding.Unicode")});
			CodeAssignStatement casXmlWriterFormatting = new CodeAssignStatement(new CodePropertyReferenceExpression(cvreXmlWriter, "Formatting"), new CodePropertyReferenceExpression(null, "System.Xml.Formatting.Indented"));
			CodeMethodInvokeExpression cmieDocLoad = new CodeMethodInvokeExpression(cvreDoc, "LoadXml", cvreMessage);
			CodeMethodInvokeExpression cmieDocWrite = new CodeMethodInvokeExpression(cvreDoc, "WriteContentTo", cvreXmlWriter);
			CodeMethodInvokeExpression cmieXmlWriterFlush = new CodeMethodInvokeExpression(cvreXmlWriter, "Flush", new CodeExpression[] {});
			CodeMethodInvokeExpression cmieMemStrFlush = new CodeMethodInvokeExpression(cvreStr, "Flush", new CodeExpression[] {});
			CodeAssignStatement casMemPosition = new CodeAssignStatement(new CodePropertyReferenceExpression(cvreStr, "Position"), new CodePrimitiveExpression(0));
			CodeVariableDeclarationStatement cvdsRet = new CodeVariableDeclarationStatement();
			cvdsRet.Name = cvreRet.VariableName;
			cvdsRet.Type = new CodeTypeReference(typeof(System.String));;
			cvdsRet.InitExpression = new CodeMethodInvokeExpression(new CodeObjectCreateExpression(typeof(System.IO.StreamReader), new CodeExpression[] {cvreStr}), "ReadToEnd", new CodeExpression[]{});
			CodeMethodInvokeExpression cmieStrClose = new CodeMethodInvokeExpression(cvreStr, "Close", new CodeExpression[] {});
			CodeMethodInvokeExpression cmieXmlWriterClose = new CodeMethodInvokeExpression(cvreXmlWriter, "Close", new CodeExpression[] {});
			CodeMethodReturnStatement cmrsRet = new CodeMethodReturnStatement(cvreRet);
			cmmPretty.Statements.Add(cvdsDoc);
			cmmPretty.Statements.Add(cvdsStr);
			cmmPretty.Statements.Add(cvdsXmlWriter);
			cmmPretty.Statements.Add(casXmlWriterFormatting);
			cmmPretty.Statements.Add(cmieDocLoad);
			cmmPretty.Statements.Add(cmieDocWrite);
			cmmPretty.Statements.Add(cmieXmlWriterFlush);
			cmmPretty.Statements.Add(cmieMemStrFlush);
			cmmPretty.Statements.Add(casMemPosition);
			cmmPretty.Statements.Add(cvdsRet);
			cmmPretty.Statements.Add(cmieStrClose);
			cmmPretty.Statements.Add(cmieXmlWriterClose);
			cmmPretty.Statements.Add(cmrsRet);
			ctd.Members.Add(cmmPretty);		
			
			return ctd;
		}

		private CodeTypeDeclaration CreateSoapExtensionExAttribute()
		{
			// Class Declaration
			CodeTypeDeclaration ctd = new CodeTypeDeclaration();
			ctd.Comments.AddRange(GetSummaryStatements());
			ctd.Name = "SoapExtensionExAttribute";
			ctd.TypeAttributes = TypeAttributes.Public | TypeAttributes.Sealed;
			ctd.BaseTypes.Add(typeof(System.Web.Services.Protocols.SoapExtensionAttribute));
			CodeFieldReferenceExpression cfreAttributeTarget = new CodeFieldReferenceExpression(new CodeTypeReferenceExpression(typeof(System.AttributeTargets)), "Method");
			ctd.CustomAttributes.Add(new CodeAttributeDeclaration("AttributeUsage", new CodeAttributeArgument( cfreAttributeTarget)));

			// Field mPriority
			CodeMemberField cmfPriority = new CodeMemberField();
			cmfPriority.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmfPriority.Name = "mPriority";
			cmfPriority.Type = new CodeTypeReference(typeof(System.Int32));
			ctd.Members.Add(cmfPriority);

			// Reference to the created field
			CodeFieldReferenceExpression cfrePriority = new CodeFieldReferenceExpression(null, cmfPriority.Name);

			// Property Priority
			CodeMemberProperty cmpPriority = new CodeMemberProperty();
			cmpPriority.Comments.AddRange(GetSummaryStatements());
			cmpPriority.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			cmpPriority.Name = "Priority";
			cmpPriority.Type = new CodeTypeReference(typeof(System.Int32));
			cmpPriority.GetStatements.Add(new CodeMethodReturnStatement(cfrePriority));
			cmpPriority.SetStatements.Add( new CodeAssignStatement(cfrePriority, new CodePropertySetValueReferenceExpression()));
			ctd.Members.Add(cmpPriority);
	
			// Property ExtensionType
			CodeMemberProperty cmpExtensionType = new CodeMemberProperty();
			cmpExtensionType.Comments.AddRange(GetSummaryStatements());
			cmpExtensionType.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			cmpExtensionType.Name = "ExtensionType";
			cmpExtensionType.Type = new CodeTypeReference(typeof(System.Type));
			cmpExtensionType.GetStatements.Add(new CodeMethodReturnStatement(new CodeTypeOfExpression(new CodeTypeReference("SoapExtensionEx"))));
			ctd.Members.Add(cmpExtensionType);
			
			return ctd;
		}

		private CodeTypeDeclaration CreateSoapExtensionEx()
		{
			CodeTypeReference ctrSoapMessage = new CodeTypeReference(typeof(System.Web.Services.Protocols.SoapMessage));
			CodeTypeReference ctrStream = new CodeTypeReference(typeof(System.IO.Stream));
			CodeTypeReference ctrMemoryStream = new CodeTypeReference(typeof(System.IO.MemoryStream));
			CodeTypeReference ctrByteArray = new CodeTypeReference(typeof(System.Byte[]));
			CodeTypeReference ctrEncoder = new CodeTypeReference(typeof(System.Text.UTF8Encoding));

			CodeVariableReferenceExpression cvreMessage = new CodeVariableReferenceExpression();
			cvreMessage.VariableName = "Message";

			CodeVariableReferenceExpression cvreStrFrom = new CodeVariableReferenceExpression();
			cvreStrFrom.VariableName = "StrFrom";

			CodeVariableReferenceExpression cvreStrTo = new CodeVariableReferenceExpression();
			cvreStrTo.VariableName = "StrTo";

			CodeVariableReferenceExpression cvreByteBuf = new CodeVariableReferenceExpression();
			cvreByteBuf.VariableName = "ByteBuf";

			CodeVariableReferenceExpression cvreEncoder = new CodeVariableReferenceExpression();
			cvreEncoder.VariableName = "Encoder";

			// SoapMessage Message
			CodeParameterDeclarationExpression cpdeMessage = new CodeParameterDeclarationExpression();
			cpdeMessage.Name = cvreMessage.VariableName;
			cpdeMessage.Type = ctrSoapMessage;
			cpdeMessage.Direction = FieldDirection.In;
			
			// Stream StrFrom
			CodeParameterDeclarationExpression cpdeStrFrom = new CodeParameterDeclarationExpression();
			cpdeStrFrom.Name = cvreStrFrom.VariableName;
			cpdeStrFrom.Type = ctrStream;
			cpdeStrFrom.Direction = FieldDirection.In;
	
			// Stream StrFrom
			CodeParameterDeclarationExpression cpdeStrTo = new CodeParameterDeclarationExpression();
			cpdeStrTo.Name = cvreStrTo.VariableName;
			cpdeStrTo.Type = ctrStream;
			cpdeStrTo.Direction = FieldDirection.In;
	
			// Class Declaration
			CodeTypeDeclaration ctd = new CodeTypeDeclaration();
			ctd.Name = "SoapExtensionEx";
			ctd.Comments.AddRange(GetSummaryStatements());
			ctd.BaseTypes.Add(typeof(System.Web.Services.Protocols.SoapExtension));

			// Field mStrOld
			CodeMemberField cmfStrOld = new CodeMemberField();
			cmfStrOld.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmfStrOld.Name = "mStrOld";
			cmfStrOld.Type = new CodeTypeReference(typeof(System.IO.Stream));
			ctd.Members.Add(cmfStrOld);

			// Field mStrNew
			CodeMemberField cmfStrNew = new CodeMemberField();
			cmfStrNew.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmfStrNew.Name = "mStrNew";
			cmfStrNew.Type = new CodeTypeReference(typeof(System.IO.Stream));
			ctd.Members.Add(cmfStrNew);

			// Reference to the created field
			CodeFieldReferenceExpression cfreStrOld = new CodeFieldReferenceExpression(null, cmfStrOld.Name);
			
			// Reference to the created field
			CodeFieldReferenceExpression cfreStrNew = new CodeFieldReferenceExpression(null, cmfStrNew.Name);

			// Methods GetInitializer(MethodInfo, Attribute)
			CodeMemberMethod cmmGetInitializerLM = new CodeMemberMethod();    
			cmmGetInitializerLM.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			cmmGetInitializerLM.Comments.AddRange(GetSummaryStatements());
			cmmGetInitializerLM.Comments.Add(new CodeCommentStatement("<param name=\"MethodInfo\"></param>", true));
			cmmGetInitializerLM.Comments.Add(new CodeCommentStatement("<param name=\"Attribute\"></param>", true));
			cmmGetInitializerLM.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmGetInitializerLM.Name = "GetInitializer";
			cmmGetInitializerLM.ReturnType = new CodeTypeReference(typeof(System.Object));
			CodeParameterDeclarationExpression cpdeMethodInfo = new CodeParameterDeclarationExpression();
			cpdeMethodInfo.Type = new CodeTypeReference(typeof(System.Web.Services.Protocols.LogicalMethodInfo));
			cpdeMethodInfo.Name = "MethodInfo";
			cpdeMethodInfo.Direction = FieldDirection.In;
			CodeParameterDeclarationExpression cpdeAttribute = new CodeParameterDeclarationExpression();
			cpdeAttribute.Type = new CodeTypeReference(typeof(System.Web.Services.Protocols.SoapExtensionAttribute));
			cpdeAttribute.Name = "Attribute";
			cpdeAttribute.Direction = FieldDirection.In;
			cmmGetInitializerLM.Parameters.Add(cpdeMethodInfo);
			cmmGetInitializerLM.Parameters.Add(cpdeAttribute);
			cmmGetInitializerLM.Statements.Add( new CodeMethodReturnStatement( new CodePrimitiveExpression(null) ) );
			ctd.Members.Add(cmmGetInitializerLM);

			// Methods GetInitializer(ServiceType)
			CodeMemberMethod cmmGetInitializerST = new CodeMemberMethod();    
			cmmGetInitializerST.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			cmmGetInitializerST.Comments.AddRange(GetSummaryStatements());
			cmmGetInitializerST.Comments.Add(new CodeCommentStatement("<param name=\"ServiceType\"></param>", true));
			cmmGetInitializerST.Comments.Add(new CodeCommentStatement("<returns></returns>", true));
			cmmGetInitializerST.Name = "GetInitializer";
			cmmGetInitializerST.ReturnType = new CodeTypeReference(typeof(System.Object));
			CodeParameterDeclarationExpression cpdeServiceType = new CodeParameterDeclarationExpression();
			cpdeServiceType.Type = new CodeTypeReference(typeof(System.Type));
			cpdeServiceType.Name = "ServiceType";
			cpdeServiceType.Direction = FieldDirection.In;
			cmmGetInitializerST.Parameters.Add(cpdeServiceType);
			cmmGetInitializerST.Statements.Add( new CodeMethodReturnStatement(new CodeTypeOfExpression(new CodeTypeReference("SoapExtensionEx"))));
			ctd.Members.Add(cmmGetInitializerST);

			// Methods Initialize
			CodeMemberMethod cmmInitialize = new CodeMemberMethod();    
			cmmInitialize.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			cmmInitialize.Comments.AddRange(GetSummaryStatements());
			cmmInitialize.Comments.Add(new CodeCommentStatement("<param name=\"Initializer\"></param>", true));
			cmmInitialize.Name = "Initialize";
			CodeParameterDeclarationExpression cpdeInitializer = new CodeParameterDeclarationExpression();
			cpdeInitializer.Type = new CodeTypeReference(typeof(System.Object));
			cpdeInitializer.Name = "Initializer";
			cpdeInitializer.Direction = FieldDirection.In;
			cmmInitialize.Parameters.Add(cpdeInitializer);
			ctd.Members.Add(cmmInitialize);

			// Methods ProcessMessage
			CodeMemberMethod cmmProcessMessage = new CodeMemberMethod();    
			cmmProcessMessage.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			cmmProcessMessage.Comments.AddRange(GetSummaryStatements());
			cmmProcessMessage.Comments.Add(new CodeCommentStatement("<param name=\"Message\"></param>", true));
			cmmProcessMessage.Name = "ProcessMessage";
			cmmProcessMessage.Parameters.Add(cpdeMessage);
			CodePropertyReferenceExpression cpreMessageStage = new CodePropertyReferenceExpression(cvreMessage, "Stage");
			CodeVariableReferenceExpression cvreSoapMessageStage = new CodeVariableReferenceExpression("System.Web.Services.Protocols.SoapMessageStage");
			CodeConditionStatement cdsBeforeSerialize = new CodeConditionStatement();
			cdsBeforeSerialize.Condition = new CodeBinaryOperatorExpression(cpreMessageStage, CodeBinaryOperatorType.ValueEquality, new CodePropertyReferenceExpression(cvreSoapMessageStage, "BeforeSerialize"));
			CodeConditionStatement cdsAfterSerialize = new CodeConditionStatement();
			cdsAfterSerialize.Condition = new CodeBinaryOperatorExpression(cpreMessageStage, CodeBinaryOperatorType.ValueEquality, new CodePropertyReferenceExpression(cvreSoapMessageStage, "AfterSerialize"));
			CodeMethodInvokeExpression cmieSaveRequest = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "SaveRequestMessage", cvreMessage);
			CodeMethodInvokeExpression cmieCopy = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Copy", new CodeExpression[] {cfreStrNew, cfreStrOld});
			cdsAfterSerialize.TrueStatements.Add(cmieSaveRequest);
			cdsAfterSerialize.TrueStatements.Add(cmieCopy);
			CodeConditionStatement cdsBeforeDeserialize = new CodeConditionStatement();
			cdsBeforeDeserialize.Condition = new CodeBinaryOperatorExpression(cpreMessageStage, CodeBinaryOperatorType.ValueEquality, new CodePropertyReferenceExpression(cvreSoapMessageStage, "BeforeDeserialize"));
			CodeMethodInvokeExpression cmieSaveResponse = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "SaveResponseMessage", cvreMessage);
			cdsBeforeDeserialize.TrueStatements.Add(cmieSaveResponse);
			CodeConditionStatement cdsAfterDeserialize = new CodeConditionStatement();
			cdsAfterDeserialize.Condition = new CodeBinaryOperatorExpression(cpreMessageStage, CodeBinaryOperatorType.ValueEquality, new CodePropertyReferenceExpression(cvreSoapMessageStage, "AfterDeserialize"));
			CodeMethodInvokeExpression cmieStringFormat = new CodeMethodInvokeExpression(null, "System.String.Format", new CodeExpression[]{new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("System.Globalization.CultureInfo"), "InvariantCulture"), new CodePrimitiveExpression("Invalid Soap Message stage [{0}]"), cpreMessageStage});
			CodeThrowExceptionStatement ctesException = new CodeThrowExceptionStatement(new CodeObjectCreateExpression(typeof(System.ArgumentException), new CodeExpression[] {cmieStringFormat, new CodePrimitiveExpression("Message")}));
			cdsBeforeSerialize.FalseStatements.Add(cdsAfterSerialize);
			cdsAfterSerialize.FalseStatements.Add(cdsBeforeDeserialize);
			cdsBeforeDeserialize.FalseStatements.Add(cdsAfterDeserialize);
			cdsAfterDeserialize.FalseStatements.Add(ctesException);
			cmmProcessMessage.Statements.Add(cdsBeforeSerialize);
			ctd.Members.Add(cmmProcessMessage);

			// Methods ChainStream
			CodeMemberMethod cmmChainStream = new CodeMemberMethod();    
			cmmChainStream.Attributes = MemberAttributes.Public | MemberAttributes.Override;
			cmmChainStream.Comments.AddRange(GetSummaryStatements());
			cmmChainStream.Comments.Add(new CodeCommentStatement("<param name=\"StrFrom\"></param>", true));
			cmmChainStream.Name = "ChainStream";
			cmmChainStream.ReturnType = ctrStream;
			cmmChainStream.Parameters.Add(cpdeStrFrom);
			cmmChainStream.Statements.Add( new CodeAssignStatement( cfreStrOld, cvreStrFrom));
			cmmChainStream.Statements.Add( new CodeAssignStatement( cfreStrNew, new CodeObjectCreateExpression(ctrMemoryStream, new CodeExpression[] {})));
			cmmChainStream.Statements.Add( new CodeMethodReturnStatement(cfreStrNew));
			ctd.Members.Add(cmmChainStream);

			// Methods SaveRequestMessage
			CodeMemberMethod cmmSaveRequestMessage = new CodeMemberMethod();    
			cmmSaveRequestMessage.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmmSaveRequestMessage.Comments.AddRange(GetSummaryStatements());
			cmmSaveRequestMessage.Comments.Add(new CodeCommentStatement("<param name=\"Message\"></param>", true));
			cmmSaveRequestMessage.Name = "SaveRequestMessage";
			cmmSaveRequestMessage.Parameters.Add(cpdeMessage);
			CodeVariableDeclarationStatement cvdsEncoder = new CodeVariableDeclarationStatement();
			cvdsEncoder.Name = cvreEncoder.VariableName;
			cvdsEncoder.Type = ctrEncoder;
			cvdsEncoder.InitExpression = new CodeObjectCreateExpression(ctrEncoder, new CodeExpression[] {});
			CodeVariableDeclarationStatement cvdsByteBuf = new CodeVariableDeclarationStatement();
			cvdsByteBuf.Name = cvreByteBuf.VariableName;
			cvdsByteBuf.Type = ctrByteArray;
			cvdsByteBuf.InitExpression = new CodeArrayCreateExpression(ctrByteArray, new CodePropertyReferenceExpression(cfreStrNew, "Length"));
			CodeMethodInvokeExpression cmieStrNewRead = new CodeMethodInvokeExpression(cfreStrNew, "Read", new CodeExpression[] {cvreByteBuf, new CodePrimitiveExpression(0), new CodePropertyReferenceExpression(cvreByteBuf, "Length") });
			CodeMethodInvokeExpression cmieEncoderGetString = new CodeMethodInvokeExpression(cvreEncoder, "GetString", new CodeCastExpression(typeof(byte[]), cvreByteBuf));
			CodeAssignStatement casSoapRequest = new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeCastExpression("SoapHttpClientProtocolEx", new CodePropertyReferenceExpression(new CodeCastExpression(typeof(System.Web.Services.Protocols.SoapClientMessage), cvreMessage), "Client")),"SoapRequest"), cmieEncoderGetString);
			cmmSaveRequestMessage.Statements.Add(cvdsEncoder);
			cmmSaveRequestMessage.Statements.Add( new CodeAssignStatement( new CodePropertyReferenceExpression(cfreStrNew, "Position"), new CodePrimitiveExpression(0)));
			cmmSaveRequestMessage.Statements.Add(cvdsByteBuf);
			cmmSaveRequestMessage.Statements.Add(cmieStrNewRead);
			cmmSaveRequestMessage.Statements.Add(casSoapRequest);
			ctd.Members.Add(cmmSaveRequestMessage);

			// Methods SaveResponseMessage
			CodeMemberMethod cmmSaveResponseMessage = new CodeMemberMethod();    
			cmmSaveResponseMessage.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmmSaveResponseMessage.Comments.AddRange(GetSummaryStatements());
			cmmSaveResponseMessage.Comments.Add(new CodeCommentStatement("<param name=\"Message\"></param>", true));
			cmmSaveResponseMessage.Name = "SaveResponseMessage";
			cmmSaveResponseMessage.Parameters.Add(cpdeMessage);
			CodeVariableReferenceExpression cvreStrTemp = new CodeVariableReferenceExpression();
			cvreStrTemp.VariableName = "StrTemp";
			CodeVariableDeclarationStatement cvdsStrTemp = new CodeVariableDeclarationStatement();
			cvdsStrTemp.Name = cvreStrTemp.VariableName;
			cvdsStrTemp.Type = ctrStream;
			cvdsStrTemp.InitExpression = new CodeObjectCreateExpression(ctrMemoryStream,  new CodeExpression[] {});
			CodeMethodInvokeExpression cmieCopyToTemp = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Copy", new CodeExpression[] {cfreStrOld, cvreStrTemp});
			CodeVariableDeclarationStatement cvdsByteBuf2 = new CodeVariableDeclarationStatement();
			cvdsByteBuf2.Name = cvreByteBuf.VariableName;
			cvdsByteBuf2.Type = ctrByteArray;
			cvdsByteBuf2.InitExpression = new CodeArrayCreateExpression(ctrByteArray, new CodePropertyReferenceExpression(cvreStrTemp, "Length"));
			CodeMethodInvokeExpression cmieStrTempRead = new CodeMethodInvokeExpression(cvreStrTemp, "Read", new CodeExpression[] {cvreByteBuf, new CodePrimitiveExpression(0), new CodePropertyReferenceExpression(cvreByteBuf, "Length")});
			CodeAssignStatement casSoapResponse = new CodeAssignStatement(new CodePropertyReferenceExpression(new CodeCastExpression("SoapHttpClientProtocolEx", new CodePropertyReferenceExpression(new CodeCastExpression(typeof(System.Web.Services.Protocols.SoapClientMessage), cvreMessage), "Client")),"SoapResponse"), cmieEncoderGetString);
			CodeMethodInvokeExpression cmieCopyToNew = new CodeMethodInvokeExpression(new CodeThisReferenceExpression(), "Copy", new CodeExpression[] {cvreStrTemp, cfreStrNew });
			cmmSaveResponseMessage.Statements.Add(cvdsEncoder);
			cmmSaveResponseMessage.Statements.Add(cvdsStrTemp);
			cmmSaveResponseMessage.Statements.Add(cmieCopyToTemp);
			cmmSaveResponseMessage.Statements.Add(cvdsByteBuf2);
			cmmSaveResponseMessage.Statements.Add(cmieStrTempRead);
			cmmSaveResponseMessage.Statements.Add(casSoapResponse);
			cmmSaveResponseMessage.Statements.Add(cmieCopyToNew);
			ctd.Members.Add(cmmSaveResponseMessage);

			// Methods Copy
			CodeMemberMethod cmmCopy = new CodeMemberMethod();    
			cmmCopy.Attributes = MemberAttributes.Private | MemberAttributes.Final;
			cmmCopy.Comments.AddRange(GetSummaryStatements());
			cmmCopy.Comments.Add(new CodeCommentStatement("<param name=\"StrFrom\"></param>", true));
			cmmCopy.Comments.Add(new CodeCommentStatement("<param name=\"StrTo\"></param>", true));
			cmmCopy.Name = "Copy";
			cmmCopy.Parameters.Add(cpdeStrFrom);
			cmmCopy.Parameters.Add(cpdeStrTo);
	
			CodeAssignStatement casStrFromPosition = new CodeAssignStatement(new CodePropertyReferenceExpression(cvreStrFrom, "Position"), new CodePrimitiveExpression(0) );
			CodeConditionStatement ccsStrFromCanSeek = new CodeConditionStatement(new CodePropertyReferenceExpression(cvreStrFrom, "CanSeek"), new CodeStatement[] {casStrFromPosition});
			
			CodeVariableReferenceExpression cvreTxtReader = new CodeVariableReferenceExpression("TxtReader");
			CodeVariableDeclarationStatement cvdsTxtReader = new CodeVariableDeclarationStatement();
			cvdsTxtReader.Name = cvreTxtReader.VariableName;
			cvdsTxtReader.Type = new CodeTypeReference(typeof(System.IO.TextReader));
			cvdsTxtReader.InitExpression = new CodeObjectCreateExpression(typeof(System.IO.StreamReader), new CodeExpression[] {cvreStrFrom});

			CodeVariableReferenceExpression cvreTxtWriter = new CodeVariableReferenceExpression("TxtWriter");
			CodeVariableDeclarationStatement cvdsTxtWriter = new CodeVariableDeclarationStatement();
			cvdsTxtWriter.Name = cvreTxtWriter.VariableName;
			cvdsTxtWriter.Type = new CodeTypeReference(typeof(System.IO.TextWriter));
			cvdsTxtWriter.InitExpression = new CodeObjectCreateExpression(typeof(System.IO.StreamWriter), new CodeExpression[] {cvreStrTo });
			
			CodeMethodInvokeExpression cmieTxtWriterWriteLine = new CodeMethodInvokeExpression(cvreTxtWriter, "WriteLine", new CodeExpression[] {new CodeMethodInvokeExpression(cvreTxtReader, "ReadToEnd", new CodeExpression[] {})});
			CodeMethodInvokeExpression cmiTxtWriterFlush = new CodeMethodInvokeExpression(cvreTxtWriter, "Flush", new CodeExpression[] {});
			CodeConditionStatement ccsStrToCanSeek = new CodeConditionStatement(new CodePropertyReferenceExpression(cvreStrTo, "CanSeek"), new CodeStatement[] {new CodeAssignStatement(new CodePropertyReferenceExpression(cvreStrTo, "Position"), new CodePrimitiveExpression(0) )});

			cmmCopy.Statements.Add(ccsStrFromCanSeek);
			cmmCopy.Statements.Add(cvdsTxtReader);
			cmmCopy.Statements.Add(cvdsTxtWriter);
			cmmCopy.Statements.Add(cmieTxtWriterWriteLine);
			cmmCopy.Statements.Add(cmiTxtWriterFlush);
			cmmCopy.Statements.Add(ccsStrToCanSeek);

			ctd.Members.Add(cmmCopy);

			return ctd;
		}

		private CodeCommentStatementCollection GetSummaryStatements()
		{
			CodeCommentStatementCollection sum = new CodeCommentStatementCollection();
			sum.Add(new CodeCommentStatement("<summary>", true));
			sum.Add(new CodeCommentStatement("", true));
			sum.Add(new CodeCommentStatement("</summary>", true));
			return sum;

		}

		private string GetDefaultNameSpace(string fileName)
		{
			if (this.FileNameSpace != String.Empty)
			{
				return this.FileNameSpace;
			}
			else 
			{
				return mNamespace;
				/*
				if (mProjItem != null) 
				{
					EnvDTE.Project proj = mProjItem.ContainingProject;

					//If resource file resides in the project root, then the file's namespace is identical to the project's DefaultNamespace
				
					if(Path.GetDirectoryName(proj.FileName)==Path.GetDirectoryName(fileName))
					{
						return (string)proj.Properties.Item("DefaultNamespace").Value;
					}
						//If not, then find the file's parent folder and get its DefaultNamespace
					else
					{
						//The parent folder can't be reached directly through some property.
						//Instead, it's necessary to go down through the whole hierarchy from the project root.
						//The hierarchy is fetched from the resource file's full filename
						string[] arrTemp = Path.GetDirectoryName(fileName).Replace(Path.GetDirectoryName(proj.FileName) + "\\","").Split(new char[] {'\\'});
						EnvDTE.ProjectItems projItems = proj.ProjectItems;
						for (int i = 0; i < arrTemp.Length; i++)
						{
							projItems = projItems.Item(arrTemp[i]).ProjectItems;
						}
						return (string)((EnvDTE.ProjectItem)projItems.Parent).Properties.Item("DefaultNamespace").Value;
					}
				}
				else 
				{
					return mNamespace;
				}
				*/
			} 
		
		}

		public string GetCodeLanguage()
		{
			return mLang;
		}

		public void SetCodeLanguage(string lang)
		{
			mLang = lang;
		}

		public string GetNamespace()
		{
			return mNamespace;
		}

		public void SetNamespace(string ns)
		{
			mNamespace = ns;
		}

		public bool GetOutputOneFileOption()
		{
			return mOutputOneFileOption;
		}

		public void SetOutputOneFileOption(bool option)
		{
			mOutputOneFileOption = option;
		}

		public string GetOutputPath()
		{
			return mOutputPath;
		}

		public void SetOutputPath(string path)
		{
			if (path.EndsWith("/")) 
			{
				mOutputPath = path;
			}
			else 
			{
				mOutputPath = path + "/";
			}
		}

		private static string CS = "cs";
		//private static string JS = "js";
		private static string VB = "vb"; 
	}
}

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

namespace eBay.WebService.CodeGenerator
{
  using System;
  using System.Runtime.InteropServices;

  /// <summary>
  /// 
  /// </summary>
  [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
  public class CustomToolAttribute: Attribute
  {

    /// <summary></summary>
    protected string _name;

    /// <summary></summary>
    protected string _description;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    public CustomToolAttribute(string name):
      this(name, "")
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    public CustomToolAttribute(string name, string description)
    {
      this._name = name;
      this._description = description;
    }

    /// <summary>
    /// 
    /// </summary>
    public string Name
    {
      get
      {
        return this._name;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Description
    {
      get
      {
        return this._description;
      }
    }

  }
}

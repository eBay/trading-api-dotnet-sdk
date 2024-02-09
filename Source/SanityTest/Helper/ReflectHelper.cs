using System;
using System.Reflection;
using System.Text;
using System.Collections;

namespace UnitTests.Helper
{
	/// <summary>
	/// Summary description for ReflectHelper.
	/// </summary>
	public class ReflectHelper
	{

		#region constructor

		public ReflectHelper()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

		#region public method


		/// <summary>
		/// check the all propertie's value of an instance to find out whether the instance contains an null value;
		/// if there is no null value in that instance properties,return true;
		/// otherwise, return false.
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="nullPropertyNums">return the number of null properties</param>
		/// <param name="nullPropertyNames">return the names of null properties</param>
		/// <returns></returns>
		public static bool IsProperteValueNotNull(object instance,out int nullPropertyNums,out string nullPropertyNames)
		{
			nullPropertyNums=0;
			nullPropertyNames=string.Empty;
			StringBuilder str=new StringBuilder();

			Type type=instance.GetType();
			object temp;

			foreach(MemberInfo member in type.GetProperties())
			{
				temp=type.InvokeMember(member.Name,BindingFlags.GetProperty,null,instance,null);
				if(temp==null)
				{
					nullPropertyNums++;
					str.Append(type.Name);
					str.Append(".");
					str.Append(member.Name);
					str.Append(";");
				}
			}
			
			if(nullPropertyNums!=0)
			{
				nullPropertyNames=str.ToString();
				return false;
			}

			return true;
		}

		/// <summary>
		///check whether the values of property which is not in excludePropertyName list is not null 
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="excludePropertyName">the property that you do not wanna check</param>
		/// <param name="nullPropertyNums"></param>
		/// <param name="nullPropertyNames"></param>
		/// <returns></returns>
		public static bool IsProperteValueNotNull(object instance,ArrayList excludePropertyName,out int nullPropertyNums,out string nullPropertyNames)
		{
			return isProperteValueNotNull(instance,excludePropertyName,out nullPropertyNums,out nullPropertyNames);
		}

		#endregion

		#region pricate method

		/// <summary>
		/// check whether the values of property which is not in excludePropertyName list is not null
		/// </summary>
		/// <param name="instance"></param>
		/// <param name="excludePropertyName"></param>
		/// <param name="nullPropertyNums"></param>
		/// <param name="nullPropertyNames"></param>
		/// <returns></returns>
		private static bool isProperteValueNotNull(object instance,ArrayList excludePropertyName,out int nullPropertyNums,out string nullPropertyNames)
		{
			nullPropertyNums=0;
			nullPropertyNames=string.Empty;
			StringBuilder str=new StringBuilder();

			Type type=instance.GetType();
			object temp;

			foreach(MemberInfo member in type.GetProperties())
			{
				if(!isItemInList(excludePropertyName,member.Name))
				{
					temp=type.InvokeMember(member.Name,BindingFlags.GetProperty,null,instance,null);
					if(temp==null)
					{
						nullPropertyNums++;
						str.Append(type.Name);
						str.Append(".");
						str.Append(member.Name);
						str.Append(";");
					}
				}
			}
			
			if(nullPropertyNums!=0)
			{
				nullPropertyNames=str.ToString();
				return false;
			}

			return true;
		}

		/// <summary>
		/// check whether an item of string type in the list
		/// </summary>
		/// <param name="list"></param>
		/// <param name="item"></param>
		/// <returns></returns>
		private static bool isItemInList(ArrayList list,string item)
		{
			if(list == null|| list.Count==0) return false;

			for(int i = 0; i<list.Count; i++)
			{
				if(string.Compare(item,list[0].ToString(),true)==0)
				{
					return true;
				}
			}

			return false;
		}

		#endregion

		
	}
}

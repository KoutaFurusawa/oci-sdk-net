/// <summary>
/// Enum Utility Class
/// 
/// author: koutaro furusawa
/// </summary>

using System;
using System.ComponentModel;
using System.Reflection;

namespace OCISDK.Core.src.Common
{
    public static class EnumAttribute
    {
        public static string GetDisplayName<T>(this T Value) where T : struct, IComparable, IConvertible, IFormattable
        {
            var displayName = "";
            FieldInfo fieldInfo = Value.GetType().GetField(Value.ToString());
            if (fieldInfo != null)
            {
                // get enum discription Attribute
                var attr = (DisplayNameAttribute)fieldInfo.GetCustomAttribute(typeof(DisplayNameAttribute));
                if (attr != null)
                {
                    displayName = attr.DisplayName;
                }

            }
            return displayName;
        }
    }
}

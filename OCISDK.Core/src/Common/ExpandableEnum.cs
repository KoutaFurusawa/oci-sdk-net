using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OCISDK.Core.src.Common
{
    /// <summary>
    /// Provide your own enumeration. This is mainly used when processing enums as strings.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ExpandableEnum<T> where T : ExpandableEnum<T>
    {
        private static readonly IDictionary<Type, object> StaticFields = new Dictionary<Type, object>();

        public string Value
        {
            get;
            private set;
        }

        protected ExpandableEnum(string value)
        {
            Value = value;
        }

        public static implicit operator string(ExpandableEnum<T> value)
        {
            return value?.Value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        protected static IDictionary<string, T> GetKeyValues()
        {
            var t = typeof(T);
            if(StaticFields.TryGetValue(t, out object obj))
            {
                return obj as IDictionary<string, T>;
            }
            else
            {
                var fields = t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
                var map = fields.Select(f => f.GetValue(null)).Cast<T>().ToDictionary(v => v.Value);
                map = new Dictionary<string, T>(map, StringComparer.OrdinalIgnoreCase);
                StaticFields.Add(t, map);
                return map;
            }
        }

        public static IEnumerable<T> GetValues()
        {
            return GetKeyValues().Values;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static T Parse(string str)
        {
            var map = GetKeyValues();
            if (!map.TryGetValue(str, out T value))
            {
                throw new InvalidCastException();
            }
            return value as T;
        }

        public virtual int CompareTo(object obj)
        {
            return Value.CompareTo(((ExpandableEnum<T>) obj).Value);
        }

        public virtual bool Equals(ExpandableEnum<T> obj)
        {
            return (obj is null) ? false : StringComparer.OrdinalIgnoreCase.Equals(Value, obj.Value);
        }

        protected virtual bool Equals(string value)
        {
            return StringComparer.OrdinalIgnoreCase.Equals(Value, value);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (!GetType().Equals(obj.GetType()))
            {
                return false;
            }

            return Equals(obj as T);
        }

        public static bool operator ==(ExpandableEnum<T> a, string b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            if (a is null)
            {
                return false;
            }
            else
            {
                return a.Equals(b);
            }
        }

        public static bool operator !=(ExpandableEnum<T> a, string b)
        {
            return !(a == b);
        }

        public static bool operator ==(string a, ExpandableEnum<T> b)
        {
            return (b == a);
        }

        public static bool operator !=(string a, ExpandableEnum<T> b)
        {
            return !(a == b);
        }
    }
}

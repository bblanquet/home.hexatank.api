using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace server.Core
{
    public static class MetaReader
    {
        public static void SetPropety<T>(T obj, string propertyName, object value)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (!property.PropertyType.IsEnum 
                && value.GetType() != property.PropertyType)
            {
                throw new InvalidCastException($"wrong property types {value.GetType().FullName} {property.PropertyType.FullName}");
            }
            if(property.PropertyType.IsEnum){
                property.SetValue(obj, Enum.Parse(property.PropertyType, (string)value));
            }
            else{
                property.SetValue(obj, value);
            }

        }

        public static List<string> GetProperties<T>()
        {
            var result = new List<string>();
            foreach(var property in typeof(T).GetProperties())
            {
                result.Add(property.Name);
            }
            return result;
        }

        public static List<object> GetValues<T>(T obj)
        {
            var result = new List<object>();
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(obj);
                if(value is int)
                {
                    result.Add(value);
                }
                else
                {
                    result.Add(Regex.Escape(obj.ToString()));
                }
            }
            return result;
        }
    }
}

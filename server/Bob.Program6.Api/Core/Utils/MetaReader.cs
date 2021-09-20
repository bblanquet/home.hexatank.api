using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bob.Program6.Api.Core
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
            if (property.PropertyType.IsEnum) {
                property.SetValue(obj, Enum.Parse(property.PropertyType, (string)value));
            }
            else {
                property.SetValue(obj, value);
            }
        }
        public static List<string> GetProps<T>()
        {
            var result = new List<string>();
            foreach (var property in typeof(T).GetProperties())
            {
                result.Add(property.Name);
            }
            return result;
        }

        public static List<string> GetTags<T>()
        {
            var result = new List<string>();
            foreach (var property in typeof(T).GetProperties())
            {
                result.Add($"@{property.Name}");
            }
            return result;
        }

        public static List<string> GetPropsAndTags<T>()
        {
            var result = new List<string>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name != "Id") { 
                    result.Add($"{property.Name} = @{property.Name}");
                }
            }
            return result;
        }

        public static string GetMemberName(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return ((MemberExpression)expression).Member.Name;
                case ExpressionType.Convert:
                    return GetMemberName(((UnaryExpression)expression).Operand);
                default:
                    throw new NotSupportedException(expression.NodeType.ToString());
            }
        }

    }
}

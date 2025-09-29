using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Entities.Common
{
    public class ErrorDetail
    {
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
    }

    public class ResponseStatus
    {
        public string status { get; set; }
        public string statusMessage { get; set; }
        public List<ErrorDetail> errorDetails { get; set; }
    }
    public class Common
    {
        public static List<string> FieldMapping(Type type)
        {
            List<string> _dict = new List<string>();

            PropertyInfo[] props = type.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                string propName = prop.Name;
                _dict.Add(propName);
            }
            return _dict;
        }
        public static KeyValuePair<float, List<KeyValuePair<int, Dictionary<string, object>>>> ConvertExpandoToKeyValue(float key, List<ExpandoObject> expando)
        {
            var result = new KeyValuePair<float, List<KeyValuePair<int, Dictionary<string, object>>>>
                (key, new List<KeyValuePair<int, Dictionary<string, object>>>());

            for (int i = 0; i < expando.Count; i++)
            {
                var element = new Dictionary<string, object>(expando[i]);

                var propertyValues = new KeyValuePair<int, Dictionary<string, object>>(i, element);

                result.Value.Add(propertyValues);
            }

            return result;
        }
    }
    
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value, null);
            }

            return someObject;
        }

        public static IDictionary<string, object> AsDictionary(this object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            return source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );

        }
    }
}

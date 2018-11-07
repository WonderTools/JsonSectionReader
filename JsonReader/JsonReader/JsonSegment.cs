using System;
using System.Collections.Generic;
using System.Reflection;
using JsonReader.Exceptions;
using Newtonsoft.Json.Linq;

namespace JsonReader
{
    public class JsonSegment
    {
        private readonly JToken _token;
        public JsonSegment(JToken token)
        {
            _token = token;
        }

        public List<List<object>> GetTable(params Type[] types)
        {
            var jArray = _token as JArray;
            if (jArray == null) throw new TableNotFoundException();
            List<List<object>> result = new List<List<object>>();
            foreach (var jToken in jArray)
            {
                var jSecondArray = jToken as JArray;
                if(jSecondArray == null) throw new Exception("Table Content mismatch");
                if(types.Length != jSecondArray.Count) throw new Exception("Table size mismatch");
                List<object> resultRow = new List<object>();
                for (int i = 0; i < types.Length; i++)
                {
                    resultRow.Add(GetData(jSecondArray[i], types[i]));
                }
                result.Add(resultRow);
            }

            return result;
        }

        private object GetData(JToken jToken, Type type)
        {
            if (type.IsClass || type.IsEnum)
                return GetData(jToken, type, nameof(GetObjectBasedOnType));
            else
                return GetData(jToken, type, nameof(GetValueBasedOnType));
        }

        private object GetData(JToken jToken, Type type, string methodName)
        {
            var currentType = this.GetType();
            var methodInfo = currentType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            methodInfo = methodInfo.MakeGenericMethod(type);
            return methodInfo.Invoke(this, new object[] {jToken});
        }        

        private object GetValueBasedOnType<T>(JToken jToken)
        {
            return jToken.Value<T>();
        }

        private object GetObjectBasedOnType<T>(JToken jToken)
        {
            return jToken.ToObject<T>();
        }
    }

    
    //As Object
    //As intOrDefault
    //As float
    //As bool
    //As Date
    //As double
    //as char
    //as byte
    //as long
    //as decimal
    //As Ulong
    //OrDefault
    //OrNull
}
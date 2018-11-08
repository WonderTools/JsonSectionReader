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
            for (var i = 0; i < jArray.Count; i++)
            {
                var jToken = jArray[i];
                var jSecondArray = jToken as JArray;
                if (jSecondArray == null) throw new ImproperRowInTableException(i);
                if (types.Length != jSecondArray.Count) throw new ImproperRowInTableException(i, types.Length, jSecondArray.Count);
                List<object> resultRow = new List<object>();
                for (int j = 0; j < types.Length; j++)
                {
                    try
                    {
                        resultRow.Add(GetData(jSecondArray[j], types[j]));
                    }
                    catch (Exception e)
                    {
                        throw new UnableToGetDataExcpetion(i, j, jToken.ToString(), types[i].Name, e);
                    }
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
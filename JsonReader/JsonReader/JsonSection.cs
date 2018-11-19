using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WonderTools.JsonReader.Exceptions;
using Newtonsoft.Json.Linq;

namespace WonderTools.JsonReader
{
    public class JsonSection
    {
        private readonly JToken _jToken;
        public JsonSection(JToken jToken)
        {
            _jToken = jToken;
        }

        public JsonSection GetSection(params object[] searchTokens)
        {
            var obj = _jToken;
            for (var index = 0; index < searchTokens.Length; index++)
            {
                var searchToken = searchTokens[index];
                if (searchToken is string x)
                {
                    if (!(obj is JObject jObject))
                        throw new FilterTokenPropertyNotFoundException(x, index);
                    if (!jObject.ContainsKey(x))
                        throw new FilterTokenPropertyNotFoundException(x, index);
                    obj = obj[x];
                }
                else if (searchToken is int y)
                {
                    if (!(obj is JArray) || (y >= obj.Count()))
                        throw new FilterTokenArrayOutOfBoundException(y, index);
                    obj = obj[y];
                }
                else throw new InvalidTokenTypeExcepton(index, searchToken.GetType());
            }
            return new JsonSection(obj);
        }

        public T GetObject<T>()
        {
            var obj = GetData(_jToken, typeof(T));
            return (T) obj;
        }

        public List<List<object>> GetTable(params Type[] types)
        {
            var jArray = _jToken as JArray;
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
            if (methodInfo == null) throw new SomethingWentWrongException(1001);
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

    //The table to be completed up to 12 elements has to be completed
    //Reading other language (german) UTF8, such file types
    //Tests for reading int, float, double, and so on has to be added.
    //as dynamic    
}
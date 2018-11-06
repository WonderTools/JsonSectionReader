using System;
using System.IO;
using System.Linq;
using JsonReader.Exceptions;
using Newtonsoft.Json.Linq;

namespace JsonReader
{
    public class WtJsonReader
    {
        private Exception Exception(string message)
        {
            return new Exception(message);
        }

        private Stream CreateStream(string fileName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            assemblies = assemblies.Where(x => !x.IsDynamic).ToList();
            var listOfList = assemblies
                .Select(asm => asm.GetManifestResourceNames()
                    .Where(name => name.EndsWith(fileName))).ToList();
            var names = listOfList.SelectMany(x => x, (c, s) => s).ToList();

            if (names.Count > 1) throw Exception("Multiple resources were identified with the file name :"+
                                                 string.Join(", ", names));
            if (names.Count == 0) throw new EmbeddedResourceNotFoundException(fileName);

            var fullFileName = names[0];
            var assembly = assemblies.First(x => x.GetManifestResourceNames().Any(y => y.EndsWith(fileName)));
            var stream = assembly.GetManifestResourceStream(fullFileName);
            return stream;
        }

        public JsonSegment Read(string fileName, params object[] tokens)
        {
            using (var stream = CreateStream(fileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    var text = reader.ReadToEnd();
                    JToken obj = JObject.Parse(text);
                    for (var index = 0; index < tokens.Length; index++)
                    {
                        var token = tokens[index];
                        if (token is string x)
                        {
                            if (!(obj is JObject jObject))
                                throw new FilterTokenPropertyNotFoundException(x, index);
                            if(!jObject.ContainsKey(x))
                                throw new FilterTokenPropertyNotFoundException(x, index);
                            obj = obj[x];
                        }
                        else if (token is int y)
                        {
                            if(!(obj is JArray) || (y >= obj.Count()))
                                throw new FilterTokenArrayOutOfBoundException(y, index);
                            obj = obj[y];
                        }
                        else throw new InvalidTokenTypeExcepton(index, token.GetType());
                    }

                    return new JsonSegment(obj);
                }
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
}
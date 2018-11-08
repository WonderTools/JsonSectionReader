using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JsonReader.Exceptions;
using Newtonsoft.Json.Linq;

namespace JsonReader
{
    public class WtJsonReader
    {
        private Stream CreateStream(string fileName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            assemblies = assemblies.Where(x => !x.IsDynamic).ToList();
            var listOfList = assemblies
                .Select(asm => asm.GetManifestResourceNames()
                    .Where(name => name.EndsWith(fileName))).ToList();
            var names = listOfList.SelectMany(x => x, (c, s) => s).ToList();
            names.Sort();

            if (names.Count > 1) throw new MultipleResourceFoundException(fileName, string.Join(",",names));
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
                    JToken obj = JObject.Parse(text, new JsonLoadSettings());
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
    }
}
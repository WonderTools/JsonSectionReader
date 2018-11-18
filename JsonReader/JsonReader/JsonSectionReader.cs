using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WonderTools.JsonReader.Exceptions;
using Newtonsoft.Json.Linq;

namespace WonderTools.JsonReader
{
    public class JsonSectionReader
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

        public JsonSection Read(string fileName, params object[] tokens)
        {
            using (var stream = CreateStream(fileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    var text = reader.ReadToEnd();
                    JToken obj = JObject.Parse(text, new JsonLoadSettings());
                    var jsonSection = new JsonSection(obj);
                    return jsonSection.GetSection(tokens);
                }
            }
        }
    }
}
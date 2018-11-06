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

        public int AsIntOrDefault()
        {
            return _token.Value<int>();
        }
    }
}
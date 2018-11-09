using System;
using WonderTools.JsonReader;

namespace WonderTools.JsonReaderTests
{
    public static class Test
    {
        public static Exception GetExceptionAttemptingToGetJsonSegment(string file, params object[] tokens)
        {
            try
            {
                var reader = new JsonSectionReader();
                reader.Read(file, tokens);
            }
            catch (Exception e)
            {
                return e;
            }
            throw new Exception();
        }
    }
}
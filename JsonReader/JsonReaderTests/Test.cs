using System;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonReaderTests
{
    public static class Test
    {
        public static Exception GetExceptionAttemptingToGetJsonSegment(string file, params object[] tokens)
        {
            try
            {
                var reader = new JsonSectionReader.JsonSectionReader();
                reader.Read(file).GetSection(tokens);
            }
            catch (Exception e)
            {
                return e;
            }
            throw new Exception();



        }
    }
}
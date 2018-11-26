using System;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests
{
    public static class Test
    {
        public static Exception GetExceptionAttemptingToGetJsonSegment(string file, params object[] tokens)
        {
            try
            {
                var reader = new JSectionReader();
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
using System;
using JsonReader;
using JsonReader.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace JsonReaderTests
{
    [TestFixture]
    public class FileLevelTests
    {
        [TestCase("InvalidFile.json", typeof(EmbeddedResourceNotFoundException), 
            "No embedded resource with name ending with InvalidFile.json was found")]
        [TestCase("Test.json", typeof(MultipleResourceFoundException),
            "Multiple file with name Test.json found : JsonReaderTests.Folder.Test.json,JsonReaderTests.Test.json")]
        public void InvalidFileTests(string fileName, Type exceptionType, string errorMessage)
        {
            var exception = Test.GetExceptionAttemptingToGetJsonSegment(fileName);
            Assert.AreEqual(exceptionType, exception.GetType());
            Assert.AreEqual(errorMessage,
                exception.Message);
        }
    }
}
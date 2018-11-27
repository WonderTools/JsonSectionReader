using System;
using WonderTools.JsonSectionReader;
using WonderTools.JsonSectionReader.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace WonderTools.JsonSectionReaderTests
{
    [TestFixture]
    public class FileLevelTests
    {
        [TestCase("InvalidFile.json", typeof(EmbeddedResourceNotFoundException),
            "No embedded resource with name ending with InvalidFile.json was found")]
        [TestCase("Test.json", typeof(MultipleResourceFoundException),
            "Multiple file with name Test.json found : WonderTools.JsonSectionReaderTests.Folder.Test.json,WonderTools.JsonSectionReaderTests.Test.json")]
        public void InvalidFileTests(string fileName, Type exceptionType, string errorMessage)
        {
            var exception = Test.GetExceptionAttemptingToGetJsonSegment(fileName);
            Assert.AreEqual(exceptionType, exception.GetType());
            Assert.AreEqual(errorMessage,
                exception.Message);
        }
    }
}
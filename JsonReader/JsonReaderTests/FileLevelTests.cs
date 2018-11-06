using System;
using JsonReader;
using JsonReader.Exceptions;
using NUnit.Framework;

namespace JsonReaderTests
{
    [TestFixture]
    public class FileLevelTests
    {
        [Test]
        public void InvalidFileTests()
        {
            Exception TestFunction()
            {
                try
                {
                    var reader = new WtJsonReader();
                    reader.Read("InvalidFile.json");
                }
                catch (Exception e)
                {
                    return e;
                }
                throw new Exception();
            }

            var exception = TestFunction();
            Assert.AreEqual(typeof(EmbeddedResourceNotFoundException), exception.GetType());
            Assert.AreEqual("No embedded resource with name ending with InvalidFile.json was found",
                exception.Message);
        }
    }
}
using System;
using System.Collections.Generic;
using JsonReader;
using JsonReader.Exceptions;
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
            Exception TestFunction()
            {
                try
                {
                    var reader = new WtJsonReader();
                    reader.Read(fileName);
                }
                catch (Exception e)
                {
                    return e;
                }
                throw new Exception();
            }

            var exception = TestFunction();
            Assert.AreEqual(exceptionType, exception.GetType());
            Assert.AreEqual(errorMessage,
                exception.Message);
        }
    }

    public class Good
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public enum MyState
    {
        One,
        Tex,
    }

    [TestFixture]
    public class DataTests
    {
        [Test]
        public void Test()
        {
            var reader = new WtJsonReader();
            var actual = reader.Read("BasicData.json", "tableData").GetTable(typeof(int), typeof(string), typeof(int), typeof(Good), typeof(int[]), typeof(MyState));
            int i = 0;
            
        }


        //[Test]
        //public void LongDataTest()
        //{
        //    long data = 4294967296;
        //    var reader = new WtJsonReader();
        //    var actual = reader.Read("BasicData.json", "longData").AsLong();
        //    Assert.AreEqual(data, actual,"The value is "+data);
        //}

        //[Test]
        //public void StringDataTest()
        //{
        //    string data = "This is great";
        //    var reader = new WtJsonReader();
        //    var actual = reader.Read("BasicData.json", "stringData").AsString();
        //    Assert.AreEqual(data, actual, "The value is " + data);
        //}

        //[Test]
        //public void IntDataAsStringTest()
        //{
        //    var data = 5432;
        //    var reader = new WtJsonReader();
        //    var actual = reader.Read("BasicData.json", "intDataAsString").AsInt();
        //    Assert.AreEqual(data, actual);
        //}


    }
}
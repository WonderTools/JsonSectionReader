using System;
using System.Text;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests
{
    [TestFixture]
    public class ReadJsonTests
    {
        [TestCase("simpleObject")]
        [TestCase("integer")]
        [TestCase("date1")]
        [TestCase("date2")]
        [TestCase("simpleString")]
        [TestCase("array")]
        [TestCase("complicatedObject")]
        public void ReadJson(string testCaseName)
        {
            var testDataSection = new JSectionReader().Read("ReadJsonTests.json", Encoding.UTF8, testCaseName);
            string json = testDataSection.GetSection("value").GetJson();
            string expectedJson = testDataSection.GetSection("serializedValue").GetObject<string>();
            Assert.AreEqual(expectedJson, json);
        }
    }
}
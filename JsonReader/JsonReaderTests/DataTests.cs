using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonReader;

namespace WonderTools.JsonReaderTests
{
    public class DataTests
    {
        public static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("DataTests.json", "number", 34850924).SetName("Reading a number as int");
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test(string fileName, string sectionName, object expected)
        {
            var section = new JsonSectionReader().Read(fileName, Encoding.UTF8).GetSection(sectionName);
            var result = section.GetObject<int>();
            Assert.AreEqual(expected, result);
        }
    }
}
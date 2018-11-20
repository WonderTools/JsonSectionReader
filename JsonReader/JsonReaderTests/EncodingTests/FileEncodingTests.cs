using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonReader;

namespace WonderTools.JsonReaderTests.EncodingTests
{
    [TestFixture]
    public class FileEncodingTests
    {
        public static IEnumerable<TestCaseData> TestCases()
        {
            var data = new List<string>() { "Straße", "café", "தமிழ்", "आप" };
            yield return new TestCaseData("FileEncodingTests-Utf8-bom.json", Encoding.UTF8, data).SetName("UTF8BOM as UTF8");
            yield return new TestCaseData("FileEncodingTests-Utf8.json", Encoding.UTF8, data).SetName("UTF8 as UTF8"); ;
            yield return new TestCaseData("FileEncodingTests-Utf8-bom.json", Encoding.Default, data).SetName("UTF8BOM as Default");
            yield return new TestCaseData("FileEncodingTests-Utf8.json", Encoding.Default, data).SetName("UTF8 as Default");
            data = new List<string>() { "Straße", "café"};
            yield return new TestCaseData("FileEncodingTests-Ansi.json", Encoding.UTF7, data).SetName("ANSI as UTF7");
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test(string fileName, Encoding encoding, List<string> expected)
        {
            var section = new JsonSectionReader().Read(fileName, encoding).GetSection("table");
            var result = section.GetTableAsObjectList<string, string>((val) => val);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
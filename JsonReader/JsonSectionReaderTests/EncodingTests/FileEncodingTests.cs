using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests.EncodingTests
{
    [TestFixture]
    public class FileEncodingTests
    {
        public static IEnumerable<TestCaseData> TestCases()
        {
            var data = new List<string>() { "Straße", "café", "தமிழ்", "आप" };
            yield return new TestCaseData("1-UTF8BOM as UTF8", "FileEncodingTests-Utf8-bom.json", Encoding.UTF8, data);
            yield return new TestCaseData("2-UTF8 as UTF8","FileEncodingTests-Utf8.json", Encoding.UTF8, data);
            yield return new TestCaseData("3-UTF8BOM as Default","FileEncodingTests-Utf8-bom.json", Encoding.Default, data);
            yield return new TestCaseData("4-UTF8 as Default", "FileEncodingTests-Utf8.json", Encoding.Default, data);
            data = new List<string>() { "Straße", "café"};
            yield return new TestCaseData("5-ANSI as UTF7","FileEncodingTests-Ansi.json", Encoding.UTF7, data);
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test(string testCaseName, string fileName, Encoding encoding, List<string> expected)
        {
            var section = JSectionReader.Section(fileName, encoding).GetSection("table");
            var result = section.GetTableAsObjectList<string, string>((val) => val);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
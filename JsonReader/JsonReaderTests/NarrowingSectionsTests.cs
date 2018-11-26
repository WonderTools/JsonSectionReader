using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests
{
    [TestFixture]
    public class NarrowingSectionsTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void Test(object[] initialFilter, object[] later1Filter, object[] later2Filter)
        {
            var reader = new JSectionReader();
            var actual = reader.Read("NarrowingSectionsTests.json", Encoding.Default,initialFilter).GetSection(later1Filter).GetSection(later2Filter)
                .GetTable(typeof(int), typeof(string));
            actual.Should().BeEquivalentTo(GetExpected());
        }

        public static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new object[0], new object[]{"test1"}, new object[0]).SetName("Initial filter empty - later filter filled");
            yield return new TestCaseData(new object[0], new object[] { "test2", 1 }, new object[0]).SetName("Initial filter empty - later filter filled ends with array");
            yield return new TestCaseData(new object[]{ "test2" }, new object[] { 1 }, new object[0]).SetName("Initial and later filter");
            yield return new TestCaseData(new object[]{}, new object[] { "test2" }, new object[]{1}).SetName("later filter 1 and 2");
        }

        private List<List<object>> GetExpected()
        {
            return new List<List<object>>()
            {
                new List<object>(){1, "string1"},
                new List<object>(){2, "string2"},
                new List<object>(){3, "string3"},
            };
        }
    }
}

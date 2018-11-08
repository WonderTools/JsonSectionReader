using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using JsonReader;
using NUnit.Framework;

namespace JsonReaderTests
{
    [TestFixture]
    public class DataTests
    {
        [TestCaseSource(nameof(GetTestCaseData))]
        public void Test(string searchPath , Type[] tableTypes, List<List<object>> expected)
        {
            var reader = new WtJsonReader();
            var actual = reader.Read("DataTests.json", searchPath)
                .GetTable(tableTypes);
            actual.Should().BeEquivalentTo(expected);
        }

        public static List<object> List(params object[] objs)
        {
            return objs.ToList();
        }

        public static IEnumerable<TestCaseData> GetTestCaseData()
        {
            yield return GetTestCase(BasicData);
            yield return GetTestCase(NullableValueInData);
            yield return GetTestCase(DateInTable);
            yield return GetTestCase(EnumInTable);
        }

        private static TestCaseData GetTestCase(Func<IEnumerable<object>> method)
        {
            var objects = method.Invoke().ToList();
            var path = (string)objects[0];
            var types = (Type[]) objects[1];
            var expected = (List<List<object>>) objects[2];
            return new TestCaseData(path, types, expected).SetName(path);
        }

        private static IEnumerable<object> BasicData()
        {
            yield return "basicData";
            yield return new[] {typeof(int), typeof(string), typeof(int)};
            yield return new List<List<object>>
            {
                List(1, "string1", 322),
                List(2, "string2", 32433),
                List(3, "string3", 32433),
                List(4, "string4", 32433),
                List(5, "string5", 32433),
                List(6, "string6", 32433),
                List(7, "string7", 32433)
            };
        }

        private static IEnumerable<object> NullableValueInData()
        {
            yield return "nullableValueInData";
            yield return new[] { typeof(int), typeof(string), typeof(int?) };
            yield return new List<List<object>>
            {
                List(1, "string1", 322),
                List(2, "string2", null),
                List(3, "string3", 32433)
            };
        }

        private static IEnumerable<object> DateInTable()
        {
            yield return "dateValueInTable";
            yield return new[] { typeof(DateTime), typeof(string), typeof(int) };
            yield return new List<List<object>>
            {
                List(new DateTime(2017, 3, 13), "string1", 322),
                List(new DateTime(2017, 3, 15), "string2", 834),
                List(new DateTime(2017, 3, 14), "string3", 32433)
            };
        }


        private static IEnumerable<object> EnumInTable()
        {
            yield return "enumValueInTable";
            yield return new[] { typeof(DayOfTheWeek), typeof(string), typeof(int) };
            yield return new List<List<object>>
            {
                List(DayOfTheWeek.Monday, "string1", 322),
                List(DayOfTheWeek.Thursday, "string2", 834),
                List(DayOfTheWeek.Sunday, "string3", 32433)
            };
        }

        public enum DayOfTheWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }


        //Table test with Enum int and string
        //Table test objects
        //Table tests List of int
        //table test with list object
    }
}
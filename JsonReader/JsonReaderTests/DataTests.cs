using System;
using System.Collections.Generic;
using System.Reflection;
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
            yield return new TestCaseData("DataTests.json", "number", 34850924, typeof(int)).SetName("Reading a number as int");
            yield return new TestCaseData("DataTests.json", "numberString", 34850924, typeof(int)).SetName("Reading a number-string as int");
            yield return new TestCaseData("DataTests.json", "string", "hello-how-are-you?", typeof(string)).SetName("Reading a string");
            yield return new TestCaseData("DataTests.json", "date", new DateTime(2017, 3, 23), typeof(DateTime)).SetName("Reading a date");
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test(string fileName, string sectionName, object expected, Type objectType)
        {
            var section = new JsonSectionReader().Read(fileName, Encoding.UTF8).GetSection(sectionName);
            var result = GetObjectAtSection(section, objectType);
            Assert.AreEqual(expected, result);
        }

        private object GetObjectAtSection(JsonSection section, Type type)
        {
            var genericMethodInfo = this.GetType().GetMethod(nameof(Read), BindingFlags.Static | BindingFlags.NonPublic);
            var methodInfo = genericMethodInfo.MakeGenericMethod(type);
            return methodInfo.Invoke(null, new object[] {section});
        }

        private static object Read<T>(JsonSection section)
        {
            var result = section.GetObject<T>();
            return result;
        }
    }
}
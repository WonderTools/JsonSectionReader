using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

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
            yield return new TestCaseData("DataTests.json", "float", (float)5.44321234, typeof(float)).SetName("Reading a float");
            yield return new TestCaseData("DataTests.json", "float", (double)5.44321234, typeof(double)).SetName("Reading a double");
            yield return new TestCaseData("DataTests.json", "person", new Person(){ Name = "John", Age = 43}, typeof(Person)).SetName("Reading an object");
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test(string fileName, string sectionName, object expected, Type objectType)
        {
            var section = new JsonSectionReader.JsonSectionReader().Read(fileName, Encoding.UTF8).GetSection(sectionName);
            var result = GetObjectAtSection(section, objectType);
            AssertAreEqual(expected, result);
        }

        private static void AssertAreEqual(object expected, object actual)
        {
            if(expected is double d) Assert.AreEqual(d, (double)actual, 0.001);
            else if (expected is float f) Assert.AreEqual(f, (float)actual, 0.001);
            else if (expected is Person p) p.Should().BeEquivalentTo(actual);
            else Assert.AreEqual(expected, actual);
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

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
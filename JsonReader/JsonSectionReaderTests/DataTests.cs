using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests
{
    [TestFixture]
    public class DataTests
    {
        public static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("1-Reading a number as int", "DataTests.json", "number", 34850924, typeof(int));
            yield return new TestCaseData("2-Reading a number-string as int","DataTests.json", "numberString", 34850924, typeof(int));
            yield return new TestCaseData("3-Reading a string","DataTests.json", "string", "hello-how-are-you?", typeof(string));
            yield return new TestCaseData("4-Reading a date","DataTests.json", "date", new DateTime(2017, 3, 23), typeof(DateTime));
            yield return new TestCaseData("5-Reading a float","DataTests.json", "float", (float)5.44321234, typeof(float));
            yield return new TestCaseData("6-Reading a double", "DataTests.json", "float", (double)5.44321234, typeof(double));
            yield return new TestCaseData("7-Reading an object","DataTests.json", "person", new Person(){ Name = "John", Age = 43}, typeof(Person));
        }

        [TestCaseSource(nameof(TestCases))]
        public void Test(string testCaseName, string fileName, string sectionName, object expected, Type objectType)
        {
            var section = new JSectionReader().Read(fileName, Encoding.UTF8).GetSection(sectionName);
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

        private object GetObjectAtSection(JSection section, Type type)
        {
            var genericMethodInfo = this.GetType().GetMethod(nameof(Read), BindingFlags.Static | BindingFlags.NonPublic);
            var methodInfo = genericMethodInfo.MakeGenericMethod(type);
            return methodInfo.Invoke(null, new object[] {section});
        }

        private static object Read<T>(JSection section)
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
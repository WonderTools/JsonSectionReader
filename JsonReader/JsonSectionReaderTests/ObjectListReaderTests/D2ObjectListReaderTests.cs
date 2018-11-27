using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests.ObjectListReaderTests
{
    public class D2ObjectListReaderTests : ObjectListReaderTests
    {
        [Test]
        public void Test()
        {
            var section = GetSection("objectList2");
            var result = section.GetTableAsObjectList<Person, string, int>((name, age) => new Person() { Name = name, Age = age });
            var expected = GetExpected();
            result.Should().BeEquivalentTo(expected);
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        List<Person> GetExpected()
        {
            return new List<Person>()
            {
                new Person() { Name = "John", Age = 10, },
                new Person() { Name ="Eric", Age = 15, },
                new Person() { Name ="Peter", Age = 17, },
            };
        }
    }
}
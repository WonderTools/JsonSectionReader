using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonSectionReaderTests.ObjectListReaderTests
{
    public class D4ObjectListReaderTests : ObjectListReaderTests
    {
        [Test]
        public void Test()
        {
            var section = GetSection("objectList4");
            var result = section.GetTableAsObjectList<Employee, string, string, int, int>((name, department, roll, age) => new Employee()
            {
                Name = name,
                Department = department,
                Roll = roll,
                Age = age,
            });
            var expected = GetExpected();
            result.Should().BeEquivalentTo(expected);
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public int Roll { get; set; }
            public int Age { get; set; }
        }

        List<Employee> GetExpected()
        {
            return new List<Employee>()
            {
                new Employee() { Name = "John", Department = "Computer", Roll = 1020, Age=30 },
                new Employee() { Name ="Eric", Department = "Computer", Roll = 1025, Age = 32},
                new Employee() { Name ="Peter", Department = "Accounts", Roll = 1030, Age = 29},
            };
        }
    }
}
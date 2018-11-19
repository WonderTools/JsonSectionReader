using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonReader;

namespace WonderTools.JsonReaderTests.ObjectListReaderTests
{
    public class D3ObjectListReaderTests : ObjectListReaderTests
    {
        [Test]
        public void Test()
        {
            var section = GetSection("objectList3");
            var result = section.GetTableAsObjectList<Employee, string, string, int>((name, department, roll) => new Employee()
                {
                    Name = name,
                    Department = department,
                    Roll = roll
                });
            var expected = GetExpected();
            result.Should().BeEquivalentTo(expected);
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Department { get; set; }
            public int Roll { get; set; }
        }

        List<Employee> GetExpected()
        {
            return new List<Employee>()
            {
                new Employee() { Name = "John", Department = "Computer", Roll = 1020, },
                new Employee() { Name ="Eric", Department = "Computer", Roll = 1025, },
                new Employee() { Name ="Peter", Department = "Accounts", Roll = 1030, },
            };
        }
    }
}
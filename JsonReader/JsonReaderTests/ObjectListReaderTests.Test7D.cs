using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonReader;

namespace WonderTools.JsonReaderTests
{
    public partial class ObjectListReaderTests
    {
        public class Test7D : ObjectListReaderTests
        {
            [Test]
            public void Test()
            {
                var section = GetSection("objectList7");
                var result = section.GetTableAsObjectList<Employee, string, string, int, int, DateTime, int, string>(
                    (name, department, roll, age, joiningDate, grade, designation) => new Employee()
                    {
                        Name = name,
                        Department = department,
                        Roll = roll,
                        Age = age,
                        JoiningDate = joiningDate,
                        Grade = grade,
                        Designation = designation,
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
                public DateTime JoiningDate { get; set; }
                public int Grade { get; set; }
                public string Designation { get; set; }
            }

            List<Employee> GetExpected()
            {
                return new List<Employee>()
                {
                    new Employee()
                    {
                        Name = "John", Department = "Computer", Roll = 1020, Age = 30, JoiningDate = new DateTime(2018,1,1), Grade = 1,
                        Designation = "Engineer"
                    },
                    new Employee()
                    {
                        Name ="Eric", Department = "Computer", Roll = 1025, Age = 32, JoiningDate = new DateTime(2018,1,1), Grade = 1,
                        Designation = "Engineer"
                    },
                    new Employee()
                    {
                        Name ="Peter", Department = "Accounts", Roll = 1030, Age = 29, JoiningDate = new DateTime(2018,1,1), Grade = 2, 
                        Designation = "Accountant"
                    },
                };
            }
        }
    }
}
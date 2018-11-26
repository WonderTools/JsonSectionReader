using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using WonderTools.JsonSectionReader;

namespace WonderTools.JsonReaderTests.ObjectListReaderTests
{
    public class D10ObjectListReaderTests : ObjectListReaderTests
    {
        [Test]
        public void Test()
        {
            var section = GetSection("objectList10");
            var result = section.GetTableAsObjectList<Employee, string, string, int, int, DateTime, int, string, string, string, string>
            ((name, department, roll, age, joiningDate, grade, designation, workstationNumber, email, phone) => new Employee()
            {
                Name = name,
                Department = department,
                Roll = roll,
                Age = age,
                JoiningDate = joiningDate,
                Grade = grade,
                Designation = designation,
                WorkStationNumber = workstationNumber,
                EmailAddress = email,
                Phone = phone
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
            public string WorkStationNumber { get; set; }
            public string EmailAddress { get; set; }
            public string Phone { get; set; }
        }

        List<Employee> GetExpected()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Name = "John", Department = "Computer", Roll = 1020, Age = 30, JoiningDate = new DateTime(2018,1,1), Grade = 1,
                    Designation = "Engineer", WorkStationNumber = "A123", EmailAddress = "john@xyz.com", Phone = "1234 12341"
                },
                new Employee()
                {
                    Name ="Eric", Department = "Computer", Roll = 1025, Age = 32, JoiningDate = new DateTime(2018,1,1), Grade = 1,
                    Designation = "Engineer", WorkStationNumber = "A423", EmailAddress = "eric@xyz.com", Phone = "1234 12342"
                },
                new Employee()
                {
                    Name ="Peter", Department = "Accounts", Roll = 1030, Age = 29, JoiningDate = new DateTime(2018,1,1), Grade = 2,
                    Designation = "Accountant", WorkStationNumber = "A163", EmailAddress = "peter@xyz.com", Phone = "1234 12343"
                },
            };
        }
    }
}
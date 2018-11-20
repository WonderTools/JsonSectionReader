using System;
using WonderTools.JsonReader;
using WonderTools.JsonReader.Exceptions;
using NUnit.Framework;

namespace WonderTools.JsonReaderTests
{
    [TestFixture]
    public class TableAccessErrorTests
    {
        [TestCase("invalidTable", typeof(TableNotFoundException),
            "Table not found at the specified path", typeof(int))]

        [TestCase("invalidRow", typeof(ImproperRowInTableException), 
            "Improper row at 1 (row number) in table exception", typeof(int), typeof(int))]

        [TestCase("invalidRow1", typeof(ImproperRowInTableException), 
            "Row 1 (row number) is having 3 elemented, but expected 2", typeof(int), typeof(int))]

        [TestCase("wrongDataType", typeof(UnableToGetDataExcpetion),
            "Unable to read data in column 1 row 1. Unable to read [  1,  \"hello this is wrong\"] as Int32", typeof(int), typeof(int))]

        public void Tests(string segment, Type exceptionType, string errorMessage, params Type[] tableTypes)
        {
            Exception GetExceptionInTable()
            {
                try
                {
                    var reader = new JsonSectionReader();
                    var table = reader.Read("TableAccessErrorTests.json").GetSection(segment).GetTable(tableTypes);
                }
                catch (Exception e)
                {
                    return e;
                }
                throw new Exception("no exception");
            }

            var exception = GetExceptionInTable();
            Assert.AreEqual(exceptionType, exception.GetType());
            Assert.AreEqual(errorMessage,
                exception.Message);
        }
    }
}
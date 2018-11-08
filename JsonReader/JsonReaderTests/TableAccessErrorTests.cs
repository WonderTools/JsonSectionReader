using System;
using JsonReader;
using JsonReader.Exceptions;
using NUnit.Framework;

namespace JsonReaderTests
{
    [TestFixture]
    public class TableAccessErrorTests
    {
        [TestCase("invalidTable", typeof(TableNotFoundException), "Table not found at the specified path", typeof(int))]
        [TestCase("invalidRow",   typeof(ImproperRowInTableException), "Improper row at 1 (row number) in table exception", typeof(int), typeof(int))]
        public void Tests(string segment, Type exceptionType, string errorMessage, params Type[] tableTypes)
        {
            Exception GetExceptionInTable()
            {
                try
                {
                    var reader = new WtJsonReader();
                    var table = reader.Read("TableAccessErrorTests.json", segment).GetTable(tableTypes);
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
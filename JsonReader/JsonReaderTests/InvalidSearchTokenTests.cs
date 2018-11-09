using JsonReader.Exceptions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace JsonReaderTests
{
    [TestFixture()]
    public class InvalidSearchTokenTests
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void ExceptionTest(Type exceptionType, string expectedError, params object[] tokens)
        {
            var exception = Test.GetExceptionAttemptingToGetJsonSegment("TestData.json", tokens);
            Assert.AreEqual(exceptionType, exception.GetType());
            Assert.AreEqual(expectedError, exception.Message);
        }

       
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            yield return new TestCaseData(
                typeof(FilterTokenArrayOutOfBoundException),
                "Token 10 at the index 2 caused array out of bound",
                new object[] { "firstNode", "secondNode", 10 })
                .SetName("1- Array out of bound");

            yield return new TestCaseData(
                    typeof(FilterTokenArrayOutOfBoundException),
                    "Token 0 at the index 1 caused array out of bound",
                    new object[] { "firstNode", 0 })
                .SetName("2- Accessing non array as array");

            yield return new TestCaseData(
                    typeof(InvalidTokenTypeExcepton),
                    "Invalid token found at index 2. Type found Object",
                    new object[] { "firstNode", "secondNode", new object(), 10 })
                .SetName("3- Invalid Token Type");

            yield return new TestCaseData(
                    typeof(FilterTokenPropertyNotFoundException),
                    "Token thirdNode at the index 1 caused property not found",
                    new object[] { "firstNode", "thirdNode", 10 })
                .SetName("4- Property not found");

            yield return new TestCaseData(
                    typeof(FilterTokenArrayOutOfBoundException),
                    "Token 0 at the index 1 caused array out of bound",
                    new object[] { "firstNode", 0 })
                .SetName("5- Accessing by Array subscript in object");

            yield return new TestCaseData(
                    typeof(FilterTokenPropertyNotFoundException),
                    "Token thirdNode at the index 2 caused property not found",
                    new object[] { "firstNode", "secondNode", "thirdNode" })
                .SetName("6- Array out of bound");
        }
    }
}

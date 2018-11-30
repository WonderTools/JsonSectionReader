using WonderTools.JsonSectionReader.Exceptions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace WonderTools.JsonSectionReaderTests
{
    [TestFixture()]
    public class InvalidSearchTokenTests
    {
        [TestCaseSource(nameof(GetTestCases))]
        public void ExceptionTest(string testCaseName, Type exceptionType, string expectedError, params object[] tokens)
        {
            var exception = Test.GetExceptionAttemptingToGetJsonSegment("InvalidSearchTokenTests.json", tokens);
            Assert.AreEqual(exceptionType, exception.GetType());
            Assert.AreEqual(expectedError, exception.Message);
        }

       
        public static IEnumerable<TestCaseData> GetTestCases()
        {
            yield return new TestCaseData("1-Array out of bound",
                typeof(FilterTokenArrayOutOfBoundException),
                "Token 10 at the index 2 caused array out of bound",
                new object[] { "firstNode", "secondNode", 10 });

            yield return new TestCaseData("2-Accessing non array as array",
                    typeof(FilterTokenArrayOutOfBoundException),
                    "Token 0 at the index 1 caused array out of bound",
                    new object[] { "firstNode", 0 });

            yield return new TestCaseData("3-Invalid token type",
                    typeof(InvalidTokenTypeExcepton),
                    "Invalid token found at index 2. Type found Object",
                    new object[] { "firstNode", "secondNode", new object(), 10 });

            yield return new TestCaseData("4-Property not found",
                    typeof(FilterTokenPropertyNotFoundException),
                    "Token thirdNode at the index 1 caused property not found",
                    new object[] { "firstNode", "thirdNode", 10 });

            yield return new TestCaseData("5-Accessing by array subscript in object",
                    typeof(FilterTokenArrayOutOfBoundException),
                    "Token 0 at the index 1 caused array out of bound",
                    new object[] { "firstNode", 0 });

            yield return new TestCaseData("6-Array out of bound",
                    typeof(FilterTokenPropertyNotFoundException),
                    "Token thirdNode at the index 2 caused property not found",
                    new object[] { "firstNode", "secondNode", "thirdNode" });
        }
    }
}

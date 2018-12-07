# JsonSectionReader - A tool to manage data in unit testing

While unit testing, the amount of test data could become voluminious and could easily make the test code less readable. Having the data separated from code imporves the readability of the tests in my opinion. Yes... This is an opinionated tool, and the opinions that shape this tool are listed below.

## 1. Test data must be separated from test code
While unit testing, the test data could be huge and when coded with the test cases, it makes the test case less readable. Having the test data separated makes the test data and test code more readable. The tool facilitates the storing the test data in a separate file.

## 2. Test data must be easily accessbile to tests
The test data must be easily accessible from the test case. Having the test data stored in a separate file or data base would make it necessary to have two entities (the test code and the test data) to run the tests. This cause path/connection string errors. 

## 3. Test data must be readable and easy to modify
The test data has to be easy to read, and modify. The test has lot of information about the tests.

The capabilities of JsonSectionReader are listed below
1. It reads data from json files that are stored as embedded resources.
2. It is capable of reading the entire file or a section of the file.
3. It also offers capabilities to deserialize the json section of interest into .Net objects.

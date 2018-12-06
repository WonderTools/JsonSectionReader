# JsonSectionReader - A tool to manage data in unit testing

While unit testing, the amount of test data could become voluminious and could easily make the test code less readable. Having the data separated from code imporves the readability of the tests. This is an opioniated tool. The opinions that influenced the tool development are listed below.
## 1. Test data must be separated from test code
While unit testing, the test data is huge and when coded with the test cases, it makes the test case less readable. Having the test data separated makes the test data and test code more readable. We decided to have the test data in a JSON file as we found JSON files were easily read and modify.

## 2. Test data must be easily accessbile to tests
The test data must be easily accessible from the test case. Having the test data in a separated file 
3. Test data must be readable and easy to modify

The capabilities of JsonSectionReader are listed below
1. It reads data from json files that are stored as embedded resources.
2. It is capable of reading the entire file or a section of the file.
3. It also offers capabilities to deserialize the json section of interest into .Net objects.

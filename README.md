# JsonSectionReader

JsonSectionReader is a tool that helps you manage your test data in unit testing.

While unit testing, the amount of test data could become voluminious and could easily make the test code less readable. This tool help you separate your test data and test code. This is an opioniated tool. The opinions that influenced the tool development are listed below.
1. Test data must be separated from test code
2. Test data must be easily accessbile to tests
3. Test data must be readable and easy to modify

The capabilities of JsonSectionReader are listed below
1. It reads data from json files that are stored as embedded resources.
2. It is capable of reading the entire file or a section of the file.
3. It also offers capabilities to deserialize the json section of interest into .Net objects.

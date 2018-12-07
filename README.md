# JsonSectionReader - A tool to manage data in unit testing

## Opinions that shaped tool
While unit testing, the amount of test data could become voluminious and could easily make the test code less readable. Having the data separated from code imporves the readability of the tests in my opinion. Yes... This is an opinionated tool, and the opinions that shape this tool are listed below.

#### 1. Test data must be separated from test code
While unit testing, the test data could be huge and when coded with the test cases, it makes the test case less readable. Having the test data separated makes the test data and test code more readable. The tool facilitates the storing the test data in a separate file.

#### 2. Test data must be readable and easy to modify
The test data has lot of information about the tests, and it's really important for this to be readable and easy to modify. The tool facilitates this by having the test data is a json file.

#### 3. Test data must be easily accessbile to tests
The test data must be easily accessible from the test case. Having the test data packaged in another entity would make such as a file or data base would increase the probability of errors such as "File not found", "Invalid Connection String", etc... To make the unit testing more reliable the test data and test code has to be packaged together, and test data must be quickly accessible from test code. The tool facilites this by letting your test data be stored in the same library as embedded resource.  

## Features of the tool
1. Reads full or sections of JSON file
2. Reads JSON file stored as embedded resource. 
3. Make deserializion of JSON to .Net objects easy
4. Capable of reading various encoding formats such as UTF8, UTF32, etc...
5. Supports for data in other languages (Non-ASCII characters)
6. Supports tabular representation of data (similar to data from database)

## Steps to use the tool
1. Add reference to the nuget package "WonderTools.JsonSectionReader"
2. Add a json file to your project say "TestData.json"
3. Make this json file as an embedded resource.
4. Add the json data that you would like it to be available
5. Call the JsonSectionReader methods to get a section of the data and to deserialize it. (Explained with examples below)

## Example

### 1. Sectioning Example 1
TestData.json
```json
"person1" : {
  "name" : "John",
  "age" : 32,
}

```

```cs
  string name = JsonSectionReader.Section("TestData.json").GetSection("person1", "name").GetObject<string>();
```


### 2. Sectioning Example 2
TestData.json
```json
"persons" : [
  {
    "name" : "John",
    "age" : 32,
  },
  { 
    "name" : "nash",
    "age" : 86,
  }
]

```

```cs
  string name = JsonSectionReader.Section("TestData.json").GetSection("persons", 1, "name").GetObject<string>();
```

### 3. File Name Example
TestData.json
```json
"persons" : [
  {
    "name" : "John",
    "age" : 32,
  },
  { 
    "name" : "nash",
    "age" : 86,
  }
]
```
TestData.json
```json
{
  "Integer" : 32,
  "Color" : "Red"
}
```

```cs
  string name = JsonSectionReader.Section("TestData.json").GetSection("persons", 1, "name").GetObject<string>();
```

### 4. Object Example


### 5. List Example


### 6. Table Example

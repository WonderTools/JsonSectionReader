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

### 1. Example1Sectioning
#### Data
Example1Sectioning.json
```json
{
  "name": "john",
  "age" : 32 
}

```
#### Code
```cs
  JSectionReader.Section("Example1Sectioning.json").GetSection("name").GetObject<string>();
```

```cs
  JSectionReader.Section("Example1Sectioning.json", Encoding.Default, "name").GetObject<string>();
```

```cs
  new JSectionReader().Read("Example1Sectioning.json", Encoding.Default, "name").GetObject<string>();
```
#### Remarks
All of the above lines return string "john".

### 2. Example2Sectioning
#### Data
Example2Sectioning.json
```json
{
  "employees": [
    {
      "name": "philip",
      "age": 28
    },
    {
      "name": "richard",
      "age": 31
    }
  ] 
}
```
#### Code
```cs
  JSectionReader.Section("Example2Sectioning.json").GetSection("employees", 1, "name").GetObject<string>();
```
#### Remarks
The statement return string "richard"

### 3. Example3Encoding
#### Data
Example3Encoding.json
```json
{
  "words" : [ "good", "bad", "Mädchen" ]
}
```
#### Code
```cs
    JSectionReader.Section("Example3Encoding.json").GetSection("words", 2).GetObject<string>();
```

#### Remarks
1. The encoding of the file is set to UTF-8 (using Notepad++)
2. The statement return the string "Mädchen"

### 4. Example4FileDiscovery
#### Data
JsonSectionReaderUsage.Example4FileDiscovery.Foo.Example4FileDiscovery.json
```json
{
  "animal": "lion"
}
```
JsonSectionReaderUsage.Example4FileDiscovery.Boo.Example4FileDiscovery.json
```json
{
  "animal" :  "elephant" 
}
```
#### Code
```cs
    JSectionReader
        .Section("JsonSectionReaderUsage.Example4FileDiscovery.Boo.Example4FileDiscovery.json")
        .GetSection("animal").GetObject<string>();
```
```cs
    JSectionReader
        .Section("Example4FileDiscovery.Boo.Example4FileDiscovery.json")
        .GetSection("animal").GetObject<string>();
```

```cs
    JSectionReader
        .Section("Boo.Example4FileDiscovery.json")
        .GetSection("animal").GetObject<string>();
```
#### Remark
1. There are two embedded resources named Example4FileDiscovery.json, so specifing file name as "Example4FileDiscovery.json" will be ambigious and would result in an exception.
2. The file named has to be more specifically mentioned to avoid ambigiouty.
3. The valid names for identifying the file are
    * JsonSectionReaderUsage.Example4FileDiscovery.Boo.Example4FileDiscovery.json
    * Example4FileDiscovery.Boo.Example4FileDiscovery.json
    * Boo.Example4FileDiscovery.json
4. All of the above c sharp statements return the string "elephant"

### 5. Example5ReadingObject
#### Data
Example5ReadingObject.json
```json
{
  "person" : {
    "name": "richard",
    "age" :  22
  }
}
```
#### Code
```cs
JSectionReader.Section("Example5ReadingObject.json").GetSection("person").GetObject<Person>();
```
#### Remark
1. The statement returns a Person object with name as "richard" and Age as 22.

### 6. Example6ReadingList
#### Data
Example6ReadingList.json
```json
{
  "numbers" : [5,4,3,2,1] 
}
```
#### Code
```cs
JSectionReader.Section("Example6ReadingList.json").GetSection("numbers").GetObject<List<int>>();
```
#### Remark
1. The statment returns a List<int> with 5, 4, 3, 2, 1 in it.

### 7. Example7ReadingAsJson
#### Data
Example7ReadingAsJson.json
```json
{
  "employees": [
    {
      "name": "John",
      "id": 31432
    },
    {
      "name": "Nash",
      "id": 31433
    }
  ] 
}
```
#### Code
```cs
new JSectionReader().Read("Example7ReadingAsJson.json").GetSection("employees" , 1).GetJson();
```
#### Remark
1. The statement returns a string **{"name":"Nash","id":31433}**

### 8. Example8ListOfList
#### Data
Example8ListOfList.json
```json
{
  "data": [
    [ 1, "Monday", "Morning" ],
    [ 2, "Monday", "Afternoon" ],
    [ 3, "Tuesday", "Morning" ],
    [ 4, "Tuesday", "Afternoon" ]
  ] 
}
```
#### Code
```cs
    new JSectionReader().Read("Example8ListOfList.json").GetSection("data")
        .GetTable(typeof(int), typeof(string), typeof(string))
```
#### Remark
1. The statement returns a List<List<object>> as shown below
```cs
    new List<List<object>>()
    {
        new List<object>() {1, "Monday", "Morning"},
        new List<object>() {2, "Monday", "Afternoon"},
        new List<object>() {3, "Tuesday", "Morning"},
        new List<object>() {4, "Tuesday", "Afternoon"},
    };
```

### 4. Object Example
#### Data
.json
```json
```
#### Code
```cs
```
#### Remark

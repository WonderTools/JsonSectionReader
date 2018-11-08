using System;

namespace JsonReader.Exceptions
{
    public class UnableToGetDataExcpetion : ApplicationException
    {
        public UnableToGetDataExcpetion(int column, int row, string data, string typeName, Exception innerException): 
            base(RemoveNewLines($"Unable to read data in column {column} row {row}. Unable to read {data} as {typeName}"),innerException)
        {
        }

        private static string RemoveNewLines(string json)
        {
            return json.Replace("\r", String.Empty).Replace("\n", string.Empty);
        }
    }
}
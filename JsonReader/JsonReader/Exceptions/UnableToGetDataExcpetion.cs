using System;

namespace JsonReader.Exceptions
{
    public class UnableToGetDataExcpetion : ApplicationException
    {
        public UnableToGetDataExcpetion(int column, int row, string data, string typeName, Exception innerException): 
            base($"Unable to read data in column {column} row {row}. Unable to read {data} as {typeName}",innerException)
        {
            
        }
    }
}
using System;

namespace JsonReader.Exceptions
{
    public class ImproperRowInTableException : ApplicationException
    {
        public ImproperRowInTableException(int rowNumber) : base($"Improper row at {rowNumber} (row number) in table exception")
        {
        }
    }
}
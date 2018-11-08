using System;

namespace JsonReader.Exceptions
{
    public class ImproperRowInTableException : ApplicationException
    {
        public ImproperRowInTableException(int rowNumber) : base($"Improper row at {rowNumber} (row number) in table exception")
        {
        }

        public ImproperRowInTableException(int rowNumber, int exepectedNumber, int actualNumber)
                    :base ($"Row {rowNumber} (row number) is having {actualNumber} elemented, but expected {exepectedNumber}")
        {
        }
    }


}
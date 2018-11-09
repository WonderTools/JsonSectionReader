using System;

namespace WonderTools.JsonReader.Exceptions
{
    public class FilterTokenArrayOutOfBoundException : ApplicationException
    {
        public FilterTokenArrayOutOfBoundException(int token, int index) 
            : base ($"Token {token} at the index {index} caused array out of bound")
        {
        }
    }
}
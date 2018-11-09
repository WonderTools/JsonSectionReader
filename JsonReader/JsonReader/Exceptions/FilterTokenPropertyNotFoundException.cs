using System;

namespace WonderTools.JsonReader.Exceptions
{
    public class FilterTokenPropertyNotFoundException : ApplicationException
    {
        public FilterTokenPropertyNotFoundException(string token, int index) 
            : base($"Token {token} at the index {index} caused property not found")
        { 
        }
    }
}
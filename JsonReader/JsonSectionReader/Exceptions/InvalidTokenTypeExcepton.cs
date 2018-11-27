using System;

namespace WonderTools.JsonSectionReader.Exceptions
{
    public class InvalidTokenTypeExcepton : ApplicationException
    {
        public InvalidTokenTypeExcepton(int i, Type t)
            : base($"Invalid token found at index {i}. Type found {t.Name}")
        {  
        }
    }
}
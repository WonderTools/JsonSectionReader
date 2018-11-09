using System;
using System.Collections.Generic;

namespace WonderTools.JsonReader.Exceptions
{
    public class MultipleResourceFoundException : ApplicationException
    {
        public MultipleResourceFoundException(string name, string files) 
            : base($"Multiple file with name {name} found : {files}")
        {
            
        }
    }
}
using System;

namespace JsonReader.Exceptions
{
    public class EmbeddedResourceNotFoundException : ApplicationException
    {
        public EmbeddedResourceNotFoundException(string name) 
            : base($"No embedded resource with name ending with {name} was found")
        {
        }
    }

    public class TableNotFoundException : ApplicationException
    {
    }
}
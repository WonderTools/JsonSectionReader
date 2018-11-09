using System;

namespace WonderTools.JsonReader.Exceptions
{
    public class TableNotFoundException : ApplicationException
    {
        public TableNotFoundException() : base("Table not found at the specified path")
        { 
        }
    }
}
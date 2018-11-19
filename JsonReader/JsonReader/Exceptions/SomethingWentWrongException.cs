using System;

namespace WonderTools.JsonReader.Exceptions
{
    public class SomethingWentWrongException : ApplicationException
    {
        public SomethingWentWrongException(int number) : base($"Something went wrong, please report this. Error code{number}")
        {
            
        }
    }
}
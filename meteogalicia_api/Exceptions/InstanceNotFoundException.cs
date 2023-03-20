using System;
namespace meteogalicia_api.Exceptions
{
	public class InstanceNotFoundException : Exception
	{
        public InstanceNotFoundException(string message)
        : base(message)
        {
        }

    }
}


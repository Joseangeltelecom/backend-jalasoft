using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceJala.Core.Exceptions
{
    public class ItemNotFoundException: Exception
    {
        public ItemNotFoundException() { }
        public ItemNotFoundException(string message) : base(message) { }
        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) { }

    }
}

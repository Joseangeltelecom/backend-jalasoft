using System;

namespace EcommerceJala.Core.Exceptions
{
    [Serializable]
    public class ItemArgumentExeption : Exception
    {
        public ItemArgumentExeption() { }
        public ItemArgumentExeption(string message): base(message) { }
        public ItemArgumentExeption(string message, Exception innerException): base(message, innerException) { }
    }
}
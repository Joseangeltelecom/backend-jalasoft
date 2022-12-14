using System;
using System.Collections.Generic;
using System.Net;

namespace BakeryFreshBread.Core.Exceptions
{
    public static class ExeptionsStatusCodes
    {
        private static Dictionary<Type, HttpStatusCode> exeptionStatusCodes = new Dictionary<Type, HttpStatusCode>()
        {
            { typeof(EntityNotFoundException), HttpStatusCode.BadRequest},
             //{ typeof(ItemNotFoundException), HttpStatusCode.NotFound}
        };
        public static HttpStatusCode GetExeptionStatusCode(Exception exception)
        {
            bool exceptionFound = exeptionStatusCodes.TryGetValue(exception.GetType(), out var statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }
    }
}

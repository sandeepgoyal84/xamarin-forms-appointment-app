using System;

namespace XFTest.Infrastructure.Helpers
{
    public class ServiceResponse<T>
    {
        public Exception Exception { get; set; }
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; }
        public T Result { get; set; }
    }
}
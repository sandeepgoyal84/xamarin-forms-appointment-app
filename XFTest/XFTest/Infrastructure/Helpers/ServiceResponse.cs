using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace XFTest.Infrastructure.Helpers
{
    public class ServiceResponse<T>
    {
        #region Properties

        public Exception Exception { get; set; }
        public bool IsSuccess { get; set; }
        public string ResponseCode { get; set; }
        public T Result { get; set; }

        #endregion
    }
}

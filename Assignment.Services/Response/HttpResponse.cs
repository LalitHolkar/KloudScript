using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Services.Response
{
    public class HttpResponse
    {
        public int StatusCode { get; set; }
        public string  Message { get; set; }
        public object Data { get; set; }
        public bool Status { get; set; } = false;
    }
}

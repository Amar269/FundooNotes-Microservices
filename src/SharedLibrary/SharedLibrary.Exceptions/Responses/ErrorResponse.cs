using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Exceptions.Responses
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public string? Details { get; set; }

        public DateTime Timestamp { get; set; }= DateTime.Now;
    }
}

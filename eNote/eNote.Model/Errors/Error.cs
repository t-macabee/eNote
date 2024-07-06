using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace eNote.Model.Errors
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

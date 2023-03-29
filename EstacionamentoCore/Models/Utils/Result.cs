using System;
using System.Collections.Generic;
using System.Text;

namespace EstacionamentoCore.Models.Utils
{
    public class Result
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public Result() { }

        public Result(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}

using System;

namespace YiunHa
{
    public class Result
    {
        public Result(int code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }

    }
}

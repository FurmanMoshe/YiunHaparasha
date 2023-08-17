using System;

namespace YiunHa
{
    public class ResultD
    {
        public ResultD(bool isExists, string message)
        {
            this.IsExists = isExists;
            this.Message = message;
        }

        public bool IsExists { get; set; }
        public string Message { get; set; }

    }
}

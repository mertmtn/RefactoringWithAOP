namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success, int statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }

        public Result(bool success, string message, int statusCode) : this(success)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}

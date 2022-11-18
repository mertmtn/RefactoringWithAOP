namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult(T data, bool success, int statusCode) : base(success)
        {
            Data = data;
            StatusCode = statusCode;
        }
        public DataResult(T data, bool success, string message, int statusCode) : base(success, message, statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }
        public T Data { get; set; }

    }
}

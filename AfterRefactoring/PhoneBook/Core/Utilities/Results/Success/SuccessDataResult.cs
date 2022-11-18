namespace Core.Utilities.Results.Success
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        public SuccessDataResult(T data) : base(data, true)
        {

        }

        public SuccessDataResult(T data, int statusCode) : base(data, true, statusCode)
        {

        }

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        public SuccessDataResult(string message, int statusCode) : base(default, true, message, statusCode)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
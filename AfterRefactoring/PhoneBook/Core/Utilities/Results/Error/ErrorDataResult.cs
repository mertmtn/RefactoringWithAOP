namespace Core.Utilities.Results.Error
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
        public ErrorDataResult(string message, int statusCode) : base(default, false, message, statusCode)
        {

        }
        public ErrorDataResult(T data, int statusCode) : base(data, false, statusCode)
        {

        }
    }
}

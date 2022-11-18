namespace Core.Utilities.Results.Error
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }

        public ErrorResult() : base(false)
        {

        }
        public ErrorResult(string message, int statusCode) : base(false, message, statusCode)
        {

        }

        public ErrorResult(int statusCode) : base(false, statusCode)
        {

        }
    }
}

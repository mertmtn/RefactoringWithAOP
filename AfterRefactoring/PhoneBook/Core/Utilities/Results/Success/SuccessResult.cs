namespace Core.Utilities.Results.Success
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }
        public SuccessResult(string message, int statusCode) : base(true, message, statusCode)
        {

        }

        public SuccessResult(int statusCode) : base(true, statusCode)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
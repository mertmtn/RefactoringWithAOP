namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; set; }
        int StatusCode { get; set; }
    }
}

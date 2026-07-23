namespace epariona_curso04_tarea02.Domain.Common;

public class Result : IResult
{
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; }

    protected Result(bool isSuccess, string? errorMessage)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(string errorMessage) => new(false, errorMessage);
}

public class Result<T> : Result, IResult<T>
{
    public T? Value { get; }

    protected Result(bool isSuccess, string? errorMessage, T? value)
        : base(isSuccess, errorMessage)
    {
        Value = value;
    }

    public static new Result<T> Success(T value) => new(true, null, value);
    public static new Result<T> Failure(string errorMessage) => new(false, errorMessage, default);
}

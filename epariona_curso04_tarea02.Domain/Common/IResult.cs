namespace epariona_curso04_tarea02.Domain.Common;

public interface IResult
{
    bool IsSuccess { get; }
    string? ErrorMessage { get; }
}

public interface IResult<T> : IResult
{
    T? Value { get; }
}

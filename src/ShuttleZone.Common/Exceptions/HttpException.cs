using System.Diagnostics.CodeAnalysis;

namespace ShuttleZone.Common.Exceptions;

public class HttpException : Exception
{
    public int StatusCode { get; private set; }
    public string? ErrorMessage { get; private set; }

    private HttpException()
    {
    }

    public HttpException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        ErrorMessage = message;
    }

    public static HttpException New()
    {
        return new HttpException();
    }

    public HttpException WithStatusCode(int statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public HttpException WithErrorMessage(string message)
    {
        ErrorMessage = message;
        return this;
    }

    public HttpException ThrowIf(bool condition)
    {
        if (condition) throw this;
        return this;
    }

    public HttpException ThrowIfNull([NotNull] object? obj)
    {
        if (obj is null) throw this;
        return this;
    }
}

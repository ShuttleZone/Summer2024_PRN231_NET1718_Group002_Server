namespace ShuttleZone.Common.Exceptions;

public class MissingAzureSettingsConfiguration : ArgumentException
{
    private readonly string? _message;
    public override string Message => _message ?? Message;

    public MissingAzureSettingsConfiguration(string message)
    {
        _message = message;
    }

    public MissingAzureSettingsConfiguration()
    {
        _message = "Can not specified the azure settings configuration.";
    }
}
namespace OnForkHub.Core.Interfaces.Validations;

public interface IValidationResult
{
    bool IsValid { get; }
    bool HasError { get; }
    IReadOnlyCollection<ValidationErrorMessage> Errors { get; }
    IDictionary<string, object> Metadata { get; }
    string ErrorMessage { get; }
    void ThrowIfInvalid(string? customMessage = null);
    Task ThrowIfInvalidAsync(string? customMessage = null);
    T? GetMetadata<T>(string key)
        where T : class;
}

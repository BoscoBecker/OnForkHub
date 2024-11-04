namespace OnForkHub.Core.ValueObjects;

public class Url : ValueObject
{
    private Url() { }

    public string Value { get; private set; }

    public static Url Create(string url)
    {
        DomainException.ThrowErrorWhen(() => string.IsNullOrWhiteSpace(url.Trim()), "URL não pode ser vazia");

        var urlObj = new Url { Value = url };
        urlObj.Validate();
        return urlObj;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value.ToLower(System.Globalization.CultureInfo.CurrentCulture);
    }

    private void Validate()
    {
        DomainException.ThrowErrorWhen(() => !Uri.IsWellFormedUriString(Value, UriKind.Absolute), "URL inválida");

        var uri = new Uri(Value, UriKind.Absolute);
        DomainException.ThrowErrorWhen(
            () => uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps,
            "URL inválida"
        );
    }
}

namespace Test.Consumer.Models;

using System.Text.Json.Serialization;

public class LoginError
{
    [JsonPropertyName("@class")]
    public string? Class { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("realmId")]
    public string? RealmId { get; set; }

    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("details")]
    public Details? Details { get; set; }
}

public class Details
{
    [JsonPropertyName("auth_method")]
    public string? AuthMethod { get; set; }

    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    [JsonPropertyName("code_id")]
    public string? CodeId { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}

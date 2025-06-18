namespace App.Domain;

public class Configuration
{
    public const int DefaultStatusCode = 200;
    public const int DefaultPageNumber = 1;
    public const int DefaultPageSize = 25;

    public const string CorsPolicyName = "wasm";

    public static string ConnectionString { get; set; } = string.Empty;
    public static string FrontEndUrl { get; set; } = string.Empty;
    public static string BackEndUrl { get; set; } = string.Empty;
    public static string JwtKey { get; set; } = string.Empty;
}

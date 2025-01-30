using System.Text;

namespace White_Horse_Inc_Api.Commom.Api
{
    public class TokenConfigurations
    {
        public string IssuerSigningKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationMinutes { get; set; }

        public byte[] IssuerSigningKeyByte => Encoding.ASCII.GetBytes(IssuerSigningKey);
        public DateTime ExpiresUtcNow => DateTime.UtcNow.AddMinutes(ExpirationMinutes);
    }
}

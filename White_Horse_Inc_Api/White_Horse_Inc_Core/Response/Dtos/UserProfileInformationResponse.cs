
namespace White_Horse_Inc_Core.Response.Dtos
{
    public class UserProfileInformationResponse
    {
        public long Id { get; init; }
        public DateTime CreationDate { get; init; }

        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Rg { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}

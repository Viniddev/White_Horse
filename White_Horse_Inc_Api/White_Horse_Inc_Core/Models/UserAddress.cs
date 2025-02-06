using White_Horse_Inc_Core.Models.Base;
using White_Horse_Inc_Core.Requests.Roles;

namespace White_Horse_Inc_Core.Models
{
    public class UserAddress : BaseEntity
    {
        public string Cep { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Number { get; set; }

        public void Update(UpdateAddressRequest newAddress)
        {
            if (newAddress != null)
            {
                Cep = newAddress.Cep;
                Street = newAddress.Street;
                Neighborhood = newAddress.Neighborhood;
                City = newAddress.City;
                Number = newAddress.Number;
            }
            else
            {
                throw new ArgumentNullException(nameof(newAddress));
            }
        }
    }
}

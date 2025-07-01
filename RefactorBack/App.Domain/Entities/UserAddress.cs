
using App.Domain.Abstractions;
using App.Domain.ViewModel.Request.Address;

namespace App.Domain.Entities;

public class UserAddress : BaseEntity, IAggregateRoot
{
    public string Cep { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public int Number { get; set; }

    public UserAddress() { }

    public UserAddress(UpdateAddressRequest address)
    {
        Cep = address.Cep;
        Street = address.Street;
        Neighborhood = address.Neighborhood;
        City = address.City;
        Number = address.Number;
    }


    public UserAddress(CreateAddressRequest address)
    {
        Cep = address.Cep;
        Street = address.Street;
        Neighborhood = address.Neighborhood;
        City = address.City;
        Number = address.Number;
    }
}

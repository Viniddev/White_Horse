using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.Address;

public class UpdateAddressRequest
{
    [Required(ErrorMessage = "Id Isn't a optional parameter.")]
    public Guid Id { get; set; }

    public string Cep { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public int Number { get; set; }
}

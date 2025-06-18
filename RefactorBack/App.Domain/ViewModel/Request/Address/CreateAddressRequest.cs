using System.ComponentModel.DataAnnotations;

namespace App.Domain.ViewModel.Request.Address;

public class CreateAddressRequest
{
    [Required(ErrorMessage = "Cep é obrigatorio")]
    [MinLength(8)]
    public string Cep { get; set; } = string.Empty;

    [Required(ErrorMessage = "Rua é obrigatorio")]
    [MinLength(6)]
    public string Street { get; set; } = string.Empty;

    [Required(ErrorMessage = "Bairro é obrigatorio")]
    [MinLength(6)]
    public string Neighborhood { get; set; } = string.Empty;

    [Required(ErrorMessage = "Cidade é obrigatorio")]
    [MinLength(6)]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Número é obrigatorio")]
    public int Number { get; set; }
}

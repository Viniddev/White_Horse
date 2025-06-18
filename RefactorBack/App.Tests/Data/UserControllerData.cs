using App.Domain.ViewModel.Response.UserInfo;

namespace App.Tests.Data;

public class UserControllerData
{
    public static List<UserInformationResponse> ListaUserInformationsResponse = new()
    {
        new()
        {
            Id = Guid.NewGuid(),
            CreationDate = DateTime.UtcNow.AddDays(-10),
            Name = "João da Silva",
            Cpf = "123.456.789-00",
            Rg = "12.345.678-9",
            Email = "joao.silva@example.com",
            PhoneNumber = "(11) 98765-4321"
        },
        new()
        {
            Id = Guid.NewGuid(),
            CreationDate = DateTime.UtcNow.AddDays(-5),
            Name = "Maria Oliveira",
            Cpf = "987.654.321-00",
            Rg = "98.765.432-1",
            Email = "maria.oliveira@example.com",
            PhoneNumber = "(21) 91234-5678"
        }
    };
}

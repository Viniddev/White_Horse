
using System.Data;
using System.Xml.Linq;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Dtos;

namespace White_Horse_Inc_Core.ModelTransform
{
    public static class ModelTransform
    {
        public static UserInformationResponse TransformUserInformation(UserInformations response)
        {
            UserInformationResponse userInformations = new UserInformationResponse()
            {
                Id = response.Id,
                CreationDate = response.CreationDate,
                Cpf = response.Cpf,
                Rg = response.Rg,
                Email = response.Email,
                Name = response.Name,
                PhoneNumber = response.PhoneNumber,
                AddressResponse = AddressTransformation(response.Address),
                Role = RolesTransformation(response.CompanyRole)
            };

            return userInformations;
        }

        public static AddressResponse AddressTransformation(UserAddress address)
        {
            return new AddressResponse() 
            {
                Id = address.Id,
                CreationDate = address.CreationDate,
                Cep = address.Cep,
                City = address.City,
                Neighborhood = address.Neighborhood,
                Number = address.Number,
                Street = address.Street,
            };
        }

        public static RoleResponse RolesTransformation(CompanyRole role)
        {
            return new RoleResponse() 
            {
                Id = role.Id,
                CreationDate = role.CreationDate,
                Name = role.Name,
                Description = role.Description,
            };
        }
    }
}

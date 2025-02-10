
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Response.Dtos;

namespace White_Horse_Inc_Core.ModelTransform
{
    public static class ModelTransform
    {
        public static UserInformationResponse TransformUserInformation(UserInformations response)
        {
            return new UserInformationResponse()
            {
                Id = response.Id,
                CreationDate = response.CreationDate,
                Cpf = response.Cpf,
                Rg = response.Rg,
                Email = response.Email,
                Name = response.Name,
                PhoneNumber = response.PhoneNumber,
                AddressResponseId = response.AddressId,
                RoleId = response.CompanyRoleId
            };
        }

        public static UserProfileInformationResponse TransformUserProfileInformation(UserInformations response)
        {
            return new UserProfileInformationResponse()
            {
                Id = response.Id,
                CreationDate = response.CreationDate,
                Cpf = response.Cpf,
                Rg = response.Rg,
                Email = response.Email,
                Name = response.Name,
                PhoneNumber = response.PhoneNumber,
                Role = response.CompanyRole.Name,
                Cep = response.Address.Cep,
                City = response.Address.City,
                Neighborhood = response.Address.Neighborhood,
                Number = response.Address.Number,
                Street = response.Address.Street,
            };
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

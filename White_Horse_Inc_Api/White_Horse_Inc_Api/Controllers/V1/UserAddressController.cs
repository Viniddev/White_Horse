using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Implementations.Repository.Interfaces;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Requests;
using White_Horse_Inc_Core.Requests.Roles;
using White_Horse_Inc_Core.Response;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("V1")]
    public class UserAddressController(IUserAddressRepository userAddressRepository) : ControllerBase
    {
        /// <summary>
        /// Obtém uma lista paginada de todos os endereços dos usuários.
        /// </summary>
        /// <returns>Retorna uma lista paginada de endereços ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("GetAllAddress")]
        public async Task<IActionResult> GetAllAddressAsync(PagedRequest pagedRequest,CancellationToken cancellationToken)
        {
            try
            {
                var response = await userAddressRepository.GetAllPagedAsync(pagedRequest, cancellationToken);

                return Ok(response);
            }
            catch
            {
                return BadRequest(new PagedResponse<List<UserAddress?>>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Obtém um endereço pelo ID.
        /// </summary>
        /// <returns>Retorna o endereço correspondente ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("GetAddressById/{Id}")]
        public async Task<IActionResult> GetAddressByIdAsync([FromRoute] int Id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await userAddressRepository.GetByIdAsync(Id, cancellationToken);

                return Ok(response);
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Cria um novo endereço.
        /// </summary>
        /// <returns>Retorna o endereço criado ou uma mensagem de erro.</returns>
        [HttpPost]
        [Route("CreateAddress")]
        public async Task<IActionResult> CreateAddressAsync([FromBody] CreateAddressRequest createRequest, CancellationToken cancellationToken)
        {
            try
            {
                UserAddress newAddress = new()
                {
                    Cep = createRequest.Cep,
                    City = createRequest.City,
                    Neighborhood = createRequest.Neighborhood,
                    Street = createRequest.Street,
                    Number = createRequest.Number,
                };

                var Roles = await userAddressRepository.GetAllAsync(cancellationToken);

                if (Roles.Data?.FirstOrDefault(x => x.Cep == newAddress.Cep && x.Street == newAddress.Street && x.Number == newAddress.Number) is not null)
                {
                    return BadRequest(new BaseResponse<UserAddress?>(null, 400, "This item has already been registered in the system."));
                }

                var response = await userAddressRepository.CreateAsync(newAddress, cancellationToken);
                return Ok(response);
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Atualiza um endereço existente.
        /// </summary>
        /// <returns>Retorna o endereço atualizado ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("UpdateAddress")]
        public async Task<IActionResult> UpdateAddressAsync([FromBody] UpdateAddressRequest updateRequest, CancellationToken cancellationToken)
        {
            try
            {
                var ListRoles = await userAddressRepository.GetAllAsync(cancellationToken);
                var RoleToUpdate = ListRoles.Data?.FirstOrDefault(x => x.Id == updateRequest.Id);

                if (RoleToUpdate is not null)
                {
                    RoleToUpdate.Update(updateRequest);

                    var response = await userAddressRepository.UpdateAsync(RoleToUpdate, cancellationToken);
                    return Ok(response);
                }

                return BadRequest(new BaseResponse<UserAddress?>(null, 400, "Couldn't find any item or a bad request happened."));
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Exclui um endereço.
        /// </summary>
        /// <returns>Retorna a confirmação da exclusão ou uma mensagem de erro.</returns>
        [HttpDelete]
        [Route("DeleteAddress")]
        public async Task<IActionResult> DeleteAddressAsync([FromBody] DeleteAddressRequest deleteRequest, CancellationToken cancellationToken)
        {
            try
            {
                var ListRoles = await userAddressRepository.GetAllAsync(cancellationToken);
                var RoleToDisable = ListRoles.Data?.FirstOrDefault(x => x.Id == deleteRequest.Id);

                if (RoleToDisable is not null)
                {
                    RoleToDisable.DisableEntity();

                    var response = await userAddressRepository.UpdateAsync(RoleToDisable, cancellationToken);
                    return Ok(response);
                }

                return BadRequest(new BaseResponse<UserAddress?>(null, 400, "This item has already been registered in the system."));
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }
    }
}

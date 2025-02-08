using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Implementations.Repository.Interfaces;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.ModelTransform;
using White_Horse_Inc_Core.Requests;
using White_Horse_Inc_Core.Requests.Roles;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Dtos;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("V1")]
    public class CompanyRoleController(ICompanyRoleRepository companyRoleRepository) : ControllerBase
    {

        /// <summary>
        /// Obtém uma lista paginada de todas as roles da empresa.
        /// </summary>
        /// <returns>Retorna uma lista paginada de roles ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetAllRolesAsync(PagedRequest pagedRequest,CancellationToken cancellationToken)
        {
            try
            {
                var response = await companyRoleRepository.GetAllPagedAsync(pagedRequest, cancellationToken);

                if (response.Data is null)
                    return BadRequest("Coudn't register the user.");


                return Ok(new BaseResponse<List<RoleResponse>>
                {
                    Data = response.Data.Select(x=> ModelTransform.RolesTransformation(x)).ToList(),
                    Message = response.Message
                });
            }
            catch 
            {
                return BadRequest(new PagedResponse<List<CompanyRole?>>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Obtém uma role específica pelo ID.
        /// </summary>
        /// <returns>Retorna a role correspondente ao ID fornecido.</returns>
        [HttpPut]
        [Route("GetRolesById/{Id}")]
        public async Task<IActionResult> GetRolesByIdAsync([FromRoute] int Id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await companyRoleRepository.GetByIdAsync(Id, cancellationToken);

                if (response.Data is null)
                    return NotFound(new BaseResponse<RoleResponse?>(null, 404, "Role not found."));

                return Ok(new BaseResponse<RoleResponse>
                {
                    Data = ModelTransform.RolesTransformation(response.Data),
                    Message = response.Message
                });
            }
            catch
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Cria uma nova role.
        /// </summary>
        /// <returns>Retorna a role criada ou uma mensagem de erro.</returns>
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleRequest createRequest, CancellationToken cancellationToken)
        {
            try
            {
                CompanyRole newRole = new CompanyRole() 
                {
                    Name = createRequest.Name,
                    Description = createRequest.Description,
                };

                var Roles = await companyRoleRepository.GetAllAsync(cancellationToken);

                if (Roles.Data?.FirstOrDefault(x => x.Name == newRole.Name && x.Description == newRole.Description) is not null) 
                {
                    return BadRequest(new BaseResponse<RoleResponse?>(null, 400, "This item has already been registered in the system."));
                }

                var response = await companyRoleRepository.CreateAsync(newRole, cancellationToken);

                if (response.Data is null)
                    return NotFound(new BaseResponse<RoleResponse?>(null, 404, "Couldn't create the item."));

                return Ok(new BaseResponse<RoleResponse>
                {
                    Data = ModelTransform.RolesTransformation(response.Data),
                    Message = response.Message,
                });
            }
            catch
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Atualiza uma role existente.
        /// </summary>
        /// <returns>Retorna a role atualizada ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("UpdateRoles")]
        public async Task<IActionResult> UpdateRolesAsync([FromBody] UpdateRolesRequest updateRequest, CancellationToken cancellationToken)
        {
            try
            {
                var ListRoles = await companyRoleRepository.GetAllAsync(cancellationToken);
                var RoleToUpdate = ListRoles.Data?.FirstOrDefault(x => x.Id == updateRequest.Id);

                if (RoleToUpdate is not null)
                {
                    RoleToUpdate.Update(updateRequest);

                    var response = await companyRoleRepository.UpdateAsync(RoleToUpdate, cancellationToken);

                    if (response.Data is null)
                        return NotFound(new BaseResponse<RoleResponse?>(null, 404, "Couldn't update the item."));

                    return Ok(new BaseResponse<RoleResponse>
                    {
                        Data = ModelTransform.RolesTransformation(response.Data),
                        Message = response.Message,
                    });
                }

                return BadRequest(new BaseResponse<CompanyRole?>(null, 400, "Couldn't find any item or a bad request happened."));
            }
            catch
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Exclui uma role pelo ID.
        /// </summary>
        /// <returns>Retorna a role desativada ou uma mensagem de erro.</returns>
        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRoleAsync([FromBody] DeleteAddressRequest deleteRequest, CancellationToken cancellationToken)
        {
            try
            {
                var ListRoles = await companyRoleRepository.GetAllAsync(cancellationToken);
                var RoleToDisable = ListRoles.Data?.FirstOrDefault(x => x.Id == deleteRequest.Id);

                if (RoleToDisable is not null)
                {
                    RoleToDisable.DisableEntity();

                    var response = await companyRoleRepository.UpdateAsync(RoleToDisable, cancellationToken);

                    if (response.Data is null)
                        return NotFound(new BaseResponse<RoleResponse?>(null, 404, "Couldn't create the item."));

                    return Ok(new BaseResponse<RoleResponse>
                    {
                        Data = ModelTransform.RolesTransformation(response.Data),
                        Message = response.Message,
                    });
                }

                return BadRequest(new BaseResponse<CompanyRole?>(null, 400, "This item has already been registered in the system."));
            }
            catch
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }
    }
}

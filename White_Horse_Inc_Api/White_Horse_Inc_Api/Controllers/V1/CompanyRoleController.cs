using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Implementations.Interfaces;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.Requests;
using White_Horse_Inc_Core.Requests.Roles;
using White_Horse_Inc_Core.Response;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [ApiController]
    [Route("V1")]
    public class CompanyRoleController(ICompanyRoleRepository companyRoleRepository) : ControllerBase
    {
        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllRolesAsync(PagedRequest pagedRequest,CancellationToken cancellationToken)
        {
            try
            {
                var response = await companyRoleRepository.GetAllPagedAsync(pagedRequest, cancellationToken);

                return Ok(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(new PagedResponse<List<CompanyRole?>>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        [HttpPut]
        [Route("GetById/{Id}")]
        public async Task<IActionResult> GetRolesByIdAsync([FromRoute] int Id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await companyRoleRepository.GetByIdAsync(Id, cancellationToken);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRolesRequest createRequest, CancellationToken cancellationToken)
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
                    return BadRequest(new BaseResponse<CompanyRole?>(null, 400, "This item has already been registered in the system."));
                }

                var response = await companyRoleRepository.CreateAsync(newRole, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

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
                    RoleToUpdate.Name = updateRequest.Name;
                    RoleToUpdate.Description = updateRequest.Description;

                    var response = await companyRoleRepository.UpdateAsync(RoleToUpdate, cancellationToken);
                    return Ok(response);
                }

                return BadRequest(new BaseResponse<CompanyRole?>(null, 400, "Couldn't find any item or a bad request happened."));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<IActionResult> DeleteRoleAsync([FromBody] DeleteRoleRequest updateRequest, CancellationToken cancellationToken)
        {
            try
            {
                var ListRoles = await companyRoleRepository.GetAllAsync(cancellationToken);
                var RoleToDisable = ListRoles.Data?.FirstOrDefault(x => x.Id == updateRequest.Id);

                if (RoleToDisable is not null)
                {
                    RoleToDisable.DisableEntity();

                    var response = await companyRoleRepository.UpdateAsync(RoleToDisable, cancellationToken);
                    return Ok(response);
                }

                return BadRequest(new BaseResponse<CompanyRole?>(null, 400, "This item has already been registered in the system."));
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponse<CompanyRole?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }
    }
}

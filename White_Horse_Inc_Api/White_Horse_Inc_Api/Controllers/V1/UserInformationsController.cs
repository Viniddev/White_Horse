using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Implementations.Repository.Interfaces;
using White_Horse_Inc_Core.Models;
using White_Horse_Inc_Core.ModelTransform;
using White_Horse_Inc_Core.Requests;
using White_Horse_Inc_Core.Requests.UserInformations;
using White_Horse_Inc_Core.Response;
using White_Horse_Inc_Core.Response.Dtos;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [Authorize]
    [ApiController]
    [Route("V1")]
    public class UserInformationsController(IUserInformationsRepository userInformationsRepository) : ControllerBase
    {
        /// <summary>
        /// Obtém todos os usuários do sistema.
        /// </summary>
        /// <returns>Retorna uma lista paginada ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsersAsync(PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            try
            {
                var response = await userInformationsRepository.GetAllPagedAsync(pagedRequest, cancellationToken);

                if (response.Data is null)
                    return BadRequest("Coudn't find any user.");

                return Ok(new BaseResponse<List<UserInformationResponse>>
                {
                    Data = response.Data.Select(x => ModelTransform.TransformUserInformation(x)).ToList(),
                    Message = response.Message
                });
            }
            catch
            {
                return BadRequest(new PagedResponse<List<UserAddress?>>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <returns>Retorna o usuário correspondente ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("GetUserById/{Id}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] int Id, CancellationToken cancellationToken)
        {
            try
            {
                var response = await userInformationsRepository.GetByIdAsync(Id, cancellationToken);

                if (response.Data is null)
                    return BadRequest("Coudn't find the user.");

                return Ok(new BaseResponse<UserInformationResponse>
                {
                    Data = ModelTransform.TransformUserInformation(response.Data),
                    Message = response.Message
                });
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Atualiza um usuário.
        /// </summary>
        /// <returns>Retorna o usuário atualizado ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserInformations updateRequest, CancellationToken cancellationToken)
        {
            try
            {
                var ListUsers = await userInformationsRepository.GetAllAsync(cancellationToken);
                var UserToUpdate = ListUsers.Data?.FirstOrDefault(x => x.Id == updateRequest.Id);

                if (UserToUpdate is not null)
                {
                    UserToUpdate.Update(updateRequest);

                    var response = await userInformationsRepository.UpdateAsync(UserToUpdate, cancellationToken);

                    if (response.Data is null)
                        return BadRequest("Coudn't update the user.");

                    return Ok(new BaseResponse<UserInformationResponse>
                    {
                        Data = ModelTransform.TransformUserInformation(response.Data),
                        Message = response.Message
                    });
                }

                return BadRequest(new BaseResponse<UserAddress?>(null, 400, "Couldn't find any item or a bad request happened."));
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Exclui um usuário.
        /// </summary>
        /// <returns>Retorna a confirmação da exclusão ou uma mensagem de erro.</returns>
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUserAsync([FromBody] DeleteUserRequest deleteRequest, CancellationToken cancellationToken)
        {
            try
            {
                var ListUsers = await userInformationsRepository.GetAllAsync(cancellationToken);
                var UserToDisable = ListUsers.Data?.FirstOrDefault(x => x.Id == deleteRequest.Id);

                if (UserToDisable is not null)
                {
                    UserToDisable.DisableEntity();

                    var response = await userInformationsRepository.UpdateAsync(UserToDisable, cancellationToken);

                    if (response.Data is null)
                        return BadRequest("Coudn't delete the user.");

                    return Ok(new BaseResponse<UserInformationResponse>
                    {
                        Data = ModelTransform.TransformUserInformation(response.Data),
                        Message = response.Message
                    });
                }

                return BadRequest(new BaseResponse<UserAddress?>(null, 400, "This item has already been registered in the system."));
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }

        /// <summary>
        /// Obtém um usuário pelo ID.
        /// </summary>
        /// <returns>Retorna o usuário correspondente ou uma mensagem de erro.</returns>
        [HttpPut]
        [Route("GetUserProfileInformations")]
        public async Task<IActionResult> GetUserProfileInformations(GetUserProfileInformations UserEmail, CancellationToken cancellationToken)
        {
            try
            {
                var response = await userInformationsRepository.GetAllAsync(cancellationToken);

                if (response.Data is null)
                    return BadRequest("Coudn't find this user.");

                var UserProfileInformations = response.Data.FirstOrDefault(x=>x.Email == UserEmail.Email);

                if (UserProfileInformations is null)
                    return BadRequest("Coudn't find this user.");

                return Ok(new BaseResponse<UserProfileInformationResponse>
                {
                    Data = ModelTransform.TransformUserProfileInformation(UserProfileInformations),
                    Message = response.Message
                });
            }
            catch
            {
                return BadRequest(new BaseResponse<UserAddress?>(null, 500, "Couldn't find any item or a bad request happened."));
            }
        }
    }
}

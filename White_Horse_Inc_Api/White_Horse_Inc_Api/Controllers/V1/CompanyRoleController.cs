using Microsoft.AspNetCore.Mvc;
using White_Horse_Inc_Api.Implementations.Interfaces;

namespace White_Horse_Inc_Api.Controllers.V1
{
    [ApiController]
    [Route("V1")]
    public class CompanyRoleController(ILogger<CompanyRoleController> logger, ICompanyRoleRepository companyRoleRepository) : ControllerBase
    {
        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllRolesAsync(CancellationToken cancellationToken)
            => Ok(await companyRoleRepository.GetAsync(cancellationToken));
    }
}

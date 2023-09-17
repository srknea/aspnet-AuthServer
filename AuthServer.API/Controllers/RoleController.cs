using AuthServer.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : CustomBaseController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("[action]/{userName}")]
        public async Task<IActionResult> CreateUserRoles(string userName)
        {
            return ActionResultInstance(await _roleService.CreateUserRoles(userName));
        }
    }
}
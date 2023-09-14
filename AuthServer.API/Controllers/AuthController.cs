using AuthServer.Core.DTOs;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Mvc;
using UdemyAuthServer.API.Controllers;

namespace AuthServer.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AuthController(ICustomAuthenticationService customAuthenticationService)
        {
            _customAuthenticationService = customAuthenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _customAuthenticationService.CreateTokenAsync(loginDto);

            /*
            if (result.StatusCode == 200)
            {
                return Ok();
            }
            else if(result.StatusCode == 404)
            {
                return NotFound();
            }
            */

            return ActionResultInstance(result);
        }

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var result = _customAuthenticationService.CreateTokenByClient(clientLoginDto);

            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var result = await _customAuthenticationService.RevokeRefreshToken(refreshTokenDto.RefreshToken);

            return ActionResultInstance(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)

        {
            var result = await _customAuthenticationService.CreateTokenByRefreshToken(refreshTokenDto.RefreshToken);

            return ActionResultInstance(result);
        }
    }
}
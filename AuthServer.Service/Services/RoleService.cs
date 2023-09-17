using AuthServer.Core.Model;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;

namespace AuthServer.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<UserRole> _roleManager;
        private readonly UserManager<UserApp> _userManager;

        public RoleService(RoleManager<UserRole> roleManager, UserManager<UserApp> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<Response<NoDataDto>> CreateUserRoles(string userName)
        {

            if (!await _roleManager.RoleExistsAsync("admin"))
            {
                // admin ve manager rolünü oluşturma
                await _roleManager.CreateAsync(new UserRole { Name = "admin" });
            }

            if (!await _roleManager.RoleExistsAsync("manager"))
            {
                // manager rolünü oluşturma
                await _roleManager.CreateAsync(new UserRole { Name = "manager" });
            }

            // İlgili kullanıcıya admin ve manager rolünü ekleme
            var user = await _userManager.FindByNameAsync(userName); // Kullanıcıyı bul
            await _userManager.AddToRoleAsync(user, "admin"); 
            await _userManager.AddToRoleAsync(user, "manager");

            return Response<NoDataDto>.Success(StatusCodes.Status201Created);
        }
    }
}
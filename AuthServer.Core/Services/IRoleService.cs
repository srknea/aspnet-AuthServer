using SharedLibrary.Dtos;

namespace AuthServer.Core.Services
{
    public interface IRoleService
    {
        Task<Response<NoDataDto>> CreateUserRoles(string userName);
    }
}
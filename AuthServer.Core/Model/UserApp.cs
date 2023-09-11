using Microsoft.AspNetCore.Identity;

namespace AuthServer.Core.Model
{
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
    }
}

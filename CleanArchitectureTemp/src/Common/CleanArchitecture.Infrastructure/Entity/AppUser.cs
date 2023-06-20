using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Entity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }

    public class UserLogin : IdentityUserLogin<int> { }
    public class UserRole : IdentityUserRole<int>
    {

    }
    public class UserClaim : IdentityUserClaim<int> { }
    public class Role : IdentityRole<int>
    {
    }
    public class RoleClaim : IdentityRoleClaim<int> { }
    public class UserToken : IdentityUserToken<int> { }
}

using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Models
{
    public sealed class UsersConfrim:IdentityUser<Guid>
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}

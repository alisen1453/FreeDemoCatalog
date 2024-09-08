using IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer.DataAccess
{
    public class UserDbContex : IdentityDbContext<UsersConfrim, IdentityRole<Guid>, Guid>
    {
        public UserDbContex(DbContextOptions options) : base(options)
        {
        }
    }
}

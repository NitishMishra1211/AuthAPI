using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static AuthAPI.Models.ApplicationDbContext;

namespace AuthAPI.Models
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                    
        }
        public class ApplicationUser:IdentityUser
        {

        }
    }
}

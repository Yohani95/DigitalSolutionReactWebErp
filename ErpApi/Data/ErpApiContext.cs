using ErpApi.Models.User;
using Microsoft.EntityFrameworkCore;
using Models.User;

namespace ErpApi.Data
{
    public class ErpApiContext : DbContext
    {
        public ErpApiContext (DbContextOptions<ErpApiContext> options)
            : base(options)
        {
        }
        public DbSet<UserModels> usuarios { get; set; }
        public DbSet<RolesModels> roles { get; set; }
    }
}

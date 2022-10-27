using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public DbSet<Models.User.UserModels> UserModels { get; set; }
    }
}

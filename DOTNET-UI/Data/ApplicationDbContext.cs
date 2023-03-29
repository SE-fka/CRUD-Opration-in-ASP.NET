using DOTNET_UI.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_UI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opttions) : base(opttions)
        {
        }

        public DbSet<UsersModel> Users { get; set; }
    }
}

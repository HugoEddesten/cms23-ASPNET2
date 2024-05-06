using AddressProvider.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddressProvider.Contexts
{
    public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
    {
        public DbSet<AddressEntity> Addresses { get; set; }
    }
}

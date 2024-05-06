using AccountProvider.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountProvider.Contexts;

public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
{
    public DbSet<AccountEntity> Accounts { get; set; }
}

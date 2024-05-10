using AccountProviderFunction.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountProviderFunction.Data.contexts;

public class Context(DbContextOptions<Context> options) : DbContext(options)
{
    public DbSet<AccountEntity> Accounts { get; set; }
}

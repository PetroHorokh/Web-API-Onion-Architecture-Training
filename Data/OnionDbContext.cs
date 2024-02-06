using Core.Models;
using Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class OnionDbContext(DbContextOptions<OnionDbContext> options) : DbContext(options)
{
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Account> Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new AccountConfiguration());

        builder
            .ApplyConfiguration(new OwnerConfiguration());
    }
}
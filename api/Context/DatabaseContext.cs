using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) 
    : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
}
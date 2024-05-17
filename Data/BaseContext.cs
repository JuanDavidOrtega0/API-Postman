using Microsoft.EntityFrameworkCore;
using PostmanAPI.Models;

namespace PostmanAPI.Data;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}
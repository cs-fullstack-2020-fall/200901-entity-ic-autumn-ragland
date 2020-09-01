using Microsoft.EntityFrameworkCore;
using Practice.Models;
namespace Practice.DOA
{
    public class GamerDbContext : DbContext
    {
        public GamerDbContext(DbContextOptions<GamerDbContext> options) : base(options)
        {
        }
        public DbSet<GamerModel> gamers{get;set;}
    }
}
using Microsoft.EntityFrameworkCore;
using IvScrumApi.Models;
namespace IvScrumApi
{
    public class DatabaseContext : DbContext
    {               
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {                             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)  
        {                             
            modelBuilder.Entity<Branch>().ToTable("branches"); 
            modelBuilder.Entity<Team>().ToTable("teams"); 
            modelBuilder.Entity<User>().ToTable("users");            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
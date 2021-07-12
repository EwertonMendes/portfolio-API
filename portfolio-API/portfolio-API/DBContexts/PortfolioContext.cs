using Microsoft.EntityFrameworkCore;
using portfolio_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio_API.DBContexts
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Skill>().ToTable("Skill");

            // Configure Primary Keys  
            modelBuilder.Entity<Project>().HasKey(p => p.Id);
            modelBuilder.Entity<Skill>().HasKey(s => s.Id);

            // Configure columns  
            modelBuilder.Entity<Project>().Property(p => p.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.Name).HasColumnType("nvarchar(45)").IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.Description).HasColumnType("nvarchar(1000)").IsRequired();
            modelBuilder.Entity<Project>().Property(p => p.ImageURL).HasColumnType("nvarchar(300)").IsRequired(false);
            modelBuilder.Entity<Project>().Property(p => p.RepoURL).HasColumnType("nvarchar(300)").IsRequired(false);

            modelBuilder.Entity<Skill>().Property(s => s.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Skill>().Property(s => s.Name).HasColumnType("nvarchar(45)").IsRequired();
            modelBuilder.Entity<Skill>().Property(s => s.Description).HasColumnType("nvarchar(300)").IsRequired();
            modelBuilder.Entity<Skill>().Property(s => s.Level).HasColumnType("int").IsRequired();
        }
    }
}

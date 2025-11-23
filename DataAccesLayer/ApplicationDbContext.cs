using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { ID_Project = 1, ProjectName = ".Net Core Application", ID_Manager = 1, StartDate = new DateTime(2025, 1, 1), EndDate = null }
            );

            modelBuilder.Entity<Manager>().HasData(
                new Manager { ID_Manager = 1, ManagerName = "John Doe", Active = 1 }
            );
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Manager> Managers { get; set; }

    }
}

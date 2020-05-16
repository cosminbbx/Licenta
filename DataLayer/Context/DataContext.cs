using System;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<EventService> EventServices { get; set; }
        public DbSet<ServicePackage> ServicePackages { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ContainerName> ContainerNames { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=DigitalEventPlanner;User Id=SA;Password=dockersql123;");
        }
    }
}

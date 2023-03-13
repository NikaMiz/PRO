using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ХранительПРО.Domain;

namespace Persistence.Context
{
    public class mainContext : DbContext
    {
        public mainContext()
        {

        }

        public mainContext(DbContextOptions<mainContext> options)
            :base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<GroupVisiting> GroupVisitings { get; set; }
        public DbSet<InfoGroup> InfoGroups { get; set; }
        public DbSet<PersonVisiting> PersonVisitings { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=AUD2204-01;Initial Catalog=maindb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupVisitingConfiguration());
            modelBuilder.ApplyConfiguration(new PersonalVisitingConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());    
            base.OnModelCreating(modelBuilder);
        }
    }
}

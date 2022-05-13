using Microsoft.EntityFrameworkCore;
using StepByStep.Infrastructure.DataAccess.Entities;
using StepByStep.Infrastructure.DataAccess.Map;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepByStep.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Environment.GetEnvironmentVariable("CONN") != null)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONN"), npgsqlOptionsAction: options =>
                {
                    options.EnableRetryOnFailure(2, TimeSpan.FromSeconds(5), new List<string>());
                    options.MigrationsHistoryTable("_MigrationHistory", "public");
                });
            }
            else
            {
                optionsBuilder.UseInMemoryDatabase("CustomerInMemory");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new AdressMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}

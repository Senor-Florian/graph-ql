using CrmGraphQL.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CrmGraphQL.Persistence
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext(DbContextOptions<CrmDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Project> Project { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client 
                { 
                    Id = new Guid("BF3B5794-3472-4AE9-BE68-1EA5607C4FD0"),
                    Name = "Adware",
                    Created = new DateTime(2020,01,01),
                    SalesRepresentativeId = new Guid("0643D282-7536-48B3-9760-5D25F5892D46")
                },
                new Client 
                {
                    Id = new Guid("C3480386-76D6-4A1F-99AC-7D785BE8C9F7"),
                    Name = "PC Trade",
                    Created = new DateTime(2020, 06, 20)
                },
                new Client
                {
                    Id = new Guid("BA3210F6-CE49-47CA-BC7C-8DF4624D96AE"),
                    Name = "Békéscsabai konzervgyár",
                    Created = new DateTime(2021, 04, 01)
                }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project 
                {
                    Id = Guid.NewGuid(),
                    Name = "Projekt 1",
                    ClientId = new Guid("BF3B5794-3472-4AE9-BE68-1EA5607C4FD0"),
                    SalesRepresentativeId = new Guid("0643D282-7536-48B3-9760-5D25F5892D46") 
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Projekt 2",
                    ClientId = new Guid("BF3B5794-3472-4AE9-BE68-1EA5607C4FD0"),
                    SalesRepresentativeId = new Guid("B6400132-4488-4248-A10B-239FB9D20CE0")
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Projekt 3",
                    ClientId = new Guid("BA3210F6-CE49-47CA-BC7C-8DF4624D96AE"),
                    SalesRepresentativeId = new Guid("B6400132-4488-4248-A10B-239FB9D20CE0")
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User 
                { 
                    Id = new Guid("0643D282-7536-48B3-9760-5D25F5892D46"),
                    Name = "Béla", 
                    Email = "bela@pctrade.hu" 
                },
                new User
                {
                    Id = new Guid("B6400132-4488-4248-A10B-239FB9D20CE0"),
                    Name = "Gábor",
                    Email = "gabor@pctrade.hu"
                }
            );
        }
    }
}

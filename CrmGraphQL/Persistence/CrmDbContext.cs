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
        public DbSet<User> User { get; set; }
        public DbSet<ModuleSetting> ModuleSettings { get; set; }

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
                    Id = new Guid("198F9ABE-DA54-4E05-8C26-839A1E9C31DE"),
                    Name = "Projekt 1",
                    ClientId = new Guid("BF3B5794-3472-4AE9-BE68-1EA5607C4FD0"),
                    SalesRepresentativeId = new Guid("0643D282-7536-48B3-9760-5D25F5892D46") ,
                    ExternalId = "EXT-001",
                    InternalId = "PCT-001"
                },
                new Project
                {
                    Id = new Guid("CC923BD0-A9A9-4D68-9918-34AA2C574BF1"),
                    Name = "Projekt 2",
                    ClientId = new Guid("BF3B5794-3472-4AE9-BE68-1EA5607C4FD0"),
                    SalesRepresentativeId = new Guid("B6400132-4488-4248-A10B-239FB9D20CE0"),
                    InternalId = "PCT-002"
                },
                new Project
                {
                    Id = new Guid("C680345D-B9FF-487A-ACD0-8DA854F2B362"),
                    Name = "Projekt 3",
                    ClientId = new Guid("BA3210F6-CE49-47CA-BC7C-8DF4624D96AE"),
                    SalesRepresentativeId = new Guid("B6400132-4488-4248-A10B-239FB9D20CE0"),
                    ExternalId = "EXT-003",
                    InternalId = "PCT-003"
                },
                new Project
                {
                    Id = new Guid("C62047B9-4B1A-4064-BFE5-C08746C61E80"),
                    Name = "Projekt 4",
                    ClientId = new Guid("BA3210F6-CE49-47CA-BC7C-8DF4624D96AE"),
                    SalesRepresentativeId = new Guid("0E265B92-FA49-42B8-AC0B-54E59A6F45A6"),
                    InternalId = "PCT-004"
                },         
                new Project
                {
                    Id = new Guid("6586F2BC-14C3-496D-A278-E38D96F76246"),
                    Name = "Projekt 5",
                    ClientId = new Guid("C3480386-76D6-4A1F-99AC-7D785BE8C9F7"),
                    SalesRepresentativeId = new Guid("0E265B92-FA49-42B8-AC0B-54E59A6F45A6"),
                    ExternalId = "EXT-005",
                    InternalId = "PCT-005"
                },                
                new Project
                {
                    Id = new Guid("A26FAA36-AA7A-4DFD-B81A-9C63087B6AAA"),
                    Name = "Projekt 6",
                    ClientId = new Guid("C3480386-76D6-4A1F-99AC-7D785BE8C9F7"),
                    SalesRepresentativeId = new Guid("0643D282-7536-48B3-9760-5D25F5892D46"),
                    ExternalId = "EXT-006",
                    InternalId = "PCT-006"
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
                }, 
                new User
                {
                    Id = new Guid("0E265B92-FA49-42B8-AC0B-54E59A6F45A6"),
                    Name = "Péter",
                    Email = "peter@pctrade.hu"
                }
            );

            modelBuilder.Entity<ModuleSetting>().HasData(
                new ModuleSetting
                {
                    Id = Guid.NewGuid(),
                    ShowProjectInternalId = true,
                    CanSalesRepresentativeEditProjectExternalId = true
                }
            );
        }
    }
}

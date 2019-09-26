using Microsoft.EntityFrameworkCore;
using SQLDocker.Data.Entities;
using System;
using System.Linq;

namespace SQLDocker.Data
{
    public class OMGContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("SuperSecretConnectionString");

#if DEBUG
            connectionString = "Server=sqldemo;Database=OMGData;User Id=sa;Password=DOTnetConf2019!";
#endif

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(pk => pk.Id)
                        .HasName("PK_Clients");

                entity.HasMany(m => m.Addresses)
                        .WithOne(o => o.Client)
                        .HasForeignKey(fk => fk.ClientId)
                        .HasConstraintName("FK_Client_Addresses");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(pk => pk.Id)
                        .HasName("PK_Addresses");
            });
        }

        public void SeedDatabase()
        {
            if (Clients.Count() > 0)
            {
                return;
            }

            Address address1 = new Address() { City = "Birmingham", StreetAddress = "123 My street", PostalCode = "11111", CreatedOn = DateTime.Now, Id = new Guid() };

            Client client1 = new Client() { Name = "ACME Corp", Id = new Guid(), CreatedOn = DateTime.Now };

            client1.Addresses.Add(address1);
            Clients.Add(client1);
            SaveChanges();
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
    }
}

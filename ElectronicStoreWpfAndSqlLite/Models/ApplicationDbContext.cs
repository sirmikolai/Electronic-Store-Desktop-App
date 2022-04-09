using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStoreWpfAndSqlLite.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(x => x.IdProduct);
                e.HasIndex(x => x.IdProduct);
                e.Property(y => y.IdProduct).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Client>(e =>
            {
                e.HasKey(x => x.IdClient);
                e.HasIndex(x => x.IdClient);
                e.Property(y => y.IdClient).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Transaction>(e =>
            {
                e.HasKey(x => x.IdTransaction);
                e.Property(y => y.IdTransaction).ValueGeneratedOnAdd();
                e.HasIndex(x => x.ProductId);
                e.HasOne(d => d.Product)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ProductId);
                e.HasIndex(x => x.ClientId);
                e.HasOne(d => d.Client)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ClientId);
            });
            base.OnModelCreating(modelBuilder);
        }

        private Product[] GetProducts()
        {
            return new Product[]
            {
                new Product { IdProduct = 1, TypeOfProduct = "Smartfon", Producer = "Apple", Model = "iPhone 13 Pro", YearOfProduction = 2022, Quantity = 10, Price = 5600.00M },
                new Product { IdProduct = 2, TypeOfProduct = "Smartfon", Producer = "Samsung", Model = "M31s", YearOfProduction = 2020, Quantity = 10, Price = 1200.00M },
            };
        }

        private Client[] GetClients()
        {
            return new Client[]
            {
                new Client { IdClient = 1, FirstName = "Mateusz", LastName = "Buzianocnik", Address = "ul. Polna 12a, 42-200 Częstochowa"},
                new Client { IdClient = 1, FirstName = "Karolina", LastName = "Kowalska", Address = "ul. Zbrodniarzy 666, 42-200 Częstochowa"},
            };
        }

        private Transaction[] GetTransactions()
        {
            return new Transaction[]
            {
                new Transaction { IdTransaction = 1, ProductId = 1, ClientId = 1, QuantityOfTransaction = 2, DateOfTransaction = System.DateTime.Now, PriceOfTransaction = 11000.00M},
            };
        }
    }
}

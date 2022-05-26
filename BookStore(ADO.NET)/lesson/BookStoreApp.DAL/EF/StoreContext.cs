using BookStoreApp.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreApp.DAL.EF
{
    public class StoreContext : DbContext
    {
        private string connectionString = string.Empty;
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public StoreContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(p => p.Login).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Account>().Property(p => p.Password).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.NameBoook).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.NameIzdat).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.Genre).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<Book>().Property(p => p.FIOAuthor).HasMaxLength(50).IsRequired();
        }
    }
}

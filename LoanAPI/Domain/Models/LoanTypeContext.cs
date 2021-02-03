using System;
using LoanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.Domain.Models
{
    public class LoanTypeContext : DbContext
    {
        public LoanTypeContext(DbContextOptions<LoanTypeContext> options) : base(options)
        {
        }

        public DbSet<LoanType> LoanTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanType>().HasData(
                new LoanType { Id = 1, Type = "housing", Interest = 5 },
                new LoanType { Id = 2, Type = "spending", Interest = 12.7 });
        }
    }
}

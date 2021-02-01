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
                new LoanType { id = 1, type = "housing", interest = 5 },
                new LoanType { id = 2, type = "spending", interest = 12.7 });
        }
    }
}

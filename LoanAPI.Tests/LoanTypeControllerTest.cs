using System;
using LoanAPI.Domain.Models;
using LoanAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanAPI.Tests
{
    public class LoanTypeControllerTest
    {
        public LoanTypeControllerTest(DbContextOptions<LoanTypeContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<LoanTypeContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new LoanTypeContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.SaveChanges();
            }
        }
    }
}

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

                var one = new LoanType
                {
                    Type = "housing",
                    Interest = 3.5

                };

                var two = new LoanType
                {
                    Type = "spending",
                    Interest = 12.7

                };

                var three = new LoanType
                {
                    Type = "car",
                    Interest = 5.9

                };

                context.AddRange(one, two, three);

                context.SaveChanges();
            }
        }
    }
}

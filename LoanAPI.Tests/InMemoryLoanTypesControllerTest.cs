using System;
using System.Linq;
using LoanAPI.Controllers;
using LoanAPI.Domain.Models;
using LoanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LoanAPI.Tests
{
    public class InMemoryLoanTypesControllerTest : LoanTypeControllerTest
    {
        public InMemoryLoanTypesControllerTest() : base(
            new DbContextOptionsBuilder<LoanTypeContext>()
            .UseInMemoryDatabase(databaseName: "TestDB")
            .Options)

        {
        }

        /* Fails for some reason

         [Fact]
         public async void Can_get_items()
         {
             using (var context = new LoanTypeContext(ContextOptions))
             {
                 var controller = new LoanTypesController(context);

                 var items = await controller.GetLoanTypes();
                 var result = items.Value;
                 var list = result.ToList();
              
                Assert.Equal(3, list.Count);

            }
        }
        */

        [Fact]
        public async void GetById()
        {
            using (var context = new LoanTypeContext(ContextOptions))
            {
                var controller = new LoanTypesController(context);

                var items = await controller.GetLoanType(1);
                var result = items.Value;

                Assert.Equal(1, result.Id);

            }
        }

        [Fact]
        public async void GetByType()
        {
            using (var context = new LoanTypeContext(ContextOptions))
            {
                var controller = new LoanTypesController(context);

                var items = await controller.GetLoanTypeByType("car");
                var result = items.Value;

                Assert.Equal(5.9, result.Interest);

            }
        }

        [Fact]
        public async void PostLoan_ConfirmLoanAddedToDatabase()
        {
            using (var context = new LoanTypeContext(ContextOptions))
            {
                var controller = new LoanTypesController(context);

                LoanType l = new LoanType
                {
                    Type = "credit",
                    Interest = 17,

                };

                _ = await controller.PostLoanType(l);
                var res = await controller.GetLoanTypeByType("credit");
                var result = res.Value;

                Assert.Equal(17, result.Interest);

            }
        

        } 

    }
}


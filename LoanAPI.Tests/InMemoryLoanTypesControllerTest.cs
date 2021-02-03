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

    

         [Fact]
         public async void GetAll()
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
        public async void GetById_UnknownID_Returns404()
        {
            using (var context = new LoanTypeContext(ContextOptions))
            {
                var controller = new LoanTypesController(context);

                var item = await controller.GetLoanType(50);
                var result = item.Value;

                Assert.IsType<NotFoundResult>(item.Result);

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

                Assert.Equal(6, result.Interest);

            }
        }

        [Fact]
        public async void PostLoan_ReturnsLoanType()
        {
            using (var context = new LoanTypeContext(ContextOptions))
            {
                var controller = new LoanTypesController(context);

                LoanType l = new LoanType
                {
                    Type = "credit",
                    Interest = 17,

                };

                var res = await controller.PostLoanType(l);
                var createdRes = Assert.IsType<CreatedAtActionResult>(res.Result);
                var result = Assert.IsType<LoanType>(createdRes.Value);

                Assert.Equal("credit", result.Type);

            }


        }

    }
}


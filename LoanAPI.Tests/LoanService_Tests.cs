using System;
using System.Collections.Generic;
using LoanAPI.Controllers;
using LoanAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace LoanAPI.Tests
{
    public class LoanService_Tests
    {

        private readonly LoanTypeController _loanTypeController;
        private Mock<List<LoanType>> _mockLoanTypes;

        public LoanService_Tests()
        {
            _mockLoanTypes = new Mock<List<LoanType>>();
            _loanTypeController = new LoanTypeController(_mockLoanTypes.Object);
        }

        [Fact]
        public void GetTest_ReturnsListofLoanTypes()
        {
            //arrange
            var mockLoanTypes = new List<LoanType> {
                new LoanType{type = "Housing", interest = 3.5},
                new LoanType{type = "Spending", interest = 12}
            };

            _mockLoanTypes.Object.AddRange(mockLoanTypes);

            //act
            var result = _loanTypeController.Get();

            //assert
            _ = Assert.IsAssignableFrom<ActionResult<List<LoanType>>>(result);
            //Assert.Equal(2, model.Value.Count);
        }
    }
}

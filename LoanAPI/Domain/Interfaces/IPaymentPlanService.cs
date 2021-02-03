using System;
using System.Collections.Generic;
using LoanAPI.Domain.Models;

namespace LoanAPI.Domain.Interfaces
{
    public interface IPaymentPlanService
    {
        List<Term> CalculateSeriesLoan(double interest, int amount, int years);
    }
}

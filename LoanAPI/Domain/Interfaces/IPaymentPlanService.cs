using System;
using System.Collections.Generic;

namespace LoanAPI.Domain.Interfaces
{
    public interface IPaymentPlanService
    {
        List<double> CalculateSeriesLoan(double interest, int amount, int years);
    }
}

using System;
using System.Collections.Generic;
using LoanAPI.Domain.Interfaces;
using LoanAPI.Domain.Models;

namespace LoanAPI.Domain.Services
{
    public class PaymentPlanService : IPaymentPlanService
    {
        public List<Term> CalculateSeriesLoan(double interest, int amount, int years)
        {
			List<Term> paymentPlan = new List<Term>();
			double amountLeft = amount;
			int terms = years * 12;
			int monthsLeft = terms;
			double interestPercent = interest / 100;
			double installment = amount / terms;

			for (int i = 0; i < monthsLeft; i++)
			{
				double amountInterest = amountLeft * (interestPercent / 12);
				double payment = amountInterest + installment;

                Term term = new Term
				{
					Id = i + 1,
					Amount = Math.Round(payment, MidpointRounding.AwayFromZero),
					Installment = Math.Round(installment, MidpointRounding.AwayFromZero),
					Interest = Math.Round(amountInterest, MidpointRounding.AwayFromZero)


				};

                paymentPlan.Add(term);

				amountLeft -= installment;
			}

			return paymentPlan;
		}
    }
}

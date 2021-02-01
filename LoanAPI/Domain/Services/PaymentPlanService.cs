using System;
using System.Collections.Generic;
using LoanAPI.Domain.Interfaces;

namespace LoanAPI.Domain.Services
{
    public class PaymentPlanService : IPaymentPlanService
    {
        public List<double> CalculateSeriesLoan(double interest, int amount, int years)
        {
			List<double> paymentPlan = new List<double>();
			double amountLeft = amount;
			int terminer = years * 12;
			int monthsLeft = terminer;
			double interestPercent = interest / 100;
			double avdrag = amount / terminer;

			for (int i = 0; i < monthsLeft; i++)
			{
				double renter = amountLeft * (interestPercent / 12);
				double payment = renter + avdrag;

				paymentPlan.Add(Math.Round(payment, MidpointRounding.AwayFromZero));

				amountLeft -= avdrag;
			}

			return paymentPlan;
		}
    }
}

using System;
namespace LoanAPI.Domain.Models
{
    public class Term
    {

        public long Id { get; set; }
        public double Amount { get; set; }
        public double Installment { get; set; }
        public double Interest { get; set; }

        public Term()
        {
        }
    }
}

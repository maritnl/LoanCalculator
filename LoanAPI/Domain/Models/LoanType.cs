using System;
namespace LoanAPI.Models
{
    public class LoanType
    {
        public long id { get; set; }
        public String type { get; set; }
        public Double interest { get; set; }

        public LoanType()
        {
        }
    }
}

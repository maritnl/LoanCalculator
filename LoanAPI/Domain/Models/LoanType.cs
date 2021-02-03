using System;
using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Models
{
    public class LoanType
    {
        public long Id { get; set; }

        [Required]
        [StringLength(30)]
        public String Type { get; set; }

        [Required]
        [Range(0, 100)]
        public Double Interest { get; set; }

        public LoanType()
        {
        }
    }
}
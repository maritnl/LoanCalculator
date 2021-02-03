using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Domain.Models;
using LoanAPI.Models;
using LoanAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Cors;

namespace LoanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanTypesController : ControllerBase
    {
        private readonly LoanTypeContext _context;

        public LoanTypesController(LoanTypeContext context)
        {
            _context = context;
        }

        // GET: api/LoanTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanType>>> GetLoanTypes()
        {
            return await _context.LoanTypes.ToListAsync();
        }

        // GET: api/LoanTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanType>> GetLoanType(long id)
        {
            var loanType = await _context.LoanTypes.FindAsync(id);

            if (loanType == null)
            {
                return NotFound();
            }

            return loanType;
        }

        [EnableCors("Allow8080")]
        [HttpGet("PaymentPlan")]
        public async Task<ActionResult<List<Term>>> CalculatePaymentPlan([FromQuery] String type, [FromQuery] int amount, [FromQuery] int years, [FromServices] IPaymentPlanService paymentPlanService)
        {
            var loanType = await _context.LoanTypes.FirstOrDefaultAsync<LoanType>(l => l.Type.Equals(type));

            if (loanType == null)
            {
                return NotFound();
            }

            var paymentPlan = paymentPlanService.CalculateSeriesLoan(loanType.interest, amount, years);

            return Ok(paymentPlan);
        }

        // PUT: api/LoanTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoanType(long id, LoanType loanType)
        {
            if (id != loanType.Id)
            {
                return BadRequest();
            }

            _context.Entry(loanType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoanTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoanTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoanType>> PostLoanType(LoanType loanType)
        {
            _context.LoanTypes.Add(loanType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoanType", new { id = loanType.Id }, loanType);
        }

        // DELETE: api/LoanTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoanType>> DeleteLoanType(long id)
        {
            var loanType = await _context.LoanTypes.FindAsync(id);
            if (loanType == null)
            {
                return NotFound();
            }

            _context.LoanTypes.Remove(loanType);
            await _context.SaveChangesAsync();

            return loanType;
        }

        private bool LoanTypeExists(long id)
        {
            return _context.LoanTypes.Any(e => e.Id == id);
        }
    }
}

using PersonalFinance.Helpers;
using PersonalFinance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private readonly PersonalFinanceContext _dbContext;

        public RevenueController(PersonalFinanceContext dbContext)
        {
            _dbContext = dbContext;
        }

   
        //GET: api/Revenue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revenue>>> GetRevenues()
        {
            if (_dbContext.Revenue_Details == null)
            {
                return NotFound();
            }

            return await _dbContext.Revenue_Details.ToListAsync();

        }

        // GET api/Revenue/5
        [HttpGet("{Rev_Id}")]
        public async Task<ActionResult<Revenue>> GetRevenues(int Rev_Id)
        {
            if (_dbContext.Revenue_Details == null)
            {
                return NotFound();
            }
            var revenue = await _dbContext.Revenue_Details.FindAsync(Rev_Id);
            if (revenue == null)
            { return NotFound(); }
            return revenue;
        }

        // POST: api/Revenue
        [HttpPost]
        public async Task<ActionResult<Revenue>> PostRevenues(Revenue revenue)
        {
            _dbContext.Revenue_Details.Add(revenue);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRevenues), new { id = revenue.Rev_Id }, revenue);

        }
        // PUT: api/Revenue/5

        [HttpPut("{Rev_Id}")]
        public async Task<IActionResult> PutRevenue(int Rev_Id, Revenue revenue)
        {
            if (Rev_Id != revenue.Rev_Id)
            {
                return BadRequest();

            }

            _dbContext.Entry(revenue).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevenueExists(Rev_Id))
                { return NotFound(); }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }



        // DELETE: Api/Revenue/5
        [HttpDelete("{Rev_Id}")]
        public async Task<IActionResult> DeleteRevenue(int Rev_Id)
        {
            if (_dbContext.Revenue_Details == null)
            {
                return NotFound();
            }
            var revenue = await _dbContext.Revenue_Details.FindAsync(Rev_Id);

            if (revenue == null)
            {
                return NotFound();
            }
            _dbContext.Revenue_Details.Remove(revenue);
            await _dbContext.SaveChangesAsync();

            return NoContent();


        }

        /// <summary>
        /// Check if Revenue Exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool RevenueExists(long rev_id)
        {
            return (_dbContext.Revenue_Details?.Any(e => e.Rev_Id == rev_id)).GetValueOrDefault();
            //throw new NotImplementedException();
        }
      
    }
}

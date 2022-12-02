using PersonalFinance.Models;
using PersonalFinance.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly PersonalFinanceContext _dbContext;

        public ExpenseController(PersonalFinanceContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expenses>>> GetExpenses()
        {
            if (_dbContext.Expense_Details == null)
            {
                return NotFound();
            }

            return await _dbContext.Expense_Details.ToListAsync();

        }

        // GET api/Epense/5
        [HttpGet("{Exp_Id}")]
        public async Task<ActionResult<Expenses>> GetExpenses(int Exp_Id)
        {
            if (_dbContext.Expense_Details == null)
            {
                return NotFound();
            }
            var expense = await _dbContext.Expense_Details.FindAsync(Exp_Id);
            if (expense == null)
            { return NotFound(); }
            return expense;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Expenses>> PostExpense(Expenses expense)
        {
            _dbContext.Expense_Details.Add(expense);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExpenses), new { id = expense.Exp_Id }, expense);

        }
        // PUT: api/Categories/5

        [HttpPut("{Exp_Id}")]
        public async Task<IActionResult> PutExpense(int Exp_Id, Expenses expense)
        {
            if (Exp_Id != expense.Exp_Id)
            {
                return BadRequest();

            }

            _dbContext.Entry(expense).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(Exp_Id))
                { return NotFound(); }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }



        // DELETE: Api/category/5
        [HttpDelete("{Exp_Id}")]
        public async Task<IActionResult> DeleteExpense(int Exp_Id)
        {
            if (_dbContext.Expense_Details == null)
            {
                return NotFound();
            }
            var expense = await _dbContext.Expense_Details.FindAsync(Exp_Id);

            if (expense == null)
            {
                return NotFound();
            }
            _dbContext.Expense_Details.Remove(expense);
            await _dbContext.SaveChangesAsync();

            return NoContent();


        }

        /// <summary>
        /// Check if Category Exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ExpenseExists(long exp_id)
        {
            return (_dbContext.Expense_Details?.Any(e => e.Exp_Id == exp_id)).GetValueOrDefault();
            //throw new NotImplementedException();
        }


    }
}

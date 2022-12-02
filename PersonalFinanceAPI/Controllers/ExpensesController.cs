using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Expenses;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace PersonalFinanceAPI.Controllers
{
    //[ApiController]
   // [Route("api/[controller]")]
    public class ExpensesController : BaseApiController
    {
        [HttpGet]
        public  async Task<ActionResult<List<Expense>>> GetExpenses()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(Int32 id)
        {
            return await Mediator.Send(new Details.Query{Id = id});

        }

        [HttpPost]

        public async Task<IActionResult> CreateExpense(Expense expense)
        {

            return Ok(await Mediator.Send( new Create.Command{Expense = expense}));


        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditExpense(Int32 id, Expense expense)
        {
            expense.Exp_Id = id;
            return Ok(await Mediator.Send( new Edit.Command{Expense = expense}));


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteExpense (Int32 id)
        {
                return Ok( await Mediator.Send(new Delete.Command{Id = id}));

        }
    }
}
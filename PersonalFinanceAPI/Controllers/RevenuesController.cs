using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Revenues;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace PersonalFinanceAPI.Controllers
{
    [AllowAnonymous]
    //[ApiController]
   // [Route("api/[controller]")]
    public class RevenuesController : BaseApiController
    {
        [HttpGet]
        public  async Task<ActionResult<List<Revenue>>> GetRevenues()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Revenue>> GetRevenue(Int32 id)
        {
            return await Mediator.Send(new Details.Query{Id = id});

        }

        [HttpPost]

        public async Task<IActionResult> CreateRevenue(Revenue revenue)
        {

            return Ok(await Mediator.Send( new Create.Command{Revenue = revenue}));


        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditRevenue(Int32 id, Revenue revenue)
        {
            revenue.Rev_Id = id;
            return Ok(await Mediator.Send( new Edit.Command{Revenue = revenue}));


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRevenue (Int32 id)
        {
                return Ok( await Mediator.Send(new Delete.Command{Id = id}));

        }

    }
}
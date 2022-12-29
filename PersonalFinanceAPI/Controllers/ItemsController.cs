using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Items;
using Domain;
using Microsoft.AspNetCore.Authorization;

namespace PersonalFinanceAPI.Controllers
{
[AllowAnonymous]
    public class ItemsController : BaseApiController
    {
         [HttpGet]
        public  async Task<ActionResult<List<Item>>> GetItems()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(Int32 id)
        {
            return await Mediator.Send(new Details.Query{Id = id});

        }

        [HttpPost]

        public async Task<IActionResult> CreateItem(Item item)
        {

            return Ok(await Mediator.Send( new Create.Command{Item = item}));


        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditItem(Int32 id, Item item)
        {
            item.Item_Id = id;
            return Ok(await Mediator.Send( new Edit.Command{Item = item}));


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteItem (Int32 id)
        {
                return Ok( await Mediator.Send(new Delete.Command{Id = id}));

        }

    }
}
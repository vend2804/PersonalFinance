using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Categories;
using Domain;

namespace PersonalFinanceAPI.Controllers
{
    //[ApiController]
   // [Route("api/[controller]")]
    public class CategoriesController : BaseApiController
    {
         [HttpGet]
        public  async Task<ActionResult<List<Category>>> GetCategories()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetItem(Int32 id)
        {
            return await Mediator.Send(new Details.Query{Id = id});

        }

        [HttpPost]

        public async Task<IActionResult> CreateItem(Category category)
        {

            return Ok(await Mediator.Send( new Create.Command{Category = category}));


        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditItem(Int32 id, Category category)
        {
            category.Cat_Id = id;
            return Ok(await Mediator.Send( new Edit.Command{Category = category}));


        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteItem (Int32 id)
        {
                return Ok( await Mediator.Send(new Delete.Command{Id = id}));

        }

    }
}
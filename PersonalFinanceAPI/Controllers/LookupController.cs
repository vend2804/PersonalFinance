using PersonalFinance.Helpers;
using PersonalFinance.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly PersonalFinanceContext _dbContext;

        public LookupController(PersonalFinanceContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            if (_dbContext.Category_Details == null)
            {
                return NotFound();
            }

            return await _dbContext.Category_Details.ToListAsync();

        }

        // GET api/category/5
        [HttpGet("{Cat_Id}")]
        public async Task<ActionResult<Categories>> GetCategories(int Cat_Id)
        {
            if (_dbContext.Category_Details == null)
            {
                return NotFound();
            }
            var category = await _dbContext.Category_Details.FindAsync(Cat_Id);
            if (category == null)
            { return NotFound(); }
            return category;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Categories>> PostCategory(Categories category)
        {
            _dbContext.Category_Details.Add(category);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategories), new { id = category.Cat_Id }, category);

        }
        // PUT: api/Categories/5

        [HttpPut("{Cat_Id}")]
        public async Task<IActionResult> PutCategory(int Cat_Id, Categories category)
        {
            if (Cat_Id != category.Cat_Id)
            {
                return BadRequest();

            }

            _dbContext.Entry(category).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(Cat_Id))
                { return NotFound(); }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }



        // DELETE: Api/category/5
        [HttpDelete("{Cat_Id}")]
        public async Task<IActionResult> DeleteCategory(int Cat_Id)
        {
            if (_dbContext.Category_Details == null)
            {
                return NotFound();
            }
            var category = await _dbContext.Category_Details.FindAsync(Cat_Id);

            if (category == null)
            {
                return NotFound();
            }
            _dbContext.Category_Details.Remove(category);
            await _dbContext.SaveChangesAsync();

            return NoContent();


        }

        /// <summary>
        /// Check if Category Exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CategoryExists(long cat_id)
        {
            return (_dbContext.Category_Details?.Any(e => e.Cat_Id == cat_id)).GetValueOrDefault();
            //throw new NotImplementedException();
        }

        // Items 
        //GET: api/Expense
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Items>>> GetItems()
        {
            if (_dbContext.Item_Details == null)
            {
                return NotFound();
            }

            return await _dbContext.Item_Details.ToListAsync();

        }

        // GET api/category/5
        [HttpGet("{Item_Id}")]
        public async Task<ActionResult<Items>> GetItems(int Item_Id)
        {
            if (_dbContext.Item_Details == null)
            {
                return NotFound();
            }
            var item = await _dbContext.Item_Details.FindAsync(Item_Id);
            if (item == null)
            { return NotFound(); }
            return item;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Items>> PostItem(Items item)
        {
            _dbContext.Item_Details.Add(item);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItems), new { id = item.Item_Id }, item);

        }
        // PUT: api/Categories/5

        [HttpPut("{Item_Id}")]
        public async Task<IActionResult> PutItem(int Item_Id, Items item)
        {
            if (Item_Id != item.Item_Id)
            {
                return BadRequest();

            }

            _dbContext.Entry(item).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExist(Item_Id))
                { return NotFound(); }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }



        // DELETE: Api/category/5
        [HttpDelete("{Item_Id}")]
        public async Task<IActionResult> DeleteItem(int Item_Id)
        {
            if (_dbContext.Item_Details == null)
            {
                return NotFound();
            }
            var item = await _dbContext.Item_Details.FindAsync(Item_Id);

            if (item == null)
            {
                return NotFound();
            }
            _dbContext.Item_Details.Remove(item);
            await _dbContext.SaveChangesAsync();

            return NoContent();


        }

        /// <summary>
        /// Check if Category Exist
        /// </summary>
        /// <param name="item_id"></param>
        /// <returns></returns>
        private bool ItemExist(long item_id)
        {
            return (_dbContext.Item_Details?.Any(e => e.Item_Id == item_id)).GetValueOrDefault();
            //throw new NotImplementedException();
        }
       
    }
}

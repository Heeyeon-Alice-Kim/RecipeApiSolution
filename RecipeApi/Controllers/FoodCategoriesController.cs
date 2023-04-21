using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Data;
using RecipeApi.Model;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoriesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public FoodCategoriesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/FoodCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodCategoryDTO>>> GetFoodCategories()
        {
            return await _context.FoodCategories
                .Select(c => new FoodCategoryDTO
                {
                    ID = c.ID,
                    Category = c.Category
                }).ToListAsync();
        }

        // GET: api/FoodCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodCategoryDTO>> GetFoodCategory(int id)
        {
            var foodCategoryDTO = await _context.FoodCategories
                .Select(c => new FoodCategoryDTO
                {
                    ID = c.ID,
                    Category = c.Category
                })
                .FirstOrDefaultAsync(c => c.ID == id);

            if (foodCategoryDTO == null)
            {
                return NotFound(new { message = "Error: Category record not found." });
            }

            return foodCategoryDTO;
        }

        // PUT: api/FoodCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodCategory(int id, FoodCategory foodCategory)
        {
            if (id != foodCategory.ID)
            {
                return BadRequest();
            }

            _context.Entry(foodCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodCategoryExists(id))
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

        // POST: api/FoodCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodCategory>> PostFoodCategory(FoodCategory foodCategory)
        {
            _context.FoodCategories.Add(foodCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFoodCategory", new { id = foodCategory.ID }, foodCategory);
        }

        // DELETE: api/FoodCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodCategory(int id)
        {
            var foodCategory = await _context.FoodCategories.FindAsync(id);
            if (foodCategory == null)
            {
                return NotFound();
            }

            _context.FoodCategories.Remove(foodCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodCategoryExists(int id)
        {
            return _context.FoodCategories.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using RecipeApi.Data;
using RecipeApi.Model;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodRecipesController : ControllerBase
    {
        private readonly RecipeContext _context;

        public FoodRecipesController(RecipeContext context)
        {
            _context = context;
        }

        // GET: api/FoodRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodRecipeDTO>>> GetFoodRecipes()
        {
            
            return await _context.FoodRecipes
                .Include(r => r.FoodCategory)
                .Select(r => new FoodRecipeDTO
                {
                    ID = r.ID,
                    Name = r.Name,
                    Ingredient = r.Ingredient,
                    Calorie = r.Calorie,
                    Image = r.Image,
                    Serve = r.Serve,
                    Description = r.Description,
                    Spicy = r.Spicy,
                    LOD = r.LOD,
                    FoodCategoryID = r.FoodCategoryID,
                    FoodCategory = new FoodCategoryDTO
                    {
                        ID = r.FoodCategory.ID,
                        Category = r.FoodCategory.Category
                    }

                }).ToListAsync();
        }

        // GET: api/FoodRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodRecipeDTO>> GetFoodRecipe(int id)
        {
            var foodRecipeDTO = await _context.FoodRecipes
                .Include(r => r.FoodCategory)
                .Select(r => new FoodRecipeDTO
                {
                    ID = r.ID,
                    Name = r.Name,
                    Ingredient = r.Ingredient,
                    Calorie = r.Calorie,
                    Image = r.Image,
                    Serve = r.Serve,
                    Description = r.Description,
                    Spicy = r.Spicy,
                    LOD = r.LOD,
                    FoodCategoryID = r.FoodCategoryID,
                    FoodCategory = new FoodCategoryDTO
                    {
                        ID = r.FoodCategory.ID,
                        Category = r.FoodCategory.Category
                    }

                }).FirstOrDefaultAsync(r => r.ID == id);

            if (foodRecipeDTO == null)
            {
                return NotFound(new { message = "Error: Recipe record not found." });
            }

            return foodRecipeDTO;
        }

        // GET: api/FoodRecipesByCategory
        [HttpGet("ByCategory{id}")]
        public async Task<ActionResult<IEnumerable<FoodRecipeDTO>>> GetFoodRecipeByCategory(int id)
        {
            var foodRecipeDTOs = await _context.FoodRecipes
                .Include(r => r.FoodCategory)
                .Select(r => new FoodRecipeDTO
                {
                    ID = r.ID,
                    Name = r.Name,
                    Ingredient = r.Ingredient,
                    Calorie = r.Calorie,
                    Image = r.Image,
                    Serve = r.Serve,
                    Description = r.Description,
                    Spicy = r.Spicy,
                    LOD = r.LOD,
                    FoodCategoryID = r.FoodCategoryID,
                    FoodCategory = new FoodCategoryDTO
                    {
                        ID = r.FoodCategory.ID,
                        Category = r.FoodCategory.Category
                    }

                }).Where(r => r.FoodCategoryID == id)
                .ToListAsync();

            if (foodRecipeDTOs.Count() > 0)
            {
                return foodRecipeDTOs;
            }
            else
            {
                return NotFound(new { message = "Error: No Recipe records for that Department." });
            }
        }

        // PUT: api/FoodRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodRecipe(int id, FoodRecipeDTO foodRecipeDTO)
        {
            if (id != foodRecipeDTO.ID)
            {
                return BadRequest(new { message = "Error: Incorrect ID for Recipe." });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Get the record you want to update
            var recipeToUpdate = await _context.FoodRecipes.FindAsync(id);

            //Check that you got it
            if (recipeToUpdate == null)
            {
                return NotFound(new { message = "Error: Recipe record not found." });
            }

            //Update the properties of the entity object from the DTO object

            recipeToUpdate.ID = foodRecipeDTO.ID;
            recipeToUpdate.Name = foodRecipeDTO.Name;
            recipeToUpdate.Image = foodRecipeDTO.Image;
            recipeToUpdate.Serve = foodRecipeDTO.Serve;
            recipeToUpdate.LOD = foodRecipeDTO.LOD;
            recipeToUpdate.Calorie = foodRecipeDTO.Calorie;
            recipeToUpdate.Spicy = foodRecipeDTO.Spicy;
            recipeToUpdate.Ingredient = foodRecipeDTO.Ingredient;
            recipeToUpdate.Description = foodRecipeDTO.Description;
            recipeToUpdate.FoodCategoryID = foodRecipeDTO.FoodCategoryID;


            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodRecipeExists(id))
                {
                    return Conflict(new { message = "Concurrency Error: Recipe has been Removed." });
                }
                else
                {
                    return Conflict(new { message = "Concurrency Error: Recipe has been updated by another user.  Back out and try editing the record again." });
                }
            }
            catch (DbUpdateException dex)
            {

                return BadRequest(new { message = "Unable to save changes to the database. Try again, and if the problem persists see your system administrator." });

            }

        }

        // POST: api/FoodRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodRecipe>> PostFoodRecipe(FoodRecipeDTO foodRecipeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FoodRecipe foodrecipe = new FoodRecipe
            {
                ID = foodRecipeDTO.ID,
                Name = foodRecipeDTO.Name,
                Serve = foodRecipeDTO.Serve,
                Image = foodRecipeDTO.Image,
                Calorie = foodRecipeDTO.Calorie,
                Ingredient = foodRecipeDTO.Ingredient,
                Description = foodRecipeDTO.Description,
                Spicy = foodRecipeDTO.Spicy,
                LOD = foodRecipeDTO.LOD,
                FoodCategoryID = foodRecipeDTO.FoodCategoryID

            };

            try
            {
                _context.FoodRecipes.Add(foodrecipe);
                await _context.SaveChangesAsync();

                //Assign Database Generated values back into the DTO
                foodRecipeDTO.ID = foodrecipe.ID;

                return CreatedAtAction(nameof(GetFoodRecipe), new { id = foodrecipe.ID }, foodRecipeDTO);

            }
            catch (DbUpdateException dex)
            {

                return BadRequest(new { message = "Unable to save changes to the database. Try again, and if the problem persists see your system administrator." });

            }
        }

        // DELETE: api/FoodRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodRecipe(int id)
        {
            var foodRecipe = await _context.FoodRecipes.FindAsync(id);
            if (foodRecipe == null)
            {
                return NotFound(new { message = "Delete Error: Employee has already been removed." });
            }

            try
            {
                _context.FoodRecipes.Remove(foodRecipe);
                await _context.SaveChangesAsync();

                return NoContent();

            }
            catch (DbUpdateException)
            {
                return BadRequest(new { message = "Delete Error: Unable to delete Patient." });
            }
        }

        private bool FoodRecipeExists(int id)
        {
            return _context.FoodRecipes.Any(e => e.ID == id);
        }
    }
}
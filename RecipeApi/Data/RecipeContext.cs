using Microsoft.EntityFrameworkCore;
using RecipeApi.Model;

namespace RecipeApi.Data
{
    public class RecipeContext : DbContext
    {
     
        public RecipeContext(DbContextOptions<RecipeContext> options)
        : base(options)
        {

        }

        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodRecipe> FoodRecipes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //prevent cascade delete
            modelBuilder.Entity<FoodCategory>()
               .HasMany(e => e.FoodRecipes)
               .WithOne(d => d.FoodCategory)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

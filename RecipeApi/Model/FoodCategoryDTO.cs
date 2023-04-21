namespace RecipeApi.Model
{
    public class FoodCategoryDTO
    {
        public int ID { get; set; }

        public string Category { get; set; }

        public ICollection<FoodRecipeDTO> FoodRecipes { get; set; }
    }
}

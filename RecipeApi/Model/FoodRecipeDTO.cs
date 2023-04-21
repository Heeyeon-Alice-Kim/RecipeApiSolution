namespace RecipeApi.Model
{
    public class FoodRecipeDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public int Serve { get; set; }
        public int Calorie { get; set; }

        public string Description { get; set; }

        public string Ingredient { get; set; }

        public string Spicy { get; set; }
        public string LOD { get; set; }

        public int FoodCategoryID { get; set; }

        public FoodCategoryDTO FoodCategory { get; set; }
    }
}

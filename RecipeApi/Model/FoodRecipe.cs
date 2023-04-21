using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RecipeApi.Model
{
    public class FoodRecipe
    {
        public int ID { get; set; }


        [Display(Name = "Name or Title")]
        [Required(ErrorMessage = "You cannot leave the recipe name blank.")]
        [StringLength(255, ErrorMessage = "Recipe Name cannot be more than 255 characters long.")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        [StringLength(1000, ErrorMessage = "Image cannot be more than 1000 characters long.")]
        public string Image { get; set; }


        [Display(Name = "Serving Size")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Serve { get; set; }


        [Display(Name = "Calorie per serving")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Calorie { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "You cannot leave the description of the artwork blank.")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Description must be a least 20 characters and no more than 500.")]
        public string Description { get; set; }

        [Display(Name = "Ingredient")]
        [Required(ErrorMessage = "You cannot leave the Ingredient of the recipe blank.")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Description must be a least 20 characters and no more than 500.")]
        public string Ingredient { get; set; }

        [Display(Name = "Spicy")]
        public String Spicy { get; set; }

        [Display(Name = "Level of Cooking Difficulty")]
        public string LOD { get; set; }


        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please identify Category.")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select Category.")]
        public int FoodCategoryID { get; set; }

        public FoodCategory FoodCategory { get; set; }

    }

    public enum Spicy {Very_Spicy, Spicy, Little_Spicy, Mild }

    public enum LevelOfDifficulty {High, Medium, Low }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RecipeApi.Model
{
    public class FoodCategory
    {
        public int ID { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "The Catgory Name cannot be left blank.")]
        [StringLength(50, ErrorMessage = "Category cannot be more than 50 characters long.")]
        public string Category { get; set; }

        public ICollection<FoodRecipe> FoodRecipes { get; set; } = new HashSet<FoodRecipe>();
    }
}

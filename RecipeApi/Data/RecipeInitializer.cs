
using Microsoft.EntityFrameworkCore;
using RecipeApi.Model;
using System.Diagnostics;

namespace RecipeApi.Data
{
    public class RecipeInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
             RecipeContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<RecipeContext>();

            try
            {
                //Delete the database if you need to apply a new Migration
                context.Database.EnsureDeleted();
                //Create the database if it does not exist and apply the Migration
                context.Database.Migrate();

                //FoodCategory
                if (context.FoodCategories.Count() == 0)
                {
                    var categories = new List<FoodCategory>
                    {  new FoodCategory { Category = "Vegetable" },
                     new FoodCategory { Category = "Pork" },
                     new FoodCategory { Category = "Beef" },
                     new FoodCategory { Category = "Chicken" },
                     new FoodCategory { Category = "etc" }
                    };
                    categories.ForEach(d => context.FoodCategories.Add(d));
                    context.SaveChanges();
                }


                //Recipe
                if (context.FoodRecipes.Count() == 0)
                {
                   var recipes = new List<FoodRecipe>
                   {
                    new FoodRecipe
                    {
                        Name = "Bibimbob",
                        Ingredient = "Freshly cooked white rice,egg, soybean sprouts, Carrot, Zucchini, Gochujang, Sesame oil",
                        Image = "~/Image/bibimbob.jpg",
                        Calorie= 413,
                        Serve = 1,
                        Description = "Bibimbap is, perhaps, the most well known dish among Korean rice dishes. A bowl of rice is arranged with all sorts of seasoned vegetables and meat (typically beef), and topped with a sunny side up fried egg.",
                        Spicy = Spicy.Little_Spicy.ToString(),
                        LOD = LevelOfDifficulty.Medium.ToString(),
                        FoodCategoryID = 1
                      

                    },
                    new FoodRecipe
                    {
                        Name = "Japchae",
                        Ingredient = "Korean glass noodles, onion, carrot, pepper, spinach, mushroom, beef or pork(or neither), Soy sauce, garlic, sugar, sesame oil, rice wine",
                        Image = "~/Image/japchae.jpg",
                        Calorie = 600,
                        Serve = 2,
                        Description = "Make japchae, a classic Korean glass noodles, with this easy recipe. Korean noodles, known as Dangmyeon, are made from sweet potato starch and are stir-fried with beef and vegetables in a savory sauce. This recipe is adaptable for gluten-free, vegan, and vegetarian diets.",
                        Spicy = Spicy.Mild.ToString(),
                        LOD = LevelOfDifficulty.Medium.ToString(),
                        FoodCategoryID = 1
                       

                    },
                    new FoodRecipe
                    {
                        Name = "Bulgogi",
                        Ingredient = "2 lb (900 g) beef sirloin or rib eye,Asian pear, Kiwi, Onion, garlic, soy sauce, sugar, rice wine, black pepper, sesame oil",
                        Image = "~/Image/bulgogi.jpg",
                        Calorie = 475,
                        Serve = 1,
                        Description = "Bulgogi is a classic Korean BBQ beef made with thin slices of beef and a flavorful marinade. This authentic beef bulgogi recipe cooks fast and your meat will be so tender and juicy. No oil is needed to cook.",
                        Spicy = Spicy.Mild.ToString(),
                        LOD = LevelOfDifficulty.Medium.ToString(),
                        FoodCategoryID = 3
                        

                    },
                    new FoodRecipe
                    {
                        Name = "Samgyupsal(Korean BBQ Pork Belly)",
                        Ingredient = "1 lb (450 g) pork belly, Korean soybean paste (doenjang), Korean chili paste (gochujang), garlic, sweet rice wine (mirin), sugar, sesame oil",
                        Image = "~/Image/samgyupsal.jpg",
                        Calorie = 1200,
                        Serve = 2,
                        Description = "Samgyupsal is a Korean dish of grilled pork belly served with sides like lettuce and dipping sauces like ssamjang and sesame oil.",
                        Spicy = Spicy.Mild.ToString(),
                        LOD = LevelOfDifficulty.Low.ToString(),
                        FoodCategoryID = 2
                       

                    },
                    new FoodRecipe
                    {
                        Name = "Jeyukbokkeum(Spicy Pork Bulgogi)",
                        Ingredient = "1 lb (450 g) pork shoulder, oil, sugar, green onion,  onion, Korean chili paste (gochujang), Korean chili flakes (gochugaru), soy sauce, sweet rice wine,sugar, garlic, sesame oil, black pepper",
                        Image = "~/Image/korean=spicy-pork.jpg",
                        Calorie = 1000,
                        Serve = 2,
                        Description = "Pork bulgogi is a Korean spicy pork stir fried with a spicy gochujang sauce. ",
                        Spicy = Spicy.Spicy.ToString(),
                        LOD = LevelOfDifficulty.Medium.ToString(),
                        FoodCategoryID = 2
                      

                    },
                    new FoodRecipe
                    {
                        Name = "Dakgalbi(Spicy Korean Chicken stir fry)",
                        Ingredient = "1 lb boneless, skinless chicken thigh, oil, green cabbage, Onion, Green Onion, soy sauce,  Korean chili flakes (gochugaru), garlic cloves, curry powder, sweet rice wine",
                        Image = "~/Image/Korean-chicken-stir-fry.jpg",
                        Calorie = 600,
                        Serve = 2,
                        Description = "Dakgalbi is a spicy Korean chicken stir fry made with chicken thighs, cabbage, rice cake, and sweet potato in a gochujang-based sauce. The original recipe is from Chuncheon.",
                        Spicy = Spicy.Spicy.ToString(),
                        LOD = LevelOfDifficulty.Medium.ToString(),
                        FoodCategoryID = 4
                       

                    },
                    new FoodRecipe
                    {
                        Name = "Crispy Korean Fried Chicken",
                        Ingredient = "1.3 kg chicken party wings, sweet rice wine (mirim), pureed ginger, salt and pepper to taste, cornstarch,p baking powder, oil" +
                                     "onion , dgarlic, sweet rice wine, ginger, Korean chili paste (gochujang), Soy sauce, ketchup, sugar, rice vinegar",
                        Image = "~/Image/fried-chicken.jpg",
                        Calorie = 1800,
                        Serve = 4,
                        Description = "Double-fry the wings, then coat in homemade gochujang sauce for a tasty game night treat or Chimaek feast with family and friends.",
                        Spicy = Spicy.Little_Spicy.ToString(),
                        LOD = LevelOfDifficulty.Medium.ToString(),
                        FoodCategoryID = 4
                        

                    },
                    new FoodRecipe
                    {
                        Name = "Tteokgalbi(Korean Beef Patties)",
                        Ingredient = "1lb beef short rib meat, onion,garlic,  ginger chopped pine nuts, sweet rice flour (chapssal-garu),honey, soy sauce, salt, sweet rice,sesame oil",
                        Image = "~/Image/tteokgalbi.jpg",
                        Calorie = 250,
                        Serve = 1,
                        Description = "Celebrate a special occasion or holiday with Korean beef patties (Tteokgalbi). The patties are conveniently broiled in an oven, then brushed with soy honey glaze.",
                        Spicy = Spicy.Mild.ToString(),
                        LOD = LevelOfDifficulty.High.ToString(),
                        FoodCategoryID = 3
                        

                    },
                    new FoodRecipe
                    {
                        Name = "Hotteok (Korean Sweet Pancake)",
                        Ingredient = "all purpose flour,sweet rice flour (chapssal-garu),sugar,instant yeast, baking powder, salt, lukewarm milk, oil, brown sugar, cinnamon, peanuts or any nuts of your choice, finely chopped",
                        Image = "~/Image/hotteok.jpg",
                        Calorie = 344,
                        Serve = 1,
                        Description = "Hotteok is Korean sweet pancake stuffed with brown sugar, cinnamon, and chopped nuts. It’s a popular winter snack and well known Korean street food.",
                        Spicy = Spicy.Mild.ToString(),
                        LOD = LevelOfDifficulty.Low.ToString(),
                        FoodCategoryID = 5
                      

                    }
                    };
                    recipes.ForEach(d => context.FoodRecipes.Add(d));
                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace GreatRecipes.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new Recipe
                    {
                        RecipeOwnerName = "Cynthia Heil, Augusta, Georgia",
                        RecipeName = "Quick Chicken Piccata",
                        BriefDescription = "Quick chicken recipes make dinner a breeze. " +
                    "Laced with lemon and simmered in white wine, " +
                    "this stovetop entree is super easy and elegant. " +
                    "Almost any side—noodles, veggies or bread—tastes " +
                    "better next to this lovely chicken. ",
                        Ingradients = "4 skinless, boneless chicken breast halves " +
                    "cayenne pepper, or to taste " +
                    "salt and ground black pepper to taste " +
                    "ll-purpose flour for dredging " +
                    "2 tablespoons olive oil " +
                    "1 tablespoon capers, drained " +
                    "½ cup white wine " +
                    "¼ cup fresh lemon juice " +
                    "¼ cup water " +
                    "3 tablespoons cold unsalted butter, cut in 1/4-inch slices " +
                    "2 tablespoons fresh Italian parsley, chopped",
                        Directions = "Place chicken breasts between 2 layers of plastic wrap and pound to about 1/2-inch thick. " +
                    "Season both sides of chicken breasts with cayenne, salt, and black pepper; dredge lightly in flour and shake off any excess. " +
                    " Heat olive oil in a skillet over medium-high heat. Place chicken in the pan, reduce heat to medium, and cook until browned and cooked through, about 5 minutes per side; remove to a plate. " +
                    " Cook capers in reserved oil, smashing them lightly to release brine, until warmed though, about 30 seconds. " +
                    "Pour white wine into skillet. Scrape any browned bits from the bottom of the pan with a wooden spoon. Cook until reduced by half, about 2 minutes. " +
                    "Stir lemon juice, water, and butter into the reduced wine mixture; cook and stir continuously to form a thick sauce, about 2 minutes. Reduce heat to low and stir parsley through the sauce. " +
                    "Return chicken breasts to the pan cook until heated through, 1 to 2 minutes. Serve with sauce spooned over the top.",
                        ImageUrl = "/Images/ChickenPasta.jpg"
                    },
            new Recipe
            {
                RecipeOwnerName = "Maura McGee, Tallahassee, Florida",
                RecipeName = "Creamy Italian Chicken",
                BriefDescription = "Italian salad dressing mix is like a secret weapon for" +
                    "adding flavor to this creamy chicken dish. Served over" +
                    "rice or pasta, this Italian dressing chicken is rich," +
                    "delicious and special enough for company. —Maura McGee, Tallahassee, Florida",
                Ingradients = "4 skinless, boneless chicken breast halves, " +
                    "cayenne pepper, or to taste, " +
                    "salt and ground black pepper to taste " +
                    "ll-purpose flour for dredging " +
                    "2 tablespoons olive oil " +
                    "1 tablespoon capers, drained " +
                    "½ cup white wine " +
                    "¼ cup fresh lemon juice " +
                    "¼ cup water " +
                    "3 tablespoons cold unsalted butter, cut in 1/4-inch slices " +
                    "2 tablespoons fresh Italian parsley, chopped ",
                Directions = "Place chicken breasts between 2 layers of plastic wrap and pound to about 1/2-inch thick. " +
                    "Season both sides of chicken breasts with cayenne, salt, and black pepper; dredge lightly in flour and shake off any excess. " +
                    " Heat olive oil in a skillet over medium-high heat. Place chicken in the pan, reduce heat to medium, and cook until browned and cooked through, about 5 minutes per side; remove to a plate. " +
                    " Cook capers in reserved oil, smashing them lightly to release brine, until warmed though, about 30 seconds. " +
                    "Pour white wine into skillet. Scrape any browned bits from the bottom of the pan with a wooden spoon. Cook until reduced by half, about 2 minutes. " +
                    "Stir lemon juice, water, and butter into the reduced wine mixture; cook and stir continuously to form a thick sauce, about 2 minutes. Reduce heat to low and stir parsley through the sauce. " +
                    "Return chicken breasts to the pan cook until heated through, 1 to 2 minutes. Serve with sauce spooned over the top. ",
                ImageUrl = "/Images/Creamy Italian Chicken.jpg"
            },

             new Recipe
             {
                 RecipeOwnerName = "Kathy Bowron, Cocolalla, Idaho",
                 RecipeName = "Li'l Ceddar Meat Loaves",
                 BriefDescription = "I got this recipe from my aunt when I was a teen and have made these " +
                    "miniature loaves many times since. My husband and three children " +
                    "count this main dish among their favorites. —Kathy Bowron, " +
                    "Cocolalla, Idaho ",
                 Ingradients = "-4 skinless, boneless chicken breast halves " +
                    "cayenne pepper, or to taste " +
                    "salt and ground black pepper to taste " +
                    "ll-purpose flour for dredging " +
                    "2 tablespoons olive oil " +
                    "1 tablespoon capers, drained " +
                    "½ cup white wine " +
                    "¼ cup fresh lemon juice " +
                    "¼ cup water " +
                    "3 tablespoons cold unsalted butter, cut in 1/4-inch slices " +
                    "2 tablespoons fresh Italian parsley, chopped ",
                 Directions = "Place chicken breasts between 2 layers of plastic wrap and pound to about 1/2-inch thick. " +
                    "Season both sides of chicken breasts with cayenne, salt, and black pepper; dredge lightly in flour and shake off any excess. " +
                    " Heat olive oil in a skillet over medium-high heat. Place chicken in the pan, reduce heat to medium, and cook until browned and cooked through, about 5 minutes per side; remove to a plate. " +
                    " Cook capers in reserved oil, smashing them lightly to release brine, until warmed though, about 30 seconds. " +
                    "Pour white wine into skillet. Scrape any browned bits from the bottom of the pan with a wooden spoon. Cook until reduced by half, about 2 minutes. " +
                    "Stir lemon juice, water, and butter into the reduced wine mixture; cook and stir continuously to form a thick sauce, about 2 minutes. Reduce heat to low and stir parsley through the sauce. " +
                    "Return chicken breasts to the pan cook until heated through, 1 to 2 minutes. Serve with sauce spooned over the top. ",
                 ImageUrl = "/Images/Li'l Cheddar Meat Loaves.jpg"
             }
                );

                context.Reviews.AddRange(
new Review
{
    Comment = "Great Recipe",
    Rate = 4,
    RecipeId = 1
},
new Review
{
    Comment = "Delicious",
    Rate = 5,
    RecipeId = 1
},
new Review
{
    Comment = "Delicious",
    Rate = 5,
    RecipeId = 2
},
new Review
{
    Comment = "Didn´t like it.",
    Rate = 2,
    RecipeId = 3
},
new Review
{
    Comment = "Good",
    Rate = 3,
    RecipeId = 4
},
new Review
{
    Comment = "Very Good",
    Rate = 4,
    RecipeId = 5
},
new Review
{
    Comment = "Like this recipe",
    Rate = 4,
    RecipeId = 5
});
                context.SaveChanges();
            }
        }
    }
}

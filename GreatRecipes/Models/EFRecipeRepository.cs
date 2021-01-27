using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatRecipes.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Recipe> Recipes => context.Recipes;

        public void SaveRecipe(Recipe recipe)
        {
                if (recipe.RecipeId == 0)
                {
                    context.Recipes.Add(recipe);
                }
                else
                {
                    Recipe recipeEntry = context.Recipes
                        .FirstOrDefault(p => p.RecipeId == recipe.RecipeId);

                    if (recipeEntry != null)
                    {
                        recipeEntry.RecipeName = recipe.RecipeName;
                        recipeEntry.RecipeOwnerName = recipe.RecipeOwnerName;
                        recipeEntry.BriefDescription = recipe.BriefDescription;
                        recipeEntry.Ingradients = recipe.Ingradients;
                        recipeEntry.Directions = recipe.Directions;
                    }
                }
                context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeId)
        {
            Recipe recipeEntry = context.Recipes
                .FirstOrDefault(p => p.RecipeId == recipeId);

            if (recipeEntry != null)
            {
                context.Recipes.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }
    }
}

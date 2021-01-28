using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatRecipes.Models;

namespace GreatRecipes.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository;

        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }
        /// <summary>
        /// This method returns the "Home" view (GET)
        /// </summary>
        /// <returns></returns>
        public ViewResult Index()
        {
            return View("Home");
        }
        /// <summary>
        /// This method returns the "RecipeList" view (GET)
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult RecipeList() => View(repository.Recipes);
        /// <summary>
        /// This method returns the "ViewRecipe" view (GET)
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult ViewRecipe(int recipeId) => View(
            repository.Recipes
            .Where(p => p.RecipeId == recipeId));
    }
}

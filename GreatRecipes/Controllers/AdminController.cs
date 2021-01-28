using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreatRecipes.Models;

namespace GreatRecipes.Controllers
{
    public class AdminController:Controller
    {
        private IRecipeRepository repository;

        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Recipes);
        /// <summary>
        /// This method returns the Edit view (GET)
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult Edit(int recipeId) =>
            View(repository.Recipes
                .FirstOrDefault(p => p.RecipeId == recipeId));
        /// <summary>
        /// This method is used to edit a Recipe (POST)
        /// </summary>
        /// <param name="recipe"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                //TempData["message"] = $"{recipe.RecipeName} has been saved!";
                return RedirectToAction("RecipeList", "Home");
            }
            else
            {
                return View(recipe);
            }
        }
        /// <summary>
        /// This method is used to delete a Recipe (POST)
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);
            return RedirectToAction("RecipeList", "Home");
        }
        /// <summary>
        /// This method returns the AddRecipe view (GET)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        /// <summary>
        /// This method is used to add a recipe by user (POST)
        /// </summary>
        /// <param name="userRecipe"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddRecipe(Recipe userRecipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(userRecipe);
                //TempData["message"] = $"{userRecipe.RecipeName} has been added!";
                return RedirectToAction("RecipeList", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}

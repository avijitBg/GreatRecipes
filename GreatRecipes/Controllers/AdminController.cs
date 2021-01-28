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

        [HttpGet]
        public ViewResult Edit(int recipeId) =>
            View(repository.Recipes
                .FirstOrDefault(p => p.RecipeId == recipeId));

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.RecipeName} has been saved!";
                return RedirectToAction("RecipeList", "Home");
            }
            else
            {
                return View(recipe);
            }
        }
        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(recipeId);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.RecipeName} was deleted!";
            }

            return RedirectToAction("RecipeList", "Home");
        }

        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe userRecipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(userRecipe);
                TempData["message"] = $"{userRecipe.RecipeName} has been added!";
                return RedirectToAction("RecipeList", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}

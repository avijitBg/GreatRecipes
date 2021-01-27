﻿using Microsoft.AspNetCore.Mvc;
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

        public ViewResult Index()
        {
            return View("Home");
        }

        [HttpGet]
        public ViewResult RecipeList() => View(repository.Recipes);

        [HttpGet]
        public ViewResult ViewRecipe(int recipeId) => View(
            repository.Recipes
            .Where(p => p.RecipeId == recipeId));

        [HttpGet]
        public ViewResult ReviewRecipe()
        {
            return View();
        }

    }
}

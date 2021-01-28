using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GreatRecipes.Models;

namespace GreatRecipes.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewRepository reviewRepository;

        public ReviewController(IReviewRepository reviewRepo)
        {
            reviewRepository = reviewRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method returns the ReviewList view (GET)
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult ReviewList(int recipeId)
        {
            List<Review> reviews = new List<Review>();
            reviews.AddRange(reviewRepository.Reviews.Where(r => r.RecipeId == recipeId));
            return View(reviews);
        }

        /// <summary>
        ///  This method returns the AddReview view (GET)
        /// </summary>
        /// <param name="recipeId"></param>
        /// <returns></returns>
        [HttpGet]
        public ViewResult AddReview(int recipeId)
        {
            return View();
        }

        /// <summary>
        /// This method is used to save a new review (POST)
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            reviewRepository.SaveReview(review);
            //TempData["message"] = $"Review has been saved!";
            return RedirectToAction("RecipeList", controllerName: "Home");
        }

    }
}
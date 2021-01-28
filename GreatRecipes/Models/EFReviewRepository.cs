using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatRecipes.Models
{
    public class EFReviewRepository : IReviewRepository
    {
        private ApplicationDbContext context;

        public EFReviewRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Review> Reviews => context.Reviews;

        /// <summary>
        /// This method is used to save a review
        /// </summary>
        /// <param name="review"></param>
        public void SaveReview(Review review)
        {
            if (review.ReviewId == 0)
            {
                context.Reviews.Add(review);
            }
            else
            {
                Review dbEntry = context.Reviews
                    .FirstOrDefault(r => r.ReviewId == review.ReviewId);
                if (dbEntry != null)
                {
                    dbEntry.ReviewId = review.ReviewId;
                    dbEntry.RecipeId = review.RecipeId;
                    dbEntry.Rate = review.Rate;
                    dbEntry.Comment = review.Comment;
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// This method is used to delete a review
        /// </summary>
        /// <param name="recipeId"></param>
        public void DeleteReview(int recipeId)
        {
            IQueryable<Review> reviews = context.Reviews
                    .Where(r => r.RecipeId == recipeId);
            if (reviews != null)
            {
                foreach (var r in reviews)
                {
                    context.Reviews.Remove(r);
                }
                context.SaveChanges();
            }
        }

    }
}

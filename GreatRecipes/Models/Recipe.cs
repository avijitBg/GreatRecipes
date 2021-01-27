using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace GreatRecipes.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required(ErrorMessage = "Recipe Owner Name is Required")]
        public string RecipeOwnerName { get; set; }
        [Required(ErrorMessage = "Recipe Name is Required")]
        public string RecipeName { get; set; }
        [Required(ErrorMessage = "A Briefe Description is Required")]
        public string BriefDescription { get; set; }
        [Required(ErrorMessage = "Ingredients is Required")]
        public string Ingradients { get; set; }
        [Required(ErrorMessage = "Directions is Required")]
        public string Directions { get; set; }
        public string ImageUrl { get; set; } = "/Images/DefaultPicture.jpg";

    }
}

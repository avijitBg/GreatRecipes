using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreatRecipes.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public int RecipeId { get; set; }

    }
}

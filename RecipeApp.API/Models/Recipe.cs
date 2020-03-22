using System.Collections.Generic;

namespace RecipeApp.API.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
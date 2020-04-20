using System.Collections.Generic;


namespace Module05_TP02.Models
{
    public class PizzaCreateViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Pate> Pates { get; set; } = new List<Pate>();

        public int IdPate { get; set; }
        public List<int> IdsIngredient { get; set; } = new List<int>();

    }
}
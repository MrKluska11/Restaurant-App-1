using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantClassLibrary
{
    public class Food : Product
    {
        public int Weight { get; set; }   //in grams
        public string Ingredients { get; set; }

        public Food(string name, string desc, decimal prize, int weight, string ingr, string pict) : base(name, desc, prize, pict)
        {
            this.Weight = weight;
            this.Ingredients = ingr;
        }

        
    }
}

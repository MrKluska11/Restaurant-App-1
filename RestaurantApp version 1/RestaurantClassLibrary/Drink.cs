using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantClassLibrary
{
    public class Drink : Product
    {
        public int Milliliters { get; set; }
        public bool Alcohol { get; set; }

        public Drink(string name, string desc, decimal prize, int mili, bool alk, string pict) : base(name, desc, prize, pict)
        {
            this.Milliliters = mili;
            this.Alcohol = alk;
        }
    }
}

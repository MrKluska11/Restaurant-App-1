using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantClassLibrary
{
    public abstract class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Prize { get; set; }
        public string Picture { get; set; }
        public int Quantity { get; set; }

        public Product(string name,string desc, decimal prize, string pict)
        {
            this.Name = name;
            this.Description = desc;
            this.Prize = prize;
            this.Picture = pict;
        }

        public string Display
        {
            get { return string.Format("{0} - {1} zł", Name, Prize); }
        }

    }
}

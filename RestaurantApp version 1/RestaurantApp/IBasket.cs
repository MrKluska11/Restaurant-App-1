using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantClassLibrary;

namespace RestaurantApp
{
    public interface IBasket
    {
        void AddToBasket(Product p);
        void DeleteFromBasket(Product p);
        void Purchase(List<Product> products, ref decimal cash);

    }
}

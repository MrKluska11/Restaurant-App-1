using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantClassLibrary;
using System.Windows.Forms;
using RestaurantApp;

namespace RestaurantApp
{
    public class Basket : IBasket
    {
        public List<Product> BasketProducts { get; set; }
        public decimal Total { get; set; }

        public Basket()
        {
            BasketProducts = new List<Product>();
            Total = 0.00m;
        }

        public void AddToBasket(Product p)
        {
            Total = 0.00m; 
            bool added = false;

            for(int i = 0; i < BasketProducts.Count; i++)
            {
                if(BasketProducts[i] == p)
                {
                    BasketProducts[i].Quantity++;
                    added = true;
                    break;
                }
            }

            if(!added)
            {
                for(int i = 0; i < BasketProducts.Count; i++)
                {
                    if(BasketProducts[i] == null)
                    {
                        p.Quantity++;
                        BasketProducts[i] = p;
                        added = true;
                        break;
                    }
                }
            }

            if(!added)
            {
                p.Quantity++;
                BasketProducts.Add(p);
            }

            foreach(Product p1 in BasketProducts)
            {
                if(p1 != null)
                {
                    Total += p1.Quantity * p1.Prize;
                }
            }
        }

        public void DeleteFromBasket(Product p)
        {           
            Total -= p.Quantity * p.Prize;

            for (int i = 0; i < BasketProducts.Count; i++)
            {
                if(BasketProducts[i] == p)
                {
                    BasketProducts[i].Quantity = 0;
                    BasketProducts[i] = null;
                    break;

                    if(BasketProducts[i].Quantity == 0)
                    {
                        BasketProducts[i] = null;
                        break;
                    }

                }
            }
        }

        public void Purchase(List<Product> products, ref decimal cash)
        {
            if(cash >= Total)
            {
                cash -= Total;
                Total = 0.00m;

                for(int i = 0; i < products.Count; i++)
                {
                    products[i].Quantity = 0;
                    products[i] = null;
                }

                MessageBox.Show("All Products have been purchased!");
            }
            else
            {
                MessageBox.Show("Not enugh cash! Try delete something from basket.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantClassLibrary;   //added by me
using System.Windows.Forms;   //added by me
using RestaurantApp;

namespace RestaurantApp 
{
    public class Generator 
    {
        public List<string> GenerateNames(List<Product> products)
        {
            List<string> names = new List<string>();

            foreach(Product p in products)
            {
                names.Add(p.Display);
            }

            return names;
        }

        public List<string> GeneratePictures(List<Product> products)
        {
            List<string> pictures = new List<string>();

            foreach(Product p in products)
            {
                if(p is Food)
                {
                    pictures.Add(Application.StartupPath.Substring(0, Application.StartupPath.Length - 23)
                                           + "images\\Foods\\" + p.Picture);
                }
                else if(p is Drink)
                {
                    pictures.Add(Application.StartupPath.Substring(0, Application.StartupPath.Length - 23)
                                           + "images\\Drinks\\" + p.Picture);
                }
            }

            return pictures;
        }

    }
}

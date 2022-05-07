using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantClassLibrary;    //added by me


namespace RestaurantApp
{
    public static class DataAssemble 
    {
        public static List<Food> SetupDataFood()
        {
            return new List<Food>()
            {
                new Food("Hot Dog", "This is a hot dog", 7.99m, 200, "Sausage, vegetables, roll, ketchup", "hot dog.jpg"),
                new Food("Kebab", "This is a kebab", 12.99m, 350, "Meet, vegetables, roll, garlic sause", "kebab.jpg"),
                new Food("Pizza", "This is a pizza", 19.99m, 500, "Ham, cheese, mushrooms, tomato sause", "pizza.jpg"),
                new Food("Burger", "This is a burger", 9.99m, 500, "Meet, cheese, vegetables, ketchup", "hamburger.jpg"),
                new Food("Tortilla", "This is a tortilla", 12.99m, 300, "Meet, vegetables, roll, garlic sause", "tortilla.jpg"),
                new Food("Cheaps", "These is a cheaps", 5.99m, 150, "Cheaps, ketchup", "frytki.jpg")
            };
        }

        public static List<Drink> SetupDataDrinks()
        {
            return new List<Drink>()
            {
                new Drink("Coca Cola", "This is a coca cola", 2.99m, 250, false, "coca cola.jpg"),
                new Drink("Cappucino", "This is a cappucino", 3.99m, 250, false, "cappucino.jpg"),
                new Drink("Black Coffe", "This is a black coffe", 3.49m, 250, false, "black coffe.jpg"),
                new Drink("Beer", "This is a beer", 4.99m, 500, true, "beer.jpg"),
                new Drink("Orange Juice", "This is a orange juice", 5.99m, 250, false, "orange juice.jpg"),
                new Drink("Cocktail", "This is a cocktail", 7.99m, 250, true, "cocktail.jpg")
            };

        }  

    }
}


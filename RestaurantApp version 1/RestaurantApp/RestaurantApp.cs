using RestaurantClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class RestaurantApp : Form
    {

        #region zmienne

        Generator generator;

        //Main
        private List<Product> foods;
        private List<Product> drinks;
        private List<Panel> panels;

        //Basket
        private Basket basket;
        private List<Label> labelsOrder;
        private List<Button> deleteButtons;

        //Menu: Foods, Drinks
        private List<Label> foodNames;
        private List<Label> drinkNames;
        private List<PictureBox> foodPictures;
        private List<PictureBox> drinkPictures;

        private decimal cash = 100;
        private int IdOrder = 1;

        private int indeksForDetails;
        private Type typeForDeatilas;

        private Order order;

        #endregion

        public RestaurantApp()
        {
            InitializeComponent();

            //Data Assemble
            drinks = DataAssemble.SetupDataDrinks().Select(x => x as Product).ToList();
            foods = DataAssemble.SetupDataFood().Select(x => x as Product).ToList();

            //Creating Names and Picuteres Bokses in menu
            foodNames = new List<Label>() { lblFood1, lblFood2, lblFood3, lblFood4, lblFood5, lblFood6 };
            drinkNames = new List<Label>() { lblDrink1, lblDrink2, lblDrink3, lblDrink4, lblDrink5, lblDrink6 };
            foodPictures = new List<PictureBox>() { pictureBoxFood1, pictureBoxFood2, pictureBoxFood3, pictureBoxFood4, pictureBoxFood5, pictureBoxFood6 };
            drinkPictures = new List<PictureBox>() { pictureBoxDrink1, pictureBoxDrink2, pictureBoxDrink3, pictureBoxDrink4, pictureBoxDrink5, pictureBoxDrink6 };

            generator = new Generator();

            List<string> names = generator.GenerateNames(foods);
            List<string> picturePaths = generator.GeneratePictures(foods);

            //Initialazing Food, Drinks names and picuteres bokses in menu
            for (int i = 0; i < foodNames.Count; i++)
            {
                foodNames[i].Text = names[i];
            }

            names = generator.GenerateNames(drinks);

            for(int i = 0; i < drinkNames.Count; i++)
            {
                drinkNames[i].Text = names[i];
            }

            for(int i = 0; i < foodPictures.Count; i++)
            {
                foodPictures[i].ImageLocation = picturePaths[i];
            }

            picturePaths = generator.GeneratePictures(drinks);

            for(int i = 0; i < drinkPictures.Count; i++)
            {
                drinkPictures[i].ImageLocation = picturePaths[i];
            }

            //Generating empty basket view
            lblNamePrize1.Text = "There are not added to basket products in this time!";
            lblCash.Text = cash + " zł";
            lblTotal.Text = "0,00 zł";

            labelsOrder = new List<Label>() { lblNamePrize1, lblNamePrize2, lblNamePrize3, lblNamePrize4, lblNamePrize5 };
            basket = new Basket();
            deleteButtons = new List<Button>() { btnDelete1, btnDelete2, btnDelete3, btnDelete4, btnDelete5 };  
        }

        private void RestaurantApp_Load(object sender, EventArgs e)
        {

        }


        #region metody


        void GenerateFoodDetails(Food food)
        {
            btnAddToBasket333.Visible = false;
            lblName.Text = food.Name;
            pictureBoxDetails.ImageLocation = Application.StartupPath.Substring(0, Application.StartupPath.Length - 23) 
                + "images\\Foods\\" + food.Picture;
            lblPrize.Text = food.Prize.ToString() + " zł";
            lblDescription.Text = food.Description;
            lblIngredientsAlcohol.Text = "Ingredients: ";
            lblWeightMililiters.Text = "Weight: ";
            lblIngredients.Text = food.Ingredients;
            lblWeight.Text = food.Weight.ToString() + " grams";

            panelDrinks.Visible = true;
            panelDetails.Visible = true;

            indeksForDetails = foods.IndexOf(food);
            typeForDeatilas = food.GetType();
        }

        void GenerateDrinkDetails(Drink drink)
        {
            btnAddToBasket333.Visible = false;
            lblName.Text = drink.Name;
            pictureBoxDetails.ImageLocation = Application.StartupPath.Substring(0, Application.StartupPath.Length - 23) +
                "images\\Drinks\\" + drink.Picture;
            lblPrize.Text = drink.Prize.ToString() + " zł";
            lblDescription.Text = drink.Description;
            lblIngredientsAlcohol.Text = "Alcohol: ";
            lblWeightMililiters.Text = "Mililiters: ";
            lblWeight.Text = drink.Milliliters.ToString() + " ml";

            if(drink.Alcohol == true)
            {
                lblIngredients.Text = "Yes";
            }
            else
            {
                lblIngredients.Text = "No";
            }

            panelDrinks.Visible = true;
            panelDetails.Visible = true;

            indeksForDetails = drinks.IndexOf(drink);
            typeForDeatilas = drink.GetType();
        }

        #endregion


        #region MenuButtons

        private void btnFoods_Click(object sender, EventArgs e)
        {
            panelFoods.Visible = true;  
            panelDrinks.Visible = false;
            panelDetails.Visible = false;
            panelBasket.Visible = false;
            btnAddToBasket333.Visible = false;
            panelAboutUs.Visible = false;
        }

        private void btnDrinks_Click(object sender, EventArgs e)
        {
            panelDrinks.Visible = true;
            panelFoods.Visible = true;   //panelFoods is parrent panel, so it must be shown (visible = true or Show())
            panelDetails.Visible = false;
            panelBasket.Visible = false;
            btnAddToBasket333.Visible = true;
            panelAboutUs.Visible = false;
        }

        private void btnBasket_Click(object sender, EventArgs e)
        {
            panelDrinks.Visible = true;
            panelFoods.Visible = true;   
            panelDetails.Visible = true;
            panelBasket.Visible = true;
            btnAddToBasket333.Visible = false;
            panelAboutUs.Visible = false;
        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            panelFoods.Visible = true;
            panelDrinks.Visible = true;
            panelDetails.Visible = true;
            panelBasket.Visible = true;
            btnAddToBasket333.Visible = false;
            panelAboutUs.Visible = true;
        }

        #endregion

        #region DetailsButtons

        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelFoods.Visible = false;
            panelDrinks.Visible = false;
        }

        private void btnAddToBasketD_Click(object sender, EventArgs e)
        {
            if(typeForDeatilas.Name == "Food")
            {
                basket.AddToBasket(foods[indeksForDetails]);
                GenerateBasketView(basket.BasketProducts);
            }
            else if(typeForDeatilas.Name == "Drink")
            {
                basket.AddToBasket(drinks[indeksForDetails]);
                GenerateBasketView(basket.BasketProducts);
            }
            
        }

        #endregion


        #region FoodButtons

        private void btnDetailsF1_Click(object sender, EventArgs e)
        {
            GenerateFoodDetails(foods[0] as Food);
        }

        private void btnDetailsF2_Click(object sender, EventArgs e)
        {
            GenerateFoodDetails(foods[1] as Food);
        }

        private void btnDetailsF3_Click(object sender, EventArgs e)
        {
            GenerateFoodDetails(foods[2] as Food);
        }

        private void btnDetailsF4_Click(object sender, EventArgs e)
        {
            GenerateFoodDetails(foods[3] as Food);
        }

        private void btnDetailsF5_Click(object sender, EventArgs e)
        {
            GenerateFoodDetails(foods[4] as Food);
        }

        private void btnDetailsF6_Click(object sender, EventArgs e)
        {
            GenerateFoodDetails(foods[5] as Food);
        }

        private void btnAddToBasketF1_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(foods[0]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketF2_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(foods[1]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketF3_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(foods[2]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketF4_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(foods[3]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketF5_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(foods[4]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketF6_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(foods[5]);
            GenerateBasketView(basket.BasketProducts);
        }

        #endregion


        #region DrinkButtons

        private void btnDetailsD1_Click(object sender, EventArgs e)
        {
            GenerateDrinkDetails(drinks[0] as Drink);
        }

        private void btnDetailsD2_Click(object sender, EventArgs e)
        {
            GenerateDrinkDetails(drinks[1] as Drink);
        }

        private void btnDetailsD3_Click(object sender, EventArgs e)
        {
            GenerateDrinkDetails(drinks[2] as Drink);
        }

        private void btnDetailsD4_Click(object sender, EventArgs e)
        {
            GenerateDrinkDetails(drinks[3] as Drink);
        }

        private void btnDetailsD5_Click(object sender, EventArgs e)
        {
            GenerateDrinkDetails(drinks[4] as Drink);
        }

        private void btnDetailsD6_Click(object sender, EventArgs e)
        {
            GenerateDrinkDetails(drinks[5] as Drink);
        }

        private void btnAddToBasketD1_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(drinks[0]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketD2_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(drinks[1]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasket333_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(drinks[2]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketD4_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(drinks[3]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketD5_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(drinks[4]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnAddToBasketD6_Click(object sender, EventArgs e)
        {
            basket.AddToBasket(drinks[5]);
            GenerateBasketView(basket.BasketProducts);
        }


        #endregion

        #region DeleteButtons

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            basket.DeleteFromBasket(basket.BasketProducts[0]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            basket.DeleteFromBasket(basket.BasketProducts[1]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            basket.DeleteFromBasket(basket.BasketProducts[2]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnDelete4_Click(object sender, EventArgs e)
        {
            basket.DeleteFromBasket(basket.BasketProducts[3]);
            GenerateBasketView(basket.BasketProducts);
        }

        private void btnDelete5_Click(object sender, EventArgs e)
        {
            basket.DeleteFromBasket(basket.BasketProducts[4]);
            GenerateBasketView(basket.BasketProducts);
        }

        #endregion


        #region Basket

        void GenerateBasketView(List<Product> products)
        {
            btnBasket.BackColor = Color.LimeGreen;
            btnPurchase.Visible = true; 

            if (products.Count == 0 || products.All(a => a == null))
            {
                btnBasket.BackColor = Color.DarkOrange;
                lblNamePrize1.Text = "There are not added to basket products in this time!";
                lblCash.Text = cash + " zł";
                lblTotal.Text = "0,00 zł";
                btnPurchase.Visible = false;
            }

            for(int i = 0; i < products.Count; i++)
            {
                if(products[i] != null)
                {
                    labelsOrder[i].Text = products[i].Display + "     Quantity: " + products[i].Quantity;
                    deleteButtons[i].Visible = true;
                }
                else
                {
                    labelsOrder[i].Text = "";
                    deleteButtons[i].Visible = false;
                }
            }

            lblTotal.Text = basket.Total + " zł";
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            basket.Purchase(basket.BasketProducts, ref cash);
            GenerateBasketView(basket.BasketProducts);
        }

        #endregion

        private void panelBasket_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

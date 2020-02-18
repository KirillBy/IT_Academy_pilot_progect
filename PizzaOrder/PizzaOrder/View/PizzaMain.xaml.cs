using PizzaAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SQLite;
using System.Linq;
using PizzaOrder.Models;
using PizzaOrder.ModelView;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using PizzaOrder.Logger;
namespace PizzaOrder.View
{
    /// <summary>
    /// Interaction logic for PizzaMain.xaml
    /// </summary>
    
    public partial class PizzaMain : Window
    {
        List<Pizza> pizzasList;
        public static Pizza selectedPizza;
        public static ObservableCollection<Order> ordersList;
        public string UserEmail = null;
        public PizzaMain()
        {
            ordersList = new ObservableCollection<Order>();
            pizzasList = new List<Pizza>();
            selectedPizza = new Pizza();
            InitializeComponent();
            Logger.Logger.InitLogger();
            Logger.Logger.Log.Info("App has been started");
            ReadDataBase();
            ReadOrders();
        }
        private  double _totalPrice;

        public  double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; TotalPriceTextBlock.Text = "Total: " + value + " $"; }
        }

        void ReadOrders()
        {
            if (PizzaMain.ordersList != null)
            {
                OrderListView.ItemsSource = PizzaMain.ordersList;
                TotalPrice = PizzaMain.ordersList.Sum(_ => _.SummOfPizza);
            }
        }
        void ReadDataBase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Pizza>();
                pizzasList = conn.Table<Pizza>().ToList().OrderBy(c => c.Name).ToList();
            }
            if (pizzasList != null)
            {
                pizzaListView.ItemsSource = pizzasList;
            }
        }

        private void pizzaListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(pizzaListView.SelectedItem != null)
            {
             string selectedItem = pizzaListView.SelectedItem?.ToString();
            selectedPizza = pizzasList.FirstOrDefault(Pizza => selectedItem == Pizza.Name);
            }
           
            if(selectedPizza != null)
            {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri((selectedPizza).PhotoAdress);
            bitmap.EndInit();
            MainImage.Source = bitmap;
                PizzaNameTextBlock.Text = selectedPizza.Name;
                PizzaDescriptionTextBlock.Text = "Desription:\n" + selectedPizza.Description;
                PizzaIngredientsTextBlock.Text = "Ingredients:\n" + selectedPizza.Ingredients;
                PizzaPriceTextBlock.Text = "Small: " + selectedPizza.SmallPrice + " $\n" +
                    "Medium: " + selectedPizza.MiddlePrice + " $\n" +
                    "Big: " + selectedPizza.BigPrice + " $\n";
            }
        }

        private void FinalOrderButton_Click(object sender, RoutedEventArgs e)
        {
            UserEmail = UserEmailTextBox.Text;
            if(isValid(UserEmail))
            {
                SendEmail sendEmail = new SendEmail();
                sendEmail.Send(UserEmail);
                UserEmail = null;
                UserEmailTextBox.Text = null;

            }
            else { MessageBox.Show("Incorrect Email. Please Check it"); 
                Logger.Logger.Log.Error("Incorrect email is entered by user"); }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            TotalPrice = PizzaMain.ordersList.Sum(_ => _.SummOfPizza);
        }
        bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}

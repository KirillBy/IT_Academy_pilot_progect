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

namespace PizzaOrder.View
{
    /// <summary>
    /// Interaction logic for PizzaMain.xaml
    /// </summary>
    
    public partial class PizzaMain : Window
    {
        List<Pizza> pizzasList;
        public static Pizza selectedPizza;
        public PizzaMain()
        {
             pizzasList = new List<Pizza>();
            selectedPizza = new Pizza();
            InitializeComponent();
            
            ReadDataBase();
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
                //foreach (var c in contacts)
                //    contactListView.Items.Add(new ListViewItem()
                //    {
                //        Content = c
                //    }) ;
                pizzaListView.ItemsSource = pizzasList;
            }

            
            
        }

        private void pizzaListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChoicePizzaButton.Visibility = Visibility.Visible;
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
                    "Medium: " + Math.Round(selectedPizza.SmallPrice * Pizza.MiddleRate,2) + " $\n" +
                    "Big: " + Math.Round(selectedPizza.SmallPrice * Pizza.BigRate,2) + " $\n";
            }
           
        }

        private void ChoicePizzaButton_Click(object sender, RoutedEventArgs e)
        {
            PizzaOrderWindow pizzaOrderWindow = new PizzaOrderWindow();
            pizzaOrderWindow.ShowDialog();
        }
    }
}

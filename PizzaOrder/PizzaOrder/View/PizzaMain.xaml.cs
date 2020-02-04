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
        Pizza selectedPizza;
        public PizzaMain()
        {
             
            InitializeComponent();
            pizzasList = new List<Pizza>();
            selectedPizza = new Pizza();
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
            string selectedItem = pizzaListView.SelectedItem?.ToString();
            foreach (var item in pizzasList)
            {
                if (item.Name == selectedItem)
                    selectedPizza = item;
            }
            if(selectedPizza != null)
            {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri((selectedPizza).PhotoAdress);
            bitmap.EndInit();
            MainImage.Source = bitmap;
                PizzaNameTextBlock.Text = selectedPizza.Name;
            }
           
        }
    }
}

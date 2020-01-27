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
using PizzaAdmin.Classes;
namespace PizzaAdmin
{
    /// <summary>
    /// Interaction logic for ContactDetailWindow.xaml
    /// </summary>
    public partial class PizzaDetailWindow : Window
    {
        Pizza pizzas;
        public PizzaDetailWindow(Pizza contacts)
        {

            InitializeComponent();
            this.pizzas = contacts;
            nameTextBox.Text = this.pizzas.Name;
            descriptionTextBox.Text = this.pizzas.Description;
            ingredientsTextBox.Text = this.pizzas.Ingredients;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                pizzas.Name = nameTextBox.Text;
                pizzas.Description = descriptionTextBox.Text;
                pizzas.Ingredients = ingredientsTextBox.Text;
                connection.CreateTable<Pizza>();
                connection.Update(pizzas);
                this.Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {

                connection.CreateTable<Pizza>();
                connection.Delete(pizzas);
                this.Close();
            }
        }
    }
}

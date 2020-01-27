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

namespace PizzaAdmin
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewPizzaWindow : Window
    {
        public NewPizzaWindow()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Pizza contacts = new Pizza()
            {
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                Ingredients = ingredientsTextBox.Text
            };

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Pizza>();
                connection.Insert(contacts);
            }

            this.Close();
        }
    }
}

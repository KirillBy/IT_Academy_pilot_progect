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
        string pictureAdress = "Unfilled";
        public PizzaDetailWindow(Pizza pizza)
        {

            InitializeComponent();
            this.pizzas = pizza;
            nameTextBox.Text = this.pizzas.Name;
            descriptionTextBox.Text = this.pizzas.Description;
            ingredientsTextBox.Text = this.pizzas.Ingredients;
            priceTextBox.Text = this.pizzas.SmallPrice.ToString();
            pictureAdress = this.pizzas.PhotoAdress;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(pictureAdress);
            bitmap.EndInit();
            ImageViewerUpdate.Source = bitmap;
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

        
        private void pictureChangeButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Picture (*.png)|*.png";
            dialog.FilterIndex = 2;

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document
                pictureAdress = dialog.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(pictureAdress);
                bitmap.EndInit();
                ImageViewerUpdate.Source = bitmap;
            }
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            double priceOfPizza;
            bool correctFill = true;
            if (!double.TryParse(priceTextBox.Text, out priceOfPizza))
            {
                MessageBox.Show("Incorrect price choisen");
                correctFill = false;
            }
            if (pictureAdress.Equals("Unfilled"))
            {
                MessageBox.Show("Picture hasn't been choisen");
                correctFill = false;
            }
            if (correctFill)
            {
                using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
                {
                    pizzas.Name = nameTextBox.Text;
                    pizzas.Description = descriptionTextBox.Text;
                    pizzas.Ingredients = ingredientsTextBox.Text;
                    pizzas.PhotoAdress = pictureAdress;
                    pizzas.SmallPrice = priceOfPizza;
                    connection.CreateTable<Pizza>();
                    connection.Update(pizzas);
                    this.Close();
                }
            }
        }
    }
}

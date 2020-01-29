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

        string pictureName = "Unfilled";
        

        private void pictureChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Picture (*.png)|*.png";
            dialog.FilterIndex = 2;

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document
                pictureName = dialog.FileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(pictureName);
                bitmap.EndInit();
                ImageViewer1.Source = bitmap;
            }
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            double priceOfPizza;
            bool correctFill = true;
            if(!double.TryParse(priceTextBox.Text, out priceOfPizza))
                {
                MessageBox.Show("Incorrect price choisen");
                correctFill = false;
                }
            if(pictureName.Equals("Unfilled"))
            {
                MessageBox.Show("Picture hasn't been choisen");
                correctFill = false;
            }
            if (correctFill)
            {
                Pizza contacts = new Pizza()
                {
                    Name = nameTextBox.Text,
                    Description = descriptionTextBox.Text,
                    Ingredients = ingredientsTextBox.Text,
                    PhotoAdress = pictureName,
                    SmallPrice = priceOfPizza

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
}

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
    public partial class ContactDetailWindow : Window
    {
        Pizza contacts;
        public ContactDetailWindow(Pizza contacts)
        {

            InitializeComponent();
            this.contacts = contacts;
            nameTextBox.Text = this.contacts.Name;
            emailTextBox.Text = this.contacts.Description;
            phoneNumberTextBox.Text = this.contacts.Ingredients;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                contacts.Name = nameTextBox.Text;
                contacts.Description = emailTextBox.Text;
                contacts.Ingredients = phoneNumberTextBox.Text;
                connection.CreateTable<Pizza>();
                connection.Update(contacts);
                this.Close();
            }
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {

                connection.CreateTable<Pizza>();
                connection.Delete(contacts);
                this.Close();
            }
        }
    }
}

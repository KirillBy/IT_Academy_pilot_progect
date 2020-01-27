﻿using PizzaAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Pizza> pizzasList;
        public MainWindow()
        {

            InitializeComponent();
            pizzasList = new List<Pizza>();
            ReadDataBase();
        }

        private void newPizzaButton_Click(object sender, RoutedEventArgs e)
        {
            NewPizzaWindow newContactWindow = new NewPizzaWindow();
            newContactWindow.ShowDialog();

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
                contactListView.ItemsSource = pizzasList;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            //var filteredName = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            var filteredName = (from c2 in pizzasList
                                where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                orderby c2.Name
                                select c2).ToList();
            contactListView.ItemsSource = filteredName;
        }

        private void contactListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pizza selectedContact = (Pizza)contactListView.SelectedItem;
            if (selectedContact != null)
            {
                PizzaDetailWindow contactDetailWindow = new PizzaDetailWindow(selectedContact);
                contactDetailWindow.ShowDialog();
                ReadDataBase();
            }
        }
    }
}

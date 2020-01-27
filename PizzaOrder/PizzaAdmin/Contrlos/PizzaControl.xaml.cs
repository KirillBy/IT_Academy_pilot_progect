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
using PizzaAdmin;
namespace PizzaAdmin.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {


        public Pizza Pizzas
        {
            get { return (Pizza)GetValue(ContactsProperty); }
            set { SetValue(ContactsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for contacts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactsProperty =
            DependencyProperty.Register("Contacts", typeof(Pizza), typeof(UserControl1), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 userControl = d as UserControl1;
            if (userControl != null)
            {
                userControl.nameTextBox.Text = (e.NewValue as Pizza).Name;
                userControl.descriptionTextBox.Text = (e.NewValue as Pizza).Description;
                userControl.ingredientsTextBox.Text = (e.NewValue as Pizza).Ingredients;
                
            }



        }

        public UserControl1()
        {
            InitializeComponent();
        }


    }
}

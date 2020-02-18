using PizzaOrder.Models;
using PizzaOrder.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaOrder.ModelView
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {

      
        public Order Order
        {
            get { return (Order)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }

        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order", typeof(Order), typeof(OrderControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OrderControl userControl = d as OrderControl;
            if (userControl != null && e.NewValue != null)
            {
                userControl.nameTextBox.Text = (e.NewValue as Order).NameOfPizza;
                userControl.sizeTextBox.Text = (e.NewValue as Order).SizeOfPizza.ToString();
                userControl.numberTextBox.Text = "x" +(e.NewValue as Order).NumbersOfPizza.ToString();
                userControl.priceTextBox.Text = (e.NewValue as Order).SummOfPizza.ToString() + "$";
            }
           
        }
        public OrderControl()
        {
            InitializeComponent();
        }

        private void deletePizzaFromOrder_Click(object sender, RoutedEventArgs e)
        {
            Logger.Logger.Log.Info($"Pizza {Order.NameOfPizza} , {Order.NumbersOfPizza}" +
$", {Order.SizeOfPizza.ToString()}, {Order.SummOfPizza.ToString()} has been removed from user list");
            PizzaMain.ordersList.Remove(Order);


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
using PizzaOrder.Models;

namespace PizzaOrder.View
{
    /// <summary>
    /// Interaction logic for PizzaOrderWindow.xaml
    /// </summary>
    public partial class PizzaOrderWindow : Window
    {
       Order order = new Order();
      
        public PizzaOrderWindow()
        {
            InitializeComponent();
         
            if (PizzaMain.selectedPizza != null)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri((PizzaMain.selectedPizza).PhotoAdress);
                bitmap.EndInit();
                OrderPizzaImage.Source = bitmap;
                OrderPizzaName.Text = PizzaMain.selectedPizza.Name;
                summAndDisplayChanging();
                OrderPizzaSum.Text = order.SummOfPizza.ToString() + " $";

            }
            order.NameOfPizza = PizzaMain.selectedPizza.Name;
        
        }
        private void summAndDisplayChanging()
        {
            switch (order.SizeOfPizza)
            {
                case pizzaSize.small:
                    order.SummOfPizza = Math.Round(PizzaMain.selectedPizza.SmallPrice * order.NumbersOfPizza,2);
                    break;
                case pizzaSize.middle:
                    order.SummOfPizza = Math.Round( PizzaMain.selectedPizza.MiddlePrice * order.NumbersOfPizza,2);
                    break;
                case pizzaSize.big:
                    order.SummOfPizza = Math.Round(PizzaMain.selectedPizza.BigPrice * order.NumbersOfPizza,2);
                    break;
                default:
                    break;
            }
            OrderPizzaSum.Text = order.SummOfPizza.ToString() + " $";
        }
        private void SmallRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            order.SizeOfPizza = pizzaSize.small;
            summAndDisplayChanging();
        }

        private void MediumRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            order.SizeOfPizza = pizzaSize.middle;
            summAndDisplayChanging();
        }

        private void BigButton_Checked(object sender, RoutedEventArgs e)
        {
            order.SizeOfPizza = pizzaSize.big;
            summAndDisplayChanging();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            order.NumbersOfPizza = 1;
            summAndDisplayChanging();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            order.NumbersOfPizza = 2;
            summAndDisplayChanging();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            order.NumbersOfPizza = 3;
            summAndDisplayChanging();
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            order.NumbersOfPizza = 4;
            summAndDisplayChanging();
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            order.NumbersOfPizza = 5;
            summAndDisplayChanging();
        }

        private void OrderPizzaButton_Click(object sender, RoutedEventArgs e)
        {
            PizzaMain.ordersList.Add(order);
            Logger.Logger.Log.Info($"New Pizza {order.NameOfPizza} , {order.NumbersOfPizza}" +
                $", {order.SizeOfPizza.ToString()}, {order.SummOfPizza.ToString()} has been added to user list");
            this.Close();
            
        }
    }
}

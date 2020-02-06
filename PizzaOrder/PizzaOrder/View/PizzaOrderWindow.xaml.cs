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

namespace PizzaOrder.View
{
    /// <summary>
    /// Interaction logic for PizzaOrderWindow.xaml
    /// </summary>
    public partial class PizzaOrderWindow : Window
    {
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
                
            }
        }

    }
}

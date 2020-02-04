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

namespace PizzaView.Controls
{
    /// <summary>
    /// Interaction logic for PizzaControl.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        public Pizza Pizza
        {
            get { return (Pizza)GetValue(PizzaProperty); }
            set { SetValue(PizzaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for contacts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PizzaProperty =
            DependencyProperty.Register("Pizza", typeof(Pizza), typeof(UserControl1), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 userControl = d as UserControl1;
            if (userControl != null)
            {
                //userControl.nameTextBox.Text = (e.NewValue as Pizza).Name;
              
                //userControl.priceTextBox.Text = (e.NewValue as Pizza).SmallPrice.ToString() + "$";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri((e.NewValue as Pizza).PhotoAdress);
                bitmap.EndInit();
                userControl.ImageViewer2.Source = bitmap;
                

            }



        }

        public UserControl1()
        {
            InitializeComponent();
        }


    }
}

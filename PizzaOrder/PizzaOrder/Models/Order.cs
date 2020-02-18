using PizzaAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PizzaOrder.Models
{
    public class Order
    {
        public string NameOfPizza { get; set; }
        public pizzaSize SizeOfPizza { get;  set; }
        public sbyte NumbersOfPizza { get; set; }
        public double SummOfPizza { get;  set ; }
        
        public Order()
        {
            NumbersOfPizza = 1;
            SizeOfPizza = pizzaSize.middle;
            
        }
        public string DisplayOrder()
        {
            return NameOfPizza + $": {SizeOfPizza}, {NumbersOfPizza}. Total $: {SummOfPizza} ";
        }
    }
}

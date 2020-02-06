using PizzaAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaOrder.Models
{
    class Order
    {
        public string NameOfPizza { get; set; }
        public pizzaSize SizeOfPizza { get;  set; }
        public sbyte NumbersOfPizza { get; set; }
        public double SummOfPizza { get;  set; }
        public string DisplayOrder()
        {
            return NameOfPizza + $": {SizeOfPizza}, {NumbersOfPizza}. Total $: {SummOfPizza} ";
        }
    }
}

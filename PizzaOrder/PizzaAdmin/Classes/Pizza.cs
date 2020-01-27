using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace PizzaAdmin.Classes
{
    public class Pizza
    {
        //[PrimaryKey, AutoIncrement]
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public pizzaSize PizzaSize { get;  set; }
        public double SmallPrice { get;  set; }
        public string PhotoName { get;  set; }



        public override string ToString()
        {
            return $"{Name}";
        }

    }
}

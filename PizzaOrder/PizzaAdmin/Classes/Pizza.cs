using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace PizzaAdmin.Classes
{
    
    public class Pizza
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }     
        public double SmallPrice { get;  set; }
        public double MiddlePrice { get;  set; }
        public double BigPrice { get;  set; }

        public string PhotoAdress { get;  set; }



        public override string ToString()
        {
            return $"{Name}";
        }

    }
}

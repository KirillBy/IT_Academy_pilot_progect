using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaOrder.Models
{
    public class Client
    {
		private string _email;

		public string Email
		{
			get { return _email; }
			set { 
				_email = value; 
				if(!value.Contains('@') && !value.Contains('.') )
				{
			      
				}
			    }
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows;
using PizzaOrder.View;
namespace PizzaOrder.ModelView
{
    public class SendEmail
    {
        

        public void Send(string userEmail)
        {
            StringBuilder OrderText = new StringBuilder();
            foreach (var item in PizzaMain.ordersList)
            {
                OrderText.Append(item.NameOfPizza.ToString()).Append("      ").Append(item.NumbersOfPizza.ToString())
                    .Append("      ").Append(item.SizeOfPizza.ToString()).Append("        ").Append(item.SummOfPizza.ToString()).Append("$\n");

            }
            MailAddress from = new MailAddress("balanovichks@gmail.com", "PizzaDelivery");
            MailAddress to = new MailAddress(userEmail);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Order";
            m.Body = OrderText.ToString(); 
            m.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("balanovichks@gmail.com", "TAP YOUR PASSWORD HERE!!!!");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
                MessageBox.Show("Your order has been sent to " + userEmail);
                PizzaMain.ordersList.Clear();
                Logger.Logger.Log.Info($"Order were send to {userEmail}");
            }
            catch(System.Net.Mail.SmtpException ex)
            {
                MessageBox.Show("Error:" + ex.Message);
                Logger.Logger.Log.Error($"Order haven't been send {userEmail}");
            }
            
        }
    }
}

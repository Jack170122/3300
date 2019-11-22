using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;


namespace FoodDudeCoreConsole
{
    class FoodItem
    {
        private DateTime date_added;
        private int days_to_expiration;   //this will need to come from the "external database" 
        private DateTime date_expiration; //DTE + date_added equals date_expiration
        private string food_name;
        private int quantity;

        public FoodItem(string food_name, DateTime date_added, int quantity)
        {
            this.food_name = food_name; this.date_added = date_added; this.quantity = quantity;
            setDTE();
            setExpiration();
        }

        private void setDTE() //this method has been changed for the prototype. will be more complicated for the final product
        {
            //will need to read from a file. 
            //FileStream file = File.OpenRead("ExternalRepository.txt");
            string[] lines = System.IO.File.ReadAllLines("ExternalRepository.txt");
            foreach (var line in lines)
            {
                string[] pair = line.Split(' ');
                if (pair[0] == food_name)
                {
                    days_to_expiration = int.Parse(pair[1]);
                    return;
                }
            }
            days_to_expiration = -1;           
        }

        private void setExpiration()
        {
            date_expiration = date_added.AddDays(days_to_expiration);
        }
        
        public string getFoodName()
        {
            return food_name;
        }

        public DateTime getExpiration()
        {
            return date_expiration; 
        }
        public void DisplayFoodItem()
        {
            Console.WriteLine("\n\nName: %s\n, Quantity: %f\n, Purchase Date: ", food_name, quantity);
            Console.WriteLine(date_added);
            Console.Write("Expiration date:");
            Console.WriteLine(date_expiration);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace FoodDudeCoreConsole
{
    public class FoodItem
    {
        public DateTime date_added { get; private set; }
        public int days_to_expiration { get; private set; }   //this will need to come from the "external database" 
        public DateTime date_expiration { get; private set; } //DTE + date_added equals date_expiration
        public string food_name { get; private set; }
        public int quantity { get; private set; }

        private string path;
        string repository_path = AppDomain.CurrentDomain.BaseDirectory + "\\" + "ExternalRepository" + ".txt";

        [JsonConstructor]
        public FoodItem(DateTime date_added, int days_to_expiration, DateTime date_expiration, string food_name, int quantity, string path = "")
        {
            this.date_added = date_added;
            this.days_to_expiration = days_to_expiration;
            this.date_expiration = date_expiration;
            this.food_name = food_name;
            this.quantity = quantity;
            this.path = path;
        }
        public FoodItem(string food_name, DateTime date_added, int quantity, string path = "")
        {
            this.food_name = food_name; this.date_added = date_added; this.quantity = quantity; this.path = path;
            setDTE();
            setExpiration();
        }

        private void setDTE() //this method has been changed for the prototype. will be more complicated for the final product
        {
            //will need to read from a file. 
            //FileStream file = File.OpenRead("ExternalRepository.txt");
            string[] lines = System.IO.File.ReadAllLines(string.IsNullOrEmpty(path) ? repository_path : path);
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
            Console.WriteLine("\n\nName: {0}\nQuantity: {1}\n Purchase Date: {2}", food_name, quantity, date_added);
            Console.WriteLine("Expiration date: {0}", date_expiration);
        }
    }
}
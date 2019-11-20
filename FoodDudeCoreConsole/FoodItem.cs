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
        private
            DateTime date_added;
            int days_to_expiration; //this will need to come from the "external database" 
            DateTime date_expiration; //DTE + date_added equals date_expiration
            string food_name;
            int quantity;

        public
            FoodItem(int dte, string name, int q)
        {
            this.date_added = DateTime.Now;
            this.days_to_expiration = dte;
            this.date_expiration = date_added.AddDays(dte);
            this.food_name = name;
            this.quantity = q;
        }

        public int getDTE() //this method has been changed for the prototype. will be more complicated for the final product
        {
            //will need to read from a file. 
            FileStream file = File.OpenRead("ExternalRepository.txt");
            string line = "   ";
            var pair = line.Split(new char[] { ' ' });
            bool okl = int.TryParse(pair[1], out var val); 
        }

        public void setDTE(int dte)
        {
            this.days_to_expiration = dte;
        }

        public int getQuantity()
        {
            return this.quantity;
        }

        public void setQuantity(int q)
        {
            this.quantity = q;
        }

        }
}
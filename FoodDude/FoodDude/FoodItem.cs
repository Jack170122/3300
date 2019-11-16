using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDude
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
            FoodItem(DateTime d_a, int dte, string name, int q)
        {
            date_added = d_a;
            days_to_expiration = dte;
            date_expiration = date_added.AddDays(dte);
            food_name = name;
            quantity = q;
        }



        }
}
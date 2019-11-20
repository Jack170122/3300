﻿using System;
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
        private int days_to_expiration; //this will need to come from the "external database" 
        private DateTime date_expiration; //DTE + date_added equals date_expiration
        private string food_name;
        private int quantity;

        
        FoodItem()
        { }

        public void getDTE() //this method has been changed for the prototype. will be more complicated for the final product
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
                }
            }
            days_to_expiration = -1;           
        }

        public void setExpiration()
        {
            date_expiration = date_added + days_to_expiration;
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
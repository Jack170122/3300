using System;
using System.Collections.Generic;
using System.Text;
using System.Linq; 

namespace FoodDudeCoreConsole
{
    class FoodDirectory
    {
      
       public string name { get; private set; }
       public List<FoodItem> food_items = new List<FoodItem>();

        
       public FoodDirectory(string name)
        { this.name = name; }
       public void DisplayFoodItems()
        {
            int selection = 0;
            do
            {
                int i;
                Console.WriteLine("\n\n{0}'s Food List: ", name);
                for ( i = 0; i < food_items.Count; i++)
                {
                    Console.Write(i + 1);
                    Console.WriteLine(". {0}\n", food_items.ElementAt(i).getFoodName());
                }

                Console.WriteLine("Please input -1 to go back. 0 to add a food item or the number associated with the food item to view it.");
                selection = Int32.Parse(Console.ReadLine());

                if (selection == 0)
                {
                    AddFoodItem();
                }
                if (selection >= 1)
                {
                    food_items.ElementAt(selection - 1).DisplayFoodItem();
                }
            } while (selection != -1);

            return;
        }

        private void AddFoodItem()
        {
            Console.WriteLine("\n\nPlease input food name: ");
            string name = Console.ReadLine();

            Console.WriteLine("\n\nPlease input purchase date (assumed today for prototype): ");
            DateTime date_time = DateTime.Now;

            Console.WriteLine("\n\nPlease input purchase quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            FoodItem new_food = new FoodItem(name, date_time, quantity);

            food_items.Add(new_food);
        }
    }
}

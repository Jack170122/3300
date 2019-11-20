using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDudeCoreConsole
{
    partial class UI
    {

        public void DisplayMainMenu()

        {
            Console.WriteLine("Welcome to FoodDude!\n Please Select from the menu items:\n" +
                "1. View Directories\n2. Settings\n3. Exit");
            string line = Console.ReadLine();
            int selection = int.Parse(line);

            while (selection!=3)
            {
                if (selection == 1)
                {
                    DisplayDirectories();
                }
                else
                {
                    DisplaySettings();
                }

            }
        }

        public void DisplayDirectories()
        {

        }
        public void DisplayFoodItems()
        {

        }

        public void DisplaySettings()
        {

        }
    }

}



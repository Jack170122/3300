using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDudeCoreConsole
{
    partial class UserInterface
    {
        SavedDirectories saved_directories; 

        public UserInterface()
        {
            saved_directories = saved_directories.GetSavedDirectories();
        }

        public void Run()
        { DisplayMainMenu(); }

        public void DisplayMainMenu()
        {
            int main_menu_selection = 0;
            do
            {
                Console.WriteLine("Welcome to FoodDude!\n Please Select from the menu items:\n" +
                    "1. View Directories\n2. Settings\n3. Exit");
                string line = Console.ReadLine();
                main_menu_selection = int.Parse(line);

                if (main_menu_selection == 1)
                {
                    DisplayDirectories();
                }
                if (main_menu_selection == 2)
                {
                    DisplaySettings();
                }

            } while (main_menu_selection != 3);

            return; 
        }

        public void DisplayDirectories()
        {
            int directories_menu_selection = 0;

            do
            {
                Console.WriteLine("DIRECTORIES:");

                for (int i = 0; i < saved_directories.food_directories.Count(); i++)
                {
                    Console.Write(i + 1);
                    Console.WriteLine(saved_directories.food_directories.ElementAt(i));
                }

                Console.WriteLine("Please input -1 to return to main menu. 0 to add directory or " +
                    "the numbered directory to view contents");



            } while (directories_menu_selection != -1);
        }
        public void DisplayFoodItems()
        {

        }

        public void DisplaySettings()
        {

        }
    }

}



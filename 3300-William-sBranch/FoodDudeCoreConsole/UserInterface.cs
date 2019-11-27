using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDudeCoreConsole
{
    partial class UserInterface
    {
        SavedDirectories saved_directories = new SavedDirectories(); 

        public UserInterface()
        {
            saved_directories = SavedDirectories.GetSavedDirectories();
        }

        public void Run()
        { DisplayMainMenu(); }

        public void DisplayMainMenu()
        {
            int selection = 0;
            do
            {
                Console.WriteLine("Welcome to FoodDude!\n Please Select from the menu items:\n" +
                    "1. View Directories\n2. Settings\n3. Exit");
                selection = int.Parse(Console.ReadLine());               

                if (selection == 1)
                {
                    saved_directories.DisplayDirectories();
                }
                if (selection == 2)
                {
                    DisplaySettings();
                }

            } while (selection != 3);

            saved_directories.SaveDirectories();
            return; 
        }

        public void DisplaySettings()
        {

        }
    }

}



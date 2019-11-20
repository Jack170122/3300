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
                "1. View Directories\n2. Settings");
            string line = Console.ReadLine();
            int selection = int.Parse(line);

            switch (selection)
            {
                case 1:
                    DisplayDirectories();
                    break;
                default:
                    break;
            }
        }

        public void DisplayDirectories()
        {

        }
    }

    partial class UI {
        
    }

    partial class UI {
        
    }

    public void DisplayFoodItems()
    {

    }

    void DisplaySettings()
    {

    }
}

}



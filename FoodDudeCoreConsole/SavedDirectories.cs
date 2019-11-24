using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace FoodDudeCoreConsole
{
    [Serializable]
    class SavedDirectories
    {
        //load saved food as the program starts from a particular path
        private static string save_path = AppDomain.CurrentDomain.BaseDirectory + "\\" + "Food_Directories" + ".txt";

        public List<FoodDirectory> food_directories = new List<FoodDirectory>();

        
        public static SavedDirectories GetSavedDirectories()
        {
            if (!File.Exists(save_path))
            {
                File.Create(save_path).Dispose(); //need to dispose or else get an error later saying file is already in use
                return new SavedDirectories();
            }

            using (StreamReader stream = new StreamReader(save_path)) //using is a good way to stop leakages like leaving a file open
            {
                string json = stream.ReadToEnd();

                try
                {
                    return JsonConvert.DeserializeObject<SavedDirectories>(json); //this worked in Unity. Need to find a non unity equivalency...
                }
                catch
                { return new SavedDirectories(); }
            }
       

        }

        public void SaveDirectories() //this will save scores to file
        {
            using (StreamWriter stream = new StreamWriter(save_path))
            {
                
                string json = JsonConvert.SerializeObject(this); //format to true makes it look nice
                Console.WriteLine("Saved Directories called. Json: " + json);
                stream.Write(json);
            }
        }

        public void DisplayDirectories()
        {
            int selection = 0;

            do
            {
                Console.WriteLine("DIRECTORIES:");

                for (int i = 0; i < food_directories.Count(); i++)
                {
                    Console.Write(i + 1);
                    Console.WriteLine(". %s", food_directories[i].name);
                }

                Console.WriteLine("Please input -1 to return to main menu. 0 to add directory or " +
                    "the numbered directory to view contents");
                selection = int.Parse(Console.ReadLine());

                if (selection == 0)
                {
                    AddDirectory();
                }

                if (selection >= 1)
                {
                    food_directories.ElementAt(selection - 1).DisplayFoodItems();
                }


            } while (selection != -1);

            return; //when user selects -1 control should return back to main menu
        }

        public void AddDirectory()
        {
            Console.WriteLine("\n\nPlease input name of new directory: ");
            string name = Console.ReadLine();
            FoodDirectory new_directory = new FoodDirectory(name);
            food_directories.Add(new_directory);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;  

namespace FoodDudeCoreConsole
{
    [Serializable]
    class SavedDirectories
    {
        //load saved food as the program starts from a particular path
        private static string save_path = AppDomain.CurrentDomain.BaseDirectory;

        public List<FoodDirectory> food_directories = new List<FoodDirectory>();


        private SavedDirectories GetSavedDirectories()
        {
            /*if (!File.Exists(save_path))
            {
                File.Create(save_path).Dispose(); //need to dispose or else get an error later saying file is already in use
                return new SavedDirectories();
            }

            using (StreamReader stream = new StreamReader(save_path)) //using is a good way to stop leakages like leaving a file open
            {
                string json = stream.ReadToEnd();

                return JsonUtility.FromJson<SavedDirectories>(json); //this worked in Unity. Need to find a non unity equivalency...
            }
            */

            using (FileStream fs = File.Create(save_path))
            {
                await JsonSerializer.SerializeAsync(fs, food_directories);
            }
        }
    }
}

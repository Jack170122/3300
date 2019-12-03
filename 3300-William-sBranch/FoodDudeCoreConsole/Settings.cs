using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;


namespace FoodDudeCoreConsole
{
    class Settings
    {
        private
            int notificationDays = 1;
        bool[] daysOfWeek = new bool[7];
        string[] sortBy = new string[3];


        public Settings(int notDay, bool[] dow, string[] sb)
        {
            this.notificationDays = notDay;
            for (int i = 0; i < 7; i++)
            {
                this.daysOfWeek[i] = dow[i];
            }
            for (int j = 0; j < 3; j++)
            {
                this.sortBy[j] = sb[j];
            }


        }

        public void sendAlert()
        {
            try
            {
                StreamReader daycheck = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Last_Day" + ".txt", false);
                StreamWriter daywrite = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Last_Day" + ".txt", false);
                String d = null;
                DateTime oldDate;
                DateTime currentDate = DateTime.Today;
                FileInfo fi = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Last_Day" + ".txt");

                if (fi.Length == 0)
                {
                    //new file
                    SavedDirectories sd = SavedDirectories.GetSavedDirectories();
                    foreach (FoodDirectory list in sd.food_directories)
                    {
                        foreach (FoodItem item in list.food_items)
                        {
                            if (item.days_to_expiration <= this.notificationDays)
                            {
                                item.DisplayFoodItem();
                                Console.WriteLine(" is about to expire");
                            }
                        }
                    }
                    daywrite.WriteLine(currentDate);
                }
                else
                {
                    d = daycheck.ReadLine();
                    oldDate = DateTime.Parse(d);  //convert string to date
                    if (oldDate.Date != currentDate.Date)
                    {
                        SavedDirectories sd = SavedDirectories.GetSavedDirectories();
                        foreach (FoodDirectory list in sd.food_directories)
                        {
                            foreach (FoodItem item in list.food_items)
                            {
                                if (item.days_to_expiration <= this.notificationDays)
                                {
                                    item.DisplayFoodItem();
                                    Console.WriteLine(" is about to expire");
                                }
                            }
                        }
                    }
                    daywrite.WriteLine(currentDate);
                }
            }
            catch
            {
                Console.WriteLine("Unable to open file.");
            }


        }

        public void updateSettings(int notDay, bool[] dow, string[] sb)
        {
            this.notificationDays = notDay;
            for (int i = 0; i < 7; i++)
            {
                this.daysOfWeek[i] = dow[i];
            }
            for (int j = 0; j < 3; j++)
            {
                this.sortBy[j] = sb[j];
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.DateTime;
using SavedDirectories.cs;
using FoodItem.cs
using FoodDirectory.cs;


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
            try{
            StreamReader daycheck = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\" + "Last_Day" + ".txt", false);
            String d = null;
            DateTime oldDate;
            DateTime currentDate = DateTime.Today
            if (daycheck.FileInfo.Length == 0)
            {
                //new file
                SavedDirectories sd = SavedDirectories.GetSavedDirectories()
                foreach (FoodDirectory list in sd)
                {
                    foreach(FoodItem item in list)
                    {
                        if (item.getExpiration() <= this.notificationDays)
                        {
                            Console.WriteLine(item.DisplayFoodItem() + "is about to expire");
                        }
                    }
                }
                daycheck.WriteLine(currentDate);
            }
            else
            {
                d = daycheck.ReadLine();
                oldDate = DateTime.strptime(d);  //convert string to date
                if (oldDate.Date != currentDate.Date)
                {
                    SavedDirectories sd = SavedDirectories.GetSavedDirectories()
                foreach (FoodDirectory list in sd)
                {
                    foreach(FoodItem item in list)
                    {
                        if (item.getExpiration() <= this.notificationDays)
                        {
                            Console.WriteLine(item.DisplayFoodItem() + "is about to expire.");
                        }
                    }
                }
                }
                daycheck.WriteLine(currentDate);
            }

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
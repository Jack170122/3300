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
        /*
        private
           
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
        */
        public static void sendAlert(SavedDirectories saved_directories)
        {
            int NOTIFICATION_DAYS = 5;

            DateTime current_date_time = new DateTime();

            DateTime comparison_time = new DateTime(current_date_time.Year, current_date_time.Month, 1);

            Console.WriteLine("\n\nThe following foods will expire in {0} days: \n\n", NOTIFICATION_DAYS);

            foreach (FoodDirectory list in saved_directories.food_directories)
            {
                Console.WriteLine("\n{0}: \n", list.name);
                foreach (FoodItem item in list.food_items)
                {
                    if (item.date_expiration.Subtract(DateTime.Today).TotalDays < NOTIFICATION_DAYS)
                    {                       
                        Console.WriteLine("{0} is about to expire in {1} days\n", item.food_name, (int)item.date_expiration.Subtract(DateTime.Today).TotalDays);
                    }
                }
            }
            //daywrite.WriteLine(currentDate);

        }
        /*public void updateSettings(int notDay, bool[] dow, string[] sb)
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
        */
    }
}
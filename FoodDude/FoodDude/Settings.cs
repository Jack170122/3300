using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace FoodDude
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
            for(int i = 0; i<7; i++)
            {
                this.daysOfWeek[i] = dow[i];
            }
            for(int j = 0; j<3; j++)
            {
                this.sortBy[j] = sb[j];
            }
        }

        public void sendAlert(){
            //this function will send the alerts
        }

        public void updateSettings(int notDay, bool[] dow, string[] sb)
        {
            this.notificationDays = notDay;
            for(int i = 0; i<7; i++)
            {
                this.daysOfWeek[i] = dow[i];
            }
            for(int j = 0; j<3; j++)
            {
                this.sortBy[j] = sb[j];
            }   
        }
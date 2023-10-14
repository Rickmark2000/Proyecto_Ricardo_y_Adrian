using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Dates_Management
    {

        //¿Se podrá impedir que se tenga que acceder directamente a la posición y se podrá optimizar?
        public DateTime create_date(string time)
        {
            DateTime actual_time;

            char[] delimiter = { '-', '/' };
            string[] group_time;
            int day = 0, month = 0, year = 0, hour = 0, minute = 0, seconds = 0;
            group_time = time.Split(delimiter);

            for (int i = 0; i < group_time.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        day = Convert.ToInt32(group_time[0]);
                        break;
                    case 1:
                        month = Convert.ToInt32(group_time[1]);
                        break;
                    case 2:
                        year = Convert.ToInt32(group_time[2]);
                        break;
                    case 3:
                        hour = Convert.ToInt32(group_time[3]);
                        break;
                    case 4:
                        minute = Convert.ToInt32(group_time[4]);
                        break;
                    case 5:
                        seconds = Convert.ToInt32(group_time[5]);
                        break;
                }
            }

            actual_time = new DateTime(year, month, day, hour, minute, seconds);

            return actual_time;
        }

        //se puede optimizar. Igual mucho anidado es poco efectivo
        public bool check_dates(DateTime time_search, DateTime time)
        {
            bool check = false;
            if((time_search.Year == time.Year)&&(time_search.Month == time.Month)&&(time_search.Day == time.Day)) 
            { 
                check = true;
            }
            else
            {
                check = false;
            }

            return check;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Ricardo_y_Adrian
{
    public class Times_Management
    {
        public DateTime create_time(string time)
        {
            DateTime actual_time;

            char[] delimiter = { '-', '/' };
            string[] group_time;
            int day, month, year, hour, minute, seconds;
            group_time = time.Split(delimiter);

            day = Convert.ToInt32(group_time[0]);
            month = Convert.ToInt32(group_time[1]);
            year = Convert.ToInt32(group_time[2]);
            hour = Convert.ToInt32(group_time[3]);
            minute = Convert.ToInt32(group_time[4]);
            seconds = Convert.ToInt32(group_time[5]);

            actual_time = new DateTime(year, month, day, hour, minute, seconds);

            return actual_time;
        }

        public bool check_times(DateTime time1, DateTime time2)
        {

            return false;
        }
    }
}

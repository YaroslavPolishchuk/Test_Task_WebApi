using DB.Date.DbLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Date.Model
{
    public static class DateRange
    {
        public static List<DateLine> CheckIntersect(DateLine current, IEnumerable<DateLine> intervals)
        {
            List<DateLine> intersected=new List<DateLine>();
            foreach (var item in intervals)
            {
                if(current.FirstDate<item.LastDate && current.FirstDate > item.FirstDate)
                {
                    intersected.Add(item);
                }
            }
            return intersected;
            
        }
        
    }
}

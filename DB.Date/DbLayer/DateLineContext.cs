using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Date.DbLayer
{
    public class DateLineContext:DbContext
    {
        public DateLineContext():base ("name=DateLine")
        {
            Database.SetInitializer<DateLineContext>(new InitDB());
        }
        public DbSet<DateLine> Dates { get; set; }
    }
}

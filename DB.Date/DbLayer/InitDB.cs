using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Date.DbLayer
{
    class InitDB: DropCreateDatabaseIfModelChanges<DateLineContext>
    {
        protected override void Seed(DateLineContext context)
        {
            base.Seed(context);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Date.DbLayer
{
    public class DateLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DateLineID { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime FirstDate { get; set; }
        [Required]
        [Column(TypeName = "Date")]        
        public DateTime LastDate { get; set; }
    }
}

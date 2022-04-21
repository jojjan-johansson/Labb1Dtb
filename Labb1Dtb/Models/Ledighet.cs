using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Labb1Dtb.Models
{
    class Ledighet
    {
        [Key]
        public int FreeId { get; set; }    
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }

        public int EmployeeId { get; set; }
        public Anstallda Employee { get; set; }
    }
}

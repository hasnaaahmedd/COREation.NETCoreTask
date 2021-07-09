using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Models
{
    public class Employee
    {
        [Required]
        [Key]
        public int employeeID { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Maximum Characters are 100")]
        public string employeeName { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum Characters are 50")]
        [EmailAddress]
        public string employeeEmail { get; set; }

        [ForeignKey("Company")]
        public int companyID { get; set; }

        public Company Company { get; set; }
    }
}

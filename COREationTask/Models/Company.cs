using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COREationTask.Models
{
    public class Company
    {
        [Required]
        [Key]
        public int companyID { get; set; }

        [Required]
        [MaxLength(100,ErrorMessage ="Maximum Characters are 100")]
        public string companyName { get; set; }

        [Required]
        [Url(ErrorMessage ="Invalid URL")]
        public string companyWebSite { get; set; }

        [MaxLength(300, ErrorMessage = "Maximum Characters are 300")]
        public string companyAddress { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}

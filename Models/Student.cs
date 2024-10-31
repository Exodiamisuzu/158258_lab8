using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int UniversityCampusID { get; set; } // Navigation property
        public UniversityCampus UniversityCampus { get; set; } // Navigation property
    }
}
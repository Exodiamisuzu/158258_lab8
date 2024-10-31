using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab8.Models
{
    public class UniversityCampus
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; } // Navigation property
    }
}
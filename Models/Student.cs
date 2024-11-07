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
        [Required(ErrorMessage = "The student name cannot be blank")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Please enter a student name between 3 and 50 characters in length")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a student name beginning with a capital letter and enter only letters and spaces.")]
        [Display(Name = "Student Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The address cannot be blank")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Please enter an address between 3 and 200 characters in length")]
        [Display(Name = "Address")]
        public string Address { get; set; }
        public int UniversityCampusID { get; set; } // Navigation property
        public UniversityCampus UniversityCampus { get; set; } // Navigation property
    }
}
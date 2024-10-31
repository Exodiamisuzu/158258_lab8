using System.Collections.Generic;
using System.Web.Mvc;
using lab8.Models;

namespace lab8.ViewModels
{
    public class StudentSearchViewModel
    {
        public string SearchString { get; set; }
        public int? CampusId { get; set; }
        public List<Student> Students { get; set; }
        public SelectList Campuses { get; set; }
    }
}

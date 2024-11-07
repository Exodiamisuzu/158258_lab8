using System.Collections.Generic;
using System.Web.Mvc;
using lab8.Models;
using PagedList;

namespace lab8.ViewModels
{
    public class StudentSearchViewModel
    {
        public string SearchString { get; set; }
        public int? CampusId { get; set; }
        //public List<Student> Students { get; set; }
        public IPagedList<Student> Students { get; set; }
        public SelectList Campuses { get; set; }
        public string SortBy { get; set; } // 添加SortBy属性
        public Dictionary<string, string> SortOptions { get; set; } // 添加SortOptions属性
        public StudentSearchViewModel()
        {
            SortOptions = new Dictionary<string, string>
            {
                { "NameAsc", "Name (A-Z)" },
                { "NameDesc", "Name (Z-A)" }
            };
        }
    }
}

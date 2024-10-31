using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab8.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Display(Name="Category Name")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
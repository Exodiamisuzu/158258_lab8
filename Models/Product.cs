using System.ComponentModel.DataAnnotations;

namespace lab8.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Product Name")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
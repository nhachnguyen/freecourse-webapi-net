using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Data
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }   

        public virtual ICollection<Product> Products { get; set; }
    }
}

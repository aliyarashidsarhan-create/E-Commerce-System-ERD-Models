using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System.Model
{
    //[Index(nameof(categoryName), IsUnique = true)]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId {  get; set; }//system generate
        [Required]
        [MaxLength(100)]
        public string categoryName  { get; set; }//user input
        [MaxLength(500)]
        public string ?description { get; set; }//user input
        [MaxLength (300)]
        public string ?imageUrl { get; set; }//user input

        public ICollection<Product>Products { get; set; }= new List<Product>();//navegation
    }
}

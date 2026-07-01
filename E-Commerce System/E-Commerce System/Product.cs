using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }//system generate 
        [Required]
        [MaxLength(150)]
        public string productName { get; set; }//user input
        [MaxLength(1000)]
        public string ? description { get; set; }//user input
        [Required]
        [Range(1, 1000)]
        public decimal price { get; set; }//
        [Required]
       
        public int stockQuantity { get; set; } = 0;//user input defult 0
        [MaxLength(300)]
        public string ?imageUrl { get; set; }
        [ForeignKey(nameof(Category))]
        public int categoryId {  get; set; }//foregn key
        [Required]
        public DateTime createdAt { get; set; }//user input
        public bool isAvailable { get; set; }//defult true

    }
}

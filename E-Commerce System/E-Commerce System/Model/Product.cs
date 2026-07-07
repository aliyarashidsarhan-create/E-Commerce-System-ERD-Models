using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System.Model
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
        [Column(TypeName ="decimal(10,2")]
        [Range(0.01, double.MaxValue)]
        public decimal price { get; set; } // user input
        [Required]
        [Range(0, int.MaxValue)]
        public int stockQuantity { get; set; } = 0;//user input defult 0
        [MaxLength(300)]
        public string ?imageUrl { get; set; }
        [ForeignKey(nameof(Category))]
        public int categoryId {  get; set; }//foregn key
        [Required]
        public DateTime createdAt { get; set; }// system generated
        public bool isAvailable { get; set; } = true;//defult true

        public Category Category { get; set; }//navegation

        public ICollection<Review>Reviews { get; set; }= new List<Review>();//navegation

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}

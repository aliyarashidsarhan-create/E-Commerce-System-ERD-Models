using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System.Model
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderItemId { get; set; }// system generated

        [Range(1, 999)]
        public int quantity { get; set; } // user input

        [ForeignKey(nameof(Order))]
        public int orderId { get; set; } // foreign key

        public virtual Order Order { get; set; }//navegation


        [ForeignKey(nameof(Product))]
        public int productId { get; set; } // foreign key
        [Required]

        public virtual Product Product { get; set; }//navegation

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal unitPrice {  get; set; } //calculate price
    }
   
}

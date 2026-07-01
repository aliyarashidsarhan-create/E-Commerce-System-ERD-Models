using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    public class OrderItem
    {
        [Key ]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderItemId { get; set; }// system generated
        [ForeignKey(nameof(Order))]
        public int orderId { get; set; } // foreign key
        [ForeignKey(nameof(Product))]
        public int productId { get; set; } // foreign key
        [Required]
        [Range(1, 999)]
        public int quantity { get; set; } // user input
        public Order Order { get; set; }//navegation
        public Product Product { get; set; }//navegation

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
   public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderId {  get; set; }//system generate
        [ForeignKey(nameof(User))]
        public int userId { get; set; }//list user
        [Required]
        public DateTime orderDate { get; set; }// system generated
        [Required]
        [Range(0, double.MaxValue)]
        public decimal totalAmount { get; set; }//calculate
        [Required]
        [MaxLength(30)]
        public string status { get; set; } = "Pending";// default value
        [Required] [MaxLength(300)]
        public string shippingAddress { get; set; }//user input
        [Required]
        [MaxLength (50)]
        public string paymentMethod { get; set; }//user input

        public User User { get; set; }//navigation

        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();//navegation
    }
}

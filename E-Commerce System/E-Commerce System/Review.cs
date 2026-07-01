using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_System
{
    public  class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reviewId {  get; set; }//system generate
        [ForeignKey(nameof(User))]
        public int userId { get; set; }//list user
        [ForeignKey(nameof(Product))]
        public int productId { get; set; }//list product
        [Required]
        [Range(1, 5)]
        public int rating { get; set; }//user input
        [MaxLength(1000)]
        public string ?comment { get; set; }//user input
        [Required]
        public DateTime reviewDate { get; set; }//user input

        public Product product { get; set; }//navegation
        public User user { get; set; }//navegation
    }
}

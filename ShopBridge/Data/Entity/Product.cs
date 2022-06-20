using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Please name should have maximum 100")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Please description should have maximum 200")]
        public string Description { get; set; }
        [Required]
        [Range(minimum: 0, maximum: Int64.MaxValue, ErrorMessage = "Please Enter Valid Price")]
        public decimal Price { get; set; }

        [Required]
        [Range(minimum: 0, maximum: Int32.MaxValue, ErrorMessage = "Please Enter Valid Quantity")]
        public int Quantity { get; set; }
        [Required]
        [Range(minimum: 0, maximum: 5, ErrorMessage = "please enter valid rating")]
        public double Rating { get; set; }
    }
}

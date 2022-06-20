using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Please first name should have maximum 100")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Please last name should have maximum 100")]
        public string LastName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class User
    {
        [Required]
        [Display(Name = "Id")]
        public int IdUser { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
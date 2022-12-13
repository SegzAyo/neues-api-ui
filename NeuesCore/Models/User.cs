using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuesCore.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Country { get; set; }

        public DateTime RegisteredDate { get; set; }

        public DateTime ModifieddDate { get; set; }


    }
}


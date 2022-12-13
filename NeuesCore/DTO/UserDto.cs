using System;
using System.ComponentModel.DataAnnotations;

namespace Neues.Core.DTO
{
    public class UserDto
    {

        public string FullName { get; set; }

        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Re-enter password please")]
        [DataType(DataType.Password)]
        public string ReEnterPassword { get; set; }

        public string Country { get; set; }

    }
}


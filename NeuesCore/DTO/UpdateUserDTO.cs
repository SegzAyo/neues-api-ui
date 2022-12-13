using System;
using System.ComponentModel.DataAnnotations;

namespace Neues.Core.DTO
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Country { get; set; }
    }
}


using System;
using System.ComponentModel.DataAnnotations;

namespace Neues.Core.Models
{
    public class ForgotPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//DTO = Data Transfer Object - Encapsulate data and transfer it from one application to another

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required] //Used for validation
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
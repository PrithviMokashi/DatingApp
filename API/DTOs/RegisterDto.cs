using System.ComponentModel.DataAnnotations;
using System;

//DTO = Data Transfer Object - Encapsulate data and transfer it from one application to another

namespace API.DTOs
{
    public class RegisterDto
    {
        //Used for validation
        [Required] public string Username { get; set; }
        [Required] public string KnownAs { get; set; }
        [Required] public string Gender { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]//Length of Password
        public string Password { get; set; }

    }
}
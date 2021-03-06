using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {
        // Data Transfer Objects
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }     
    }
}
using System.ComponentModel.DataAnnotations;

namespace Sharing.Domain
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "You must specify password between 2 and 20 letters")]
        public string Password { get; set; }
    }
}

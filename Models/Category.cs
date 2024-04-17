using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MVC_assessment.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="please enter your name")]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage ="email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(10,MinimumLength =10)]
        public string Phone { get; set; }
        
        [Required(ErrorMessage ="password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirm_password { get; set; }
        public string? LinkedinUrl { get; set; }

    }
}

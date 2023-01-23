using System.ComponentModel.DataAnnotations;

namespace indigo.ViewModels
{
    public class UserLoginVM
    {
        [Required]
        public string UsernameorEmail{ get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

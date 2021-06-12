using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Enter User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter User Password")]
        public string UserPassword { get; set; }

    }
}

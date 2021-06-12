using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC.Models
{
    public class User
    {
        /// <summary>
        ///  User Number
        /// </summary>
        [Key] // Make it PK
        public int UserNo { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        [Required(ErrorMessage ="Please Enter User Name")] // Not Null
        public string UserName { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// User Password
        /// </summary>
        [Required]
        public string UserPassword { get; set; }
    }
}

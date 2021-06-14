using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetNote.MVC.Models
{
    public class Note
    {
        /// <summary>
        ///  Note Number
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        /// <summary>
        /// Note Title
        /// </summary>
        [Required(ErrorMessage ="Please Type the Title")]
        public string NoteTitle { get; set; }

        /// <summary>
        /// Note Content
        /// </summary>
        [Required]
        public string NoteContents { get; set; }
        
        /// <summary>
        /// User Number
        /// </summary>
        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; } // Virtual - for lazy loading
    }
}

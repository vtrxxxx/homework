using System.ComponentModel.DataAnnotations;

namespace hw11.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display (Name = "Note Name")]

        public string? Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Content { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [RegularExpression(@"^#[\w\d\s]+$", ErrorMessage = "Tag must start with '#' and contain only letters, digits, or spaces.")]
        [Display(Name = "Tag")]
        public string? Tag { get; set; }


    }
}

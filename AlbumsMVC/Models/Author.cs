using System.ComponentModel.DataAnnotations;

namespace AlbumsMVC.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name = "Author Name")]
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        [Display(Name = "Image")]

        public string ImageURL { get; set; }
    }
}
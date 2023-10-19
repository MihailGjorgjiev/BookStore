using AlbumsMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(0,5000)]
        public decimal Price { get; set; }
        [Display(Name = "Image")]
        public string BookImageUrl { get; set; }
        [Display(Name ="Quantity in Stock")]
        
        public int Quantity { get; set; }
        public Genre Genre { get; set; }
        public Author Author { get; set; }
        
        
    }
}
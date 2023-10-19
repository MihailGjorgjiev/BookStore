﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumsMVC.Models
{
    public class Genre
    {
        [Display(Name = "Id")]     
        public int GenreId { get; set; }
        [Display(Name = "Genre Name")]
        public string Name { get; set; }
        
        public List<Book> Books { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        [Display(Name = "Book")]
        public Book Book { get; set; }
        [Required]
        public string UserId { get; set; }
        [Display(Name = "Client")]
        [Required]
        public ApplicationUser User { get; set; }
        [Display(Name ="Date Of Purchase")]
        [Required]
        public DateTime DateOfPurchase { get; set; }
    }
}
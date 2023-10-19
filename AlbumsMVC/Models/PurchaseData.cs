using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class PurchaseData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }
        [Required]
        [Display(Name = "Name and Surname")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "CVV")]
        public string CVV { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }
        [Required]
        [Display(Name = "Delivery Address")]
        public string Address { get; set; }
    }
}
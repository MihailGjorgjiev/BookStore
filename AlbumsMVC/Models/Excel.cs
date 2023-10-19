using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class Excel
    {
        public string BookTitle { get; set; }
        public string Email { get; set; }
        public DateTime TimeOfPurchase { get; set; }
        public decimal Price { get; set; }
    }
}
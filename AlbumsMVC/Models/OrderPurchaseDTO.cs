using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbumsMVC.Models
{
    public class OrderPurchaseDTO
    {
        public Order Order { get; set; }
        public PurchaseData PurchaseData { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace prjMVCCoreDemo.Models
{
    public partial class TShoppingCart
    {
        public int FId { get; set; }
        public string FDate { get; set; }
        public int? FCustomerId { get; set; }
        public int? FProductId { get; set; }
        public decimal? FPrice { get; set; }
        public int? FCount { get; set; }
    }
}

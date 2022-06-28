using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prjMVCCoreDemo.Models
{
    public partial class TProduct
    {
        public int FId { get; set; }
        [DisplayName("產品名稱")]
        public string FName { get; set; }
        [DisplayName("產品成本")]
        public decimal? FCost { get; set; }
        [DisplayName("庫存量")]
        public int? FQty { get; set; }
        [DisplayName("產品單價")]
        public decimal? FPrice { get; set; }
        public string FImagePath { get; set; }
    }
}

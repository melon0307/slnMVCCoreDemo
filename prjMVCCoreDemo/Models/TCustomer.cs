using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace prjMVCCoreDemo.Models
{
    public partial class TCustomer
    {
        public int FId { get; set; }
        [DisplayName("客戶姓名")]
        public string FName { get; set; }
        [DisplayName("電話號碼")]
        public string FPhone { get; set; }
        [DisplayName("電子郵件")]
        public string FEmail { get; set; }
        [DisplayName("住址")]
        public string FAddress { get; set; }
        [DisplayName("密碼")]
        public string FPassword { get; set; }
    }
}

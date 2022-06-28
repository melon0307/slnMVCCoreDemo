using Microsoft.AspNetCore.Http;
using prjMVCCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjMVCCoreDemo.ViewModels
{
    public class CProductViewModel
    {
        private TProduct _prod;

        public CProductViewModel()
        {
            _prod = new TProduct();
        }
        
        public TProduct product
        {
            get { return _prod; }
            set { _prod = value; }
        }
        public int FId
        { 
            get { return _prod.FId; }
            set { _prod.FId = value; }
        }
        
        public string FName
        {
            get { return _prod.FName; }
            set { _prod.FName = value; }
        }

        public decimal? FCost
        {
            get { return _prod.FCost; }
            set { _prod.FCost = value; }
        }

        public int? FQty
        {
            get { return _prod.FQty; }
            set { _prod.FQty = value; }
        }

        public decimal? FPrice
        {
            get { return _prod.FPrice; }
            set { _prod.FPrice = value; }
        }

        public string FImagePath
        {
            get { return _prod.FImagePath; }
            set { _prod.FImagePath = value; }
        }

        public IFormFile photo { get; set; }
    }
}

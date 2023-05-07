using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaiWebNangCao.Models;

namespace BaiWebNangCao.Models
{
    public class Cart
    {
        public int productID { get; set; }
        public int quantity { get; set; }
        public Product productDetail { get; set; }
    }
}
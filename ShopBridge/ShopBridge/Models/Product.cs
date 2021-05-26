using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class ProductMaster
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ItemNumer { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<bool> Isdeleted { get; set; }
    }
}
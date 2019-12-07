using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetCoders.Model.Model;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoders.Models
{
    public class SalesView
    {

        public SalesView()
        {
            SalesProductInfo = new SalesProductInfo();
            SalesInfos = new List<SalesInfo>();
            Customer = new Customer();
            Product = new Product();
            Category = new Category();
            ProductSelectListItems = new List<SelectListItem>();
        }



        //selfproperty
        public Customer Customer { get; set; }
        public List<SelectListItem> CustomerSelectListItems { get; set; }
        public Category Category { get; set; }
        public List<SelectListItem> CategorySelectListItems { get; set; }
        public Product Product { get; set; }
        public List<SelectListItem> ProductSelectListItems { get; set; }
        public int AvailableQuantity { get; set; }
        public double TotalMRP { get; set; }
        public double GrantTotal { get; set; }
        public int Discount { get; set; }
        public double PayableAmount { get; set; }
        public int LoyaltyPoint { get; set; }

        public double DiscountAmount { get; set; }
        //Sales property
        [Required]

        public SalesInfo SalesInfo { get; set; }

        //Salesproduct property


        public List<SalesInfo> SalesInfos { get; set; }

        public SalesProductInfo SalesProductInfo { get; set; }





    }
}
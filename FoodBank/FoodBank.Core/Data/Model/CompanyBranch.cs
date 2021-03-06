﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodBank.Core.Data.Enum;

namespace FoodBank.Core.Data.Model
{
    public class CompanyBranch
    {
        public CompanyBranch()
        {
            Listings = new List<Listing>();
            CompanyUsers = new List<CompanyUser>();
            SellOrders = new List<Order>();
            BuyOrders = new List<Order>();
        }

        public Guid CompanyBranchId { get; set; }
        public string CompanyBranchName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string TownCity { get; set; }
        public County County { get; set; }
        public string PostCode { get; set; }

        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmailAddress { get; set; }

        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<CompanyUser> CompanyUsers { get; set; }
        public virtual ICollection<Listing> Listings { get; set; }

       
        public virtual ICollection<Order> SellOrders { get; set; }

        [InverseProperty("CustomerId")]
        public virtual ICollection<Order> BuyOrders { get; set; }
    }
}

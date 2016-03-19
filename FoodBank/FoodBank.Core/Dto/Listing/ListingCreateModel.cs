﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBank.Core.Dto.Listing
{
    public class ListingCreateModel
    {
        public string ListingName { get; set; }
        public string SupplierReference { get; set; }   
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public DateTime? UseByDate { get; set; }
        public Guid SupplierBranchId  { get; set; }
    }
}
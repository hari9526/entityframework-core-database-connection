using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseConnectionEntityFrameworkCore.DataDB
{
    public partial class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public long OrderMasterId { get; set; }
        public int FoodItemId { get; set; }
        public decimal FoodItemPrice { get; set; }
        public int Quantity { get; set; }

        public virtual FoodItem FoodItem { get; set; }
        public virtual OrderMaster OrderMaster { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseConnectionEntityFrameworkCore.DataDB
{
    public partial class FoodItem
    {
        public FoodItem()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int FoodItemId { get; set; }
        public string FoodItemName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

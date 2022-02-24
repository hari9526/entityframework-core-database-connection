using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseConnectionEntityFrameworkCore.DataDB
{
    public partial class OrderMaster
    {
        public OrderMaster()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long OrderMasterId { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string Pmethod { get; set; }
        public decimal Gtotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

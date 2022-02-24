using System;
using System.Collections.Generic;

#nullable disable

namespace DatabaseConnectionEntityFrameworkCore.DataDB
{
    public partial class Customer
    {
        public Customer()
        {
            OrderMasters = new HashSet<OrderMaster>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public virtual ICollection<OrderMaster> OrderMasters { get; set; }
    }
}

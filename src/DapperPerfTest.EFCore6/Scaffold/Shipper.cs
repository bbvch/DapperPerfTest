using System.Collections.Generic;

namespace DapperPerfTest.EFCore6.Scaffold
{
    public partial class Shipper
    {
        public Shipper()
        {
            this.Orders = new HashSet<Order>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

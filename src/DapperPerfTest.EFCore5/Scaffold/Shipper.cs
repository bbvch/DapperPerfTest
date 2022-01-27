using System.Collections.Generic;

#nullable disable

namespace DapperPerfTest.EFCore5.Scaffold
{
    public partial class Shipper
    {
        public Shipper()
        {
            this.Orders = new HashSet<Order>();
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

using System.Collections.Generic;

namespace DapperPerfTest.EFCore6.Scaffold
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            this.Customers = new HashSet<Customer>();
        }

        public string CustomerTypeId { get; set; } = null!;
        public string? CustomerDesc { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

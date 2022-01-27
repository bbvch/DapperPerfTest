using System.Collections.Generic;

#nullable disable

namespace DapperPerfTest.EFCore5.Scaffold
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            this.CustomerCustomerDemos = new HashSet<CustomerCustomerDemo>();
        }

        public string CustomerTypeId { get; set; }
        public string CustomerDesc { get; set; }

        public virtual ICollection<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
    }
}

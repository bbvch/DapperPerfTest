using System.Collections.Generic;

#nullable disable

namespace DapperPerfTest.EFCore5.Scaffold
{
    public partial class Region
    {
        public Region()
        {
            this.Territories = new HashSet<Territory>();
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }
    }
}

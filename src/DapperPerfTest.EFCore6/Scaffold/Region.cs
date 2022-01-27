using System.Collections.Generic;

namespace DapperPerfTest.EFCore6.Scaffold
{
    public partial class Region
    {
        public Region()
        {
            this.Territories = new HashSet<Territory>();
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; } = null!;

        public virtual ICollection<Territory> Territories { get; set; }
    }
}

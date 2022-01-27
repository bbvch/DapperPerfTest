using System.Collections.Generic;

#nullable disable

namespace DapperPerfTest.EFCore5.Scaffold
{
    public partial class Territory
    {
        public Territory()
        {
            this.EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        public string TerritoryId { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}

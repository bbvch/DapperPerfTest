#nullable disable

namespace DapperPerfTest.EFCore5.Scaffold
{
    public partial class ProductsByCategory
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public short? UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}

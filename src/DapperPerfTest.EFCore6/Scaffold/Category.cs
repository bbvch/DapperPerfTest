using System.Collections.Generic;

namespace DapperPerfTest.EFCore6.Scaffold
{
    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

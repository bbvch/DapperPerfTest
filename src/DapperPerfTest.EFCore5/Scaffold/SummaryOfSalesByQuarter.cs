using System;

#nullable disable

namespace DapperPerfTest.EFCore5.Scaffold
{
    public partial class SummaryOfSalesByQuarter
    {
        public DateTime? ShippedDate { get; set; }
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}

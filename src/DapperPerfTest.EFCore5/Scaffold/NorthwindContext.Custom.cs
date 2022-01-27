using Microsoft.EntityFrameworkCore;

namespace DapperPerfTest.EFCore5.Scaffold
{
    public partial class NorthwindContext
    {
        public virtual DbSet<DbResult<int>> IntResult { get; set; }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbResult<int>>()
                .HasNoKey()
                .Property(_ => _.Value);
        }
    }
}

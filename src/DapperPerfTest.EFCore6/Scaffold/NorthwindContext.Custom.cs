using Microsoft.EntityFrameworkCore;

namespace DapperPerfTest.EFCore6.Scaffold
{
    public partial class NorthwindContext
    {
        public virtual DbSet<DbResult<int>> IntResult { get; set; } = null!;

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbResult<int>>()
                .HasNoKey()
                .Property(_ => _.Value);
        }
    }
}

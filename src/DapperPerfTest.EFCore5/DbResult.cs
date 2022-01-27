namespace DapperPerfTest.EFCore5
{
    public class DbResult<T>
        where T : struct
    {
        public DbResult(T value)
        {
            this.Value = value;
        }

        public T Value { get; }
    }
}

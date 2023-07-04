namespace LibraryManagement.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=library_mgmt;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<Book> Books { get; set; }
    }
}

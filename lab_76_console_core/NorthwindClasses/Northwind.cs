using Microsoft.EntityFrameworkCore;

namespace lab_76_console_core
{
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "../data/Northwind.db");
            // use SQLite
             optionsBuilder.UseSqlite($"Filename={"C:/Data/Northwind.db"}");
            // use SQL
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;"
            //    + "Initial Catalog=Northwind;"
            //    + "Integrated Security=true;"
            //    + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
            // filter out discontinued products
            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.Discontinued);
        }
    }
}

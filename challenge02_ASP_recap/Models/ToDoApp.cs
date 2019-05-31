using Microsoft.EntityFrameworkCore;

namespace challenge02_ASP_recap.Models
{
    public class ToDoApp : DbContext
    {
        public ToDoApp() { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "ToDO.db");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;" + "Initial Catalog=ToDo;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

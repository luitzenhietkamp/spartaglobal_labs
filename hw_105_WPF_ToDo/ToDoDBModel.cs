namespace hw_105_WPF_ToDo
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ToDoDBModel : DbContext
    {
        public ToDoDBModel()
            : base("name=ToDoDBModel")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

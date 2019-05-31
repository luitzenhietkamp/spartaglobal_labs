using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace hw_108_ASP_Core_Challenge.Models
{
    public class ChallengeDB : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public ChallengeDB() { }

        public ChallengeDB(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "ChallengeDB.db");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;" + "Initial Catalog=ChallengeDB;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

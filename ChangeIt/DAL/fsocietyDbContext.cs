using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Windows.Storage;

namespace ChangeIt.DAL
{
    public class fsocietyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = ApplicationData.Current.LocalFolder.Path + "\\fsociety.db";
            optionsBuilder.UseSqlite("FileName=" + dbPath);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

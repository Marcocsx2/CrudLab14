using CrudXamarinLab14.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrudXamarinLab14
{
    public class DatabaseContext: DbContext
    {
        public DbSet<PersonModel> People { get; set; }
        public DatabaseContext()
        {
            this.Database.EnsureCreated();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "person.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}

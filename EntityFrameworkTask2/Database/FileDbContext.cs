using EntityFrameworkTask2.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTask2.Database
{
    public class FileDbContext : DbContext
    {
        public DbSet<FileInfomation> FileInfomations { get; set; }

        public DbSet<Folder> Folders { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=FileInfomations;Trusted_Connection=True;");

    }
}

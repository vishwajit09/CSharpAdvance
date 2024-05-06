using EntityFrameworkProject.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject.Database
{
    internal class BookContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=Books;Trusted_Connection=True;");

    }
}

using EntityFrameworkProject.Database;
using EntityFrameworkProject.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var dbContext = new BookContext();

            var page = new Page(1, "Cinderalla");
            dbContext.Pages.Add(page);
            dbContext.SaveChanges();

            dbContext.Remove(dbContext.Pages.Where(x => x.Content == "Cinderalla").FirstOrDefault());
            dbContext.SaveChanges();
        }
    }
}

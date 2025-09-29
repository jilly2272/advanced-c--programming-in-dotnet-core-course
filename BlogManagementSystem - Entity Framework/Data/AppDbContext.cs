//Defines the DbContext class responsible for interacting with the database. It includes DbSet properties for both Blog and Comment entities and specifies the database connection string.

using BlogManagementSystem___Entity_Framework.Model;
using Microsoft.EntityFrameworkCore;
namespace BlogManagementSystem___Entity_Framework.Data;

public class AppDbContext: DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = "";
        while (string.IsNullOrEmpty(path))
        {
            Console.WriteLine("Input path of database location you would like to access/create:");
            path = Console.ReadLine();
        }
        
        optionsBuilder.UseJet($"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={path}")
            .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }
}
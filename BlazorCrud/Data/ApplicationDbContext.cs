using BlazorCrud.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
namespace BlazorCrud.Data

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Libro> Libro { get; set; }
    }
}

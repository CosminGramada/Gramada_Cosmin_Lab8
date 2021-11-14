using Microsoft.EntityFrameworkCore;
using Gramada_Cosmin_Lab8.Models;

namespace Gramada_Cosmin_Lab8.Data
{
    public class Gramada_Cosmin_Lab8Context : DbContext
    {
        public Gramada_Cosmin_Lab8Context (DbContextOptions<Gramada_Cosmin_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Publisher> Publisher { get; set; }

        public DbSet<Gramada_Cosmin_Lab8.Models.Category> Category { get; set; }
    }
}

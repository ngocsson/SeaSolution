using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace App.SeaSolution.Data.Data
{
    public class SeaSolutionContext : DbContext
    {
        public SeaSolutionContext(DbContextOptions<SeaSolutionContext> option) : base (option)
        {
        }

        #region DbSet
        public DbSet<Customers> Cutomers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        #endregion
    }
}

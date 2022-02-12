using Microsoft.EntityFrameworkCore;
using DAL.Entities;



namespace DAL
{
    public class MyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<SalesPoint> SalesPoints { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Sale> Sales { get; set; }


        public MyContext(DbContextOptions options) : base(options)
        {
            
        }
    }


}

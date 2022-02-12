using Microsoft.EntityFrameworkCore;



namespace DAL
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions options) : base(options)
        {

        }
    }


}

using Microsoft.EntityFrameworkCore;

namespace WebAppSano.Models
{
    public class AppDb : DbContext
    {

        //add uodate remove
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HDC3-L-94S8B54;Initial catalog=db_sano;Integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<UsersModel> tblusers { get; set; }  // table
        public DbSet<ProductsModel> tblproducts { get; set; }  // table
    }
}

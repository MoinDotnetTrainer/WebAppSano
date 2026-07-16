using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusinessLogic.Models
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> values) : base(values) { }  // connection

        public DbSet<ProductsModel> productsModels { get; set; } // table
    }
}

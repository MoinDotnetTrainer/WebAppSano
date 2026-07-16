using Microsoft.EntityFrameworkCore;
using ServiceBusinessLogic.IRepo;
using ServiceBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusinessLogic.RepoBl
{
    public class ProductsBl : IProducts
    {
        public readonly AppDb _db;
        public ProductsBl(AppDb db)
        {
            _db = db;
        }

        public async Task AddProducts(ProductsModel data)
        {
            await _db.productsModels.AddAsync(data);
            await _db.SaveChangesAsync();
        }


        public async Task<IList<ProductsModel>> GetProducts()
        {
            return await _db.productsModels.ToListAsync();
        }

        public async Task<ProductsModel> GetProductsByID(int ID)
        {
            return await _db.productsModels
                            .FirstOrDefaultAsync(p => p.ID == ID);
        }
        public async Task UpdateProduct(ProductsModel product)
        {
            _db.productsModels.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _db.productsModels.FindAsync(id);

            if (product != null)
            {
                _db.productsModels.Remove(product);
                await _db.SaveChangesAsync();
            }
        }


    }
}

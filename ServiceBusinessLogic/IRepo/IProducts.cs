using ServiceBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusinessLogic.IRepo
{
    public interface IProducts
    {
        Task AddProducts(ProductsModel data);  // abstrct method --> decleation impl

        Task<IList<ProductsModel>> GetProducts();

        Task<ProductsModel> GetProductsByID(int ID);

        Task UpdateProduct(ProductsModel product);
        Task DeleteProduct(int id);
    }
}

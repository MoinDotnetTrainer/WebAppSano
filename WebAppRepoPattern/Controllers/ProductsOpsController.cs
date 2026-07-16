using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceBusinessLogic.IRepo;
using ServiceBusinessLogic.Models;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAppRepoPattern.Controllers
{
    public class ProductsOpsController : Controller
    {

        public readonly IProducts _ipro;
        public ProductsOpsController(IProducts ipro)
        {
            _ipro = ipro;
        }

        [HttpGet]
        public IActionResult InsertProducts()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertProducts(ProductsModel data)
        {
            await _ipro.AddProducts(data);
            return RedirectToAction("GetProductsData");
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsData()
        {

            return View(await _ipro.GetProducts());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int ID)
        {
            var res = await _ipro.GetProductsByID(ID);

            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductsModel data)
        {
            await _ipro.UpdateProduct(data);
            return RedirectToAction("GetProductsData");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {

            var res = await _ipro.GetProductsByID(ID);

            return View(res);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int ID)
        {

            await _ipro.DeleteProduct(ID);
            return RedirectToAction("GetProductsData");
        }
    }
}

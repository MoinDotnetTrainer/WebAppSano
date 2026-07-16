using Microsoft.AspNetCore.Mvc;
using WebAppSano.Models;

namespace WebAppSano.Controllers
{
    public class UsersOpsController : Controller
    {

        public AppDb db;
        public UsersOpsController()
        {
            db = new AppDb();
        }

        [HttpGet]
        public IActionResult InsertUsers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertUsers(UsersModel data)
        {

            // db Insert Business Logic
            // Ef core
            db.tblusers.Add(data);  // 
            db.SaveChanges(); //
            return View();
        }


        [HttpGet]
        public IActionResult DisplayUsers()
        {
            var res = from s in db.tblusers select s;
            return View(res);
        }

    }
}

using DALL.DataAcessLayer;
using DALL.Repositry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TestInterview.Models;

namespace TestInterview.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public async Task<ActionResult> RegisterNew()
        {
            return  View();
        }
        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return  View();
        }



        [HttpPost]
        public async Task<ActionResult> RegisterNew(User user)
        {
            if (user == null) return View("Login");
            var cmd = new Commander<User>();
            if (!(await IsExist(user.userName)))
            { 
                await cmd.AddNewUser(user);
                return View("Login");
            }
            TempData["msg"] = "User Name already exist";
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            if (user == null) return View("Login");
            var cmd = new Commander<User>();
            if ((await IsLogin(user.userName,user.password)))
            {
                var user1 =await cmd.GetById(x => x.userName == user.userName && x.password == user.password);
                Session["userId"] = user1.Id;
                return RedirectToAction("Index", "Home");
            }
            return View("Login");

        }

        public async Task<bool>  IsExist(string userName)
        {
            var cmd = new Commander<User>();
            var old =await  cmd.Getby(x => x.userName == userName);
            return   old.Count()!=0;
        }

        public async Task<bool> IsLogin(string userName,string password)
        {
            var cmd = new Commander<User>();
            var user = await cmd.Getby(x => x.userName == userName&& x.password==password);
             
            return user.Count() != 0 ;
        }

        [HttpGet]

      
         public ActionResult ChangePassword()
        {
            return  View();
        }
        [HttpPost]
        public async Task <ActionResult> ChangePassword(ChangePasswordVM user)
        {
            if (!ModelState.IsValid)
            {
                TempData["msg"] = "Password Mismatch";

                return View();
            }
            int id = Convert.ToInt32(Session["userId"]);
            var cmd = new Commander<User>();
            var oldPassword =(await cmd.Getby(x => x.password == user.oldPassword)).FirstOrDefault();
            TempData["msg"] = "Faild";
            if (oldPassword == null) return RedirectToAction("Index", "Home");

            if (Session["userId"] != null)
            {

           

                var userUpdate =await cmd.GetById(x => x.Id == id);
                userUpdate.password = user.newPassword;
                 await cmd.UpdatePassword(userUpdate);
                TempData["msg"] = "Success";
                return RedirectToAction("Index", "Home");

            }

            return View();
             
        }


    }
}
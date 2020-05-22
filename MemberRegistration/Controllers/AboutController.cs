using MemberRegistration.Data.Models;
using MemberRegistration.Extention;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace MemberRegistration.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var user = HttpContext.Session.Get<Users>("Oturum");
            if (user == null) //kullanıcının session değeri yok ise giriş yapsın
            {
                return RedirectToAction("Index", "Login");
            }

            var db = new MemberRegistrationContext();
            var userDB = db.Users.FirstOrDefault(u => u.UserId == user.UserId);
            return View(userDB);


        }


    }
}
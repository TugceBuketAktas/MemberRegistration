using MemberRegistration.Data.Models;
using MemberRegistration.Extention;
using MemberRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MemberRegistration.Controllers
{
    public class LoginController : Controller
    {

        private readonly MemberRegistrationContext _context;
        public LoginController(MemberRegistrationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }


        [HttpPost]
        //FromForm modelimizi nereden çağırdığımızı söylüyoruz
        public IActionResult Index([FromForm]LoginModel loginModel)
        {
            var user = _context.Users.Where(p => p.UserUsername == loginModel.user_username && p.UserPasswd == loginModel.user_passwd).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Message = "Böyle bir kullanıcı yok.";
                return View();
            }
            else
            {
                //HttpContext.Session.SetString("OturumId", user.UserUsername);
                HttpContext.Session.Set<Users>("Oturum", user); //kullanıcıyı artık bir yerlere gönderebiliriz.
                return RedirectToAction("Index", "About");
            }

        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var username = _context.Users.Where(p => p.UserUsername == model.UserUsername).FirstOrDefault();
                if (username != null)
                {
                    ViewBag.Message = "Böyle bir kullanıcı var başka bir kullanıcı adı giriniz.";
                    return View();
                }
                else
                {

                    Users user = new Users
                    {

                        UserEmail = model.UserEmail,
                        UserFullname = model.UserFullname,
                        UserPasswd = model.UserPasswd,
                        UserUsername = model.UserUsername,
                        UserJob = model.UserJob,
                        UserPhone = model.UserPhone,
                        UserCity = model.UserCity,
                        UserNeighborhood = model.UserNeighborhood,
                    };
                    _context.Add(user);
                    await _context.SaveChangesAsync();

                }
            }

            return RedirectToAction(nameof(LoginController.Index), "Login");

        }

    }
}
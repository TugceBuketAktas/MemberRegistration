using MemberRegistration.Data.Models;
using MemberRegistration.Extention;
using MemberRegistration.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MemberRegistration.Controllers
{
    [AdminSessionFilter]
    public class AdminController : Controller
    {
        private readonly MemberRegistrationContext _context;
        public AdminController(MemberRegistrationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Users);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var session = HttpContext.Session.Get<Users>("Oturum");
            if (session != null && session.UserPermission == true)
            {
                if (session.UserId == id)
                {
                    return RedirectToAction(nameof(Index));

                }
                var user = await _context.Users.FindAsync(id);
                _context.Users.Remove(user);
                _context.SaveChanges();

                return RedirectToAction("Index","Admin");

            }
           
            return View();
        }


    }
}
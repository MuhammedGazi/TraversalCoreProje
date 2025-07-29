using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactUsManager contactUsManager = new ContactUsManager(new EfContactUsDal());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager=new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            destinationManager.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var value=destinationManager.TGetByID(id);
            destinationManager.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Updatedestination(int id)
        {
            var value = destinationManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Updatedestination(Destination p)
        {
            destinationManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}

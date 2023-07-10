using Microsoft.AspNetCore.Mvc;
using MvcCoreTutorial.Models.Domain;

namespace MvcCoreTutorial.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public PersonController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public IActionResult Index()
        {
            ViewBag.greeting = "View Bag";
            ViewData["greeting2"] = "View Data";
            TempData["greeting3"] = "Temp Data";
            return View();
        }

        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _databaseContext.Person.Add(person);
                _databaseContext.SaveChanges();
                return RedirectToAction("DisplayPerson");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could Not Add";
                throw;
            }

            return View();
        }

        public IActionResult DisplayPerson()
        {
            var person = _databaseContext.Person.ToList();
            return View(person);
        }
        public IActionResult EditPerson(int id)
        {
            var person = _databaseContext.Person.Find(id);
            return View(person);
        }

        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _databaseContext.Person.Update(person);
                _databaseContext.SaveChanges();
                TempData["msg"] = "Success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could Not Update";
                throw;
            }

            return RedirectToAction("DisplayPerson");
        }

        public IActionResult DeletePerson(int id) 
        {
            
            try
            {
                var person = _databaseContext.Person.Find(id);
                if(person != null)
                {
                    _databaseContext.Person.Remove(person);
                    _databaseContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("DisplayPerson");
        }
    }
}

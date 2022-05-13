using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Logica;
using BusinessLogic.Container;
using DataAccess;
using HoveniersAdministratieASP2.Models;

namespace HoveniersAdministratieASP2.Controllers
{
    public class LoginController : Controller
    {
        private GebruikerContainer gc = new GebruikerContainer(new GebruikerDAL());
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                Gebruiker g = gc.FindByUserNameAndPassword(loginVM.Gebruikersnaam, loginVM.Wachtwoord);
                if (g == null)
                {
                    return Content("Gebruikersnaam of wachtwoord ongeldig");
                }
                else
                {
                    return RedirectToAction("Index", "ManagerHome");
                }
            }
            return Content("Niet alle velden zijn gevuld");
        }
    }
}

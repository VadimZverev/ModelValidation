using ModelValidation.Models;
using System;
using System.Web.Mvc;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if (ModelState.IsValid)
            {
                // инструкции для хранения нового Appointment
                // в репозитории будут идти здесь в реальном проекте

                return View("Completed", appt);
            }
            else
            {
                return View();
            }

        }
    }
}
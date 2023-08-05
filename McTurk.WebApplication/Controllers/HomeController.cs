using McTurk.WebApp.Models;
using McTurk.Business.Service;
using McTurk.DataAccess;
using McTurk.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace McTurk.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppointmentService _appointmentService = new();
        private readonly McTurkContext _context = new();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult randevuolustur()
        {
            return View();
        }
        [HttpPost]
        public IActionResult randevuolustur(int id)
        {
            try
            {
                var vehicleResult = new Vehicle();
                vehicleResult.PlateNumber = Request.Form["spnPlateNumber"];
                vehicleResult.RegistrationDate = Convert.ToDateTime(Request.Form["spnDate"]);
                vehicleResult.RegistrationNumber = Request.Form["spnNum"];
                _context.Vehicles.Add(vehicleResult);

                var vehicleTypeResult = new VehicleType();
                vehicleTypeResult.Name = Request.Form["rdwhose"];
                _context.VehicleTypes.Add(vehicleTypeResult);

                var userResult = new Users();
                userResult.IdentityNumber = Request.Form["spnTckn"];
                userResult.FullName = Request.Form["spnName"];
                userResult.PhoneNumber = Request.Form["spnGsm"];
                _context.Users.Add(userResult);

                var appointmentResult = new AppointmentReport();
                appointmentResult.TransactionDate = Convert.ToDateTime(Request.Form["spnDate2"]);
                _context.AppointmentReports.Add(appointmentResult);

                var stationResult = new Station();
                stationResult.Name = Request.Form["rdwstation"];
                _context.Stations.Add(stationResult);
                _context.SaveChanges();
                return View("odemeal");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        public IActionResult randevusorgulama()
        {
            return View();
        }

        [HttpPost]
        public IActionResult randevusorgulama(AppointmentReportDto appointmentReportDto)
        {
            return RedirectToAction("Index");
        }
        public IActionResult odemeal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult odemeal(PaymentInfo payment)
        {
            return View("Index");
        }
    }
}
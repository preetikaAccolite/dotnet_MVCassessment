using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVC_assessment.Data;
using MVC_assessment.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace MVC_assessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        


        public HomeController(ILogger<HomeController> logger,ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
            
        {
            Employeelogin emp=new Employeelogin();
            return View(emp);
        }
        [HttpPost]
        public IActionResult Index(Employeelogin emp)

        {
           var status=_db.Employee.Where(m=>m.Name==emp.Name && m.password==emp.password).FirstOrDefault();
            Console.WriteLine(status);
            if(status==null) {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                Response.Cookies.Append("UserId",status.Id.ToString());
                Response.Cookies.Append("UserName", status.Name);
                Response.Cookies.Append("UserGender", status.Gender);
                Response.Cookies.Append("UserEmil", status.Email);
                Response.Cookies.Append("UserPhone", status.Phone);
                return RedirectToAction("success", "Home");
            }
            return View(emp);
        }
        public async Task<IActionResult> logout()
        {
         
            return RedirectToAction("Index", "Home");
        }
        public IActionResult success()
        {
            string userId = Request.Cookies["UserId"];
            string userName = Request.Cookies["UserName"];
            string userEmail = Request.Cookies["UserEmail"];
            string userPhone = Request.Cookies["UserPhone"];
            string userGender = Request.Cookies["UserGender"];
            ViewData["UserId"] = userId;
            ViewData["UserName"] = userName;
            ViewData["UserEmail"] = userEmail;
            ViewData["UserPhone"] = userPhone;
            ViewData["UserGender"]= userGender;
            List<ContactUrl> c = _db.ContactUrl.ToList();
            return View(c);
        }
        [HttpGet]
        public IActionResult EditProfile()
        {
            string userId = Request.Cookies["UserId"];
            var user = _db.Employee.FirstOrDefault(m => m.Id.ToString() == userId);

            if (user == null)
            {
                return NotFound(); 
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(Category updatedProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedProfile); 
            }

            _db.Employee.Update(updatedProfile);
            _db.SaveChanges();

           
            Response.Cookies.Delete("UserName");
            Response.Cookies.Append("UserName", updatedProfile.Name);

            return RedirectToAction("Success");
        }
        public IActionResult Privacy()
        {
            return View();
        }
  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

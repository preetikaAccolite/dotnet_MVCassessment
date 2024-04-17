using Microsoft.AspNetCore.Mvc;
using MVC_assessment.Data;
using MVC_assessment.Models;

namespace MVC_assessment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public IActionResult Index()
        {   List<Category> categories = _db.Employee.ToList();
            return View(categories);
           
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
            
        {
       
            
                _db.Employee.Add(obj);
                _db.SaveChanges();
            
            return View();
        }
    }
}

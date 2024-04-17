using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_assessment.Data;
using MVC_assessment.Models;

namespace MVC_assessment.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Add(ContactUrl obj)
        {
            if (ModelState.IsValid)
            {
                _db.ContactUrl.Add(obj);
                _db.SaveChanges();

                return RedirectToAction("success", "Home");
            }
            return View(obj);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await _db.ContactUrl.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }
        [HttpPost]
      
        public async Task<IActionResult> Edit(int id, ContactUrl obj)
        {
            if (id != obj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Entry(obj).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                _db.SaveChanges();
                return RedirectToAction("success", "Home");
            }
            return View(obj);
        }
        public IActionResult Delete(int id,ContactUrl obj)
        {
            var staff = _db.ContactUrl.FirstOrDefault(e => e.Id == obj.Id);
            _db.ContactUrl.Remove(staff);
            _db.SaveChanges();
            return RedirectToAction("success","Home");
        }

    }
}
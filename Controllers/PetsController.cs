using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_Care_Centre_MVC.Models;

namespace Pet_Care_Centre_MVC.Controllers
{
    //Pets controller 
    [Authorize]
    public class PetsController : Controller
    {
        private readonly Pet_Care_Centre_MVCDataContext _context;

        public PetsController(Pet_Care_Centre_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Pets
        //Uses a linq query to get all the Pets
        public IActionResult Index()
        {
            return View((from pets in _context.Pet select pets).ToList());
        }

        // GET: Pets/Details/5
        //Gets the details using a lamda query
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = _context.Pet
                .FirstOrDefault(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        //Gets the Creates form 
        public IActionResult Create()
        {
            ViewData["petType"] = new SelectList(Enum.GetValues(typeof(PetType)));
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the pet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,PetType")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pet);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Edit/5
        //Gets the form for edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = _context.Pet.Find(id);
            ViewData["petType"] = new SelectList(Enum.GetValues(typeof(PetType)), pet.PetType);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the pet
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,PetType")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pet);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        //Gets the pet for delete using  a lamda
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet =  _context.Pet
                .FirstOrDefault(m => m.Id == id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        //Deletes the pet
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pet =  _context.Pet.Find(id);
            _context.Pet.Remove(pet);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Check the pet exists using a lamda query
        private bool PetExists(int id)
        {
            return _context.Pet.Any(e => e.Id == id);
        }
    }
}

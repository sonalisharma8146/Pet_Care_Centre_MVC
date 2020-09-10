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
    //Pets session controller.
    [Authorize]
    public class PetCareSessionsController : Controller
    {
        private readonly Pet_Care_Centre_MVCDataContext _context;

        public PetCareSessionsController(Pet_Care_Centre_MVCDataContext context)
        {
            _context = context;
        }

        // GET: PetCareSessions
        //Gets all the pet sessions using  a lamda query
        public IActionResult Index()
        {
            var pet_Care_Centre_MVCDataContext = _context.PetCareSession.Include(p => p.CareTaker).Include(p => p.Pet);
            return View( pet_Care_Centre_MVCDataContext.ToList());
        }

        // GET: PetCareSessions/Details/5
        //Gets the details of the pet session 
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petCareSession =_context.PetCareSession
                .Include(p => p.CareTaker)
                .Include(p => p.Pet)
                .FirstOrDefault(m => m.Id == id);
            if (petCareSession == null)
            {
                return NotFound();
            }

            return View(petCareSession);
        }

        // GET: PetCareSessions/Create
        //Gets the Create form for pet session
        public IActionResult Create()
        {
            ViewData["CareTakerId"] = new SelectList(_context.CareTaker, "Id", "Name");
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Name");
            return View();
        }

        // POST: PetCareSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the pet 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CareTakerId,PetId,Start,End")] PetCareSession petCareSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petCareSession);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CareTakerId"] = new SelectList(_context.CareTaker, "Id", "Id", petCareSession.CareTakerId);
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", petCareSession.PetId);
            return View(petCareSession);
        }

        // GET: PetCareSessions/Edit/5
        //Gets the Pet sessions for edit.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petCareSession = _context.PetCareSession.Find(id);
            if (petCareSession == null)
            {
                return NotFound();
            }
            ViewData["CareTakerId"] = new SelectList(_context.CareTaker, "Id", "Name", petCareSession.CareTakerId);
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Name", petCareSession.PetId);
            return View(petCareSession);
        }

        // POST: PetCareSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the Pet care session 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CareTakerId,PetId,Start,End")] PetCareSession petCareSession)
        {
            if (id != petCareSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petCareSession);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetCareSessionExists(petCareSession.Id))
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
            ViewData["CareTakerId"] = new SelectList(_context.CareTaker, "Id", "Id", petCareSession.CareTakerId);
            ViewData["PetId"] = new SelectList(_context.Pet, "Id", "Id", petCareSession.PetId);
            return View(petCareSession);
        }

        // GET: PetCareSessions/Delete/5
        //Gets the pet session for delete.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var petCareSession = _context.PetCareSession
                .Include(p => p.CareTaker)
                .Include(p => p.Pet)
                .FirstOrDefault(m => m.Id == id);
            if (petCareSession == null)
            {
                return NotFound();
            }

            return View(petCareSession);
        }

        // POST: PetCareSessions/Delete/5
        //Delete the pet care session.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var petCareSession = _context.PetCareSession.Find(id);
            _context.PetCareSession.Remove(petCareSession);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Pet care session existance check using lamda 
        private bool PetCareSessionExists(int id)
        {
            return _context.PetCareSession.Any(e => e.Id == id);
        }
    }
}

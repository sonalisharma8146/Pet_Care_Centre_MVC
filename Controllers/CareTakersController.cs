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
    //Cate taker controller
    [Authorize]
    public class CareTakersController : Controller
    {
        private readonly Pet_Care_Centre_MVCDataContext _context;

        public CareTakersController(Pet_Care_Centre_MVCDataContext context)
        {
            _context = context;
        }

        // GET: CareTakers
        //Gets all the care takers 
        public IActionResult Index()
        {
            return View((from careTaker in _context.CareTaker select careTaker).ToList());
        }

        // GET: CareTakers/Details/5
        //Gets the details of the Care taker using a lamda 
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careTaker =  _context.CareTaker
                .FirstOrDefault(m => m.Id == id);
            if (careTaker == null)
            {
                return NotFound();
            }

            return View(careTaker);
        }

        // GET: CareTakers/Create
        //Returns the Care taker form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: CareTakers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the care taker 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,PhoneNumber")] CareTaker careTaker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(careTaker);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(careTaker);
        }

        // GET: CareTakers/Edit/5
        //Gets the Care taker for edit.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careTaker =  _context.CareTaker.Find(id);
            if (careTaker == null)
            {
                return NotFound();
            }
            return View(careTaker);
        }

        // POST: CareTakers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the care taker.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,PhoneNumber")] CareTaker careTaker)
        {
            if (id != careTaker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(careTaker);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CareTakerExists(careTaker.Id))
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
            return View(careTaker);
        }

        // GET: CareTakers/Delete/5
        //Gets the care taker for delete using a lamda query
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var careTaker = _context.CareTaker
                .FirstOrDefault(m => m.Id == id);
            if (careTaker == null)
            {
                return NotFound();
            }

            return View(careTaker);
        }

        // POST: CareTakers/Delete/5
        //Delete the care taker 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var careTaker =  _context.CareTaker.Find(id);
            _context.CareTaker.Remove(careTaker);
           _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the care taker exists using a lamda 
        private bool CareTakerExists(int id)
        {
            return _context.CareTaker.Any(e => e.Id == id);
        }
    }
}

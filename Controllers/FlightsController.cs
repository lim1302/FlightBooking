using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UkraineAirline.Data;
using UkraineAirline.Models;

namespace UkraineAirline.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flight.ToListAsync());
        }

        // GET: Flights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlightID,FlightNo,Origin,Destination,Departure,Arrival")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flight);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight.SingleOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightID,FlightNo,Origin,Destination,Departure,Arrival")] Flight flight)
        {
            if (id != flight.FlightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.FlightID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _context.Flight
                .SingleOrDefaultAsync(m => m.FlightID == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flight = await _context.Flight.SingleOrDefaultAsync(m => m.FlightID == id);
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FlightExists(int id)
        {
            return _context.Flight.Any(e => e.FlightID == id);
        }

        // GET: Flights/Search
        public async Task<IActionResult> Search(String origin, String destination, String date)
        {
            ViewData["origin"] = origin;
            ViewData["destination"] = destination;
            ViewData["date"] = date;

            if (!String.IsNullOrEmpty(origin) && !String.IsNullOrEmpty(destination) && !String.IsNullOrEmpty(date))
            {
                DateTime depart = DateTime.Parse(date);
                var flights = from f in _context.Flight select f;
                flights = flights.Where(f => f.Origin.Contains(origin)
                               && f.Destination.Contains(destination)
                               && f.Departure.Date.Equals(depart.Date));
                return View(await flights.AsNoTracking().ToListAsync());
            }
            else
            {
                return View(await _context.Flight.ToListAsync());
            }
        }
    }
}

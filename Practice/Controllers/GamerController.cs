using Microsoft.AspNetCore.Mvc;
using Practice.DOA;
using System;
using System.Collections.Generic;
using System.Linq;
using Practice.Models;

namespace Practice.Controllers
{
    public class Gamer : Controller
    {
        // ref to db context
        private readonly GamerDbContext _context;
        public Gamer(GamerDbContext context)
        {
            _context = context;
        }
        // sanity landing page
        public IActionResult Index()
        {
            return Content("Gamer Controller");
        }
        // get method to view all items in db
        public IActionResult ViewAll()
        {
            return View(_context);
        }
        // post method to create new db item
        [HttpPost]
        public IActionResult AddGamer(string name, int age, int hoursPlayed)
        {
            GamerModel newGamer = new GamerModel(){name = name, age = age, hoursPlayed = hoursPlayed};
            _context.Add(newGamer);
            _context.SaveChanges();
            return View("ViewAll", _context);
        }
        // put method to update value of exiting db item
        [HttpPut]
        public IActionResult UpdateHoursPlayed(int id, int hoursPlayed)
        {
            GamerModel matchingGamer = _context.gamers.FirstOrDefault(gamer => gamer.id == id);
            if(matchingGamer != null)
            {
                matchingGamer.hoursPlayed = hoursPlayed;
                _context.SaveChanges();
                return View("ViewAll", _context);
            } else {
                ViewData["gamerID"] = id;
                return View("NotFound");
            }
        }
        // delete method to delete db item
        [HttpDelete]
        public IActionResult DeleteGamer(int id, int hoursPlayed)
        {
            GamerModel matchingGamer = _context.gamers.FirstOrDefault(gamer => gamer.id == id);
            if(matchingGamer != null)
            {
                _context.Remove(matchingGamer);
                _context.SaveChanges();
                return View("ViewAll", _context);
            } else {
                ViewData["gamerID"] = id;
                return View("NotFound");
            }
        }
    }
}
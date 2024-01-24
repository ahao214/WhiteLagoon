﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VillaNumberController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var villaNumbers = _db.VillaNumbers.ToList();
            return View(villaNumbers);
        }


        public IActionResult Create()
        {
            IEnumerable<SelectListItem> list = _db.Villas.ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            //ViewData["villaList"] = list;    
            ViewBag.VillaList = list;
            return View();
        }

        [HttpPost]
        public IActionResult Create(VillaNumber obj)
        {

            if (ModelState.IsValid)
            {
                _db.VillaNumbers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The villa Number has been created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public IActionResult Update(int villaId)
        {
            VillaNumber? obj = _db.VillaNumbers.FirstOrDefault(u => u.VillaNo == villaId);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Update(VillaNumber obj)
        {

            if (ModelState.IsValid && obj.VillaId > 0)
            {
                _db.VillaNumbers.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The villa has been updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int villaId)
        {
            VillaNumber? obj = _db.VillaNumbers.FirstOrDefault(u => u.VillaNo == villaId);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(VillaNumber obj)
        {
            VillaNumber? objFromDb = _db.VillaNumbers.FirstOrDefault(u => u.VillaNo == obj.VillaId);
            if (objFromDb is not null)
            {
                _db.VillaNumbers.Remove(objFromDb);
                _db.SaveChanges();
                TempData["success"] = "The villa has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The villa could not be deleted";
            return View();
        }

    }
}
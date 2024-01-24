using Microsoft.AspNetCore.Mvc;
using WhiteLagoon.Application.Common.Interface;
using WhiteLagoon.Domain.Entities;
using WhiteLagoon.Infrastructure.Data;

namespace WhiteLagoon.Web.Controllers
{
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AmenityController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var villas = _unitOfWork.Amenity.GetAll();
            return View(villas);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Amenity obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The description cannot exactly match the Name");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "The Amenity has been created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public IActionResult Update(int Id)
        {
            Amenity? obj = _unitOfWork.Amenity.Get(u => u.Id == Id);
            if (obj == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Update(Amenity obj)
        {
            if (ModelState.IsValid && obj.Id > 0)
            {
                _unitOfWork.Amenity.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "The Amenity has been updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int Id)
        {
            Amenity? obj = _unitOfWork.Amenity.Get(u => u.Id == Id);
            if (obj is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(Amenity obj)
        {
            Amenity? objFromDb = _unitOfWork.Amenity.Get(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                _unitOfWork.Amenity.Remove(objFromDb);
                _unitOfWork.Save();
                TempData["success"] = "The Amenity has been deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = "The Amenity could not be deleted";
            return View();
        }

    }
}
